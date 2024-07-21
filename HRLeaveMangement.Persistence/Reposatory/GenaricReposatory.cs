using HRLeaveMangement.Application.Contracts.Persistence;
using HRLeaveMangement.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveMangement.Persistence.Reposatory
{
    public class GenaricReposatory<T> : IGenaricReposatory<T> where T : class
    {
        private readonly LeaveMangeMentDbcontext _dbcontext;

        public GenaricReposatory(LeaveMangeMentDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<T> Add(T entity)
        {
           await _dbcontext.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
             _dbcontext.Set<T>().Remove(entity); 
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exists(int Id)
        {
            var entity = Get(Id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
           return await _dbcontext.Set<T>().FindAsync(id);

        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
             _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return entity;
        }
    }
}
