using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SquareRouteProject.Presentation.Controllers.api
{
    [RoutePrefix("api/RouteSchool")]
    public class RouteSchoolController : ApiController
    {
        private UnitOfWorkDataModels _unitOfWork;

        public RouteSchoolController() 
        {
            _unitOfWork = new UnitOfWorkDataModels();
        }

        #region RouteSchool Methods
        #region RouteSchool CREATE
        //POST api/RouteSchool/AddRouteSchool
        [Route("AddRouteSchool")]
        public IHttpActionResult AddRouteSchool(RouteSchool routeSchool)
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.RouteSchoolRepository.Repo.Add(routeSchool);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region RouteSchool GET
        //GET api/RouteSchool/GetAllRouteSchoolsByRouteId/routeId
        [Route("GetAllRouteSchoolsByRouteId/{routeId}")]
        public IList<RouteSchool> GetAllRouteSchoolsByRouteId(int routeId)
        {
            return _unitOfWork.RouteSchoolRepository.GetAllRouteSchoolsByRouteId(routeId);
        }

        //GET api/RouteSchool/GetAllRouteSchoolsBySchoolId/schoolId
        [Route("GetAllRouteSchoolsBySchoolId/{schoolId}")]
        public IList<RouteSchool> GetAllRouteSchoolsBySchoolId(int schoolId)
        {
            return _unitOfWork.RouteSchoolRepository.GetAllRouteSchoolsBySchoolId(schoolId);
        }
        #endregion

        #region RouteSchool UPDATE
        //POST api/RouteSchool/UpdateRouteSchool
        [Route("UpdateRouteSchool")]
        public IHttpActionResult UpdateRouteSchool(RouteSchool routeSchool)
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.RouteSchoolRepository.Repo.Update(routeSchool);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region RouteSchool DELETE
        //POST api/RouteSchool/DeleteRouteSchool
        [Route("DeleteRouteSchool")]
        public IHttpActionResult DeleteRouteSchool(RouteSchool routeSchool)
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.RouteSchoolRepository.Repo.Remove(routeSchool);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion
        #endregion
    }
}