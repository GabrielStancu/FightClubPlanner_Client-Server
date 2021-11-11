using Core.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected FightClubContext Context;

        public GenericRepository(FightClubContext context)
        {
            Context = context;
        }

        public async Task<T> SelectByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> SelectAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            bool alreadyStored = Context.Set<T>().Any(e => e.Equals(entity));

            if (!alreadyStored)
            {
                await Context.Set<T>().AddAsync(entity);
                await Context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
