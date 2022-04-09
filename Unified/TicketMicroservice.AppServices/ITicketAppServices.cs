using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMicroservice.Core.Entity;
using TicketMicroservice.Ticket.Dto;

namespace TicketMicroservice.AppServices
{
    public interface ITicketAppServices
    {

        //Get all
        Task<List<TicketDto>> GetTicketAllAsync();


        //Get ID
        Task<TicketDto> GetTicketAsync(int TicketId);


        //Insert
        Task<int> AddTicketAsync(TicketDto ticket);


        //Edit
        Task EditTicketAsync(TicketDto ticket);


        //Delete
        Task DeleteTicketAsync(int TicketId);
    }
}
