using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMicroservice.Core.Entity;

namespace TicketMicroservice.EntityFramework
{
    public class TicketContext : DbContext
    {
        public virtual DbSet<Ticket> Tickets { get; set; }

        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {

        }
    }
}
