using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMicroservice.Core.Entity;

namespace TicketMicroservice.AppServices
{
    public class TicketAppServices : ITicketAppServices
    {
        public Task<int> AddTicketAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTicketAsync(int TicketId)
        {
            throw new NotImplementedException();
        }

        public Task EditTicketAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Ticket>> GetTicketAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetTicketAsync(int TicketId)
        {
            throw new NotImplementedException();
        }
    }
}
