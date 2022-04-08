using JourneyMicroservice.Core.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.AppServices
{
    public interface IJourneyAppServices
    {
        //Get all
        Task<List<Journey>> GetJourneyAllAsync();
        
        
        //Get ID
        Task<Journey> GetJourneyAsync(int JourneyId);
        
        
        //Insert
        Task<int> AddJourneyAsync(Journey journey);


        //Edit
        Task EditJourneyAsync(Journey journey);


        //Delete
        Task DeleteJourneyAsync(int JourneyId);

    }
}
