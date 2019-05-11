using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Morais.Core.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("customers/")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        [HttpGet]
        [Route("customers/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [HttpPost]
        [Route("customers/")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut]
        [Route("customers/{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        [HttpDelete]
        [Route("customers/{id}")]
        public void Delete(int id)
        {
        }
    }
}
