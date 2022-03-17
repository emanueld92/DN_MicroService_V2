using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMicroservice.Core.Entity;

namespace TicketMicroservice.AppServices
{
    public interface ITicketAppServices
    {

        //Get all
        Task<IList<Ticket>> GetTicketAllAsync();


        //Get ID
        Task<Ticket> GetTicketAsync(int TicketId);


        //Insert
        Task<int> AddTicketAsync(Ticket ticket);


        //Edit
        Task EditTicketAsync(Ticket ticket);


        //Delete
        Task DeleteTicketAsync(int TicketId);
    }
}
