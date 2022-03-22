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
    public class ConceptoDAO : Conexion
    {
        //public List<VariableData> ListarConcepto(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        //{
        //    List<VariableData> lista = new List<VariableData>();

        //    using (SqlConnection cn = new SqlConnection(cadCnx))
        //    {
        //        SqlCommand cmd = new SqlCommand("TSP_TGCONCEPTO_Q02", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();

        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("@intIdSesion", intIdSesion);
        //        param.Add("@intIdMenu", intIdMenu);
        //        param.Add("@intIdSoft", intIdSoft);

        //        param.Add("@intActivoFilter", intActivoFilter);
        //        param.Add("@strfilter", strfilter);
        //        param.Add("@intfiltrojer", intfiltrojer);
        //        //salida
        //        //param.Add("@TotalRows", 0);
        //        param.Add("@intResult", 0);
        //        param.Add("@strMsjDB", "");
        //        param.Add("@strMsjUsuario", "");
        //        AsignarParametros(cmd, param);

        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
                 
        //            VariableData obj = new VariableData();

        //            obj.strCoConcepto = reader.GetString(0);
        //            obj.strDesConcepto = reader.GetString(1);
        //            obj.intIdConcepto = reader.GetInt32(2);
        //            obj.strDeTipotipo = reader.GetString(3);
        //            obj.strDeTipoum = reader.GetString(4);
        //            obj.strActivo = reader.GetString(5);
        //            lista.Add(obj);

        //        }
        //        reader.Close();

        //        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
        //        strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
        //        strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

        //    }
        //    return lista;
        //}


    }
}
