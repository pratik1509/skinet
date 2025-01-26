using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetListAsync();
    Task<T?> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> GetEntityListWithSpec(ISpecification<T> spec);
    void AddEntity(T entity);
    void DeleteEntity(T entity);
    void Update(T entity);
    bool IsExist(int id);
    Task<bool> SaveAllAsync();

}
