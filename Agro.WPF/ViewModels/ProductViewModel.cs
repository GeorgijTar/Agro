
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;

namespace Agro.WPF.ViewModels;

public class ProductViewModel : ViewModel
{
    private readonly IBaseRepository<Product> _productRepository;
    private readonly IBaseRepository<GroupDoc> _groupRepository;
    private readonly IBaseRepository<TypeDoc> _typeRepository;
    private readonly IBaseRepository<UnitOkei> _unitRepository;
    private readonly IBaseRepository<Nds> _ndsRepository;
    private readonly IBaseRepository<Status> _statusRepository;

    private Visibility _visibilityNds = Visibility.Hidden;
    public Visibility VisibilityNds { get => _visibilityNds; set => Set(ref _visibilityNds, value); }


    private string _title = "Добавление новой номенклатуры";
    public string Title { get => _title; set => Set(ref _title, value); }


    private Product _product = new();
    public Product Product { get => _product; set => Set(ref _product, value); }


    private IEnumerable<GroupDoc>? _groups = new List<GroupDoc>();
    public IEnumerable<GroupDoc>? Groups { get => _groups; set => Set(ref _groups, value); }


    private IEnumerable<TypeDoc>? _types = new List<TypeDoc>();
    public IEnumerable<TypeDoc>? Types { get => _types; set => Set(ref _types, value); }


    private IEnumerable<Nds>? _nds= new List<Nds>();
    public IEnumerable<Nds>? NdsCollection { get => _nds; set => Set(ref _nds, value); }


    private IEnumerable<UnitOkei>? _units=new List<UnitOkei>();
    public IEnumerable<UnitOkei>? UnitsCollection { get => _units; set => Set(ref _units, value); }

    private ProductsViewModel? _senderModel;
    public ProductsViewModel? SenderModel { get => _senderModel; set=> Set(ref _senderModel, value); }

    public ProductViewModel(
        IBaseRepository<Product> productRepository,
        IBaseRepository<GroupDoc> groupRepository,
        IBaseRepository<TypeDoc> typeRepository,
        IBaseRepository<UnitOkei> unitRepository,
        IBaseRepository<Nds> ndsRepository,
        IBaseRepository<Status> statusRepository)
    {
        _productRepository = productRepository;
        _groupRepository = groupRepository;
        _typeRepository = typeRepository;
        _unitRepository = unitRepository;
        _ndsRepository = ndsRepository;
        _statusRepository = statusRepository;
        LoadData();
        Product.PropertyChanged += LoadGroup;
    }

  

    private async void LoadGroup(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Type")
        {
            var groups = await _groupRepository.GetAllAsync();
            Groups = groups!.Where(x => x.TypeApplication == Product.Type.Name);
            if (Product.Type.Id == 8)
            {
                VisibilityNds = Visibility.Visible;
            }
            else
            {
                VisibilityNds=Visibility.Hidden;
            }
        }
    }

    private async void LoadData()
    {
        UnitsCollection = await _unitRepository.GetAllAsync();

        var type = await _typeRepository.GetAllAsync();
        Types=type!.Where(x => x.TypeApplication == "Товары");
        NdsCollection = await _ndsRepository.GetAllAsync();
    }
    
    #region Command

    private ICommand? _saveProductCommand;

    public ICommand SaveProductCommand => _saveProductCommand
        ??= new RelayCommand(OnSaveProductExecuted, SaveProductCan);

    private async void OnSaveProductExecuted(object p)
    {
            Product.Status = await _statusRepository.GetByIdAsync(5);
            if (VisibilityNds == Visibility.Hidden) Product.Nds = null!;
            Product = await _productRepository.SaveAsync(Product);
            
            var prod = SenderModel!.ProductsCollection!.FirstOrDefault(x => x.Id == Product.Id);
            if (prod != null!)
            {
                prod = Product;
            }
            else
            {
                SenderModel!.ProductsCollection!.Add(Product);
            }
            
            var window = p as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
    }

    private bool SaveProductCan(object arg)
    {
        if (VisibilityNds == Visibility.Visible)
        {
            return Product.Name != null! && Product.NameMini != null! && Product.Type != null! &&
                   Product.Group != null! && Product.Unit.Name != null! && Product.Nds!.Name != null!;
        }
        else
        {
            return Product.Name != null! && Product.NameMini != null! && Product.Type != null! &&
                   Product.Group != null! && Product.Unit.Name != null!;
        }
      
    }

    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }



    private ICommand? _showProductCommand;

    public ICommand ShowProductCommand => _showProductCommand
        ??= new RelayCommand(OnShowProductExecuted);

    private void OnShowProductExecuted(object obj)
    {
        ProductsView view = new ProductsView();
        var model = view.DataContext as ProductsViewModel;
        model!.SenderModel = this;
        view.DataContext = model;
        view.ShowDialog();
    }

    #endregion

}
