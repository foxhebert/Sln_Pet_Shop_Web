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
    public class JerarquiaOrgBL
    {
        private JerarquiaOrgDAO objDao = new JerarquiaOrgDAO();
      
        #region Mant. Jerarquía Organizacional
        //1.1
        public List<JerarquiaOrg> ListarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, int intActivoFilter, ref string strMsjUsuario)
        {
            List<JerarquiaOrg> lista = new List<JerarquiaOrg>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarJerarquiaOrg(intIdSesion, intIdMenu, intIdSoft, strfilter, intActivoFilter,  ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarJerarquiaOrg] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarJerarquiaOrg)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: Exception");
                throw new Exception("Error General (ListarJerarquiaOrg)");
            }
            return lista;
        }
        //1.2
        public List<JerarquiaOrg> ListarJerarquíaSuperior_xNivel(long intIdSesion, int intIdMenu, int intIdSoft, int intNivelJer, ref string strMsjUsuario)
        {
            List<JerarquiaOrg> lista = new List<JerarquiaOrg>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarJerarquíaSuperior_xNivel(intIdSesion, intIdMenu, intIdSoft, intNivelJer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarJerarquíaSuperior_xNivel] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarJerarquíaSuperior_xNivel)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: Exception");
                throw new Exception("Error General (ListarJerarquíaSuperior_xNivel)");
            }
            return lista;
        }
        //1.3
        public List<int> ListarNivelJerarquico(long intIdSesion, int intIdMenu, int intIdSoft,ref string strMsjUsuario)
        {
            List<int> lista = new List<int>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarNivelJerarquico(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarNivelJerarquico] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarNivelJerarquico)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: Exception");
                throw new Exception("Error General (ListarNivelJerarquico)");
            }
            return lista;
        }
        //1.4
        public JerarquiaOrg ConsultarJerarquiaOrg_xId(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdJerOrg, ref string strMsjUsuario)
        {
            try
            {
                JerarquiaOrg obj = null;
                int intResult = 0;
                string strMsjDB = "";

                obj = objDao.ConsultarJerarquiaOrg(intIdSesion, intIdMenu, intIdSoft, IntIdJerOrg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarJerarquiaOrg_xId] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }
                return obj;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarJerarquiaOrg_xId)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: Exception");
                throw new Exception("Error General (ConsultarJerarquiaOrg_xId)");
            }

        }
        //1.5
        public int GetNumJeraquia(ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                intResult = objDao.GetNumJeraquia(ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GetNumJeraquia] => Respuesta del Procedimiento : " + strMsjDB);
                    }
                }
                return intResult;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GetNumJeraquia)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: Exception");
                throw new Exception("Error General (GetNumJeraquia)");
            }
        }
        //1.6
        public List<DetalleJerarquiaOrg> ConsultarDetalleJerarquia_xCod(long intIdSesion, int intIdMenu, int intIdSoft, string strCoIntJO, ref string strMsjUsuario)
        {
            List<DetalleJerarquiaOrg> lista = new List<DetalleJerarquiaOrg>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleJerarquia_xCod(intIdSesion, intIdMenu, intIdSoft, strCoIntJO, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleJerarquia_xCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleJerarquia_xCod)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleJerarquia_xCod)");
            }
            return lista;
        }
        //1.7
        public bool IUJerarquiaOrg_T(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, JerarquiaOrg objDatos, List<DetalleJerarquiaOrg> detalle, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string strCoIntJO = "";
                string Msj = "";
                intResult = objDao.IUJerarquiaOrg_T(intIdSesion, intIdMenu, intIdSoft, objDatos, detalle, intIdUsuario, intTipoOperacion, ref strCoIntJO, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //1.7 Se cambió el método ListarJerarquiaOrg HG 14.04.21
                        Log.AlmacenarLogMensaje("[IUJerarquiaOrg_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[IUJerarquiaOrg_T] => Respuesta de la clase de Datos: " + Msj);
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
            //    Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IUJerarquiaOrg_T)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUJerarquiaOrg_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: Exception");
                throw new Exception("Error General (IUJerarquiaOrg_T)");
            }
        }
        //1.8
        public bool EliminarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IntIdJerOrg, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool tudobem = false;
                tudobem = objDao.EliminarJerarquiaOrg(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, IntIdJerOrg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //1.9 Se cambió el método ListarJerarquiaOrg HG 14.04.21
                        Log.AlmacenarLogMensaje("[EliminarJerarquiaOrg] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarJerarquiaOrg)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "JerarquiaOrgBL.cs: Exception");
                throw new Exception("Error General (EliminarJerarquiaOrg)");
            }
        }

        #endregion Mant. Jerarquía Organizacional

    }
}
