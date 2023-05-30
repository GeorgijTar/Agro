
using System.Collections.ObjectModel;
using System.Windows.Input;
using Agro.DAL.Entities.Registers;
using Agro.DAL.Entities.Warehouse;
using Agro.Dto.Warehouse;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Microsoft.Win32;
using ReportExcelLib.Tmc;

namespace Agro.WPF.ViewModels.TMC;
public class MovementTmcViewModel : ViewModel
{
    private readonly ITmcSprRepository<Tmc> _tmcSprRepository;
    private TmcSprDto _tmcSprDto = null!;
    public TmcSprDto TmcSprDto
    {
        get => _tmcSprDto;
        set
        {
            Set(ref _tmcSprDto, value);
            LoadData(value.Id, value.IdStorageLocation);
        }
    }

    private ObservableCollection<TmcRegister> _tmcRegisters = null!;
    public ObservableCollection<TmcRegister> TmcRegisters { get => _tmcRegisters; set => Set(ref _tmcRegisters, value); }

    private TmcRegister _tmcRegister = null!;
    public TmcRegister TmcRegister { get => _tmcRegister; set => Set(ref _tmcRegister, value); }


    public MovementTmcViewModel(ITmcSprRepository<Tmc> tmcSprRepository )
    {
        _tmcSprRepository = tmcSprRepository;
      
    }

    private async void LoadData(int idTmc, int idLs)
    {
        if (TmcSprDto != null!)
        {
            TmcRegisters = await _tmcSprRepository.GetHistoriTmcByIdAsync(idTmc, idLs);
        }
        
    }

    #region Commands

    #region Excel

    private ICommand? _excelCommand;

    public ICommand ExcelCommand => _excelCommand
        ??= new RelayCommand(OnExcelExecuted, ExcelCan);

    private bool ExcelCan(object arg)
    {
        return TmcSprDto!=null!;
    }

    private void OnExcelExecuted(object obj)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.DefaultExt = "*.xlsx";
        saveFileDialog.FileName = $"Движение ТМЦ";
        saveFileDialog.Filter = "Microsoft Excel (*.xlsx)|*.xlsx";
        if (saveFileDialog.ShowDialog() == true)
        {
            MovementToExcel.ToExcel(TmcRegisters, TmcSprDto, saveFileDialog.FileName);
        }
    }

    #endregion

    #endregion
}
