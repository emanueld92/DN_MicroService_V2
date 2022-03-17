using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.EntityFramework.Repository
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : class, new()
    {
        private readonly JourneyContext _context;
        protected JourneyContext Context { get => _context; }

        public Repository(JourneyContext context) => _context = context;

        //Insert
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{(nameof(AddAsync))} Entitymust not be null");
            }
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw new ArgumentNullException($"{(nameof(entity))} Could not be saved:{ex.Message}");
            }
        }
        //Delete
        public virtual async Task DeleteAsync(TId id)
        {
            var entity = await _context.FindAsync<TEntity>(id);

            _context.Remove<TEntity>(entity);
            await _context.SaveChangesAsync();
        }

        //Get All
        public virtual IQueryable<TEntity> GetAll()
        {
            try
            {

                return _context.Set<TEntity>();
            }
            catch (Exception ex)
            {

                throw new Exception($"Couldn't retrive Entities: {ex.Message}");
            }
        }
        //Get Id
        public virtual async Task<TEntity> GetAsync(TId id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            return entity;
        }
        //Update
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException($"{(nameof(AddAsync))} Entity must not be null");
            }
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{(nameof(entity))} Could not be update:{ex.Message}");
            }
        }


    }
}
