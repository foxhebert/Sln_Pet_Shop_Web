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
    public class CategoriaBL
    {
        private CategoriaDAO objDao = new CategoriaDAO();
        public List<Categoria> ListarCategorias(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCategorias(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        //4.36 Cambiar ListarCargos por ListarCategorias HG 16.04.21
                        Log.AlmacenarLogMensaje("[ListarCategorias] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs");
                throw new Exception("Ocurrió un error en BD (ListarCategorias)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs");
                throw new Exception("Error General (ListarCategorias)");
            }
            return lista;
        }
        public bool InsertarCategoria(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, Categoria objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                int idUnid = objDao.InsertarCategoria(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarCategoria] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "CategoriaBL.cs");
            //    //4.35 Cambiar InsertarCategoria_IU01 por InsertarCategoria HG 16.04.21
            //    throw new Exception("Ocurrió un error de Transacción (InsertarCategoria)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: SqlException");
                //4.35 Cambiar InsertarCategoria_IU01 por InsertarCategoria HG 16.04.21
                throw new Exception("Ocurrió un error en BD (InsertarCategoria)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: Exception");
                //4.35 Cambiar InsertarCategoria_IU01 por InsertarCategoria HG 16.04.21
                throw new Exception("Error General (InsertarCategoria)");
            }
        }
        public bool EliminmarCategoria(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCategoria, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminmarCategoria(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdCategoria, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarCategoria] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarCategoria)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: Exception");
                throw new Exception("Error General (EliminmarCategoria)");
            }
        }
        public List<Categoria> ObtenerValidacionesCategoria(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerValidacionesCategoria(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerValidacionesCategoria] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerValidacionesCategoria)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: Exception");
                throw new Exception("Error General (ObtenerValidacionesCategoria)");
            }
            return lista;
        }
        public bool ActualizarCategoria(long intIdSesion, int intIdMenu, int intIdSoft, Categoria objDatos, int intIdUsuario, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                    tudobem = objDao.ActualizarCategoria(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarCategoria] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "CategoriaBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarCategoria)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarCategoria)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: Exception");
                throw new Exception("Error General (ActualizarCategoria)");
            }
        }
        public List<CamposAdicionales2> ListarCamposAdicionalesCategorias(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCamposAdicionalesCategorias(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCamposAdicionalesCategorias] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCamposAdicionalesCategorias)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: Exception");
                throw new Exception("Error General (ListarCamposAdicionalesCategorias)");
            }
            return lista;
        }
        public List<Categoria> ConsultarDetalleCategoriaxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdCateg, ref string strMsjUsuario)
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleCategoriaxCod(intIdSesion, intIdMenu, intIdSoft, intIdCateg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleCategoriaxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleCategoriaxCod)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleCategoriaxCod)");
            }
            return lista;
        }
    }
}
