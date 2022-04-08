using JourneyMicroservice.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.EntityFramework.Repository
{
    public class JourneyRepository : Repository<int, Journey>
    {

        public JourneyRepository(JourneyContext context) : base(context)
        {

        }
    }

}
