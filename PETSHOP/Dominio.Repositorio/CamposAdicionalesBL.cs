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
    public class CamposAdicionalesBL
    {
        private CampoAdicionalesDAO objDao = new CampoAdicionalesDAO();
        //1.11
        public List<CamposAdicionales> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, ref string strMsjUsuario)
        {
            try
            {
                List<CamposAdicionales> lista = new List<CamposAdicionales>();
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCamposAdicionales(intIdSesion, intIdMenu, intIdSoft, intActivo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCamposAdicionales] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return lista;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CamposAdicionalesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCamposAdicionales_Q02)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CamposAdicionalesBL.cs: Exception");
                throw new Exception("Error General (ListarCamposAdicionales_Q02)");
            }
        }
        //1.12
        public List<Entidade> ListaraEntidades(long intIdSesion, int intIdMenu, int intIdSoft,  ref string strMsjUsuario)

        {
            try
            {
                List<Entidade> lista = new List<Entidade>();
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListaraEntidades( intIdSesion,  intIdMenu,  intIdSoft, ref intResult, ref strMsjDB, ref  strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListaraEntidades] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return lista;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CamposAdicionalesBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListaraEntidades)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CamposAdicionalesBL.cs: Exception");
                throw new Exception("Error General (ListaraEntidades)");
            }

        }
    }
}
