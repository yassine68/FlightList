﻿using FlightList.Application.Contracts;
using FlightList.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlightList.Persistence.Repositories;

public partial class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly FlightDbContext _dbContext;

    public BaseRepository(FlightDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

}
