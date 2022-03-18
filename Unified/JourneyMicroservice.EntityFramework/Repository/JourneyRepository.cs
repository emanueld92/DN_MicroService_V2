using JourneyMicroservice.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.EntityFramework.Repository
{
    public class JourneyRepository:Repository<int,Journey>
    {

        public JourneyRepository(JourneyContext context): base(context) 
        { 
        
        }

         public override async Task<Journey> AddAsync(Journey entity)
        {
            var orgin = await Context.Origins.FindAsync(entity.Origin.OriginId);
            var destination = await Context.Destinations.FindAsync(entity.Destination.DestinationId);

            entity.Destination = null;
            entity.Origin = null;

            entity.Origin = orgin;
            entity.Destination= destination;

            await Context.Journeys.AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public override async Task<Journey> GetAsync(int id)
        {

            var journey = await Context.Journeys.Include(x => x.Origin).Include(x => x.Destination).FirstOrDefaultAsync(x => x.IdJourney == id);


            return journey;
        }


        public override IQueryable<Journey> GetAll()
        {
            try
            {
                var sources = Context.Journeys.Include(x => x.Origin).Include(x => x.Destination);
                return sources;
            }
            catch (Exception ex)
            {

                throw new Exception($"Couldn't retrive Entities: {ex.Message}");
            }
        }

        public override async Task<Journey> UpdateAsync(Journey entity)
        {
            var origin = await Context.Origins.FindAsync(entity.Origin.OriginId);
            var destination = await Context.Destinations.FindAsync(entity.Destination.DestinationId);
            entity.Origin = null;
            entity.Destination = null;
            origin.Journeys.Add(entity);
            destination.Journeys.Add(entity);

            var journey = await Context.Journeys.FindAsync(entity.IdJourney);

            journey.Departure = entity.Departure;
            journey.Arrival = entity.Arrival;



            await Context.SaveChangesAsync();

            return journey;
        }
    }
}
