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
    public class RegNegComedorBL
    {
        private RegNegComedorDAO objRegNegCom = new RegNegComedorDAO();

        //2.37
        public List<ReglaNegocio> ListarRegNegCom(Session_Movi objSession, string strfilter, int intActivoFilter, ref string strMsjUsuario)
        {
            List<ReglaNegocio> lista = new List<ReglaNegocio>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objRegNegCom.ListarRegNegCom(objSession, strfilter, intActivoFilter, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //COMENTANDO
                        Log.AlmacenarLogMensaje("[ListarRegNegCom] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "RegNegComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarRegNegCom)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "RegNegComedorBL.cs: Exception");
                throw new Exception("Error General (ListarRegNegCom)");
            }
            return lista;
        }
        //2.38
        public bool IUNegocioCom_T(Session_Movi objSession, int intTipoOperacion, ReglaNegocio objDatos, List<TGREGNEG_DET> listaReglaNegDet, List<TGREGLANEG_SUBSIDIO_DET> listaDetSubsi, List<TGREGLANEG_SERV_DET> listaDetServ, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 1;
                string strMsjDB = "";
                string Msj = "";

                intResult = objRegNegCom.IUNegocioCom_T(objSession, intTipoOperacion, objDatos, listaReglaNegDet, listaDetSubsi, listaDetServ, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUNegocioCom_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[IUNegocioCom_T] => Respuesta de la clase de Datos: " + Msj);
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
            //    Log.AlmacenarLogError(ex, "ReglaNegocioComedorBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IUNegocioCom_T)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUNegocioCom_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioComedorBL.cs: Exception");
                throw new Exception("Error General (IUNegocioCom_T)");
            }
        }
        //2.39
        public bool EliminmarReglaNegocioCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objRegNegCom.EliminmarReglaNegocioCom(objSession, intIdReglaNeg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarReglaNegocioCom] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarReglaNegocioCom)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioComedorBL.cs: Exception");
                throw new Exception("Error General (EliminmarReglaNegocioCom)");
            }
        }
        //2.40
        public List<ReglaNegocio> ObtenerRegistroReglaNegocioCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario)
        {
            List<ReglaNegocio> lista = new List<ReglaNegocio>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objRegNegCom.ObtenerRegistroReglaNegocioCom(objSession, intIdReglaNeg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //COMENTANDO
                        Log.AlmacenarLogMensaje("[ObtenerRegistroReglaNegocioCom] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroReglaNegocioCom)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ReglaNegocioComedorBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroReglaNegocioCom)");
            }
            return lista;

        }
        //2.41
        public List<TGREGNEG_DET> ObtenerRegistroReglaNedocioDetCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario)
        {

            List<TGREGNEG_DET> lista = new List<TGREGNEG_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objRegNegCom.ObtenerRegistroReglaNedocioDetCom(objSession, intIdReglaNeg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //COMENTANDO
                        Log.AlmacenarLogMensaje("[ObtenerRegistroReglaNedocioDetCom] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "RegNegComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroReglaNedocioDetCom)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "RegNegComedorBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroReglaNedocioDetCom)");
            }
            return lista;

        }
        //2.42
        public List<TGREGLANEG_SUBSIDIO_DET> ObtenerRegistroReglaNedocioSubsiCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario)
        {

            List<TGREGLANEG_SUBSIDIO_DET> lista = new List<TGREGLANEG_SUBSIDIO_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objRegNegCom.ObtenerRegistroReglaNedocioSubsiCom(objSession, intIdReglaNeg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //COMENTANDO
                        Log.AlmacenarLogMensaje("[ObtenerRegistroReglaNedocioSubsiCom] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "RegNegComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroReglaNedocioSubsiCom)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "RegNegComedorBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroReglaNedocioSubsiCom)");
            }
            return lista;
        }
        //2.43
        public List<TGREGLANEG_SERV_DET> ObtenerRegistroReglaNedocioServCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario)
        {
            List<TGREGLANEG_SERV_DET> lista = new List<TGREGLANEG_SERV_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objRegNegCom.ObtenerRegistroReglaNedocioServCom(objSession, intIdReglaNeg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //COMENTANDO
                        Log.AlmacenarLogMensaje("[ObtenerRegistroReglaNedocioServCom] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "RegNegComedorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroReglaNedocioServCom)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "RegNegComedorBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroReglaNedocioServCom)");
            }
            return lista;
        }
    }
}
