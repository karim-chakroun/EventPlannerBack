using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Data.Infrastructures
{
    public class DataBaseFactory : Disposable, IDatabaseFactory
    {
        private AppContext dataContext;
        public AppContext DataContext
        {
            get { return dataContext; }
        }
        public DataBaseFactory() { dataContext = new AppContext(); }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
