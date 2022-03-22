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
    public class ConceptoBL
    {
        private ConceptoDAO objDao = new ConceptoDAO();
        ////2.19
        //public List<VariableData> ListarConcepto(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        //{
        //    List<VariableData> lista = new List<VariableData>();
        //    try
        //    {
        //        int intResult = 0;
        //        string strMsjDB = "";

        //        lista = objDao.ListarConcepto(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
        //        if (intResult == 0)
        //        {
        //            if (!strMsjDB.Equals(""))
        //            {
        //                Log.AlmacenarLogMensaje("[ListarConcepto] => Respuesta del Procedimiento : " + strMsjDB);
        //                if (strMsjUsuario.Equals(""))
        //                    strMsjUsuario = strMsjDB;
        //            }

        //        }

        //    }
        //    catch (SqlException ex)
        //    {
        //        Log.AlmacenarLogError(ex, "ConceptoBL.cs");
        //        throw new Exception("Ocurrió un error en BD (ListarConcepto)");
        //    }

        //    catch (Exception ex)
        //    {
        //        Log.AlmacenarLogError(ex, "ConceptoBL.cs");
        //        throw new Exception("Error General (ListarConcepto)");
        //    }
        //    return lista;
        //}
    }

}
