using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EventPlanner.Data.Infrastructures
{
    public interface IDatabaseFactory : IDisposable
    {
        IdentityDbContext DataContext { get; }
    }
}
