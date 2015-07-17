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
        private IAccessCodeUserRepository _accessCodeUserRepository;
        private IBusStopRepository _busStopRepository;
        private IRouteDriverRepository _routeDriverRepository;
        private IRouteRepository _routeRepository;        
        private IRouteSchoolRepository _routeSchoolRepository;
        private IRouteUserRepository _routeUserRepository;
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

        public IAccessCodeUserRepository AccessCodeUserRepository
        {
            get { return _accessCodeUserRepository ?? (_accessCodeUserRepository = new AccessCodeUserRepository(_context)); }
        }

        public IBusStopRepository BusStopRepository
        {   
            get { return _busStopRepository ?? (_busStopRepository = new BusStopRepository(_context)); }
        }

        public IRouteDriverRepository RouteDriverRepository
        {
            get { return _routeDriverRepository ?? (_routeDriverRepository = new RouteDriverRepository(_context)); }
        }

        public IRouteRepository RouteRepository
        {
            get { return _routeRepository ?? (_routeRepository = new RouteRepository(_context)); }
        }

        public IRouteSchoolRepository RouteSchoolRepository
        {
            get { return _routeSchoolRepository ?? (_routeSchoolRepository = new RouteSchoolRepository(_context)); }
        }

        public IRouteUserRepository RouteUserRepository
        {
            get { return _routeUserRepository ?? (_routeUserRepository = new RouteUserRepository(_context)); }
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
            _accessCodeUserRepository = null;
            _busStopRepository = null;
            _routeDriverRepository = null;
            _routeRepository = null;
            _routeSchoolRepository = null;
            _routeUserRepository = null;
            _context.Dispose();
        }
        #endregion

    }
}
