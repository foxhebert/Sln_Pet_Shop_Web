using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.SqlServer
{
    public class ServicioDAO : Conexion
    {
        //2.33
        public List<TCSERVICIO> ListarServicios(Session_Movi objSession, int intActivoFilter, string strfilter, int intTipoSerivicio, int intTipoMenu, int intClase, int intUso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TCSERVICIO> lista = new List<TCSERVICIO>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TCSERVICIO_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intActivo", intActivoFilter);
                param.Add("@strFiltro", strfilter);
                param.Add("@intTipoSerivicio", intTipoSerivicio);
                param.Add("@intTipoMenu", intTipoMenu);
                param.Add("@intClase", intClase);//añadido 18.03.2021
                param.Add("@intUso", intUso);//añadido 18.03.2021
                                             //salida
                                             //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TCSERVICIO obj = new TCSERVICIO();

                    obj.intIdServicio = reader.GetInt32(0);
                    obj.strCoServicio = reader.GetString(1);
                    obj.strDesServicio = reader.GetString(2);
                    obj.strDesTipServicio = reader.GetString(3);
                    obj.strDesTipMenu = reader.GetString(4);
                    obj.strDesEstado = reader.GetString(5);
                    obj.strDesClase = reader.GetString(6);//añadido 18.03.2021

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //2.34
        public int IUServicio(Session_Movi objSession, TCSERVICIO objDatos, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int intIdServicioOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TCSERVICIO_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);//parametros de entrada

                param.Add("@strCoServicio", objDatos.strCoServicio);
                param.Add("@strDesServicio", objDatos.strDesServicio);
                param.Add("@strCoExporta", objDatos.strCoExporta);
                param.Add("@IntIdUniOrg", objDatos.intIdUniOrg);
                param.Add("@IntIdTipServ", objDatos.intIdTipServ);
                param.Add("@IntIdTipoMenu", objDatos.intIdTipoMenu);
                param.Add("@monCostoServ", objDatos.monCostoServ);
                param.Add("@intIdMoneda", objDatos.intIdMoneda);



                if (objDatos.strServicioCampo1 == null)
                    param.Add("@strServicioCampo1", DBNull.Value);
                else
                    param.Add("@strServicioCampo1", objDatos.strServicioCampo1);


                if (objDatos.strServicioCampo2 == null)
                    param.Add("@strServicioCampo2", DBNull.Value);
                else
                    param.Add("@strServicioCampo2", objDatos.strServicioCampo2);


                if (objDatos.strServicioCampo3 == null)
                    param.Add("@strServicioCampo3", DBNull.Value);
                else
                    param.Add("@strServicioCampo3", objDatos.strServicioCampo3);


                if (objDatos.strServicioCampo4 == null)
                    param.Add("@strServicioCampo4", DBNull.Value);
                else
                    param.Add("@strServicioCampo4", objDatos.strServicioCampo4);


                if (objDatos.strServicioCampo5 == null)
                    param.Add("@strServicioCampo5", DBNull.Value);
                else
                    param.Add("@strServicioCampo5", objDatos.strServicioCampo5);

                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@intClase", objDatos.intClase); //añadido 18.03.2021
                param.Add("@intCategSC", objDatos.intCategSC); //añadido 20.03.2021

                param.Add("@intIdUsuario", objSession.intIdUsuario);
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                param.Add("@intIdServicio", objDatos.intIdServicio);

                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdServicioOut = Convert.ToInt32(cmd.Parameters["@intIdServicio"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdServicioOut;
        }
        //2.35
        public bool EliminarServicio(Session_Movi objSession, int intIdServicio, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TCSERVICIO_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                param.Add("@intIdServicio", intIdServicio);
                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                exito = Transaction(cn, cmd);

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return exito;


        }
        //2.36
        public List<TCSERVICIO> ObtenerRegistrodeServicio(Session_Movi objSession, int intIdServicio, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            List<TCSERVICIO> listDetCar = new List<TCSERVICIO>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TCSERVICIO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdServicio", intIdServicio);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        TCSERVICIO obj = new TCSERVICIO();
                        obj.intIdServicio = reader.GetInt32(0);
                        obj.strCoServicio = reader.GetString(1);
                        obj.strDesServicio = reader.GetString(2);
                        obj.intIdUniOrg = reader.GetInt32(3);
                        obj.strCoExporta = reader.GetString(4);
                        obj.intIdTipServ = reader.GetInt32(5);
                        obj.intIdTipoMenu = reader.GetInt32(6);
                        obj.intIdMoneda = reader.GetInt32(7);
                        obj.monCostoServ = reader.GetDecimal(8);
                        obj.bitFlActivo = reader.GetBoolean(9);
                        obj.intIdJerOrg = reader.GetInt32(10);
                        obj.intClase = reader.GetInt32(11);//añadido 18.03.2021
                        obj.intCategSC = reader.GetInt32(12);//añadido 20.03.2021

                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;

        }

    }
}
