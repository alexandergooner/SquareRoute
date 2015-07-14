using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SquareRouteProject.Presentation.Controllers.api
{
    [RoutePrefix("api/Route")]
    public class RouteController : ApiController
    {
        private UnitOfWorkDataModels _unitOfWork;

        public RouteController()
        {
            _unitOfWork = new UnitOfWorkDataModels();
        }

        #region Route Methods
        #region Route CREATE
        // POST api/Route/AddRoute
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
        // GET api/Route/GetRouteById
        [Route("GetRouteById")]
        public Route GetRouteById(int id)
        {
            return _unitOfWork.RouteRepository.GetRouteById(id);
        }

        // GET api/Route/GetRouteByRouteNum
        [Route("GetRouteByRouteNum")]
        public Route GetRouteByRouteNum(int routeNum)
        {
            return _unitOfWork.RouteRepository.GetRouteByRouteNum(routeNum);
        }

        // GET api/Route/GetRoutesByDistrictId
        [Route("GetRoutesByDistrictId")]
        public IList<Route> GetRoutesByDistrictId(int districtId)
        {
            return _unitOfWork.RouteRepository.GetRoutesByDistrictId(districtId);
        }

        // GET api/Route/GetAllRoutes
        [Route("GetAllRoutes")]
        public IList<Route> GetAllRoutes()
        {
            return _unitOfWork.RouteRepository.Repo.GetAll();
        }
        #endregion

        #region Route UPDATE
        // POST api/Route/UpdateRoute
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
        // POST api/Route/DeleteRouteById
        [Route("DeleteRouteById")]
        public IHttpActionResult DeleteRouteById(int routeId)
        {
            _unitOfWork.RouteRepository.DeleteRouteById(routeId);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        #endregion
        #endregion
    }
}