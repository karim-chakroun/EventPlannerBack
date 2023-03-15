using EventPlanner.Data.Infrastructures;
using EventPlanner.Domain.Models;
using Service.Pattern;

namespace EventPlanner.Service
{
    public class ServiceServ : Service<Services>, IServServices
    {
        public ServiceServ(IUnitOfWork utk) : base(utk)
        {
        }
    }
}
