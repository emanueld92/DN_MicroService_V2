using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.Core.Entity
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }

        public List<Journey> Journeys { get; set; }

        public Destination()
        {
            Journeys = new List<Journey>();
        }
    }
}
