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
    public class GlobalBL
    {
        private GlobalDAO objDao = new GlobalDAO();
        
        //5.31
        public List<CombosGlobal> ListarComboGeneral(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            List<CombosGlobal> lista = new List<CombosGlobal>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarComboGeneral(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
    
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarComboGeneral] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarComboGeneral)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: Exception");
                throw new Exception("Error General (ListarComboGeneral)");
            }
            return lista;
        }
        //5.32 - 6.7
        public List<CamposAdicionalesGlobal> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, string strNoEntidad, ref string strMsjUsuario)
        {
            List<CamposAdicionalesGlobal> lista = new List<CamposAdicionalesGlobal>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCamposAdicionales(intIdSesion, intIdMenu, intIdSoft, strNoEntidad, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCamposAdicionales] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCamposAdicionales)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: Exception");
                throw new Exception("Error General (ListarCamposAdicionales)");
            }
            return lista;
        }

        //5.74
        public List<MaestroCaracteres> MaestroMaxCaracteres(string strTableName)
        {

            List<MaestroCaracteres> lista = new List<MaestroCaracteres>();
            try
            {
                lista = objDao.MaestroMaxCaracteres(strTableName);
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarMaestroMaxCaracteres)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: Exception");
                throw new Exception("Error General (ListarMaestroMaxCaracteres)");
            }
            return lista;
        }


        #region Tipo 
        //1.13
        public List<TGTipo> ListarTGTipo(Session_Movi objSession, string strGrupo, string strSubGrupo, int IntIdTipo, ref string strMsjUsuario)
        {
            List<TGTipo> lista = new List<TGTipo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarTGTipo(objSession, strGrupo, strSubGrupo, IntIdTipo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTipoUM] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTGTipo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: Exception");
                throw new Exception("Error General (ListarTGTipo)");
            }
            return lista;
        }
        //1.14
        public bool IUTGTipo(Session_Movi objSession, int intTipoOperacion, TGTipo objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";
                int idOut = objDao.IUTGTipo(objSession, objDatos, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUTGTipo] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "GlobalBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IUTGTipo)");
            //}//Comentado Solicitado por ER 21.04.2021
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUTGTipo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: Exception");
                throw new Exception("Error General (IUTGTipo)");
            }

        }
        //1.15
        public bool EliminarTGTipo(Session_Movi objSession, int IntIdTipo, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminarTGTipo(objSession, IntIdTipo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarTipo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarTGTipo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GlobalBL.cs: Exception");
                throw new Exception("Error General (EliminarTGTipo)");
            }
        }

        #endregion Tipo
    }
}
