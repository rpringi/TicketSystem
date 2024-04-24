using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.data.Models;

namespace TicketSystem.data.Services
{
    public interface ITicketData
    {
        IEnumerable<Ticket> GetAll();
       Ticket Get(int id);
        void Add(Ticket ticket);
        void Update(Ticket ticket);
    }
}
