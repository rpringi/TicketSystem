using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Deadline {  get; set; }
        [Display(Name ="Solved?")]
        public Boolean IsSolved { get; set; }

    }
}
