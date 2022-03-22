using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dominio.Repositorio
{
    public class ServicioBL
    {

        private ServicioDAO objServicio = new ServicioDAO();

        //2.33
        public List<TCSERVICIO> ListarServicios(Session_Movi objSession, int intActivoFilter, string strfilter, int intTipoSerivicio, int intTipoMenu, int intClase, int intUso, ref string strMsjUsuario)
        {

            List<TCSERVICIO> lista = new List<TCSERVICIO>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objServicio.ListarServicios(objSession, intActivoFilter, strfilter, intTipoSerivicio, intTipoMenu, intClase, intUso, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarServicios] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ServicioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarServicios)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ServicioBL.cs: Exception");
                throw new Exception("Error General (ListarServicios)");
            }
            return lista;


        }
        //2.34
        public bool IUServicio(Session_Movi objSession, int intTipoOperacion, TCSERVICIO objDatos, ref string strMsjUsuario)
        {

            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                // using (TransactionScope scope = new TransactionScope())
                //{
                int idEmpresa = objServicio.IUServicio(objSession, objDatos, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario);

                //  scope.Complete();
                // }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUServicio] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                else
                {

                    tudobem = true;
                }


                return tudobem;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "ServicioBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IUServicio)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ServicioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUServicio)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ServicioBL.cs: Exception");
                throw new Exception("Error General (IUServicio)");
            }

        }
        //2.35
        public bool EliminarServicio(Session_Movi objSession, int intIdServicio, ref string strMsjUsuario)
        {

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objServicio.EliminarServicio(objSession, intIdServicio, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarServicio] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ServicioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarServicio)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ServicioBL.cs: Exception");
                throw new Exception("Error General (EliminarServicio)");
            }
        }
        //2.36
        public List<TCSERVICIO> ObtenerRegistrodeServicio(Session_Movi objSession, int intIdServicio, ref string strMsjUsuario)
        {

            List<TCSERVICIO> lista = new List<TCSERVICIO>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objServicio.ObtenerRegistrodeServicio(objSession, intIdServicio, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerRegistrodeServicio] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ServicioBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistrodeServicio)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ServicioBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistrodeServicio)");
            }
            return lista;
        }

    }
}
