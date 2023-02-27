﻿using EventPlanner.Domain.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service
{
    public interface IEventService : IService<Events>
    {
        public IEnumerable<Events> GetEventsWithNotif();
    }
}
