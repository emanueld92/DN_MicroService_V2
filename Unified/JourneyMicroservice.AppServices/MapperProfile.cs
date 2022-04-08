using AutoMapper;
using JourneyMicroservice.Core.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.AppServices
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            //core to DTO Mapper
            CreateMap<JourneyMicroservice.Core.Entity.Journey, JourneyMicroservice.Journey.Dto.JourneyDto>();
            
            ///Dto to Core Mapper
            CreateMap<JourneyMicroservice.Journey.Dto.JourneyDto, JourneyMicroservice.Core.Entity.Journey >();

        }

    }
}
