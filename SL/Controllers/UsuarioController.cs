using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SL.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("api/Usuario/UsuarioGetbyUserName")]
        public IHttpActionResult UsuarioGetbyUserName([FromBody] ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.UsuarioGetbyUserName(usuario);

            if (result.Correct)
            {
                return Ok("Autorice");
            }
            else
            {
                return NotFound();
            }
        }
    }
}