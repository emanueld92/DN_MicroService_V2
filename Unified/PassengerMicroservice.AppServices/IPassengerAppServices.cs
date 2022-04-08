using PassengerMicroservice.Core.Entity;
using PassengerMicroservice.Passenger.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerMicroservice.AppServices
{
    public interface IPassengerAppServices
    {

        //Get all
        Task<List<PassengerDto>> GetPassengerAllAsync();
        //Create
        Task<int> AddPassengerAsync(PassengerDto passenger);
        //Delete
        Task DeletePassengerAsync(int passengerId);
        //Get ID
        Task<PassengerDto> GetPassengerAsync(int passengerId);
        //Update
        Task EditPassengerAsync(PassengerDto passenger);
    }
}
