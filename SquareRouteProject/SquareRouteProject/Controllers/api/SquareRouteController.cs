using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SquareRouteProject.Presentation.Models;
using SquareRouteProject.Infastructure;
using ApplicationUser = SquareRouteProject.Presentation.Identity.IdentityUser;
using SquareRouteProject.Domain.Repositories;

namespace SquareRouteProject.Presenation.Controllers.api
{
    public class SquareRouteController : ApiController
    {
        private static UnitOfWork _unitOfWork = new UnitOfWork("");
        public IUserRepository _db = _unitOfWork.UserRepository;

        public SquareRouteController() { }


    }
}