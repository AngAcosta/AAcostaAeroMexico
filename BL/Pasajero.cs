using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pasajero
    {
        public static ML.Result Add(ML.Pasajero pasajero)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaAeroMexicoEntities context = new DL.AAcostaAeroMexicoEntities())
                {
                    int query = context.PasajeroAdd(pasajero.Nombre, pasajero.Apellidos);

                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Message = "Se Inserto el Pasajero";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Inserto el Pasajero";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaAeroMexicoEntities context = new DL.AAcostaAeroMexicoEntities())
                {
                    var query = context.PasajeroGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Pasajero pasajero = new ML.Pasajero();

                            pasajero.IdPasajero = obj.IdPasajero;
                            pasajero.Nombre = obj.Nombre;
                            pasajero.Apellidos = obj.Apellidos;

                            result.Objects.Add(pasajero);
                        }
                    }
                    result.Correct = true;
                }
                //result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;

            }
            return result;
        }
    }
}