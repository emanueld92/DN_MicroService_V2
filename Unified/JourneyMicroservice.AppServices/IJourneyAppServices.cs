using JourneyMicroservice.Journey.Dto;
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
        Task<List<JourneyDto>> GetJourneyAllAsync();
        
        
        //Get ID
        Task<JourneyDto> GetJourneyAsync(int JourneyId);
        
        
        //Insert
        Task<int> AddJourneyAsync(JourneyDto journey);


        //Edit
        Task EditJourneyAsync(JourneyDto journey);


        //Delete
        Task DeleteJourneyAsync(int JourneyId);

    }
}
