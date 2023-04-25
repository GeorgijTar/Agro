using System.Collections.ObjectModel;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Registers;
using Agro.Dto.Warehouse;

namespace Agro.Interfaces.Base.Repositories;

public interface ITmcSprRepository<Tmc>
{
    Task<ObservableCollection<TmcSprDto>?> GetAllAsync(CancellationToken cancel = default);

    Task<Tmc?> GetTmcByIdAsync(int idTmc, CancellationToken cancel = default);

    Task  <ObservableCollection<TmcRegister>> GetHistoriTmcByIdAsync(int idTmc, CancellationToken cancel = default);
    Task<ObservableCollection<TmcRegister>> GetHistoriTmcByIdAsync(int idTmc, int idSl, CancellationToken cancel = default);

    /// <summary>
    /// Возвращает текущий остаток номенклатуры на складе по ИД
    /// с отбором по месту хранения и счету учета
    /// </summary>
    /// <param name="idTmc"> Ид номенклатуры </param>
    /// <param name="idAp"> Ид счета учета </param>
    /// <param name="cancel">Токен отмены</param>
    /// <param name="idLs"> Ид места хранения </param>
    /// <returns></returns>
    Task<TmcSprDto?> GetRemainsTmcByIdLsApAsync(int idTmc, int idLs, int idAp,   CancellationToken cancel = default);

    Task<UnitOkei?> GetUnitByIdAsync(int idUnit, CancellationToken cancel = default);

    Task<AccountingPlan?> GetAccountingByIdAsync(int idAccounting, CancellationToken cancel = default);
}
