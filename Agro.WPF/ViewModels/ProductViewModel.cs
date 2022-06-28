
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Agro.Domain.Base;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;

namespace Agro.WPF.ViewModels;

public class ProductViewModel : ViewModel
{
    private readonly IProductRepository<ProductDto> _productRepository;
    private readonly IGroupRepository<GroupDto> _groupRepository;
    private readonly ITypeRepository<TypeDocDto> _typeRepository;
    private readonly IUnitRepository<UnitOkeiDto> _unitRepository;
    private readonly INdsRepository<NdsDto> _ndsRepository;

    public ProductViewModel(
        IProductRepository<ProductDto> productRepository,
        IGroupRepository<GroupDto> groupRepository,
        ITypeRepository<TypeDocDto> typeRepository,
        IUnitRepository<UnitOkeiDto> unitRepository,
        INdsRepository<NdsDto> ndsRepository)
    {
        _productRepository = productRepository;
        _groupRepository = groupRepository;
        _typeRepository = typeRepository;
        _unitRepository = unitRepository;
        _ndsRepository = ndsRepository;
        Product = new ProductDto();
        LoadData();
    }

    private Visibility _visibilityNds = Visibility.Hidden;
    public Visibility VisibilityNds { get => _visibilityNds; set => Set(ref _visibilityNds, value); }

    private string _title = "Добавление новой номенклатуры";

    public string Title { get => _title; set => Set(ref _title, value); }

    private ProductDto _product = null!;
    public ProductDto Product
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

    private ObservableCollection<GroupDto> _groups;
    public ObservableCollection<GroupDto> Groups { get => _groups; set => Set(ref _groups, value); }

    private GroupDto _group;

    public GroupDto SelectGroup
    {
        get => _group;
        set
        {
            Set(ref _group, value);
            Product.Group = value;
        }
    }

    private UnitOkeiDto _unit;
    public UnitOkeiDto SelectUnit
    {
        get => _unit;
        set
        {
            Set(ref _unit, value); 
            Product.Unit = value;
        }
    }

    private NdsDto? _selectNds;

    public NdsDto? SelectNds
    {
        get => _selectNds;
        set
        {
            Set(ref _selectNds, value); 
            Product.Nds=value;
        }
    }


    private ObservableCollection<TypeDocDto> _types;

    public ObservableCollection<TypeDocDto> Types { get => _types; set => Set(ref _types, value); }



    private TypeDocDto _type;
    public TypeDocDto SelectType
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

    private ObservableCollection<NdsDto> _nds;

    public ObservableCollection<NdsDto> NdsCollection { get => _nds; set => Set(ref _nds, value); }

    private ObservableCollection<UnitOkeiDto> _units;

    public ObservableCollection<UnitOkeiDto> UnitsCollection { get => _units; set => Set(ref _units, value); }


    private void LoadGroups(string typeApplication)
    {
        Groups = new ObservableCollection<GroupDto>();
        var groups = _groupRepository.GetAllByTypeApplication(typeApplication);
        foreach (var group in groups)
        {
            Groups.Add(group);
        }
    }
    private void LoadData()
    {
        try
        {
            Types = new ObservableCollection<TypeDocDto>();

            var types = _typeRepository.GetAllByTypeApplication("Товары");
            foreach (var type in types)
            {
                Types.Add(type);
            }

            NdsCollection = new ObservableCollection<NdsDto>();
            var nds = _ndsRepository.GetAll();
            foreach (var nd in nds!)
            {
                NdsCollection.Add(nd);
            }

            UnitsCollection = new ObservableCollection<UnitOkeiDto>();
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
            ProductDto product;
            Product.Status = new StatusDto() { Id = 5, Name = "Актуально" };
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

    public delegate void ProductHandler(ProductDto product);
    public event ProductHandler ProductEvent;

    #endregion
}
