using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RoulleteAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NumberController : ApiController
    {
        public int Get()
        {
            Random rnd = new Random();
            return rnd.Next(37);
        }
    }
}
