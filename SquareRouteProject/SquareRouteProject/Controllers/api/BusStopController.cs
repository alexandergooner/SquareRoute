using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SquareRouteProject.Presentation.Controllers.api
{
    [RoutePrefix("api/BusStop")]
    public class BusStopController : ApiController
    {
        private UnitOfWorkDataModels _unitOfWork;

        public BusStopController() 
        {
            _unitOfWork = new UnitOfWorkDataModels();
        }
        #region BusStop Methods
        #region BusStop CREATE
        // POST api/BusStop/AddBusStop
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
        // GET api/BusStop/GetBusStopById
        [Route("GetBusStopById")]
        public BusStop GetBusStopById(int id)
        {
            return _unitOfWork.BusStopRepository.GetStopById(id);
        }

        // GET api/BusStop/GetBusStopsbyRouteId
        [Route("GetBusStopsbyRouteId")]
        public IList<BusStop> GetBusStopsbyRouteId(int id)
        {
            return _unitOfWork.BusStopRepository.GetStopsByRouteId(id);
        }

        // GET api/BusStop/GetAllBusStops
        [Route("GetAllBusStops")]
        public IList<BusStop> GetAllBusStops()
        {
            return _unitOfWork.BusStopRepository.Repo.GetAll();
        }
        #endregion

        #region BusStop UPDATE
        // POST api/BusStop/UpdateBusStop
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
        // POST api/BusStop/DeleteBusStopById
        [Route("DeleteBusStopById")]
        public IHttpActionResult DeleteBusStopById(int busStopId)
        {
            _unitOfWork.BusStopRepository.DeleteBusStopById(busStopId);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        #endregion
        #endregion
    }
}