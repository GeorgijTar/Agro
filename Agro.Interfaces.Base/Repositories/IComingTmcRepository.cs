using Agro.DAL.Entities.Base;
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
}
