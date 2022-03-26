using System.ComponentModel.DataAnnotations;

namespace TicketMicroservice.Api.Models
{
    public class TicketViewModel
    {
        [Required]
        public int JourneyId { get; set; }
        [Required]
        public int PassengerId { get; set; }
        [Required]
        public int Seat { get; set; }

    }
}
