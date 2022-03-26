using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.Core.Entity
{
    public class Journey
    {
        [Key]
        public int IdJourney { get; set; }

        public Destination Destination { get; set; }

        public Origin Origin { get; set; }

        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; }


    }
}
