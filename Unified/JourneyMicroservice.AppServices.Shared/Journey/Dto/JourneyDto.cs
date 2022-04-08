using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.Journey.Dto
{
    public class JourneyDto
    {
       
        public int IdJourney { get; set; }

        public int Destination { get; set; }

        public int Origin { get; set; }

        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; }
    }
}
