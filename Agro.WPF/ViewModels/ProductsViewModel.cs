
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Agronomy;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;

namespace Agro.WPF.ViewModels;

public class ProductsViewModel : ViewModel
{
    private readonly IBaseRepository<Product> _repository;
    private readonly IBaseRepository<GroupDoc> _groupRepository;
    private readonly IBaseRepository<TypeDoc> _typeRepository;

    public ProductsViewModel(
        IBaseRepository<Product> repository,
        IBaseRepository<GroupDoc> groupRepository,
        IBaseRepository<TypeDoc> typeRepository)
    {
        _repository = repository;
        _groupRepository = groupRepository;
        _typeRepository = typeRepository;
        ProductsCollection = new ObservableCollection<Product>();
        LoadData();
    }

    #region Property

    public object SenderModel = null!;

    private string _title = "Номенклатура";
    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<Product>? _products;
    public ObservableCollection<Product>? ProductsCollection { get => _products; set => Set(ref _products, value); }

    private Product? _product;
    public Product? Product { get => _product; set => Set(ref _product, value); }

    private ObservableCollection<GroupDoc>? _groups;
    public ObservableCollection<GroupDoc>? GroupFilter { get => _groups; set => Set(ref _groups, value); }

    private GroupDoc _group = new ();

    public GroupDoc SelectedGroup
    {
        get => _group;
        set
        {
            Set(ref _group, value);
            CollectionView!.Filter = FilterByGroup;
            CollectionView.GroupDescriptions.Add(new PropertyGroupDescription("Type"));
        }
    }

    private ObservableCollection<TypeDoc>? _type;

    public ObservableCollection<TypeDoc>? TypeFilter { get => _type; set => Set(ref _type, value); }

    private TypeDoc _selecteType=null!;

    public TypeDoc SelectedType
    {
        get => _selecteType;
        set
        {
            Set(ref _selecteType, value);
            CollectionView!.Filter = FilterByType;
        }
    }

    private string _nameFilter=null!;

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

    private async void LoadData()
    {
        await LoadDataProdukt();
        await LoadFilterData();
    }
    private async Task LoadDataProdukt()
    {
        if (ProductsCollection != null)
        {
            ProductsCollection.Clear();
            var products = await _repository.GetAllAsync();
            products = products!.Where(x => x.Status.Id == 5); 
            foreach (var product in products)
            {
                ProductsCollection.Add(product);
            }
            CollectionView = CollectionViewSource.GetDefaultView(ProductsCollection);
        }
    }

    private async Task LoadFilterData()
    {
        GroupFilter = new ObservableCollection<GroupDoc>();
        SelectedGroup = new GroupDoc() { Id = 0, Name = "Все" };
        GroupFilter.Add(SelectedGroup);
        var groups = await _groupRepository.GetAllAsync();
        groups=groups!.Where(group => group.TypeApplication == "Товары");
        foreach (var group in groups)
        {
            GroupFilter.Add(group);
        }

        TypeFilter = new ObservableCollection<TypeDoc>();
        SelectedType = new TypeDoc() { Id = 0, Name = "Все" };
        TypeFilter.Add(SelectedType);
        var types = await _typeRepository.GetAllAsync();
        types = types!.Where(type => type.TypeApplication == "Товары");
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
            Product? dto = obj as Product;
            return dto!.Name.Contains(NameFilter);
        }
        return true;
    }

    private bool FilterByType(object obj)
    {
        string qer;
        if (SelectedType == null! || SelectedType.Id == 0)
        {
            qer = string.Empty;
        }
        else { qer = SelectedType.Name; }
            
       

        if (!string.IsNullOrEmpty(qer))
        {    
            Product? dto = obj as Product;
            return dto!.Type.Name.Contains(qer);
        }
        return true;
    }

    private bool FilterByGroup(object obj)
    {
        string qer;
        if (SelectedGroup == null! || SelectedGroup.Id == 0)
        {
            qer = string.Empty;
        }
        else { qer = SelectedGroup.Name; }

        if (!string.IsNullOrEmpty(qer))
        {
            Product? dto = obj as Product;
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
        viewModel!.SenderModel = this;
        product.Show();
    }

    
    private ICommand? _edeteProductCommand;

    public ICommand EdeteProductCommand => _edeteProductCommand
        ??= new RelayCommand(OnEdeteProductExecuted, EdeteProductCan);

    private bool EdeteProductCan(object arg)
    {
        if (Product != null!) return true;
        return false;
    }

    private void OnEdeteProductExecuted(object obj)
    {
        ProductView product = new ProductView();
        var viewModel = product.DataContext as ProductViewModel;
        viewModel!.Product = Product!;
        viewModel.SenderModel = this;
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

   
   private ICommand? _selectRowCommand;

   public ICommand SelectRowCommand => _selectRowCommand
       ??= new RelayCommand(OnSelectRowExecuted, SelectRowCan);

   private bool SelectRowCan(object arg)
   {
       return Product != null!;
   }

   private void OnSelectRowExecuted(object obj)
   {
       if (SenderModel != null!)
       {
           if (SenderModel is ProductInvoiceViewModel productInvoiceViewModel)
           {
               productInvoiceViewModel.ProductInvoice.Product = Product!;
           }

           if (SenderModel is CultureViewModel cultureViewModel)
           {
               cultureViewModel.Culture.Product= Product!;
           }

           var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
           if (window != null!)
               window.Close();
        }
   }

   #endregion
}



