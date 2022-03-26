using System;
using System.ComponentModel.DataAnnotations;

namespace JourneyMicroservice.Api.Models
{
    public class JourneyViewModels
    {
        [Required]
        public int DestinationId { get; set; }
        [Required]
        public int OriginId { get; set; }
        [Required]
        public DateTime Departune { get; set; }
        [Required]
        public DateTime Arrival { get; set; }
    }
}

