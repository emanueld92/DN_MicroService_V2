using Microsoft.EntityFrameworkCore;
using PassengerMicroservice.Core.Entity;
using PassengerMicroservice.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerMicroservice.AppServices
{
    public class PassengerAppServices : IPassengerAppServices
    {
        private readonly IRepository<int, Passenger> _repository;
        public PassengerAppServices(IRepository<int, Passenger> repository)
        {
            _repository = repository;
        }


        //Insert
        public async Task<int> AddPassengerAsync(Passenger passenger)
        {
            await _repository.AddAsync(passenger);

            return passenger.IdPassenger;
        }

        //Delete
        public async Task DeletePassengerAsync(int passengerId)
        {
            await _repository.DeleteAsync(passengerId);
        }

        //Update

        public async Task EditPassengerAsync(Passenger passenger)
        {
            await _repository.UpdateAsync(passenger);

        }

        //Get ALL
        public async Task<List<Passenger>> GetPassengerAllAsync()
        {

            return await _repository.GetAll().ToListAsync();
        }
        //Get Id
        public async Task<Passenger> GetPassengerAsync(int passengerId)
        {
            return await _repository.GetAsync(passengerId);


        }
    }
}
