using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMicroservice.AppServices
{
    public interface IJourneyAppServices
    {

        Task<JourneyMicroservice.Core.Entity.Journey> GetJourney(int id);
    }
}
