﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerMicroservice.Core.Entity
{
    public class Passenger
    {
        [Key]
        public int IdPassenger { get; set; }
       
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength (100)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
