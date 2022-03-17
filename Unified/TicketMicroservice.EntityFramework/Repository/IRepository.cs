using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMicroservice.EntityFramework.Repository
{
    public interface IRepository<TId, TEntity> where TEntity: class, new()
    {
        //GET ALL
        IQueryable<TEntity> GetAll();
        //GET ID
        Task<TEntity> GetAsync(TId id);
        //INSERT
        Task<TEntity> AddAsync(TEntity entity);
        //UPDATE
        Task<TEntity> UpdateAsync(TEntity entity);
        //DELETE
        Task DeleteAsync(TId id);
       
    }
}
