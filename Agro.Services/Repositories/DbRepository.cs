using Agro.DAL;
using Agro.DAL.Entities.Base;
using Agro.Interfaces.Base.Repositories.Base;
using Microsoft.EntityFrameworkCore;


namespace Agro.Services.Repositories;

public class DbRepository<T> : IBaseRepository<T> where T : Entity
{
    private readonly AgroDb _db;

    public DbRepository(AgroDb db) => _db = db;


    #region Реализация асинхронных задач

    /// <summary>Существует ли сущность с указанным идентификатором</summary>
    /// <param name="id">Проверяемый идентификатор сущности</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Истина, если сущность с указанным идентификатором существует в репозитории</returns>
    public async Task<bool> ExistIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Set<T>().AnyAsync(p => p.Id == id, cancel).ConfigureAwait(false);
    }

    // <summary>Существует ли в репозитории указанная сущность</summary>
    /// <param name="item">Проверяемая сущность</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Истина, если указанная сущность существует в репозитории</returns>
    public async Task<bool> ExistAsync(T item, CancellationToken cancel = default)
    {
        return await _db.Set<T>().AnyAsync(e => e == item, cancel).ConfigureAwait(false);
    }

    /// <summary>Получить число хранимых сущностей</summary>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    public async Task<int> GetCountAsync(CancellationToken cancel = default)
    {
        return await _db.Set<T>().CountAsync(cancel).ConfigureAwait(false);
    }

    /// <summary>Извлечь все сущности из репозитория</summary>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Перечисление всех сущностей репозитория</returns>
    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancel = default)
    {
        return await _db.Set<T>().ToArrayAsync(cancel).ConfigureAwait(false);
    }


    /// <summary>Получить сущность по указанному идентификатору</summary>
    /// <param name="id">Идентификатор извлекаемой сущности</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Сущность с указанным идентификатором в случае её наличия
    /// и null, если сущность отсутствует</returns>
    public async Task<T?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        return await _db.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancel).ConfigureAwait(false);
    }

    /// <summary>Добавление сущности в репозиторий с помощью фабричного метода</summary>
    /// <param name="item">добавляемая в репозиторий сущность</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Добавленная в репозиторий сущность</returns>
    public async Task<T> AddAsync(T item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        var table = _db.Set<T>();
        await table.AddAsync(item, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return item;
    }

    /// <summary>Добавление перечисленных сущностей в репозиторий</summary>
    /// <param name="items">Перечисление добавляемых в репозиторий сущностей</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Задача, завершающаяся при завершении операции добавления сущностей</returns>
    public async Task AddRangeAsync(IEnumerable<T> items, CancellationToken cancel = default)
    {
        if (items is null)
            throw new ArgumentNullException(nameof(items));

        var table = _db.Set<T>();
        await table.AddRangeAsync(items, cancel).ConfigureAwait(false);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
    }

    /// <summary>Обновление сущности в репозитории</summary>
    /// <param name="item">Сущность, хранящая в себе информацию, которую надо обновить в репозитории</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Сущность из репозитория с обновлёнными данными</returns>
    public async Task<T> UpdateAsync(T item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        //_db.Attach(item);
        _db.Update(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return item;
    }

    /// <summary>Обновление перечисленных сущностей</summary>
    /// <param name="items">Перечисление сущностей, информацию из которых надо обновить в репозитории</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Задача, завершаемая при завершении операции обновления сущностей</returns>
    public async Task UpdateRangeAsync(IEnumerable<T> items, CancellationToken cancel = default)
    {
        if (items is null) throw new ArgumentNullException(nameof(items));

        _db.AttachRange(items);
        _db.UpdateRange(items);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
    }

    // <summary>Удаление сущности из репозитория</summary>
    /// <param name="item">Удаляемая из репозитория сущность</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Удалённая из репозитория сущность</returns>f
    public async Task<T> DeleteAsync(T item, CancellationToken cancel = default)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        var table = _db.Set<T>();
        table.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return item;
    }

    /// <summary>Удаление перечисления сущностей из репозитория</summary>
    /// <param name="items">Перечисление удаляемых сущностей</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Задача, завершаемая при завершении операции удаления сущностей</returns>
    public async Task DeleteRangeAsync(IEnumerable<T> items, CancellationToken cancel = default)
    {
        if (items is null)
            throw new ArgumentNullException(nameof(items));

        var table = _db.Set<T>();
        table.RemoveRange(items);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);

    }

    /// <summary>Удаление сущности по заданному идентификатору</summary>
    /// <param name="id">Идентификатор сущности, которую надо удалить</param>
    /// <param name="cancel">Признак отмены асинхронной операции</param>
    /// <returns>Удалённая из репозитория сущность</returns>
    public async Task<T> DeleteByIdAsync(int id, CancellationToken cancel = default)
    {
        var table = _db.Set<T>();

        var item = await table.FirstOrDefaultAsync(s => s.Id == id, cancel).ConfigureAwait(false);
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        table.Remove(item);
        await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        return item;
    }

    #endregion

    #region Реализация сенхронных методов

    public bool ExistId(int id, CancellationToken cancel = default)
    {
        if (cancel.IsCancellationRequested)
            return false;

        return _db.Set<T>().Any(p => p.Id == id);
    }

    public bool Exist(T item, CancellationToken cancel = default)
    {
        if (cancel.IsCancellationRequested)
            return false;

        return _db.Set<T>().Any(e => e == item);
    }

    public int GetCount(CancellationToken cancel = default)
    {
        return cancel.IsCancellationRequested ? 0 : _db.Set<T>().Count();
    }

    public IEnumerable<T>? GetAll(CancellationToken cancel = default)
    {
        return cancel.IsCancellationRequested ? null : _db.Set<T>().ToArray();
    }

    public T? GetById(int id, CancellationToken cancel = default)
    {
        return _db.Set<T>().Find(id);
    }

    public T? Add(T item, CancellationToken cancel = default)
    {
        if (cancel.IsCancellationRequested)
            return null;  // TO-DO Что возвращать?

        if (item is null)
            throw new ArgumentNullException(nameof(item));

        var table = _db.Set<T>();
        table.Add(item);
        _db.SaveChanges();
        return item;
    }

    public bool AddRange(IEnumerable<T> items, CancellationToken cancel = default)
    {
        if (cancel.IsCancellationRequested)
            return false;

        if (items is null)
            throw new ArgumentNullException(nameof(items));

        var table = _db.Set<T>();
        table.AddRange(items);
        _db.SaveChanges();
        return true;
    }

    public T? Update(T item, CancellationToken cancel = default)
    {
        if (cancel.IsCancellationRequested)
            return null; // TO-DO Что возвращать?

        if (item is null)
            throw new ArgumentNullException(nameof(item));

        _db.Attach(item);
        _db.Update(item);
        _db.SaveChanges();
        return item;
    }

    public bool UpdateRange(IEnumerable<T> items, CancellationToken cancel = default)
    {
        if (cancel.IsCancellationRequested)
            return false;

        if (items is null) throw new ArgumentNullException(nameof(items));

        _db.AttachRange(items);
        _db.UpdateRange(items);
        _db.SaveChanges();
        return true;
    }

    public T? Delete(T item, CancellationToken cancel = default)
    {
        if (cancel.IsCancellationRequested)
            return null; // TO-DO Что возвращать?

        if (item is null)
            throw new ArgumentNullException(nameof(item));

        var table = _db.Set<T>();
        table.Remove(item);
        _db.SaveChanges();
        return item;
    }

    public bool DeleteRange(IEnumerable<T> items, CancellationToken cancel = default)
    {
        if (cancel.IsCancellationRequested)
            return false;

        if (items is null)
            throw new ArgumentNullException(nameof(items));

        var table = _db.Set<T>();
        table.RemoveRange(items);
        _db.SaveChanges();
        return true;
    }

    public T? DeleteById(int id, CancellationToken cancel = default)
    {
        if (cancel.IsCancellationRequested)
            return null;  // TO-DO Что возвращать?

        var table = _db.Set<T>();

        var item = table.FirstOrDefault(s => s.Id == id);
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        table.Remove(item);
        _db.SaveChanges();
        return item;
    }

    public async Task<IEnumerable<T>?> GetAllByStatusAsync(int statusId, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<T> SaveAsync(T item, CancellationToken cancel = default)
    {
        if (item.Id == 0)
        {
            return await AddAsync(item);
        }
        else
        {
            return await UpdateAsync(item);
        }
    }

    Task<bool> IBaseRepository<T>.DeleteAsync(T item, CancellationToken cancel)
    {
        throw new NotImplementedException();
    }

    Task<bool> IBaseRepository<T>.DeleteByIdAsync(int id, CancellationToken cancel)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T>? GetAll()
    {
        throw new NotImplementedException();
    }

    public T? GetById(int id)
    {
        return _db.Set<T>().FirstOrDefault(x => x.Id == id);
    }



    #endregion
}

