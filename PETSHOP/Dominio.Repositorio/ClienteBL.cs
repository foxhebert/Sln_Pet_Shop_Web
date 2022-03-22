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
    public class ClienteBL
    {

        private ClienteDAO objDao = new ClienteDAO();

        public List<Cliente> ListarClientes(long intIdSesion, int intIdMenu, int intIdSoft, int intEstado, string strBusqueda, int intCentroAlm, ref string strMsjUsuario)
        {

            List<Cliente> lista = new List<Cliente>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarClientes(intIdSesion, intIdMenu, intIdSoft, intEstado, strBusqueda, intCentroAlm, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarClientes] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Ocurrió un error en BD (ListarClientes)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Error General (ListarClientes)");
            }
            return lista;
        }

        public bool InsertarOrUpdateCliente(long intIdSesion, int intIdMenu, int intIdSoft, Cliente objDatos, int intIdUsuario, int intIdUsuarModif, int intTipoOperacion, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                // using (TransactionScope scope = new TransactionScope())
                //{
                int idCliente = objDao.InsertarOrUpdateCliente(intIdSesion, intIdMenu, intIdSoft, objDatos, intIdUsuario, intIdUsuarModif, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario);
                //  scope.Complete();
                // }
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarCliente] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "ClienteBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (InsertarCliente)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Ocurrió un error en BD (InsertarCliente)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Error General (InsertarCliente)");
            }
        }

        public bool EliminarCliente(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCliente, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminarCliente(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdCliente, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarCliente] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Ocurrió un error en BD (EliminarCliente)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Error General (EliminarCliente)");
            }
        }

        public List<Cliente> ListarClientesPorId(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCliente, ref string strMsjUsuario)
        {

            List<Cliente> lista = new List<Cliente>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarClientesPorId(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdCliente, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarClientesPorId] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Ocurrió un error en BD (ListarClientesPorId)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Error General (ListarClientesPorId)");
            }
            return lista;
        }

        public List<MaestroCaracteres> MaestroMaxCaracteres(string strTableName)
        {

            List<MaestroCaracteres> lista = new List<MaestroCaracteres>();
            try
            {

                lista = objDao.MaestroMaxCaracteres(strTableName);
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Ocurrió un error en BD (ListarMaestroMaxCaracteres)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Error General (ListarMaestroMaxCaracteres)");
            }
            return lista;
        }

        public List<Cliente> ListarComboCliente(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarComboCliente(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCombosClientes] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Ocurrió un error en BD (ListarCombosClientes)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ClienteBL.cs");
                throw new Exception("Error General (ListarCombosClientes)");
            }
            return lista;
        }

    }
}
