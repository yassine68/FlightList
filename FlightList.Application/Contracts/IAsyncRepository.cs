﻿namespace FlightList.Application.Contracts;

public interface IAsyncRepository<T> where T : class
{
    Task<T?> GetByIdAsync(string id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}