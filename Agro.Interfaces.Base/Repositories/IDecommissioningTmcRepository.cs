using System.Collections.ObjectModel;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Registers;
using Agro.Dto;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.Interfaces.Base.Repositories;
public interface IDecommissioningTmcRepository<DecommissioningTmc> : IBaseRepository<DecommissioningTmc> where DecommissioningTmc : Entity
{
    /// <summary>
    /// Получить Dto модель документа списания
    /// </summary>
    /// <param name="item"> документ списания </param>
    /// <param name="cancel"> токен отмены </param>
    /// <returns></returns>
    public Task<DecommissioningTmcDto> GetDecommissioningTmcDtoAsync(DecommissioningTmc item, CancellationToken cancel = default);

    /// <summary>
    /// Получение Dto модели документа по его Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task<DecommissioningTmcDto> GetDecommissioningTmcDtoByIdAsync(int id, CancellationToken cancel = default);

    /// <summary>
    /// Получить коллекцию Dto документов списания
    /// </summary>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task<ObservableCollection<DecommissioningTmcDto>> GetAllDecommissioningTmcDtoAsync(CancellationToken cancel = default);

    /// <summary>
    /// Получение регистрационного номера документа
    /// </summary>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task<int> GetRegNumberAsync(DateTime date, CancellationToken cancel = default);

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

