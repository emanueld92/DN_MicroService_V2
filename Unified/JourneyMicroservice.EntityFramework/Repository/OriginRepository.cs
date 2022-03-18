using JourneyMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.EntityFramework.Repository
{
    public class OriginRepository:Repository<int,Origin>
    {
        public OriginRepository(JourneyContext context) : base(context)
        {

        }
    }
}
