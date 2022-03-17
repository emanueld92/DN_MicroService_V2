using JourneyMicroservice.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.EntityFramework
{
    public class JourneyContext :DbContext
    {
        public virtual DbSet<Journey> Journeys { get; set; } 

        public JourneyContext(DbContextOptions<JourneyContext> options) : base(options)
        {

        }
    }
}
