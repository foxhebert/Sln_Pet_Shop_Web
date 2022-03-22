using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dominio.Repositorio
{
    public class CCostoBL
    {

        private CCostoDAO objDao = new CCostoDAO();

        public List<CCosto> ListarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<CCosto> lista = new List<CCosto>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCCosto(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCCosto] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCCosto)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                throw new Exception("Error General (ListarCCosto)");
            }
            return lista;
        }


        public List<TGTipoEN> ListarCampoTipoCCosto(long intIdSesion, int intIdMenu, int intIdSoft,ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampoTipoCCosto(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampoTipoCCosto] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCampoTipoCCosto)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                throw new Exception("Error General (ListarCampoTipoCCosto)");
            }
            return lista;
        }

        public bool InsertarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, CCosto objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                int idUnid = objDao.InsertarCCosto(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarCCosto] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "CCostoBL.cs");
            //    //4.76 Corregir InsertarCCosto_IU01 HG 16.04.21
            //    throw new Exception("Ocurrió un error de Transacción (InsertarCCosto)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                //4.76 Corregir InsertarCCosto_IU01 HG 16.04.21
                throw new Exception("Ocurrió un error en BD (InsertarCCosto)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                //4.76 Corregir InsertarCCosto_IU01 HG 16.04.21
                throw new Exception("Error General (InsertarCCosto)");
            }
        }


        public bool ActualizarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, CCosto objDatos, int intIdUsuario, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                    tudobem = objDao.ActualizarCCosto(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarCCosto] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "CCostoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarCCosto)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarCCosto)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                throw new Exception("Error General (ActualizarCCosto)");
            }
        }

        public List<CCosto> ObtenerValidacionesCCosto(long intIdSesion, int intIdMenu, int intIdSoft,  ref string strMsjUsuario)
        {

            List<CCosto> lista = new List<CCosto>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerValidacionesCCosto(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerValidacionesCCosto] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerValidacionesCCosto)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                throw new Exception("Error General (ObtenerValidacionesCCosto)");
            }
            return lista;
        }

        public List<CamposAdicionales2> ListarCamposAdicionalesCCosto(long intIdSesion, int intIdMenu, int intIdSoft,ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCamposAdicionalesCCosto(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCamposAdicionalesCCosto] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCamposAdicionalesCCosto)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                throw new Exception("Error General (ListarCamposAdicionalesCCosto)");
            }
            return lista;
        }

        public bool EliminmarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IntIdCCosto, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminmarCCosto(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, IntIdCCosto, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarCCosto] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarCCosto)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                throw new Exception("Error General (EliminmarCCosto)");
            }
        }


        public List<CCosto> ConsultarDetalleCCostoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdCCosto,ref string strMsjUsuario)
        {
            List<CCosto> lista = new List<CCosto>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleCCostoxCod(intIdSesion, intIdMenu, intIdSoft, IntIdCCosto, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleCCostoxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleCCostoxCod)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleCCostoxCod)");
            }
            return lista;
        }

        }

}

