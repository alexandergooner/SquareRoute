using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SquareRouteProject.Presentation.Controllers.api
{
    [RoutePrefix("api/RouteUser")]
    public class RouteUserController : ApiController
    {
        private UnitOfWorkDataModels _unitOfWork;

        public RouteUserController()
        {
            _unitOfWork = new UnitOfWorkDataModels();
        }

        #region RouteUser Methods
        #region RouteUser CREATE
        //POST api/RouteUser/AddRouteUser
        [Route("AddRouteUser")]
        public IHttpActionResult AddRouteUser(RouteUser routeUser)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RouteUserRepository.Repo.Add(routeUser);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region RouteUser GET
        //GET api/RouteUser/GetAllRouteUsersByUserId/userId
        [Route("GetAllRouteUsersByUserId/{userId}")]
        public IList<RouteUser> GetAllRouteUsersByUserId(Guid userId)
        {
            return _unitOfWork.RouteUserRepository.GetAllRouteUsersByUserId(userId);
        }

        //GET api/RouteUser/GetAllRouteUsersByUsername/username
        [Route("GetAllRouteUsersByUsername/{username}")]
        public IList<RouteUser> GetAllRouteUsersByUsername(string username)
        {
            return _unitOfWork.RouteUserRepository.GetAllRouteUsersByUsername(username);
        }        
        #endregion

        #region RouteUser UPDATE
        //POST api/RouteUser/UpdateRouteUser
        [Route("UpdateRouteUser")]
        public IHttpActionResult UpdateRouteUser(RouteUser routeUser)
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.RouteUserRepository.Repo.Update(routeUser);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region RouteUser Delete
        //DELETE api/RouteUser/DeleteRouteUser
        [Route("DeleteRouteUser")]
        public IHttpActionResult DeleteRouteUser(RouteUser routeUser)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RouteUserRepository.Repo.Remove(routeUser);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion
        #endregion
    }
}