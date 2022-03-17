using PassengerMicroservice.Core.Entity;
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
        Task<IList<Passenger>> GetPassengerAllAsync();
        //Create
        Task<int> AddPassengerAsync(Passenger passenger);
        //Delete
        Task DeletePassengerAsync(int passengerId);
        //Get ID
        Task<Passenger> GetPassengerAsync(int passengerId);
        //Update
        Task EditPassengerAsync(Passenger passenger);
    }
}
