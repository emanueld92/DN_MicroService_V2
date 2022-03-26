using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMicroservice.AppServices
{
    public interface IPassengerAppServices
    {
        Task<PassengerMicroservice.Core.Entity.Passenger> GetPassenger(int id);
    }
}
