using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketSystem.data.Models;
using TicketSystem.data.Services;

namespace Ticketsystem.Web.api
{
    public class TicketsController : ApiController
    {
        private readonly ITicketData db;
        public TicketsController(ITicketData db) {
            this.db = db;

        }
        public IEnumerable<Ticket> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
