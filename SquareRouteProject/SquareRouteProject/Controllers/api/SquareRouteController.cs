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
using SquareRouteProject.Domain.Repositories;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;

namespace SquareRouteProject.Presenation.Controllers.api
{
    public class SquareRouteController : ApiController
    {
        private static UnitOfWork _unitOfWork;
        public IUserRepository _db;

        public SquareRouteController() : this("Data Source=(LocalDB)\\mssqllocaldb;Initial Catalog=SquareRouteProject;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False") { }

        public SquareRouteController(string connectionString) 
        {
            _unitOfWork = new UnitOfWork(connectionString);
            _db = _unitOfWork.UserRepository;
        }

        
        public IList<SquareRouteProject.Domain.Entities.User> Get()
        {
            var userId = User.Identity.GetUserId();
            var items = _db.FindByUserName("alexander.voltaire@gmail.com");
            return new List<SquareRouteProject.Domain.Entities.User> { items };
        }
    }
}