using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketSystem.data.Models;
using TicketSystem.data.Services;

namespace Ticketsystem.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketData db;

        public TicketsController(ITicketData db)
        {
            this.db = db;
        }
        // GET: Tickets
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            if (ticket.Deadline.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError(nameof(ticket.Deadline), "Deadline must not be in the past");
            }
                if (ModelState.IsValid)
            {
                db.Add(ticket);
                return RedirectToAction("Details",new {id=ticket.Id});
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {

            if (ModelState.IsValid)
            {
                db.Update(ticket);
                return RedirectToAction("Details", new { id = ticket.Id });
            }
            return View(ticket);
        }
        
    }
}