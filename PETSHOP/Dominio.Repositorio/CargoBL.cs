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
    public class CargoBL
    {
        private CargoDAO objDao = new CargoDAO();
        //4.20
        public List<Cargo> ListarCargos(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCargos(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCargos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCargos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (ListarCargos)");
            }
            return lista;
        }
        
        
        //4.21
        public bool InsertarCargo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, Cargo objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";

                int idUnid = objDao.InsertarCargo(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarCargo] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "CargoBL.cs");
            //    //4.30 Cambiar InsertarCargo_IU01 por InsertarCargo HG 16.04.21
            //    throw new Exception("Ocurrió un error de Transacción (InsertarCargo)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                //4.30 Cambiar InsertarCargo_IU01 por InsertarCargo HG 16.04.21
                throw new Exception("Ocurrió un error en BD (InsertarCargo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                //4.30 Cambiar InsertarCargo_IU01 por InsertarCargo HG 16.04.21
                throw new Exception("Error General (InsertarCargo)");
            }
        }
        //4.22
        public bool ActualizarCargo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, Cargo objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";

                    tudobem = objDao.ActualizarCargo(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarCargo] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "CargoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarCargo)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarCargo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (ActualizarCargo)");
            }
        }
        //4.23
        public bool EliminmarCargo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCargo, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminmarCargo(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdCargo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarCargo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarCargo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (EliminmarCargo)");
            }
        }
        //4.24
        public List<Cargo> ListarCargosEditar(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCargosEditar(intIdSesion, intIdMenu, intIdSoft, strfilter, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCargosEditar] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCargosEditar)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (ListarCargosEditar)");
            }
            return lista;
        }
        //4.25
        public List<Cargo> ListarCargosxEstado(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCargosxEstado(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCargosxEstado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCargosxEstado)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (ListarCargosxEstado)");
            }
            return lista;
        }
        //4.26
        public List<Cargo> ListarCargosxDependencia(long intIdSesion, int intIdMenu, int intIdSoft, int intfiltrojer, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCargosxDependencia(intIdSesion, intIdMenu, intIdSoft, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCargosxDependencia] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCargosxDependencia)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (ListarCargosxDependencia)");
            }
            return lista;
        }
        //4.27
        public List<Cargo> ListarCargosxDescripcion(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCargosxDescripcion(intIdSesion, intIdMenu, intIdSoft, strfilter, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCargosxDescripcion] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCargosxDescripcion)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (ListarCargosxDescripcion)");
            }
            return lista;
        }
        //4.28
        public List<CamposAdicionales2> ListarCamposAdicionalesCargos(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<CamposAdicionales2> lista = new List<CamposAdicionales2>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCamposAdicionalesCargos(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {   //4.29 Cambiar ListarCargosxDescripcion por ListarCamposAdicionalesCargo HG 16.04.21
                        Log.AlmacenarLogMensaje("[ListarCamposAdicionalesCargo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCamposAdicionalesCargos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (ListarCamposAdicionalesCargos)");
            }
            return lista;
        }
        //4.29
        public List<Cargo> ObtenerValidaciones(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerValidaciones(intIdSesion, intIdMenu, intIdSoft, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerValidaciones] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerValidaciones)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (ObtenerValidaciones)");
            }
            return lista;
        }
        //4.30
        public List<Cargo> ConsultarDetalleCargoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdCargo,ref string strMsjUsuario)
        {
            List<Cargo> lista = new List<Cargo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleCargoxCod(intIdSesion, intIdMenu, intIdSoft, intIdCargo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleCargoxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleCargoxCod)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleCargoxCod)");
            }
            return lista;
        }
        //4.31
        public List<UnidadOrg> ListarCampoUnidOrga(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJerOrg, ref string strMsjUsuario)
        {
            List<UnidadOrg> lista = new List<UnidadOrg>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCampoUnidOrga(intIdSesion, intIdMenu, intIdSoft, intIdJerOrg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCampoUnidOrga] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCampoUnidOrga)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (ListarCampoUnidOrga)");
            }
            return lista;
        }
        //4.32
        public List<UnidadOrg> ObtenerIDjer(long intIdSesion, int intIdMenu, int intIdSoft, int intidCargo, ref string strMsjUsuario)
        {
            List<UnidadOrg> lista = new List<UnidadOrg>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerIDjer(intIdSesion, intIdMenu, intIdSoft, intidCargo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerIDjer] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerIDjer)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CargoBL.cs: Exception");
                throw new Exception("Error General (ObtenerIDjer)");
            }
            return lista;
        }

    }

}
