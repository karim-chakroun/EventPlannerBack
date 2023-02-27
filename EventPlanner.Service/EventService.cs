using EventPlanner.Data.Infrastructures;
using EventPlanner.Domain.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service
{
    public class EventService : Service<Events>, IEventService
    {
        public EventService(IUnitOfWork utk) : base(utk)
        {
        }

        public IEnumerable<Events> GetEventsWithNotif()
        {
            IDatabaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);
            return utwk.getRepository<Events>().GetMany(e => e.Notifications != null).Distinct();
        }
    }
}
