namespace Vet.Domain.Interfaces;

/// <summary>
/// Базовый интерфейс репозитория для выполнения стандартных CRUD-операций
/// </summary>
/// <typeparam name="T">Тип доменной сущности</typeparam>
public interface IRepository<TEntity, TKey>
{
    /// <summary>
    /// Получить все сущности
    /// </summary>
    public Task<IReadOnlyList<TEntity>> GetAllAsync();

    /// <summary>
    /// Найти сущность по ID
    /// </summary>
    public Task<TEntity?> GetByIdAsync(TKey entityId);

    /// <summary>
    /// Добавить новую сущность
    /// </summary>
    public Task<TEntity> AddAsync(TEntity entity);

    /// <summary>
    /// Обновить существующую сущность
    /// </summary>
    public Task<bool> UpdateAsync(TEntity entity);

    /// <summary>
    /// Удалить сущность по ID
    /// </summary>
    public Task<bool> DeleteAsync(TKey entityId);
}
