using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SL.Controllers
{
    public class VueloPasajeroController : ApiController
    {
        [HttpGet]
        [Route("api/VueloPasajero/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.VueloPasajero vueloPasajero = new ML.VueloPasajero();
            ML.Result result = BL.VueloPasajero.GetAll();

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
        [Route("api/VueloPasajero/Add")]
        public IHttpActionResult Add([FromBody] ML.VueloPasajero vueloPasajero)
        {
            ML.Result result = BL.VueloPasajero.Add(vueloPasajero);

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