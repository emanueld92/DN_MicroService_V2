using JourneyMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.AppServices
{
    public interface IDestinationAppServices
    {
        //Get all
        Task<IList<Destination>> GetDestinationAllAsync();
        //Create
        Task<int> AddDestinationAsync(Destination detination);
        //Delete
        Task DeleteDestinationAsync(int detinationId);
        //Get ID
        Task<Destination> GetDestinationAsync(int detinationId);
        //Update
        Task EditDestinationAsync(Destination detination);
    }
}
