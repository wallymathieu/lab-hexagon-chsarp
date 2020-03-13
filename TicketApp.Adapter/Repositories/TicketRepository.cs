﻿using System;
using System.Collections.Generic;
using System.Linq;
using TicketApp.Application.Domain;

namespace TicketApp.Application.Repositories
{
    internal class TicketRepository : Repository<Ticket, int>, ITicketRepository
    {
        public TicketRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public List<Ticket> FindByCreationIsAfter(DateTime creation)
        {
            return
                (from ticket in appDbContext.Set<Ticket>()
                 where ticket.Creation.Date >= creation.Date
                 select ticket).ToList();
        }

        public List<Ticket> FindByCreationIsAfterAndPriority(DateTime creation, int priority)
        {
            return
                (from ticket in appDbContext.Set<Ticket>()
                 where ticket.Priority == priority 
                    && ticket.Creation.Date>=creation.Date
                 select ticket).ToList();
        }

        public List<Ticket> FindByPriority(int priority)
        {
            return
                (from ticket in appDbContext.Set<Ticket>()
                 where ticket.Priority == priority
                 select ticket).ToList();
        }
    }
}