using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.ModelBinding;
using TicketSystem.data.Models;

namespace TicketSystem.data.Services
{
    public class InMemoryTicketData : ITicketData
    {
        List<Ticket> tickets;
        public InMemoryTicketData()
        {
            tickets = new List<Ticket>();
                
        }

        public void Add(Ticket ticket)
        {
                tickets.Add(ticket);
                ticket.IsSolved = false;
                ticket.CreatedAt = DateTime.Now;
                ticket.Id = tickets.Max(t => t.Id) + 1;//temporary solution to finding ID. 
        }
        public void Update(Ticket ticket)
        {
            var existing = Get(ticket.Id);
            if (existing != null)
            {
                existing.Description= ticket.Description;
                existing.Deadline= ticket.Deadline;
                existing.IsSolved= ticket.IsSolved;
            }
        }
        public Ticket GET(int id)
        {
            return tickets.FirstOrDefault(t=>t.Id==id);
        }

        public Ticket Get(int id)
        {
            return tickets.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return tickets.OrderByDescending(r=>r.Deadline);
        }
    }
}
