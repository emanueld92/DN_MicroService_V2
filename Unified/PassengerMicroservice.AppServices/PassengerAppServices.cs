using PassengerMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerMicroservice.AppServices
{
    public class PassengerAppServices : IPassengerAppServices
    {
        public Task<int> AddPassengerAsync(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public Task DeletePassengerAsync(int passengerId)
        {
            throw new NotImplementedException();
        }

        public Task EditPassengerAsync(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Passenger>> GetPassengerAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Passenger> GetPassengerAsync(int passengerId)
        {
            throw new NotImplementedException();
        }
    }
}
