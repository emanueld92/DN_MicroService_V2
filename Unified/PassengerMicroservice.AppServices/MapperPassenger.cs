using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace PassengerMicroservice.AppServices
{
    public class MapperPassenger:Profile
    {

        public MapperPassenger()
        {
            //Core to DTo
            CreateMap<PassengerMicroservice.Core.Entity.Passenger, PassengerMicroservice.Passenger.Dto.PassengerDto>();

            //DTO to Core

            CreateMap<PassengerMicroservice.Passenger.Dto.PassengerDto, PassengerMicroservice.Core.Entity.Passenger>();
           
        }
    }
}
