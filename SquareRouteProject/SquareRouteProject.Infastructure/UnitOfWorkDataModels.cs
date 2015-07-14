using SquareRouteProject.Infastructure.Repositories;
using SquareRouteProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure
{
    public class UnitOfWorkDataModels
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private IAccessCodeRepository _accessCodeRepository;
        private IBusStopRepository _busStopRepository;
        private IRouteRepository _routeRepository;        
        #endregion

        #region Constructors
        public UnitOfWorkDataModels()
        {
            _context = new ApplicationDbContext();
        }
        #endregion 
 
        #region IUnitOfWorkDataModels Members
        public IAccessCodeRepository AccessCodeRepository
        {
            get { return _accessCodeRepository ?? (_accessCodeRepository = new AccessCodeRepository(_context)); }
        }

        public IBusStopRepository BusStopRepository
        {   
            get { return _busStopRepository ?? (_busStopRepository = new BusStopRepository(_context)); }
        }

        public IRouteRepository RouteRepository
        {
            get { return _routeRepository ?? (_routeRepository = new RouteRepository(_context)); }
        }

        public int SaveChanges() 
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        #endregion

        #region IDispoable Members
        public void Dispose()
        {
            _accessCodeRepository = null;
            _busStopRepository = null;
            _routeRepository = null;
            _context.Dispose();
        }
        #endregion

    }
}
