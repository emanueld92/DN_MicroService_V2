using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMicroservice.Core.Entity;
using TicketMicroservice.EntityFramework.Repository;

namespace TicketMicroservice.AppServices
{
    public class TicketAppServices : ITicketAppServices
    {
        private readonly IRepository<int, Ticket> _repository;
        public TicketAppServices(IRepository<int, Ticket> repository)
        {
            _repository = repository;
        }


        //Insert
        public async Task<int> AddTicketAsync(Ticket ticket)
        {
            await _repository.AddAsync(ticket);

            return ticket.IdTicket;
        }

        //Delete
        public async Task DeleteTicketAsync(int ticketId)
        {
            await _repository.DeleteAsync(ticketId);
        }

        //Update

        public async Task EditTicketAsync(Ticket ticket)
        {
            await _repository.UpdateAsync(ticket);

        }

        //Get ALL
        public async Task<List<Ticket>> GetTicketAllAsync()
        {

            return await _repository.GetAll().ToListAsync();
        }
        //Get Id
        public async Task<Ticket> GetTicketAsync(int ticketId)
        {
            return await _repository.GetAsync(ticketId);


        }
    }
}
