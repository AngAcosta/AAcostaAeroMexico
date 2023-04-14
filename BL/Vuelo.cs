using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Vuelo
    {
        public static ML.Result Add(ML.Vuelo vuelo)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaAeroMexicoEntities context = new DL.AAcostaAeroMexicoEntities())
                {
                    int query = context.VueloAdd(vuelo.FechaInicio.ToString(),vuelo.NumeroDeVuelo,vuelo.Origen,vuelo.Destino,vuelo.FechaDeSalida.ToString(), vuelo.FechaFin.ToString());

                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Message = "Se Inserto el Vuelo";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Inserto el Vuelo";
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
                    var query = context.VueloGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Vuelo vuelo = new ML.Vuelo();

                            vuelo.IdViaje = obj.IdViaje;
                            vuelo.FechaInicio = obj.FechaInicio.ToString();
                            vuelo.NumeroDeVuelo = obj.NumeroDeVuelo;
                            vuelo.Origen = obj.Origen;
                            vuelo.Destino = obj.Destino;
                            vuelo.FechaDeSalida = obj.FechaDeSalida.ToString();
                            vuelo.FechaFin = obj.FechaFin.ToString();

                            result.Objects.Add(vuelo);
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