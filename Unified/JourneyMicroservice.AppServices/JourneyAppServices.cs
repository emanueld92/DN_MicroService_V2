using JourneyMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.AppServices
{
    public class JourneyAppServices : IJourneyAppServices
    {
        public Task<int> AddJourneyAsync(Journey journey)
        {
            throw new NotImplementedException();
        }

        public Task DeleteJourneyAsync(int JourneyId)
        {
            throw new NotImplementedException();
        }

        public Task EditJourneyAsync(Journey journey)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Journey>> GetJourneyAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Journey> GetJourneyAsync(int JourneyId)
        {
            throw new NotImplementedException();
        }
    }
}
