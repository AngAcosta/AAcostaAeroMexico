using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SL.Controllers
{
    public class PasajeroController : ApiController
    {
        [HttpGet]
        [Route("api/Pasajero/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Pasajero pasajero = new ML.Pasajero();
            ML.Result result = BL.Pasajero.GetAll();

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
        [Route("api/Pasajero/Add")]
        public IHttpActionResult Add([FromBody] ML.Pasajero pasajero)
        {
            ML.Result result = BL.Pasajero.Add(pasajero);

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