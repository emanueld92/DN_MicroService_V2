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
    public class DestinationAppServices : IDestinationAppServices
    {

        private readonly IRepository<int,  Destination> _repository;
        public DestinationAppServices(IRepository<int,  Destination> repository)
        {
            _repository = repository;
        }


        //Insert
        public async Task<int> AddDestinationAsync(Destination destination)
        {
            await _repository.AddAsync(destination);

            return destination.DestinationId;
        }

        //Delete
        public async Task DeleteDestinationAsync(int destinationId)
        {
            await _repository.DeleteAsync(destinationId);
        }

        //Update

        public async Task EditDestinationAsync(Destination destination)
        {
            await _repository.UpdateAsync(destination);

        }

        //Get ALL
        public async Task<IList<Destination>> GetDestinationAllAsync()
        {

            return await _repository.GetAll().ToListAsync();
        }
        //Get Id
        public async Task<Destination> GetDestinationAsync(int destinationId)
        {
            return await _repository.GetAsync(destinationId);


        }


    }
}
