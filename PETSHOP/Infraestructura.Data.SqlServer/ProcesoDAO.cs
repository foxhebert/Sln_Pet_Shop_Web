using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.SqlServer
{
    public class ProcesoDAO : Conexion
    {



        //public List<TG_PERIODO> ListarPeriodo(Session_Movi objSession, int intActivo, int intActivoFilter, string strfilter, string intfiltrojer1, string intfiltrojer2, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        //{
        //    List<TG_PERIODO> lista = new List<TG_PERIODO>();

        //    using (SqlConnection cn = new SqlConnection(cadCnx))
        //    {
        //        SqlCommand cmd = new SqlCommand("TSP_TGPERIODO_Q02", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();

        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("@intIdSesion", objSession.intIdSesion);
        //        param.Add("@intIdMenu", objSession.IntIdMenu);
        //        param.Add("@intIdSoft", objSession.intIdSoft);


        //        param.Add("@intActivo", intActivo);
        //        param.Add("@intActivoFilter", intActivoFilter);
        //        param.Add("@strfilter", strfilter);
        //        param.Add("@intfiltrojer1", intfiltrojer1);
        //        param.Add("@intfiltrojer2", intfiltrojer2);

        //        //salida
        //        //param.Add("@TotalRows", 0);
        //        param.Add("@intResult", 0);
        //        param.Add("@strMsjDB", "");
        //        param.Add("@strMsjUsuario", "");
        //        AsignarParametros(cmd, param);

        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            TG_PERIODO obj = new TG_PERIODO();

        //            obj.intIdPeriodo = reader.GetInt32(0);
        //            obj.strCoPeriodo = reader.GetString(2);
        //            obj.strDesPeriodo = reader.GetString(3);
        //            obj.intAnioFiscal = reader.GetInt32(7);
        //            obj.strMesAño = reader.GetString(19);

        //            obj.strCerrado = reader.GetString(11);
        //            obj.strEstado = reader.GetString(18);
        //            obj.strDesPlanilla = reader.GetString(20);


        //            lista.Add(obj);

        //        }
        //        reader.Close();

        //        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
        //        strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
        //        strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

        //    }
        //    return lista;
        //}

        //public int IUPeriodo(TG_PERIODO objDatos, int intTipoOperacion, Session_Movi objSession, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        //{

        //    int intIdPeriOdoOut = 0;
        //    using (SqlConnection cn = new SqlConnection(cadCnx))
        //    {
        //        SqlCommand cmd = new SqlCommand("TSP_TGPERIODO_IU01", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("@intIdSesion", objSession.intIdSesion);
        //        param.Add("@intIdMenu", objSession.IntIdMenu);
        //        param.Add("@intIdSoft", objSession.intIdSoft);//parametros de entrada
        //        param.Add("@intIdPlanilla", objDatos.intIdPlanilla);
        //        param.Add("@strCoPeriodo", objDatos.strCoPeriodo);
        //        param.Add("@strDesPeriodo", objDatos.strDesPeriodo);
        //        param.Add("@dttFeIniPerio", objDatos.dttFeIniPerio);

        //        param.Add("@dttFeFinPerio", objDatos.dttFeFinPerio);
        //        param.Add("@dttFeCiePerio", objDatos.dttFeCiePerio);
        //        param.Add("@intAnioFiscal", objDatos.intAnioFiscal);
        //        param.Add("@intMes", objDatos.intMes);
        //        param.Add("@bitFlProyectado", objDatos.bitFlProyectado);
        //        param.Add("@bitCerrado", objDatos.bitCerrado);
        //        param.Add("@intIdUnidOrg", objDatos.IntIdUniOrg);


        //        if (objDatos.strPeriodoCampo1 == null)
        //            param.Add("@strPeriodoCampo1", DBNull.Value);
        //        else
        //            param.Add("@strPeriodoCampo1", objDatos.strPeriodoCampo1);


        //        if (objDatos.strPeriodoCampo2 == null)
        //            param.Add("@strPeriodoCampo2", DBNull.Value);
        //        else
        //            param.Add("@strPeriodoCampo2", objDatos.strPeriodoCampo2);


        //        if (objDatos.strPeriodoCampo3 == null)
        //            param.Add("@strPeriodoCampo3", DBNull.Value);
        //        else
        //            param.Add("@strPeriodoCampo3", objDatos.strPeriodoCampo3);


        //        if (objDatos.strPeriodoCampo4 == null)
        //            param.Add("@strPeriodoCampo4", DBNull.Value);
        //        else
        //            param.Add("@strPeriodoCampo4", objDatos.strPeriodoCampo4);


        //        if (objDatos.strPeriodoCampo5 == null)
        //            param.Add("@strPeriodoCampo5", DBNull.Value);
        //        else
        //            param.Add("@strPeriodoCampo5", objDatos.strPeriodoCampo5);



        //        param.Add("@bitFlActivo", objDatos.bitFlActivo);
        //        param.Add("@intIdUsuario", objSession.intIdUsuario);
        //        param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
        //        //Parámetros de Salida
        //        param.Add("@intIdPeriodo", objDatos.intIdPeriodo);
        //        param.Add("@intResult", 0);
        //        param.Add("@strMsjDB", "");
        //        param.Add("@strMsjUsuario", "");
        //        AsignarParametros(cmd, param);
        //        int result = cmd.ExecuteNonQuery();
        //        intIdPeriOdoOut = Convert.ToInt32(cmd.Parameters["@intIdPeriodo"].Value.ToString());
        //        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
        //        strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
        //        strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
        //    }
        //    return intIdPeriOdoOut;
        //}

        //public List<TG_PERIODO> ObtenerRegistroPeriodo(Session_Movi objSession, int intIdPeriodo,
        //                                         ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        //{
        //    List<TG_PERIODO> listDetCar = new List<TG_PERIODO>();
        //    using (SqlConnection cn = new SqlConnection(cadCnx))
        //    {
        //        SqlCommand cmd = new SqlCommand("TSP_TGPERIODO_Q01", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();

        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("@intIdSesion", objSession.intIdSesion);
        //        param.Add("@intIdMenu", objSession.IntIdMenu);
        //        param.Add("@intIdSoft", objSession.intIdSoft);



        //        param.Add("@intIdPeriodo", intIdPeriodo);
        //        //salida
        //        param.Add("@intResult", 0);
        //        param.Add("@strMsjDB", "");
        //        param.Add("@strMsjUsuario", "");

        //        AsignarParametros(cmd, param);
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {

        //                TG_PERIODO obj = new TG_PERIODO();
        //                obj.intIdPlanilla = reader.GetInt32(1);
        //                obj.strCoPeriodo = reader.GetString(2);
        //                obj.strDesPeriodo = reader.GetString(3);
        //                obj.dttFeIniPerio = Convert.ToString(reader.GetDateTime(4));
        //                obj.dttFeFinPerio = Convert.ToString(reader.GetDateTime(5));
        //                obj.dttFeCiePerio = Convert.ToString(reader.GetDateTime(6));
        //                obj.intAnioFiscal = reader.GetInt32(7);
        //                obj.intMes = reader.GetInt32(8);
        //                obj.bitFlProyectado = reader.GetBoolean(9);
        //                obj.bitCerrado = reader.GetBoolean(10);
        //                obj.IntIdUniOrg = reader.GetInt32(11);
        //                obj.strPeriodoCampo1 = reader.GetString(13);
        //                obj.strPeriodoCampo2 = reader.GetString(14);
        //                obj.strPeriodoCampo3 = reader.GetString(15);
        //                obj.strPeriodoCampo4 = reader.GetString(16);
        //                obj.strPeriodoCampo5 = reader.GetString(17);
        //                obj.bitFlActivo = reader.GetBoolean(18);
        //                obj.IntIdJerOrg = reader.GetInt32(19);

        //                listDetCar.Add(obj);
        //            }

        //        }


        //        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
        //        strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
        //        strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
        //    }

        //    return listDetCar;
        //}
        //public bool EliminmarPeriodo(Session_Movi objSession, int intIdPeriodo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        //{
        //    bool exito = false;

        //    using (SqlConnection cn = new SqlConnection(cadCnx))
        //    {
        //        SqlCommand cmd = new SqlCommand("TSP_TGPERIODO_D02", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();

        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("@intIdSesion", objSession.intIdSesion);
        //        param.Add("@intIdMenu", objSession.IntIdMenu);
        //        param.Add("@intIdSoft", objSession.intIdSoft);
        //        param.Add("@intIdUsuario", objSession.intIdUsuario);
        //        param.Add("@intIdPeriodo", intIdPeriodo);
        //        //Parámetros de Salida                              
        //        param.Add("@intResult", 0);
        //        param.Add("@strMsjDB", "");
        //        param.Add("@strMsjUsuario", "");
        //        AsignarParametros(cmd, param);

        //        exito = Transaction(cn, cmd);

        //        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
        //        strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
        //        strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
        //    }

        //    return exito;
        //}

        ////////public List<ValidacionesxLongitud> MaestroMaxCaracteres(string strMaestro)
        ////////{

        ////////    List<ValidacionesxLongitud> listDetCar = new List<ValidacionesxLongitud>();
        ////////    using (SqlConnection cn = new SqlConnection(cadCnx))
        ////////    {
        ////////        SqlCommand cmd = new SqlCommand("TSP_MAESTROS_Q01", cn);
        ////////        cmd.CommandType = CommandType.StoredProcedure;
        ////////        cn.Open();

        ////////        Dictionary<string, object> param = new Dictionary<string, object>();



        ////////        param.Add("@strMaestro", strMaestro);



        ////////        AsignarParametros(cmd, param);
        ////////        using (SqlDataReader reader = cmd.ExecuteReader())
        ////////        {
        ////////            while (reader.Read())
        ////////            {

        ////////                ValidacionesxLongitud obj = new ValidacionesxLongitud();
        ////////                obj.NombreColum = reader.GetString(0);
        ////////                obj.intNumero = reader.GetInt32(1);

        ////////                listDetCar.Add(obj);
        ////////            }

        ////////        }

        ////////    }

        ////////    return listDetCar;
        ////////}
    }
}
