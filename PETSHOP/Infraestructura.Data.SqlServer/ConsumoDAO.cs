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
    public class ConsumoDAO : Conexion    {


        #region TOMA_DE_CONSUMO

        //5.75
        public List<Consumo> ObtenerRegistroConsumo(Session_Movi objSession, int IntIdAsistencia, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Consumo> listaConsumo = new List<Consumo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_CONSUMO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdAsistencia", IntIdAsistencia);

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Consumo obj = new Consumo();

                        obj.intIdAsistencia = reader.GetInt32(0);
                        obj.intIdPersonal = reader.GetInt32(1);
                        obj.strFotocheck = reader.GetString(2);
                        obj.strNombresCompletos = reader.GetString(3);
                        obj.dttFecha = reader.GetString(4);
                        obj.dttFechaHora = reader.GetString(5);
                        obj.imgFoto = reader.GetString(6);

                        //AÑADIDO 10.03.21
                        obj.strTipoServicio = reader.GetString(7);
                        obj.intTipoPeriodoConsumo = reader.GetInt32(8);
                        obj.intCantMaxConsumo = reader.GetInt32(9);
                        obj.bitMarcaDNI = reader.GetBoolean(10);//Añadido HG.19.03.21
                        obj.strHorarioAtencion = reader.GetString(11);//Añadido ES 07.04.2021
                        obj.CantS = reader.GetInt32(12);//Añadido ES 09.04.2021
                        obj.TotalS = reader.GetDecimal(13);//Añadido ES 09.04.2021
                        obj.CantC = reader.GetInt32(14);//Añadido ES 09.04.2021
                        obj.TotalC = reader.GetDecimal(15);//Añadido ES 09.04.2021
                        obj.Sim = reader.GetString(16);//Añadido ES 09.04.2021
                        obj.bitTodosTS = reader.GetBoolean(17);//Añadido ES 12.04.2021

                        listaConsumo.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listaConsumo;
        }
        //5.76
        public int RegistrarConsumo(Session_Movi objSession, int intTipoOperacion, Consumo objDatos, bool bitTodosTS, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref int intValida)
        {

            int intIdConsumoOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_TCCONSUMO_I00", cn);  
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu"  , objSession.intIdMenu.ToString());
                param.Add("@intIdSoft"  , objSession.intIdSoft);
                /*=======================================================
                        PARAMETROS DE ENTRADA TOMA DE CONSUMO 
                 =======================================================*/
                param.Add("@intIdServicio", objDatos.intIdServicio);
                param.Add("@intIdAsistencia", objDatos.intIdAsistencia);
                param.Add("@intCantidad", objDatos.intCantidad);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                param.Add("@intTipoOperacion", intTipoOperacion); //1: insert, 2: update
                param.Add("@bitTodosTS", bitTodosTS); //0: Cualquier tipo de servicio, 1: Todos los TS
                /*=======================================================
                        PARAMETROS DE SALIDA TOMA DE CONSUMO 
                 =======================================================*/
                param.Add("@intIdConsumo", objDatos.intIdConsumo); // param.Add("@IntIdEmp", objDatos.IntIdEmp);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                param.Add("@intValida", 0);

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdConsumoOut = Convert.ToInt32(cmd.Parameters["@intIdConsumo"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
                intValida = Convert.ToInt32(cmd.Parameters["@intValida"].Value.ToString());
            }
            return intIdConsumoOut;
        }
        //5.77
        public bool AnularServicioRegistrado(Session_Movi objSession, int intIdAsistencia, int intIdServicio, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref int intValida)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TCCONSUMO_D00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                //param.Add("@intIdConsumo", intIdConsumo);
                param.Add("@intIdAsistencia", intIdAsistencia);
                param.Add("@intIdServicio", intIdServicio);
                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                param.Add("@intValida", 0);//ES 12.03.2021
                AsignarParametros(cmd, param);

                exito = Transaction(cn, cmd);

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
                intValida = Convert.ToInt32(cmd.Parameters["@intValida"].Value.ToString());//ES 12.03.2021
            }

            return exito;
        }
        //5.78
        public List<Consumo> ListarConsumo(Session_Movi objSession, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Consumo> lista = new List<Consumo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_TCCONSUMO_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);

                //salida             
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Consumo obj = new Consumo();
                    obj.intIdConsumo = reader.GetInt32(0);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.79
        public List<TGREGLANEG_SERV_DET> ListarReglaNegocioServicio(Session_Movi objSession, int intIdAsistencia, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGREGLANEG_SERV_DET> lista = new List<TGREGLANEG_SERV_DET>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_TGREGLANEG_SERV_DET_Q00", cn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdAsistencia", intIdAsistencia);

                //salida             
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TGREGLANEG_SERV_DET obj = new TGREGLANEG_SERV_DET();
                    obj.IntIdReglaNeg  = reader.GetInt32(0);
                    obj.intIdServicio  = reader.GetInt32(1);
                    obj.strDesServicio = reader.GetString(2);//STRING
                    obj.intIdTipServ   = reader.GetString(3);
                    obj.intIdTipoMenu  = reader.GetString(4);
                    obj.monCostoServ   = reader.GetDecimal(5);//DECIMAL
                    //obj.intIdMoneda    = reader.GetInt32(6);
                    obj.strCoMoneda = reader.GetString(6);
                    obj.dcTipoCambio = reader.GetDecimal(7);
                    obj.simbolo = reader.GetString(8);


                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.80
        public int RegistrarComedorConDni(Session_Movi objSession, ComedorMarcaConDni objDatos, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int intIdComedorOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_I02", cn);//TSP_TCSERVICIO_IU01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu",   objSession.intIdMenu.ToString());
                param.Add("@intIdSoft",   objSession.intIdSoft); 
                //parametros de entrada

                //-------------------------------------------------------------------------------                
                param.Add("@intIdAsistencia" , 0);                       // @intIdAsistencia 
                param.Add("@strNumDocumento" , objDatos.strNumDocumento);// @strNumDocumento
                param.Add("@dttFechaMarca"   , objDatos.dttFechaMarca);  // @dttFechaMarca
                param.Add("@intNumTerminalRelac", objDatos.intNumTerminalRelac);     // @intNumTerminalRelac int
                param.Add("@bitMarcaDNI", objDatos.bitMarcaDNI);     // @bitMarcaDNI         bit
                param.Add("@intIdUsuario"    , objSession.intIdUsuario);
                param.Add("@intTipoOperacion", 1);       //1: insert, 2: update
                //------------------------------------------------------------------------------- 

                //Parámetros de Salida                                                    
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();  
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdComedorOut;
        }
        //5.81
        public List<TGREGLANEG_SERV_DET> ListarServicioComplementario(Session_Movi objSession, int intIdAsistencia, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGREGLANEG_SERV_DET> lista = new List<TGREGLANEG_SERV_DET>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TCERVICIO_COMPLEMENTARIO_Q00", cn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdAsistencia", intIdAsistencia);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TGREGLANEG_SERV_DET obj = new TGREGLANEG_SERV_DET();
                    obj.intIdServicio = reader.GetInt32(0);
                    obj.strDesServicio = reader.GetString(1);
                    obj.strCategoria = reader.GetString(2);
                    obj.monCostoServ = reader.GetDecimal(3);
                    obj.strCoMoneda = reader.GetString(4);
                    obj.dcTipoCambio = reader.GetDecimal(5);
                    obj.simbolo = reader.GetString(6);

                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        #endregion TOMA_DE_CONSUMO

        #region Imprimir
        //8.1
        public List<Imprimir> DatosImpresion(Session_Movi objSession, int intId, int tipo, DataTable tblistaConsumoSelects, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Imprimir> datosPrint = new List<Imprimir>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TCCONSUMO_IMPRIMIR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intId", intId);
                param.Add("@intTipo", tipo);
                param.Add("@TT_TCCONSUMO", tblistaConsumoSelects);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Imprimir obj = new Imprimir();
                    //obj.ndocu = reader.GetString(0); //Servicio
                    //obj.fecha = reader.GetString(1); //fecha y hora
                    //obj.nomcli = reader.GetString(2); //Nombre del Comensal
                    obj.empresa = reader.GetString(0);
                    obj.comensal = reader.GetString(1);
                    obj.tipdoc = reader.GetString(2);
                    obj.numdoc = reader.GetString(3);
                    obj.fecha = reader.GetString(4);
                    obj.tipServ = reader.GetString(5);
                    obj.cant = reader.GetInt32(6);  //Cantidad
                    obj.precio = reader.GetString(7);  //Precio del Servicio con moneda
                    obj.descr = reader.GetString(8); //Descripcion del Servicio
                    obj.simbolo = reader.GetString(9);  //Adicional decimal
                    obj.uca1 = reader.GetDecimal(10); //Adicional String
                    obj.rollos = reader.GetString(11); //Adicional String

                    datosPrint.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
             return datosPrint;
        }
        #endregion Imprimir

    }
}



