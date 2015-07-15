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
        // GET api/BusStop/GetBusStopById/id
        [Route("GetBusStopById/{id}")]
        public BusStop GetBusStopById(int id)
        {
            return _unitOfWork.BusStopRepository.GetStopById(id);
        }

        // GET api/BusStop/GetBusStopsbyRouteId/id
        [Route("GetBusStopsbyRouteId/{id}")]
        public IList<BusStop> GetBusStopsByRouteId(int id)
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
        public IHttpActionResult UpdateBusStop(BusStop busStop)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BusStopRepository.Repo.Update(busStop);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region BusStop DELETE
        // POST api/BusStop/DeleteBusStopById/id
        [Route("DeleteBusStopById/{id}")]
        public IHttpActionResult DeleteBusStopById(int id)
        {
            _unitOfWork.BusStopRepository.DeleteBusStopById(id);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        #endregion
        #endregion
    }
}