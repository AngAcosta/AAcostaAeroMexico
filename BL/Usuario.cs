using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result UsuarioGetbyUserName(ML.Usuario usuario) //Ang 123
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaAeroMexicoEntities context = new DL.AAcostaAeroMexicoEntities())
                {
                    var query = context.UsuarioGetByUserName(usuario.UserName).AsEnumerable().FirstOrDefault();

                    if (query != null)
                    {
                        usuario = new ML.Usuario();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Password = query.Password;

                    }
                    result.Correct = true;
                    result.Message = "Atorice";
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.Message = ex.Message;
                result.Message = "No Atorice";
            }
            return result;
        }
    }
}
