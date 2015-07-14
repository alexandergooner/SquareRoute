using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SquareRouteProject.Infastructure.Repositories;
namespace SquareRouteProject.Presentation.Controllers.api
{
    public class GalleryController : ApiController
    {

        //private ImageDbContext imgdb = new ImageDbContext();


        public GalleryController(){


        
    }

        // GET: api/Gallery
        public IQueryable <string> GetImages ()
        {
            return imgbd.Images;
        }

        // GET: api/Gallery/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Gallery
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Gallery/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Gallery/5
        public void Delete(int id)
        {
        }
    }
}
