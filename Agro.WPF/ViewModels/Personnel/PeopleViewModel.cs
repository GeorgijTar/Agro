
using System.Linq;
using Agro.DAL.Entities;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Personnel;
using System.Windows.Input;
using Agro.Interfaces.Base.Repositories.Base;
using System.Windows;
using System;
using Agro.DAL.Entities.Personnel;

namespace Agro.WPF.ViewModels.Personnel;
public class PeopleViewModel : ViewModel
{
    private readonly IBaseRepository<People> _peopleRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private People _people = new();
    public People People { get => _people; set => Set(ref _people, value); }

    private IdentityDocument? _document;
    public IdentityDocument? Document { get => _document; set => Set(ref _document, value); }

    public object SenderModel { get; set; }= null!;

    public PeopleViewModel(IBaseRepository<People> peopleRepository, IBaseRepository<Status> statusRepository)
    {
        _peopleRepository = peopleRepository;
        _statusRepository = statusRepository;
    }
    

    #region Commands
    private ICommand? _savePeople;

    public ICommand SaveCommand => _savePeople
        ??= new RelayCommand(OnSavePeoplesExecuted, CanSavePeoplesExecuted);

    private bool CanSavePeoplesExecuted(object arg)
    {
        return People.Surname!=null! && People.Surname.Trim().Length>2 && People.Name!=null! && People.Name.Trim().Length>2 
               && People.Patronymic!=null! && People.Patronymic.Trim().Length>3;
    }

    private async void OnSavePeoplesExecuted(object obj)
    {
        People.Status = await _statusRepository.GetByIdAsync(5);
        var pl = await _peopleRepository.SaveAsync(People);
        if (SenderModel is PeoplsViewModel paplsViewModel)
        {
            var pld = paplsViewModel.Peoples.FirstOrDefault(x => x.Id == pl.Id);
            if (pld! == null!)
            {
                paplsViewModel.Peoples.Add(pl);
            }
        }
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
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

    private ICommand? _addDocCommand;

    public ICommand AddDocCommand => _addDocCommand
        ??= new RelayCommand(OnAddDocExecuted);

    private void OnAddDocExecuted(object obj)
    {
        var view = new DocumentView();
        var mod = view.DataContext as DocumentViewModel;
        mod!.Title = "Добавление нового документа";
        mod.Document = new();
        mod.SenderModel = this;
        mod.Document.PropertyChanged += mod.DocChahg;
        view.DataContext = mod;
        view.ShowDialog();

    }


    private ICommand? _editDocCommand;

    public ICommand EditDocCommand => _editDocCommand
        ??= new RelayCommand(OnEditDocExecuted, CanEditDocExecuted);

    private bool CanEditDocExecuted(object arg)
    {
        return Document != null!;
    }

    private void OnEditDocExecuted(object obj)
    {
        var view = new DocumentView();
        var mod = view.DataContext as DocumentViewModel;
        mod!.Title = "Добавление нового документа";
        mod.Document = Document!;
        mod.SenderModel = this;
        mod.Document.PropertyChanged += mod.DocChahg;
        view.DataContext = mod;
        view.ShowDialog();

    }

    

    private ICommand? _deleteDocCommand;

    public ICommand DeleteDocCommand => _deleteDocCommand
        ??= new RelayCommand(OnDeleteDocExecuted, CanEditDocExecuted);

    private void OnDeleteDocExecuted(object obj)
    {
        var result = MessageBox.Show("Вы деййствительно хотите удалить выбранный документ", "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            People.Documents!.Remove(Document!);
        }
    }
    #endregion

}
