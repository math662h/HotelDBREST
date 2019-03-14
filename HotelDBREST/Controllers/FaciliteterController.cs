using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HotelDBREST.DBUtil;
using ModelLib.model;

namespace HotelDBREST.Controllers
{
    public class FaciliteterController : ApiController
    {
        private static IManage<Faciliteter> manager = new ManageFaciliteter();

        // GET: api/Faciliteter
        public IEnumerable<Faciliteter> Get()
        {
            return manager.Get();
        }

        // GET: api/Faciliteter/5
        public Faciliteter Get(int id)
        {
            return manager.Get(id);
        }

        // POST: api/Faciliteter
        public bool Post([FromBody]Faciliteter facilitet)
        {
            return manager.Post(facilitet);
        }

        // PUT: api/Faciliteter/5
        public bool Put(int id, [FromBody]Faciliteter facilitet)
        {
            return manager.Put(id, facilitet);
        }

        // DELETE: api/Faciliteter/5
        public bool Delete(int id)
        {
            return manager.Delete(id);
        }
    }
}