using System.ComponentModel.DataAnnotations;

namespace PassengerMicroservice.Api.Models
{
    public class PassengerViewModel
    {
       [Required]
       [StringLength(100)]
       public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
