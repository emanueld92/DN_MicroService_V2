using JourneyMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMicroservice.Core.Entity
{
    public class Ticket
    {
        [Key]
        public int IdTicket { get; set; }

        public int JourneyId { get; set; }

        public int PassengerId { get; set; }

        public int Seat { get; set; }
    }
}
