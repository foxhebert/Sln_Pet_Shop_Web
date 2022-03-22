using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public class GrupoLiquidacionBL
    {
        private GrupoLiquidacionDAO objDao = new GrupoLiquidacionDAO();
        //6.8
        public List<GrupoLiquidacionData> ListGrupoLiquidacion(Session_Movi session, int filtroUniOrg, int filtroPlanilla, string filtroGrupoLiquidacion, int filtroActivo, int filtroPeriodo, ref string strMsjUsuario)
        {
            List<GrupoLiquidacionData> lista = new List<GrupoLiquidacionData>();

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListGrupoLiquidacion(session, filtroUniOrg, filtroPlanilla, filtroGrupoLiquidacion, filtroActivo, filtroPeriodo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListGrupoLiquidacion] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoLiquidacionBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListGrupoLiquidacion)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoLiquidacionBL.cs: Exception");
                throw new Exception("Error General (ListGrupoLiquidacion)");
            }
            return lista;
        }
        //6.9
        public bool EliminarGrupoLiquidacion(Session_Movi session, int intIdGrupoLiquidacion, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool estado = false;

                estado = objDao.EliminarGrupoLiquidacion(session, intIdGrupoLiquidacion, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarGrupoLiquidacion] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return estado;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoLiquidacionBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarGrupoLiquidacion)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoLiquidacionBL.cs: Exception");
                throw new Exception("Error General (EliminarGrupoLiquidacion)");
            }
        }
        //6.10
        public GrupoLiquidacion ObtenerGrupoLiquidacionPorsuPK(Session_Movi session, int intIdGrupoLiquidacion, ref string strMsjUsuario)
        {
            GrupoLiquidacion obj = new GrupoLiquidacion();
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                //bool estado = false;

                obj = objDao.ObtenerGrupoLiquidacionPorsuPK(session, intIdGrupoLiquidacion, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerGrupoLiquidacionPorsuPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoLiquidacionBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerGrupoLiquidacionPorsuPK)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoLiquidacionBL.cs: Exception");
                throw new Exception("Error General (ObtenerGrupoLiquidacionPorsuPK)");
            }
            return obj;
        }
        //6.11
        public int IUGrupoLiquidacion(Session_Movi session, GrupoLiquidacion grupoLiquidacion, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int codID = 0;

            try
            {
                codID = objDao.IUGrupoLiquidacion(session, grupoLiquidacion, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUGrupoLiquidacion] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoLiquidacionBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUGrupoLiquidacion)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoLiquidacionBL.cs: Exception");
                throw new Exception("Error General (IUGrupoLiquidacion)");
            }
            return codID;
        }

    }
}
