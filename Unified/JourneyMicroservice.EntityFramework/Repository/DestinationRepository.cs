using JourneyMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMicroservice.EntityFramework.Repository
{
    public class DestinationRepository:Repository<int,Destination>
    {


        public DestinationRepository(JourneyContext context) : base(context)
        {

        }
    }
}
