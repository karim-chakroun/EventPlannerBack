using EventPlanner.Data.Infrastructures;
using EventPlanner.Domain.Models;
using Service.Pattern;

namespace EventPlanner.Service
{
    public class ServExternServices : Service<ExternServices>, IExternServices
    {
        public ServExternServices(IUnitOfWork utk) : base(utk)
        {
        }
    }
}
