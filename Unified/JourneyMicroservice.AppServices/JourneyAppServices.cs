using JourneyMicroservice.Core.Entity;
using JourneyMicroservice.EntityFramework.Repository;
using JourneyMicroservice.Journey.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace JourneyMicroservice.AppServices
{
    public class JourneyAppServices : IJourneyAppServices
    {
        private readonly IRepository<int, JourneyMicroservice.Core.Entity.Journey> _repository;
        private readonly IMapper _mapper;
        public JourneyAppServices(IRepository<int, JourneyMicroservice.Core.Entity.Journey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //Insert
        public async Task<int> AddJourneyAsync(JourneyDto journey)
        {
            var j = _mapper.Map<JourneyMicroservice.Core.Entity.Journey>(journey);
            await _repository.AddAsync(j);
     

            return j.IdJourney;
        }

        //Delete
        public async Task DeleteJourneyAsync(int journeyId)
        {
            await _repository.DeleteAsync(journeyId);
        }

        //Update

        public async Task EditJourneyAsync(JourneyDto journey)
        {
            var j = _mapper.Map<JourneyMicroservice.Core.Entity.Journey>(journey);
            
            await _repository.UpdateAsync(j);

        }

        //Get ALL
        public async Task<List<JourneyDto>> GetJourneyAllAsync()
        {
            var j= await _repository.GetAll().ToListAsync();
            List<JourneyDto> journeys = _mapper.Map<List<JourneyDto>>(j);
            return journeys;
        }
        //Get Id
        public async Task<JourneyDto> GetJourneyAsync(int journeyId)
        {


            return _mapper.Map<JourneyDto>(await _repository.GetAsync(journeyId));


        }
    }
}
