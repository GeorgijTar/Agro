
using System.Collections.ObjectModel;
using Agro.DAL.Entities.Registers;
using Agro.DAL.Entities.Warehouse;
using Agro.Dto.Warehouse;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.ViewModels.Base;

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
}
