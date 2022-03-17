using Microsoft.EntityFrameworkCore;
using PassengerMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerMicroservice.EntityFramework
{
    public class PassengerContext : DbContext
    {

        public virtual DbSet<Passenger> Passengers { get; set; }

        public PassengerContext(DbContextOptions<PassengerContext> options) : base(options)
        {

        }
    }
}
