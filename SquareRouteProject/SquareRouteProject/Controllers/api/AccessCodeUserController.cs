using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SquareRouteProject.Presentation.Controllers.api
{
    [RoutePrefix("api/AccessCodeUser")]
    public class AccessCodeUserController : ApiController
    {
        private UnitOfWorkDataModels _unitOfWork;

        public AccessCodeUserController()
        {
            _unitOfWork = new UnitOfWorkDataModels();
        }

        #region AccessCodeUser Methods
        #region AccessCodeUser CREATE
        //POST api/AccessCodeUser/AddAccessCodeUser
        [Route("AddAccessCodeUser")]
        public IHttpActionResult AddAccessCodeUser(AccessCodeUser accessCodeUser)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AccessCodeUserRepository.Repo.Add(accessCodeUser);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region AccessCodeUser GET
        //GET api/AccessCodeUser/GetAllAccessCodeUsersByUserId/userId
        [Route("GetAllAccessCodeUsersByUserId/{userId}")]
        public IList<AccessCodeUser> GetAllAccessCodeUsersByUserId(Guid userId)
        {
            return _unitOfWork.AccessCodeUserRepository.GetAllAccessCodeUsersByUserId(userId);
        }

        //GET api/AccessCodeUser/GetAllAccessCodeUsersByAccessCodeId/accessCodeId
        [Route("GetAllAccessCodeUsersByAccessCodeId/{accessCodeId}")]
        public IList<AccessCodeUser> GetAllAccessCodeUsersByAccessCodeId(int accesssCodeId)
        {
            return _unitOfWork.AccessCodeUserRepository.GetAllAccessCodeUsersByAccessCodeId(accesssCodeId);
        }
        #endregion

        #region AccessCodeUser UPDATE
        //POST api/AccessCodeUser/UpdateAccessCodeUser
        [Route("UpdateAccessCodeUser")]
        public IHttpActionResult UpdateAccessCodeUser(AccessCodeUser accessCodeUser)
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.AccessCodeUserRepository.Repo.Update(accessCodeUser);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region AccessCodeUser DELETE
        //DELETE api/AccessCodeUser/DeleteAccessCodeUser
        [Route("DeleteAccessCodeUser")]
        public IHttpActionResult DeleteAccessCodeUser(AccessCodeUser accessCodeUser) 
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.AccessCodeUserRepository.Repo.Remove(accessCodeUser);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion
        #endregion
    }
}