

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.Domain.Base;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;

namespace Agro.WPF.ViewModels;

public class ProductsViewModel : ViewModel
{
    private readonly IProductRepository<ProductDto> _repository;
    private readonly IGroupRepository<GroupDto> _groupRepository;
    private readonly ITypeRepository<TypeDocDto> _typeRepository;

    public ProductsViewModel(
        IProductRepository<ProductDto> repository,
        IGroupRepository<GroupDto> groupRepository,
        ITypeRepository<TypeDocDto> typeRepository)
    {
        _repository = repository;
        _groupRepository = groupRepository;
        _typeRepository = typeRepository;
        ProductsCollection = new ObservableCollection<ProductDto>();
        LoadData();
    }

    #region Property

    private string _title = "Номенклатура";
    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<ProductDto>? _products;
    public ObservableCollection<ProductDto>? ProductsCollection { get => _products; set => Set(ref _products, value); }

    private ProductDto? _product;
    public ProductDto? Product { get => _product; set => Set(ref _product, value); }

    private ObservableCollection<GroupDto>? _groups;
    public ObservableCollection<GroupDto> GroupFilter { get => _groups; set => Set(ref _groups, value); }

    private GroupDto _group;

    public GroupDto SelectedGroup
    {
        get => _group;
        set
        {
            Set(ref _group, value);
            CollectionView!.Filter = FilterByGroup;
            CollectionView.GroupDescriptions.Add(new PropertyGroupDescription("Type"));


        }
    }

    private ObservableCollection<TypeDocDto>? _type;

    public ObservableCollection<TypeDocDto> TypeFilter { get => _type; set => Set(ref _type, value); }

    private TypeDocDto _selecteType;

    public TypeDocDto SelectedType
    {
        get => _selecteType;
        set
        {
            Set(ref _selecteType, value);
            CollectionView!.Filter = FilterByType;
        }
    }

    private string _nameFilter;

    public string NameFilter
    {
        get => _nameFilter;
        set
        {
            Set(ref _nameFilter, value);
            CollectionView!.Filter = FilterByName;
        }
    }

    #endregion   

    #region Metodi

    private async Task LoadData()
    {
        await LoadDataProdukt();
        await LoadFilterData();
    }
    private async Task LoadDataProdukt()
    {
        if (ProductsCollection != null)
        {
            ProductsCollection.Clear();
            var products = await _repository.GetAllByStatusAsync(5);
            foreach (var product in products!)
            {
                ProductsCollection.Add(product);
            }
            CollectionView = CollectionViewSource.GetDefaultView(ProductsCollection);
        }
    }

    private async Task LoadFilterData()
    {
        GroupFilter = new ObservableCollection<GroupDto>();
        SelectedGroup = new GroupDto() { Id = 0, Name = "Все" };
        GroupFilter.Add(SelectedGroup);
        var groups = await _groupRepository.GetAllByTypeApplicationAsync("Товары");
        foreach (var group in groups)
        {
            GroupFilter.Add(group);
        }

        TypeFilter = new ObservableCollection<TypeDocDto>();
        SelectedType = new TypeDocDto() { Id = 0, Name = "Все" };
        TypeFilter.Add(SelectedType);
        var types = await _typeRepository.GetAllByTypeApplicationAsync("Товары");
        foreach (var type in types)
        {
            TypeFilter.Add(type);
        }
    }

    #endregion

    #region Filter

    private ICollectionView? _collectionView;
    public ICollectionView? CollectionView
    {
        get => _collectionView;
        set => Set(ref _collectionView, value);
    }

    private bool FilterByName(object obj)
    {
        if (!string.IsNullOrEmpty(NameFilter))
        {
            ProductDto? dto = obj as ProductDto;
            return dto!.Name.Contains(NameFilter);
        }
        return true;
    }

    private bool FilterByType(object obj)
    {
        string qer;
        if (SelectedType == null || SelectedType.Id == 0)
        {
            qer = string.Empty;
        }
        else { qer = SelectedType.Name; }
            
       

        if (!string.IsNullOrEmpty(qer))
        {    
            ProductDto? dto = obj as ProductDto;
            return dto!.Type.Name.Contains(qer);
        }
        return true;
    }

    private bool FilterByGroup(object obj)
    {
        string qer;
        if (SelectedGroup == null || SelectedGroup.Id == 0)
        {
            qer = string.Empty;
        }
        else { qer = SelectedGroup.Name; }

        if (!string.IsNullOrEmpty(qer))
        {
            ProductDto? dto = obj as ProductDto;
            return dto!.Group.Name.Contains(qer);
        }
        return true;
    }

    #endregion

    #region Commands

    private ICommand? _addProductCommand;

    public ICommand AddProductCommand => _addProductCommand
        ??= new RelayCommand(OnAddProductExecuted);

    private void OnAddProductExecuted(object obj)
    {
        ProductView product = new ProductView();
        var viewModel = product.DataContext as ProductViewModel;
        viewModel.ProductEvent += GridRefreh;
        product.Show();
    }

    private void GridRefreh(ProductDto product)
    {
        var productCol = ProductsCollection.FirstOrDefault(c => c.Id == product.Id);
        if (productCol is null)
        {
            ProductsCollection.Add(product);
        }
        else
        {
            productCol = product;
        }
    }

    private ICommand? _edeteProductCommand;

    public ICommand EdeteProductCommand => _edeteProductCommand
        ??= new RelayCommand(OnEdeteProductExecuted, EdeteProductCan);

    private bool EdeteProductCan(object arg)
    {
        if (Product != null) return true;
        return false;
    }

    private void OnEdeteProductExecuted(object obj)
    {
        ProductView product = new ProductView();
        var viewModel = product.DataContext as ProductViewModel;
        viewModel!.Product = Product!;
        viewModel.ProductEvent += GridRefreh;
        product.Show();
    }
    
    private ICommand? _deleteProductCommand;

    public ICommand DeleteProductCommand => _deleteProductCommand
        ??= new RelayCommand(OnDeleteProductExecuted, DeleteProductCan);

    private bool DeleteProductCan(object arg)
    {
        if (Product != null!) return true;
        return false;
    }

    private async void OnDeleteProductExecuted(object obj)
    {
        var resalt = MessageBox.Show("Вы действительно хотите удалить запись?", "", MessageBoxButton.YesNo);
        if (resalt == MessageBoxResult.Yes)
        {
            if (await _repository.DeleteAsync(Product!))
            {
                ProductsCollection!.Remove(Product!);
                
            }
        }
    }

    private ICommand? _refreshProductCommand;

    public ICommand RefreshProductCommand => _refreshProductCommand
        ??= new RelayCommand(OnRefreshProductExecuted);

   private async void OnRefreshProductExecuted(object obj)
   {
     await LoadDataProdukt();
   }

    #endregion
}



