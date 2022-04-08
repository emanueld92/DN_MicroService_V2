using Microsoft.EntityFrameworkCore;
using PassengerMicroservice.Core.Entity;
using PassengerMicroservice.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PassengerMicroservice.Passenger.Dto;

namespace PassengerMicroservice.AppServices
{
    public class PassengerAppServices : IPassengerAppServices
    {
        private readonly IRepository<int,PassengerMicroservice.Core.Entity.Passenger> _repository;
        private readonly IMapper _mapper;
        public PassengerAppServices(IRepository<int, PassengerMicroservice.Core.Entity.Passenger> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }


        //Insert
        public async Task<int> AddPassengerAsync(PassengerDto passenger)
        {
            var p = _mapper.Map<PassengerMicroservice.Core.Entity.Passenger>(passenger);
            await _repository.AddAsync(p);

            return p.IdPassenger;
        }

        //Delete
        public async Task DeletePassengerAsync(int passengerId)
        {
            await _repository.DeleteAsync(passengerId);
        }

        //Update

        public async Task EditPassengerAsync(PassengerDto passenger)
        {
            var p = _mapper.Map<PassengerMicroservice.Core.Entity.Passenger>(passenger);
            await _repository.UpdateAsync(p);

        }

        //Get ALL
        public async Task<List<PassengerDto>> GetPassengerAllAsync()
        {
            var ps= await _repository.GetAll().ToListAsync();
            List<PassengerDto> passengers = _mapper.Map<List<PassengerDto>>(ps);
            return passengers;
        }
        //Get Id
        public async Task<PassengerDto> GetPassengerAsync(int passengerId)
        {
            return _mapper.Map<PassengerDto>(await _repository.GetAsync(passengerId));


        }
    }
}
