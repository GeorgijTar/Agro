using Agro.Domain.Base;

namespace Agro.Interfaces;

internal interface ICounterpartyManager
{

    #region Get

    /// <summary>
    /// Метод возвращающий всех сонтрагентов
    /// </summary>
    /// <param name="cancel">окен отмены</param>
    /// <returns></returns>
    Task<IEnumerable<CounterpartyDto>> GetAllCounterpartyAsync(CancellationToken cancel = default);

    /// <summary>
    /// Метод возвращающий количество всех контрагентов
    /// </summary>
    /// <param name="cancel">окен отмены</param>
    /// <returns></returns>
    Task<int> GetAllCounterpartyCountAsync(CancellationToken cancel = default);

    /// <summary>
    /// Метод получения всех контрагентов указанного типа
    /// </summary>
    /// <param name="typeId">Идентификатор типа</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<IEnumerable<CounterpartyDto>> GetAllCounterpartyByTypeAsync(int typeId, CancellationToken cancel = default);

    /// <summary>
    /// Метод получения всех контрагентов указанной группы
    /// </summary>
    /// <param name="groupId">Идентификатор группы</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<IEnumerable<CounterpartyDto>> GetAllCounterpartyByGroupAsync(int groupId, CancellationToken cancel = default);

    /// <summary>
    /// Метод возвращающий конкретного контрагента по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<CounterpartyDto> GetCounterpartyByIdAsync(int id, CancellationToken cancel = default);

    /// <summary>
    /// Метод возвращающий контрагента по его ИНН
    /// </summary>
    /// <param name="inn">ИНН контрагента</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<CounterpartyDto> GetCounterpartyByInnAsync(string inn, CancellationToken cancel = default);

    /// <summary>
    /// Метод возвращающий контрагента по его ОГРН
    /// </summary>
    /// <param name="ogrn">ОГРН контрагента</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<CounterpartyDto> GetCounterpartyByOgrnAsync(string ogrn, CancellationToken cancel = default);

    #endregion

    #region Создание

    /// <summary>
    /// Создание контрагента
    /// </summary>
    /// <param name="name">Наименование контрагента</param>
    /// <param name="payName">Платежное наименование контрагента</param>
    /// <param name="inn">ИНН контрагента</param>
    /// <param name="kpp">КПП контрагента</param>
    /// <param name="type">Тип контрагента</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<CounterpartyDto> CreateCounterpartyAsync(
        string name,
        string payName,
        TypeDocDto type,
        string inn,
        string kpp,
        CancellationToken cancel = default
    );

    #endregion

    #region Редактирование

    /// <summary>
    /// Метод замены типа контрагента
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="newType">Новый тип контрагента</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<bool> ChangeCounterpartyTypeAsync(int id, TypeDocDto newType, CancellationToken cancel = default);

    /// <summary>
    /// Метод замены группы контрагента
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="newGroup">Новая группа</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<bool> ChangeCounterpartyGroupAsync(int id, GroupDto newGroup, CancellationToken cancel = default);

    /// <summary>
    /// Метод изменения статуса контрагента
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="newStatus">Новый статус</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<bool> ChangeCounterpartyStatusAsync(int id, StatusDto newStatus, CancellationToken cancel = default);

    /// <summary>
    /// Метод изменения адреса контрагента
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="newAddress">Новый адрес</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<bool> ChangeCounterpartyAddressAsync(int id, AddressDto newAddress, CancellationToken cancel = default);

    /// <summary>
    /// Метод изменяющий наименование контрагента
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="newName">Новое наименовани контрагента</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<bool> ChangeCounterpartyNameAsync(int id, string newName, CancellationToken cancel = default);

    /// <summary>
    /// Метод изменяющий платежного наименование контрагента
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="newPayName">Новое платежное наименовани контрагента</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<bool> ChangeCounterpartyPayNameAsync(int id, string newPayName, CancellationToken cancel = default);

    /// <summary>
    ///  Метод изменяющий ИНН контрагента
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="newInn">Новый ИНН</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<bool> ChangeCounterpartyInnAsync(int id, string newInn, CancellationToken cancel = default);

    /// <summary>
    /// Метод изменяющий КПП контрагента
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newKpp">Новый КПП</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<bool> ChangeCounterpartyKppAsync(int id, string newKpp, CancellationToken cancel = default);

    /// <summary>
    /// Метод изменяющий ОГРН контрагента
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="newOgrn">Новый ОГРН</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<bool> ChangeCounterpartyOgrnAsync(int id, string newOgrn, CancellationToken cancel = default);

    /// <summary>
    /// Метод изменяющий ОКПО контрагента
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="newOkpo">Новый ОКПО</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<bool> ChangeCounterpartyOkpoAsync(int id, string newOkpo, CancellationToken cancel = default);

    #endregion

    #region BankDetails

    /// <summary>
    /// Метод привязки банковских реквизитов контрагенту
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="newBankDetailsId">Идентификатор банковских реквизитов</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<BankDetailsDto> AddCounterpartyBankDetailsAsync(int id, int newBankDetailsId, CancellationToken cancel = default);

    /// <summary>
    /// Метод отвязки банковских реквизитов контрагенту
    /// </summary>
    /// <param name="id">Идентификатор контрагента</param>
    /// <param name="bankDetailsId">Идентификатор банковских реквизитов</param>
    /// <param name="cancel">Токен отмены</param>
    /// <returns></returns>
    Task<bool> DeleteCounterpartyBankDetailsAsync(int id, int bankDetailsId, CancellationToken cancel = default);

    #endregion






}

