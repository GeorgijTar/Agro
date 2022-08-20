using Agro.DAL.Entities.Agronomy;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Agronomy;
using System.Windows;
using System;
using System.Linq;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.WPF.Views.Windows;

namespace Agro.WPF.ViewModels.Agronomy;
public class CultureViewModel : ViewModel
{
    private readonly IBaseRepository<Culture> _cultureRepository;
    private readonly IBaseRepository<Status> _statusRepository;

    public CultureViewModel(IBaseRepository<Culture> cultureRepository, IBaseRepository<Status> statusRepository)
    {
        _cultureRepository = cultureRepository;
        _statusRepository = statusRepository;
    }
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    private Culture _culture = new();
    public Culture Culture { get => _culture; set => Set(ref _culture, value); }

    private object _senderModel = null!;

    public object SenderModel { get => _senderModel; set => Set(ref _senderModel, value); }


    #region Command

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return Culture.Name!=null! && Culture.Product!=null! && Culture.YearHarvest!=null!;
    }

    private async void OnSaveExecuted(object obj)
    { 
        Culture.Status = await _statusRepository.GetByIdAsync(5);
      var cult =  await _cultureRepository.SaveAsync(Culture);
      if (SenderModel is CulturesViewModel culturesViewModel)
      {
          var cl = culturesViewModel.Cultures.FirstOrDefault(x => x.Id == cult.Id);
          if (cl != null!)
          {
              cl = cult;
          }
          else
          {
              culturesViewModel.Cultures.Add(cult);
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



    private ICommand? _showProductCommand;

    public ICommand ShowProductCommand => _showProductCommand
        ??= new RelayCommand(OnShowProductExecuted);

    private void OnShowProductExecuted(object obj)
    {
        ProductsView view = new ProductsView();
        var model = view.DataContext as ProductsViewModel;
        model!.SenderModel= this;
        view.DataContext= model;
        view.ShowDialog();
    }
    #endregion
}
