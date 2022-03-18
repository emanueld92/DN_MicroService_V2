using JourneyMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.AppServices
{
    public interface IOriginAppServices
    {
        //Get all
        Task<IList<Origin>> GetOriginAllAsync();
        //Create
        Task<int> AddOriginAsync(Origin detination);
        //Delete
        Task DeleteOriginAsync(int detinationId);
        //Get ID
        Task<Origin> GetOriginAsync(int detinationId);
        //Update
        Task EditOriginAsync(Origin detination);
    }
}
