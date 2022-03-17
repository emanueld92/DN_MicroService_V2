using JourneyMicroservice.Core.Entity;
using JourneyMicroservice.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.AppServices
{
    public class JourneyAppServices : IJourneyAppServices
    {
        private readonly IRepository<int, Journey> _repository;
        public JourneyAppServices(IRepository<int, Journey> repository)
        {
            _repository = repository;
        }


        //Insert
        public async Task<int> AddJourneyAsync(Journey journey)
        {
            await _repository.AddAsync(journey);

            return journey.IdJourney;
        }

        //Delete
        public async Task DeleteJourneyAsync(int journeyId)
        {
            await _repository.DeleteAsync(journeyId);
        }

        //Update

        public async Task EditJourneyAsync(Journey journey)
        {
            await _repository.UpdateAsync(journey);

        }

        //Get ALL
        public async Task<List<Journey>> GetJourneyAllAsync()
        {

            return await _repository.GetAll().ToListAsync();
        }
        //Get Id
        public async Task<Journey> GetJourneyAsync(int journeyId)
        {
            return await _repository.GetAsync(journeyId);


        }
    }
}
