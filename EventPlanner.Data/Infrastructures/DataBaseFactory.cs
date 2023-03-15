using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EventPlanner.Data.Infrastructures
{
    public class DataBaseFactory : Disposable, IDatabaseFactory
    {
        private IdentityDbContext dataContext;
        public IdentityDbContext DataContext
        {
            get { return dataContext; }
        }
        public DataBaseFactory() { dataContext = new AppPlanningContext(); }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
