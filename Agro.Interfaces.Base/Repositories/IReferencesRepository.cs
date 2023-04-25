
using Agro.DAL.Entities;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Bank.Base;
using Agro.DAL.Entities.Bank.Pay;
using Agro.DAL.Entities.Organization;
using Agro.DAL.Entities.Storage;
using Agro.DAL.Entities.TaxesType;
using Agro.DAL.Entities.Warehouse.Coming;
using Agro.DAL.Entities.Warehouse.Decommissioning;

namespace Agro.Interfaces.Base.Repositories;
public interface IReferencesRepository
{
    /// <summary>
    /// Справочник статусов
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<Status>?> GetAllStatusAsync(CancellationToken cancel = default);

    /// <summary>
    /// Справочник типов документов
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<TypeDoc>?> GetAllTypeDocAsync(CancellationToken cancel = default);


    /// <summary>
    /// Справочник групп документов
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<GroupDoc>?> GetAllGroupDocAsync(CancellationToken cancel = default);

    /// <summary>
    /// Справочник типов операций платежей
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<TypeOperationPay>?> GetAllTypeOperationPayAsync(CancellationToken cancel = default);

    /// <summary>
    /// Справочник типов обязательств
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<TypeCommitment>?> GetAllTypeCommitmentAsync(CancellationToken cancel = default);

    /// <summary>
    /// Справочник типов направления денежных потоков ДДС
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<TypeCashFlow>?> GetAllTypeCashFlowAsync(CancellationToken cancel = default);

    /// <summary>
    /// Справочник Оснований платежа
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<BasisPayment>?> GetAllBasisPaymentAsync(CancellationToken cancel = default);


    /// <summary>
    /// Справочник Видов операциий
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<TypeTransactions>?> GetAllTypeTransactionsAsync(CancellationToken cancel = default);

    /// <summary>
    /// Справочник статусов плательщика
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<PayerStatus>?> GetAllPayerStatusAsync(CancellationToken cancel = default);


    /// <summary>
    /// Справочник ставок НДС
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<Nds>?> GetAllNdsAsync(CancellationToken cancel = default);


    /// <summary>
    /// Справочник банковских счетов организации
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<BankDetails>?> GetAllBankDetailsOrgAsync(CancellationToken cancel = default);

    /// <summary>
    /// Данные об организации
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<Organization?> GetOrganizationAsync(CancellationToken cancel = default);


    /// <summary>
    /// Справочник видов платежа
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<TypePayment>?> GetAllTypesPaymentAsync(CancellationToken cancel = default);


    /// <summary>
    /// Справочник очередности платежа
    /// </summary>
    /// <param name="cancel">Токен отмены</param>
    /// <returns>IEnumerable</returns>
    public Task<IEnumerable<OrderPayment>?> GetAllOrderPaymentAsync(CancellationToken cancel = default);

    /// <summary>
    /// План счетов
    /// </summary>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task<IEnumerable<AccountingPlan>?> GetAllAccountingPlanAsync(CancellationToken cancel = default);

    /// <summary>
    /// Справочник мест хранения
    /// </summary>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task<IEnumerable<StorageLocation>?> GetAllStorageLocationAsync(CancellationToken cancel = default);

    /// <summary>
    /// Справочник валют
    /// </summary>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task<IEnumerable<Currency>?> GetAllCurrencyAsync(CancellationToken cancel = default);

    /// <summary>
    /// Справочник валют
    /// </summary>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task<IEnumerable<AccountingMethodNds>?> GetAllAccountingMethodNdsAsync(CancellationToken cancel = default);

    /// <summary>
    /// Справочник типов объектов списания
    /// </summary>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task<IEnumerable<TypeObject>?> GetAllTypeObjectAsync(CancellationToken cancel = default);

    /// <summary>
    /// Справочник групп объектов списания
    /// </summary>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task<IEnumerable<GroupObject>?> GetAllGroupObjectAsync(CancellationToken cancel = default);
}
