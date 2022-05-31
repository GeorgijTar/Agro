using Agro.Interfaces.Base.Entities;

namespace Agro.Interfaces.Base.Repositories;

/// <summary>Репозиторий сущностей</summary>
/// <typeparam name="T">Тип сущности, хранимой в репозитории</typeparam>
/// <typeparam name="TKey">Тип первичного ключа</typeparam>
public interface IRepository<T, in TKey> where T : IEntity<TKey>
{

    #region Асинхронные задачи

    ///// <summary>Проверка репозитория на пустоту</summary>
    ///// <param name="cancel">Признак отмены асинхронной операции</param>
    ///// <returns>Истина, если в репозитории нет ни одной сущности</returns>
    //async Task<bool> IsEmptyAsync(CancellationToken cancel = default)
    //{
    //    var count = await GetCountAsync(cancel).ConfigureAwait(false);
    //    return count > 0;
    //}

    ///// <summary>Существует ли сущность с указанным идентификатором</summary>
    ///// <param name="id">Проверяемый идентификатор сущности</param>
    ///// <param name="cancel">Признак отмены асинхронной операции</param>
    ///// <returns>Истина, если сущность с указанным идентификатором существует в репозитории</returns>
    //Task<bool> ExistIdAsync(int id, CancellationToken cancel = default);

    ///// <summary>Существует ли в репозитории указанная сущность</summary>
    ///// <param name="item">Проверяемая сущность</param>
    ///// <param name="cancel">Признак отмены асинхронной операции</param>
    ///// <returns>Истина, если указанная сущность существует в репозитории</returns>
    //Task<bool> ExistAsync(T item, CancellationToken cancel = default);

    /// <summary>Получить число хранимых сущностей</summary>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    Task<int> GetCountAsync(CancellationToken cancel = default);

    /// <summary>Извлечь все сущности из репозитория</summary>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Перечисление всех сущностей репозитория</returns>
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancel = default);

    /// <summary>Получить сущность по указанному идентификатору</summary>
    /// <param name="id">Идентификатор извлекаемой сущности</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Сущность с указанным идентификатором в случае её наличия
    /// и null, если сущность отсутствует</returns>
    Task<T?> GetByIdAsync(int id, CancellationToken cancel = default);

    /// <summary>Добавление сущности в репозиторий с помощью фабричного метода</summary>
    /// <param name="item">добавляемая в репозиторий сущность</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Добавленная в репозиторий сущность</returns>
    Task<T> AddAsync(T item, CancellationToken cancel = default);

    /// <summary>Добавление перечисленных сущностей в репозиторий</summary>
    /// <param name="items">Перечисление добавляемых в репозиторий сущностей</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Задача, завершающаяся при завершении операции добавления сущностей</returns>
    Task AddRangeAsync(IEnumerable<T> items, CancellationToken cancel = default);

    /// <summary>Обновление сущности в репозитории</summary>
    /// <param name="item">Сущность, хранящая в себе информацию, которую надо обновить в репозитории</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Сущность из репозитория с обновлёнными данными</returns>
    Task<T> UpdateAsync(T item, CancellationToken cancel = default);

    /// <summary>Обновление перечисленных сущностей</summary>
    /// <param name="items">Перечисление сущностей, информацию из которых надо обновить в репозитории</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Задача, завершаемая при завершении операции обновления сущностей</returns>
    Task UpdateRangeAsync(IEnumerable<T> items, CancellationToken cancel = default);

    /// <summary>Удаление сущности из репозитория</summary>
    /// <param name="item">Удаляемая из репозитория сущность</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Удалённая из репозитория сущность</returns>
    Task<T> DeleteAsync(T item, CancellationToken cancel = default);

    /// <summary>Удаление перечисления сущностей из репозитория</summary>
    /// <param name="items">Перечисление удаляемых сущностей</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Задача, завершаемая при завершении операции удаления сущностей</returns>
    Task DeleteRangeAsync(IEnumerable<T> items, CancellationToken cancel = default);

    /// <summary>Удаление сущности по заданному идентификатору</summary>
    /// <param name="id">Идентификатор сущности, которую надо удалить</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Удалённая из репозитория сущность</returns>
    Task<T> DeleteByIdAsync(int id, CancellationToken cancel = default);

    #endregion

    #region Синхронные методы

   // /// <summary>Проверка репозитория на пустоту</summary>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Истина, если в репозитории нет ни одной сущности</returns>
   // bool IsEmpty(CancellationToken cancel = default)
   // {
   //     var count =  GetCount(cancel);
   //     return count > 0;
   // }

   // /// <summary>Существует ли сущность с указанным идентификатором</summary>
   // /// <param name="id">Проверяемый идентификатор сущности</param>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Истина, если сущность с указанным идентификатором существует в репозитории</returns>
   // bool ExistId(TKey id, CancellationToken cancel = default);

   // /// <summary>Существует ли в репозитории указанная сущность</summary>
   // /// <param name="item">Проверяемая сущность</param>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Истина, если указанная сущность существует в репозитории</returns>
   // bool Exist(T item, CancellationToken cancel = default);

   // /// <summary>Получить число хранимых сущностей</summary>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // int GetCount(CancellationToken cancel = default);

   // /// <summary>Извлечь все сущности из репозитория</summary>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Перечисление всех сущностей репозитория</returns>
   // IEnumerable<T>? GetAll(CancellationToken cancel = default);

   // /// <summary>Получить сущность по указанному идентификатору</summary>
   // /// <param name="id">Идентификатор извлекаемой сущности</param>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Сущность с указанным идентификатором в случае её наличия
   // /// и null, если сущность отсутствует</returns>
   // T? GetById(int id, CancellationToken cancel = default);

   // /// <summary>Добавление сущности в репозиторий с помощью фабричного метода</summary>
   // /// <param name="item">добавляемая в репозиторий сущность</param>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Добавленная в репозиторий сущность</returns>
   // T? Add(T item, CancellationToken cancel = default);

   // /// <summary>Добавление перечисленных сущностей в репозиторий</summary>
   // /// <param name="items">Перечисление добавляемых в репозиторий сущностей</param>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Истина если сущности успешно добавлены</returns>
   // bool AddRange(IEnumerable<T> items, CancellationToken cancel = default);

   // /// <summary>Обновление сущности в репозитории</summary>
   // /// <param name="item">Сущность, хранящая в себе информацию, которую надо обновить в репозитории</param>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Сущность из репозитория с обновлёнными данными</returns>
   // T? Update(T item, CancellationToken cancel = default);

   // /// <summary>Обновление перечисленных сущностей</summary>
   // /// <param name="items">Перечисление сущностей, информацию из которых надо обновить в репозитории</param>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Истина если сущности успешно обновлены</returns>
   // bool UpdateRange(IEnumerable<T> items, CancellationToken cancel = default);

   // /// <summary>Удаление сущности из репозитория</summary>
   // /// <param name="item">Удаляемая из репозитория сущность</param>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Удалённая из репозитория сущность</returns>
   // T? Delete(T item, CancellationToken cancel = default);

   // /// <summary>Удаление перечисления сущностей из репозитория</summary>
   // /// <param name="items">Перечисление удаляемых сущностей</param>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Задача, завершаемая при завершении операции удаления сущностей</returns>
   // bool DeleteRange(IEnumerable<T> items, CancellationToken cancel = default);

   // /// <summary>Удаление сущности по заданному идентификатору</summary>
   // /// <param name="id">Идентификатор сущности, которую надо удалить</param>
   // /// <param name="cancel">Признак отмены асинхронной операции</param>
   // /// <returns>Удалённая из репозитория сущность</returns>
   //T? DeleteById(int id, CancellationToken cancel = default);


    #endregion
}

/// <summary>Репозиторий сущностей</summary>
public interface IRepository<T> : IRepository<T, int> where T : IEntity<int> { }