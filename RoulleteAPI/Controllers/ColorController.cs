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
    public class ColorController : ApiController
    {
        public string Get()
        {
            Random rnd = new Random();
            if (rnd.Next(2) == 1) return "r";
            return "b";
        }
    }
}
