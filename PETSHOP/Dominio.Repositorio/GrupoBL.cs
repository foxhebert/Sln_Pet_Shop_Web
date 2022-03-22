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
    public class GrupoBL
    {
        private GrupoDAO objDao = new GrupoDAO();

        public List<Grupo> ListarGrupos(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<Grupo> lista = new List<Grupo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarGrupos(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarGrupos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs");
                throw new Exception("Ocurrió un error en BD (ListarGrupos)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs");
                throw new Exception("Error General (ListarGrupos)");
            }
            return lista;
        }
        public bool InsertarGrupo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, Grupo objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                int idUnid = objDao.InsertarGrupo(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarGrupo] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "GrupoBL.cs");
            //    //4.60 Remover InsertarGrupo_IU01 y añadir InsertarGrupo HG 16.04.21
            //    throw new Exception("Ocurrió un error de Transacción ()");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: SqlException");
                //4.60 Remover InsertarGrupo_IU01 y añadir InsertarGrupo HG 16.04.21
                throw new Exception("Ocurrió un error en BD (InsertarGrupo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: Exception");
                //4.60 Remover InsertarGrupo_IU01 y añadir InsertarGrupo HG 16.04.21
                throw new Exception("Error General (InsertarGrupo)");
            }
        }

        public bool EliminmarGrup(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdGrupo, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool tudobem = false;
                tudobem = objDao.EliminmarGrup(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarGrup] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarGrup)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: Exception");
                throw new Exception("Error General (EliminmarGrup)");
            }
        }

        public List<Grupo> ObtenerValidacionesGrupo(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {

            List<Grupo> lista = new List<Grupo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerValidacionesGrupo(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerValidacionesGrupo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerValidacionesGrupo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: Exception");
                throw new Exception("Error General (ObtenerValidacionesGrupo)");
            }
            return lista;
        }

        public List<CamposAdicionales2> ListarCamposAdicionalesGrupo(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCamposAdicionalesGrupo(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCamposAdicionalesGrupo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCamposAdicionalesGrupo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: Exception");
                throw new Exception("Error General (ListarCamposAdicionalesGrupo)");
            }
            return lista;
        }

        public bool ActualizarGrupo(long intIdSesion, int intIdMenu, int intIdSoft, Grupo objDatos, int intIdUsuario, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                    tudobem = objDao.ActualizarGrupo(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarGrupo] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "GrupoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarGrupo)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarGrupo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: Exception");
                throw new Exception("Error General (ActualizarGrupo)");
            }
        }

        public List<Grupo> ConsultarDetalleGrupoxCod(long intIdSesion, int intIdMenu, int intIdSoft ,int intIdGrupo, ref string strMsjUsuario)
        {
            List<Grupo> lista = new List<Grupo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleGrupoxCod(intIdSesion, intIdMenu, intIdSoft, intIdGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleGrupoxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleGrupoxCod)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleGrupoxCod)");
            }
            return lista;
        }

    }
}
