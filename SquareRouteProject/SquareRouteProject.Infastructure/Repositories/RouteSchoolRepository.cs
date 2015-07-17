using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure.Repositories
{
    internal class RouteSchoolRepository : Repository<RouteSchool>, IRouteSchoolRepository
    {
        internal RouteSchoolRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        //Property Provides access to base Repository<TEntity> members
        public IRepository<RouteSchool> Repo
        {
            get { return this;  }
        }

        //GET All RouteSchool entries for a given routeId
        public IList<RouteSchool> GetAllRouteSchoolsByRouteId(int routeId)
        {
            return Set.Where(x => x.RouteId == routeId).ToList();
        }

        //GET All RouteSchool entries for a given schoolId
        public IList<RouteSchool> GetAllRouteSchoolsBySchoolId(int schoolId)
        {
            return Set.Where(x => x.SchoolId == schoolId).ToList();
        }
    }

}
