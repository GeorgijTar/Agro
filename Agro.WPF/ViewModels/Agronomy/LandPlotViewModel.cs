using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Agronomy;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.DAL.Entities.Base;

namespace Agro.WPF.ViewModels.Agronomy;

public class LandPlotViewModel : ViewModel
{
    private readonly IBaseRepository<LandPlot> _landPlotRepository;
    private readonly IBaseRepository<TypeDoc> _typeRepository;
    private readonly IBaseRepository<Status> _statusRepository;

    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    private LandPlot _landPlot = new();
    public LandPlot LandPlot { get => _landPlot; set => Set(ref _landPlot, value); }


    private IEnumerable<TypeDoc>? _typeDocs;
    public IEnumerable<TypeDoc>? TypeDocs { get => _typeDocs; set => Set(ref _typeDocs, value); }


    private object _senderModel = null!;
    public object SenderModel { get => _senderModel; set => Set(ref _senderModel, value); } 


    
    public LandPlotViewModel(
        IBaseRepository<LandPlot> landPlotRepository, 
        IBaseRepository<TypeDoc> typeRepository, 
        IBaseRepository<Status> statusRepository)
    {
        _landPlotRepository = landPlotRepository;
        _typeRepository = typeRepository;
        _statusRepository = statusRepository;
        LoadTypes();
    }

    private async void LoadTypes()
    {
        var types = await _typeRepository.GetAllAsync();
        TypeDocs=types!.Where(t=>t.TypeApplication=="ЗУ").ToArray();
    }

    #region Command

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return LandPlot.Number != null! && LandPlot.Area != 0 && LandPlot.Cost != 0 && LandPlot.Type !=null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        LandPlot.Status = await _statusRepository.GetByIdAsync(5);
        var lp = await _landPlotRepository.SaveAsync(LandPlot);
        if (SenderModel is LandPlotsViewModel landPlotsViewModel)
        {
            var cl = landPlotsViewModel.LandPlots.FirstOrDefault(x => x.Id == lp.Id);
            if (cl != null!)
            {
                cl = lp;
            }
            else
            {
                landPlotsViewModel.LandPlots.Add(lp);
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

    #endregion
}