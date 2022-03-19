﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMicroservice.Core.Entity;

namespace TicketMicroservice.EntityFramework.Repository
{
    public class TicketRepository:Repository<int,Ticket>
    {

        public TicketRepository(TicketContext context): base(context)
        {


        }


    }
}
