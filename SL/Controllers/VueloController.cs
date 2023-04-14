using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SL.Controllers
{
    public class VueloController : ApiController
    {
        [HttpGet]
        [Route("api/Vuelo/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Vuelo vuelo = new ML.Vuelo();
            ML.Result result = BL.Vuelo.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/Vuelo/Add")]
        public IHttpActionResult Add([FromBody] ML.Vuelo vuelo)
        {
            ML.Result result = BL.Vuelo.Add(vuelo);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}