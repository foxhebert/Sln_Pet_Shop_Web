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
    public class TipoPersonBL
    {
        private TipoPersonDAO objDao = new TipoPersonDAO();
        public List<TipoPerson> ListarTipoPerson(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<TipoPerson> lista = new List<TipoPerson>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarTipoPerson(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //4.42 Cambiar ListarCargos por ListarTipoPerson HG 16.04.21
                        Log.AlmacenarLogMensaje("[ListarTipoPerson] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTipoPerson)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: Exception");
                throw new Exception("Error General (ListarTipoPerson)");
            }
            return lista;
        }
        public bool InsertarTipoPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, TipoPerson objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";

                int idUnid = objDao.InsertarTipoPersonal(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarTipoPersonal] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "TipoPersonBL.cs");
            //    //4.43 Cambiar InsertarTipoPerson_IU01 por InsertarTipoPersonal HG 16.04.21
            //    throw new Exception("Ocurrió un error de Transacción (InsertarTipoPersonal)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: SqlException");
                //4.43 Cambiar InsertarTipoPerson_IU01 por InsertarTipoPersonal HG 16.04.21
                throw new Exception("Ocurrió un error en BD (InsertarTipoPersonal)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: Exception");
                //4.43 Cambiar InsertarTipoPerson_IU01 por InsertarTipoPersonal HG 16.04.21
                throw new Exception("Error General (InsertarTipoPersonal)");
            }
        }
        public bool EliminmarTipo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdTipo, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminmarTipo(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdTipo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarTipo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarTipo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: Exception");
                throw new Exception("Error General (EliminmarTipo)");
            }
        }
        public List<CamposAdicionales2> ListarCamposAdicionalesTipoPerson(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCamposAdicionalesTipoPerson(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCamposAdicionalesTipoPerson] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCamposAdicionalesTipoPerson)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: Exception");
                throw new Exception("Error General (ListarCamposAdicionalesTipoPerson)");
            }
            return lista;
        }
        public List<TipoPerson> ObtenerValidacionesTipoPerson(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<TipoPerson> lista = new List<TipoPerson>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerValidacionesTipoPerson(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerValidacionesTipoPerson] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerValidacionesTipoPerson)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: Exception");
                throw new Exception("Error General (ObtenerValidacionesTipoPerson)");
            }
            return lista;
        }
        public bool ActualizarTipoPersonal(long intIdSesion, int intIdMenu, int intIdSoft, TipoPerson objDatos, int intIdUsuario, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                //using (TransactionScope scope = new TransactionScope())
                //{
                    tudobem = objDao.ActualizarTipoPersonal(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                 //   scope.Complete();
              //  }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarTipoPersonal] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "TipoPersonBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarTipoPersonal)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarTipoPersonal)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: Exception");
                throw new Exception("Error General (ActualizarTipoPersonal)");
            }
        }
        public List<TipoPerson> ConsultarDetalleTipoPerxCod(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdTiPers, ref string strMsjUsuario)
        {
            List<TipoPerson> lista = new List<TipoPerson>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleTipoPerxCod(intIdSesion, intIdMenu, intIdSoft, IntIdTiPers, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleTipoPerxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleTipoPerxCod)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleTipoPerxCod)");
            }
            return lista;
        }

    }
    
}
