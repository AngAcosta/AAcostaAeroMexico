using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class VueloPasajero
    {
        public static ML.Result Add(ML.VueloPasajero vueloPasajero)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaAeroMexicoEntities context = new DL.AAcostaAeroMexicoEntities())
                {
                    int query = context.ViajePasajeroAdd(vueloPasajero.Vuelo.IdViaje, vueloPasajero.Pasajero.IdPasajero);

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
                    var query = context.ViajePasajeroGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.VueloPasajero vueloPasajero = new ML.VueloPasajero();

                            vueloPasajero.IdVueloPasajero = obj.IdViajePasajero;

                            vueloPasajero.Vuelo = new ML.Vuelo();
                            vueloPasajero.Vuelo.IdViaje = obj.IdViaje.Value;
                            vueloPasajero.Vuelo.FechaInicio = obj.FechaInicio.ToString();
                            vueloPasajero.Vuelo.NumeroDeVuelo = obj.NumeroDeVuelo;
                            vueloPasajero.Vuelo.Origen = obj.Origen;
                            vueloPasajero.Vuelo.Destino = obj.Destino;
                            vueloPasajero.Vuelo.FechaDeSalida = obj.FechaDeSalida.ToString();
                            vueloPasajero.Vuelo.FechaFin = obj.FechaFin.ToString();

                            vueloPasajero.Pasajero = new ML.Pasajero();
                            vueloPasajero.Pasajero.IdPasajero = obj.IdPasajero.Value;
                            vueloPasajero.Pasajero.Nombre = obj.Nombre;
                            vueloPasajero.Pasajero.Apellidos = obj.Apellidos;

                            result.Objects.Add(vueloPasajero);
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