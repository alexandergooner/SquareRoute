using SquareRouteProject.Domain;
using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SquareRouteProject.Presentation.Controllers.api
{
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        private UnitOfWorkDataModels _unitOfWork;

        public AdminController()
        {
            _unitOfWork = new UnitOfWorkDataModels();
        }

        #region BusStop Methods
        #region BusStop CREATE        
        // POST api/Admin/AddBusStop
        [Route("AddBusStop")]
        public IHttpActionResult AddBusStop(BusStop busStop)
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.BusStopRepository.Repo.Add(busStop);
                _unitOfWork.SaveChanges();
            }
            return Ok();
        }
        #endregion

        #region BusStop GET        
        // GET api/Admin/GetBusStopById
        [Route("GetBusStopById")]
        public BusStop GetBusStopById(int id) 
        {
            return _unitOfWork.BusStopRepository.GetStopById(id);
        }

        // GET api/Admin/GetBusStopsbyRouteId
        [Route("GetBusStopsbyRouteId")]
        public IList<BusStop> GetBusStopsbyRouteId(int id) 
        {
            return _unitOfWork.BusStopRepository.GetStopsByRouteId(id);
        }

        // GET api/Admin/GetAllBusStops
        [Route("GetAllBusStops")]
        public IList<BusStop> GetAllBusStops() 
        {
            return _unitOfWork.BusStopRepository.Repo.GetAll();
        }
        #endregion

        #region BusStop UPDATE
        // POST api/Admin/UpdateBusStop
        [Route("UpdateBusStop")]
        public IHttpActionResult UpdateBusStop(BusStop stop) 
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.BusStopRepository.Repo.Update(stop);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region BusStop DELETE
        // POST api/Admin/DeleteBusStopById
        [Route("DeleteBusStopById")]
        public IHttpActionResult DeleteBusStopById(int busStopId)
        {
            _unitOfWork.BusStopRepository.DeleteBusStopById(busStopId);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        #endregion
        #endregion

        #region Route Methods
        #region Route CREATE
        // POST api/Admin/AddRoute
        [Route("AddRoute")]
        public IHttpActionResult AddRoute(Route route)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RouteRepository.Repo.Add(route);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region Route GET
        // GET api/Admin/GetRouteById
        [Route("GetRouteById")]
        public Route GetRouteById(int id)
        {
            return _unitOfWork.RouteRepository.GetRouteById(id);
        }

        // GET api/Admin/GetRouteByRouteNum
        [Route("GetRouteByRouteNum")]
        public Route GetRouteByRouteNum(int routeNum) 
        {
            return _unitOfWork.RouteRepository.GetRouteByRouteNum(routeNum);
        }

        // GET api/Admin/GetRoutesByDistrictId
        [Route("GetRoutesByDistrictId")]
        public IList<Route> GetRoutesByDistrictId(int districtId)
        {
            return _unitOfWork.RouteRepository.GetRoutesByDistrictId(districtId);
        }

        // GET api/Admin/GetAllRoutes
        [Route("GetAllRoutes")]
        public IList<Route> GetAllRoutes() 
        {
            return _unitOfWork.RouteRepository.Repo.GetAll();
        }
        #endregion

        #region Route UPDATE
        // POST api/Admin/UpdateRoute
        [Route("UpdateRoute")]
        public IHttpActionResult UpdateRoute(Route route)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RouteRepository.Repo.Update(route);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region DELETE
        // POST api/Admin/DeleteRouteById
        [Route("DeleteRouteById")]
        public IHttpActionResult DeleteRouteById(int routeId)
        {
            _unitOfWork.RouteRepository.DeleteRouteById(routeId);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        #endregion
        #endregion

        #region AccessCode Methods
        #region AccessCode CREATE
        // POST api/Admin/AddAccessCode
        [Route("AddAccessCode")]
        public IHttpActionResult AddAccessCode(AccessCode accessCode) 
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AccessCodeRepository.Repo.Add(accessCode);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region AccessCode GET
        // GET api/Admin/GetAccessCodeById
        [Route("GetAccessCodeById")]
        public AccessCode GetAccessCodeById(int id)
        {
            return _unitOfWork.AccessCodeRepository.GetAccessCodeById(id);
        }

        // GET api/Admin/GetAccessCodeByName
        [Route("GetAccessCodeByName")]
        public AccessCode GetAccessCodeByName(string accessCodeName)
        {
            return _unitOfWork.AccessCodeRepository.GetAccessCodeByValue(accessCodeName);
        }

        // GET api/Admin/GetAccessCodeByRouteId
        [Route("GetAccessCodeByRouteId")]
        public AccessCode GetAccessCodeByRouteId(int routeId)
        {
            return _unitOfWork.AccessCodeRepository.GetAccessCodeByRouteId(routeId);
        }

        // GET api/Admin/GetAllAccessCodes
        [Route("GetAllAccessCodes")]
        public IList<AccessCode> GetAllAccessCodes()
        {
            return _unitOfWork.AccessCodeRepository.Repo.GetAll();
        }


        #endregion
        
        #region AccessCode UPDATE
        // POST api/Admin/UpdateAccessCode
        [Route("UpdateAccessCode")]
        public IHttpActionResult UpdateAccessCode(AccessCode accessCode)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AccessCodeRepository.Repo.Update(accessCode);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        #endregion
        
        #region AccessCode Delete
        // POST api/Admin/DeleteAccessCodeById
        [Route("DeleteAccessCodeById")]
        public IHttpActionResult DeleteAccessCodeById(int accessCodeId)
        {
            _unitOfWork.AccessCodeRepository.DeleteAccessCodeById(accessCodeId);
            _unitOfWork.SaveChanges();
            return Ok();
        }        
        #endregion
        #endregion
    }
}