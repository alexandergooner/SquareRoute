﻿using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SquareRouteProject.Presentation.Controllers.api
{
    [RoutePrefix("api/RouteDriver")]
    public class RouteDriverController : ApiController
    {
        private UnitOfWorkDataModels _unitOfWork;
        public RouteDriverController()
        {
            _unitOfWork = new UnitOfWorkDataModels();
        }

        #region RouteDriver Methods
        #region RouteDriver CREATE
        //POST api/RouteDriver/AddRouteDriver
        [Route("AddRouteDriver")]
        public IHttpActionResult AddRouteDriver(RouteDriver routeDriver)
        {
            if (ModelState.IsValid)
            {                
                _unitOfWork.RouteDriverRepository.Repo.Add(routeDriver);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        #region RouteDriver GET
        //GET api/RouteDriver/GetRouteDriverByUserId/userId
        [Route("GetRouteDriverByUserId/{userId}")]
        public RouteDriver GetRouteDriverByUserId(Guid userId)
        {
            return _unitOfWork.RouteDriverRepository.GetRouteDriverByUserId(userId);
        }

        //GET api/RouteDriver/GetRouteDriverByRouteId/routeId
        [Route("GetRouteDriverByRouteId/{routeId}")]
        public RouteDriver GetRouteDriverByRouteId(int routeId)
        {
            return _unitOfWork.RouteDriverRepository.GetRouteDriverByRouteId(routeId);
        }

        //GET api/RouteDriver/GetRouteDriverByRouteNum/routeNum
        [Route("GetRouteDriverByRouteNum/{routeNum}")]
        public RouteDriver GetRouteDriverByRouteNum(int routeNum)
        {
            return _unitOfWork.RouteDriverRepository.GetRouteDriverByRouteNum(routeNum);
        }
        #endregion

        #region RouteDriver UPDATE
        //POST api/RouteDriver/UpdateRouteDriver
        [Route("UpdateRouteDriver")]
        public IHttpActionResult UpdateRouteDriver(RouteDriver routeDriver)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RouteDriverRepository.Repo.Update(routeDriver);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        //POST api/RouteDriver/GPSUpdate
        [Route("GPSUpdate")]
        public IHttpActionResult GPSUpdate(LocationUpdate locationUpdate)
        {
            if (ModelState.IsValid)
            {
                RouteDriver result = _unitOfWork.RouteDriverRepository.GetRouteDriverByMobileDeviceId(locationUpdate.MobileDeviceId);
                if (result != null) 
                {
                    result.Latitude = locationUpdate.Latitude;
                    result.Longitude = locationUpdate.Longitude;
                    _unitOfWork.RouteDriverRepository.Repo.Update(result);
                    _unitOfWork.SaveChanges();
                    return Ok();
                }
                
            }
            return BadRequest();
        }        
        #endregion
        
        #region RouteDriver DELETE
        //POST api/RouteDriver/DeleteRotueDriver
        [Route("DeleteRouteDriver")]
        public IHttpActionResult DeleteRouteDriver(RouteDriver routeDriver)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RouteDriverRepository.Repo.Remove(routeDriver);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }        
        #endregion
        #endregion
    }

}