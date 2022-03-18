using JourneyMicroservice.Core.Entity;
using JourneyMicroservice.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.AppServices
{
    public class OriginAppServices : IOriginAppServices
    {
        private readonly IRepository<int, Origin> _repository;
        public OriginAppServices(IRepository<int, Origin> repository)
        {
            _repository = repository;
        }
        //Insert
        public async Task<int> AddOriginAsync(Origin origin)
        {
            await _repository.AddAsync(origin);

            return origin.OriginId;
        }

        //Delete
        public async Task DeleteOriginAsync(int originId)
        {
            await _repository.DeleteAsync(originId);
        }

        //Update

        public async Task EditOriginAsync(Origin origin)
        {
            await _repository.UpdateAsync(origin);

        }

        //Get ALL
        public async Task<IList<Origin>> GetOriginAllAsync()
        {

            return await _repository.GetAll().ToListAsync();
        }
        //Get Id
        public async Task<Origin> GetOriginAsync(int originId)
        {
            return await _repository.GetAsync(originId);


        }

    }
}
