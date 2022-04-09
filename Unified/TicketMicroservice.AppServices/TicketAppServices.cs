using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketMicroservice.Core.Entity;
using TicketMicroservice.EntityFramework.Repository;
using AutoMapper;
using TicketMicroservice.Ticket.Dto;

namespace TicketMicroservice.AppServices
{
    public class TicketAppServices : ITicketAppServices
    {
        private readonly IRepository<int, TicketMicroservice.Core.Entity.Ticket> _repository;
        private readonly IMapper _mapper;
        public TicketAppServices(IRepository<int,TicketMicroservice.Core.Entity.Ticket> repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //Insert
        public async Task<int> AddTicketAsync(TicketDto ticket)
        {
            var t = _mapper.Map<TicketMicroservice.Core.Entity.Ticket>(ticket);
            await _repository.AddAsync(t);

            return t.IdTicket;
        }

        //Delete
        public async Task DeleteTicketAsync(int ticketId)
        {
            await _repository.DeleteAsync(ticketId);
        }

        //Update

        public async Task EditTicketAsync(TicketDto ticket)
        {
            var t = _mapper.Map<TicketMicroservice.Core.Entity.Ticket>(ticket);

            await _repository.UpdateAsync(t);

        }

        //Get ALL
        public async Task<List<TicketDto>> GetTicketAllAsync()
        {
            var ts= await _repository.GetAll().ToListAsync();
            List<TicketDto> tickets = _mapper.Map<List<TicketDto>>(ts);
            return tickets;
        }
        //Get Id
        public async Task<TicketDto> GetTicketAsync(int ticketId)
        {
            return _mapper.Map<TicketDto>(await _repository.GetAsync(ticketId));

        }
    }
}
