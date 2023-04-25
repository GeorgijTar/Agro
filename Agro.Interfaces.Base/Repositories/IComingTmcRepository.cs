using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Registers;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;

public interface IComingTmcRepository<ComingTmc>: IBaseRepository<ComingTmc> where ComingTmc : Entity
{
    /// <summary>
    /// Получение очередного регистрационного номера
    /// </summary>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task<int> GetRegNumberAsync(CancellationToken cancel = default);

    public Task<IEnumerable<ComingTmc>?> GetAllNoTrackingAsync(CancellationToken cancel = default);

    public Task<ComingTmc> SetStatusAsync(int idStatus, ComingTmc item, CancellationToken cancel = default);

    public Task<bool> DeleteAccountingRegister (Guid idAr, CancellationToken cancel = default);

    public Task<bool> DeleteTmcRegister(Guid idAr, CancellationToken cancel = default);

    /// <summary>
    /// Удаление записей в регистре проводок
    /// </summary>
    /// <param name="accountingPlanRegisters">удаляемые записи</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    public Task<bool> DeleteAccountingRegisterRangePlanAsync(IEnumerable<AccountingPlanRegister> accountingPlanRegisters, CancellationToken cancel = default);

    /// <summary>
    /// Удаление записей в регистре ТМЦ
    /// </summary>
    /// <param name="tmcRegisters">удаляемые записи</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    public Task<bool> DeleteTmcRegisterRangePlanAsync(IEnumerable<TmcRegister> tmcRegisters, CancellationToken cancel = default);
}
