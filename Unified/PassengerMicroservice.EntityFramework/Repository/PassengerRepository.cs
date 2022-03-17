using PassengerMicroservice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerMicroservice.EntityFramework.Repository
{
    public class PassengerRepository: Repository<int, Passenger>
    {

        public PassengerRepository(PassengerContext context) : base(context)
        {

        }
    }
}
