using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMicroservice.Ticket.Dto
{
    public class TicketDto
    {
        public int IdTicket { get; set; }
        public int JourneyId { get; set; }

        public int PassengerId { get; set; }

        public int Seat { get; set; }
    }
}
