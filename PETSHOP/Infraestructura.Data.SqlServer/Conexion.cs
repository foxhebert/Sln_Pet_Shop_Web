using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.SqlServer
{
    public class Conexion
    {
        public string cadCnx = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

        public int timeSQL = Int32.Parse(ConfigurationManager.AppSettings["timeSQL"].ToString());

        protected bool Transaction(SqlConnection cn, SqlCommand cmd)
        {
            int result = 0;
            SqlTransaction objTrans = null;
            try
            {
                objTrans = cn.BeginTransaction();
                cmd.Transaction = objTrans;
                result = cmd.ExecuteNonQuery();
                objTrans.Commit();
                return true;
            }
            catch (Exception)
            {
                objTrans.Rollback();
                return false;
            }

        }

        protected void PoblarParametros(SqlCommand cmd, params object[] parametros)
        {
            // variable es la que controla el indice del vector de
            // parametros
            int indice = 0;
            // descubrir los parametros del SqlCommand enviado
            SqlCommandBuilder.DeriveParameters(cmd);
            // recorerr cada parametro a traves de un foreach
            foreach (SqlParameter oPrm in cmd.Parameters)
            {
                // si el nombre del parametro es distinto de @RETURN_VALUE
                // que estamos en un parámetro de usuario
                if (oPrm.ParameterName != "@RETURN_VALUE")
                {
                    oPrm.Value = parametros[indice];
                    indice++;
                }
            }
        }

        protected void AsignarParametros(SqlCommand cmd, Dictionary<string, object> parametros)
        {
            // descubrir los parametros del SqlCommand enviado
            SqlCommandBuilder.DeriveParameters(cmd);

            foreach (KeyValuePair<string, object> item in parametros)
            {
                if (cmd.Parameters[item.Key].SqlDbType == SqlDbType.Structured)
                {
                    string typeName = cmd.Parameters[item.Key].TypeName;
                    int positionDot = typeName.LastIndexOf(".");
                    positionDot = positionDot > 0 ? positionDot + 1 : 0;
                    cmd.Parameters[item.Key].TypeName = typeName.Substring(positionDot);
                }

                cmd.Parameters[item.Key].Value = item.Value;
            }

        }


    }
}
