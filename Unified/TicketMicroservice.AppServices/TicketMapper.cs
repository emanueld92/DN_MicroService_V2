using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace TicketMicroservice.AppServices
{
    public class TicketMapper: Profile
    {

        public TicketMapper()
        {
            //Core to Dto
            CreateMap<TicketMicroservice.Ticket.Dto.TicketDto, TicketMicroservice.Core.Entity.Ticket>();

           //Dto to Core
            CreateMap<TicketMicroservice.Core.Entity.Ticket, TicketMicroservice.Ticket.Dto.TicketDto>();
           

        }
    }
}
