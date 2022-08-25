using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities.Agronomy;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Weight;
using Agro.WPF.Views.Windows.Agronomy;

namespace Agro.WPF.ViewModels.Agronomy;

public class CulturesViewModel : ViewModel
{
    private readonly IBaseRepository<Culture> _cultureRepository;

    public object SenderModel { get; set; } = null!;
    public CulturesViewModel(IBaseRepository<Culture> cultureRepository)
    {
        Title = "Выращиваемые культуры";
        _cultureRepository = cultureRepository;
        LoadCulture();
    }

    private async void LoadCulture()
    {
        Cultures.Clear();
        var cultures = await _cultureRepository.GetAllAsync();
        cultures = cultures!.Where(c => c.Status!.Id != 6).ToArray();
        foreach (var culture in cultures)
        {
            Cultures.Add(culture);
        }
    }

    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<Culture> _cultures = new();
    public ObservableCollection<Culture> Cultures { get => _cultures; set => Set(ref _cultures, value); }


    private Culture _culture = null!;
    public Culture Culture { get => _culture; set => Set(ref _culture, value); }



    #region Command

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        CultureView view = new();
        var model = view.DataContext as CultureViewModel;
        model!.SenderModel = this;
        model.Title = "Добавление новой выращиваемой культуры";
        view.DataContext = model;
        view.ShowDialog();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, CanEditExecuted);

    private bool CanEditExecuted(object arg)
    {
        return Culture != null!;
    }

    private void OnEditExecuted(object obj)
    {
        CultureView view = new();
        var model = view.DataContext as CultureViewModel;
        model!.SenderModel = this;
        model.Culture = Culture;
        model.Title = "Редактирование выращиваемой культуры";
        view.DataContext = model;
        view.ShowDialog();
    }


    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, CanDeleteExecuted);

    private bool CanDeleteExecuted(object arg)
    {
        return Culture != null!;
    }

    private async void OnDeleteExecuted(object obj)
    {
        var rezalt = MessageBox.Show($"Вы действительно хотите удалить: {Culture.Name}",
            "Редактор", MessageBoxButton.YesNo);
        if (rezalt == MessageBoxResult.Yes)
        {
            await _cultureRepository.DeleteAsync(Culture);
        }
    }


    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshExecuted);

    private void OnRefreshExecuted(object obj)
    {
        LoadCulture();
    }



    private ICommand? _doubleClickCommand;

    public ICommand DoubleClickCommand => _doubleClickCommand
        ??= new RelayCommand(OnDoubleClickExecuted);

    private void OnDoubleClickExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is ComingFieldViewModel comingFieldViewModel)
            {
                comingFieldViewModel.ComingField.Culture = Culture;
            }
            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
    }



    #endregion
}