using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data.Infrastructures
{
    public interface IDatabaseFactory : IDisposable
    {
        IdentityDbContext DataContext { get; }
    }
}
