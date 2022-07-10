
using System;
using System.Collections.ObjectModel;
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

    public ProductViewModel(
        IBaseRepository<Product> productRepository,
        IBaseRepository<GroupDoc> groupRepository,
        IBaseRepository<TypeDoc> typeRepository,
        IBaseRepository<UnitOkei> unitRepository,
        IBaseRepository<Nds> ndsRepository)
    {
        _productRepository = productRepository;
        _groupRepository = groupRepository;
        _typeRepository = typeRepository;
        _unitRepository = unitRepository;
        _ndsRepository = ndsRepository;
        Product = new Product();
        LoadData();
    }

    private Visibility _visibilityNds = Visibility.Hidden;
    public Visibility VisibilityNds { get => _visibilityNds; set => Set(ref _visibilityNds, value); }

    private string _title = "Добавление новой номенклатуры";

    public string Title { get => _title; set => Set(ref _title, value); }

    private Product _product = null!;
    public Product Product
    {
        get => _product;
        set
        {
            Set(ref _product, value);
            SelectType = value.Type;
            SelectGroup = value.Group;
            SelectUnit = value.Unit;
            SelectNds = value.Nds;
        }
    }

    private ObservableCollection<GroupDoc> _groups;
    public ObservableCollection<GroupDoc> Groups { get => _groups; set => Set(ref _groups, value); }

    private GroupDoc _group;

    public GroupDoc SelectGroup
    {
        get => _group;
        set
        {
            Set(ref _group, value);
            Product.Group = value;
        }
    }

    private UnitOkei _unit;
    public UnitOkei SelectUnit
    {
        get => _unit;
        set
        {
            Set(ref _unit, value); 
            Product.Unit = value;
        }
    }

    private Nds? _selectNds;

    public Nds? SelectNds
    {
        get => _selectNds;
        set
        {
            Set(ref _selectNds, value); 
            Product.Nds=value;
        }
    }


    private ObservableCollection<TypeDoc> _types;

    public ObservableCollection<TypeDoc> Types { get => _types; set => Set(ref _types, value); }



    private TypeDoc _type;
    public TypeDoc SelectType
    {
        get => _type;
        set
        {
            Set(ref _type, value);
            if (value != null!)
            {
                VisibilityNds = value.Id == 8 ? Visibility.Visible : Visibility.Hidden;
                Product.Type = value;
                LoadGroups(value.Name);
            }
        }
    }

    private ObservableCollection<Nds> _nds;

    public ObservableCollection<Nds> NdsCollection { get => _nds; set => Set(ref _nds, value); }

    private ObservableCollection<UnitOkei> _units;

    public ObservableCollection<UnitOkei> UnitsCollection { get => _units; set => Set(ref _units, value); }


    private async void LoadGroups(string typeApplication)
    {
        Groups = new ObservableCollection<GroupDoc>();
        var groups = await _groupRepository.GetAllAsync();
        groups = groups.Where(x => x.TypeApplication == typeApplication);
        foreach (var group in groups)
        {
            Groups.Add(group);
        }
    }
    private async void LoadData()
    {
        try
        {
            Types = new ObservableCollection<TypeDoc>();

            var types = await _typeRepository.GetAllAsync();
            types = types.Where(x => x.TypeApplication == "Товары");
            foreach (var type in types)
            {
                Types.Add(type);
            }

            NdsCollection = new ObservableCollection<Nds>();
            var nds = _ndsRepository.GetAll();
            foreach (var nd in nds!)
            {
                NdsCollection.Add(nd);
            }

            UnitsCollection = new ObservableCollection<UnitOkei>();
            var units = _unitRepository.GetAll();
            foreach (var unit in units!)
            {
                UnitsCollection.Add(unit);
            }

            
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

    }




    #region Command

    private ICommand? _saveProductCommand;

    public ICommand SaveProductCommand => _saveProductCommand
        ??= new RelayCommand(OnSaveProductExecuted, SaveProductCan);

    private async void OnSaveProductExecuted(object p)
    {
        try
        {
            Product product;
            Product.Status = new Status() { Id = 5, Name = "Актуально" };
            if (Product.Id == 0)
            {
                product = await _productRepository.AddAsync(Product);
            }
            else
            {
                product = await _productRepository.UpdateAsync(Product);
               
            }

            ProductEvent(product);

            var window = p as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            throw;
        }
    }

    private bool SaveProductCan(object arg)
    {
        if (Product.Name == null! || Product.NameMini == null! || Product.Type == null! || Product.Group == null! ||
            Product.Unit == null!) return false;
        return true;
    }

    #endregion


    #region Event

    public delegate void ProductHandler(Product product);
    public event ProductHandler ProductEvent;

    #endregion
}
