using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.SqlServer
{
    public class ImpresionDAO : Conexion
    {
      

        #region IMPRESION ETIQUETAS

        /*================================================================================= 
         * 14.1 -- de GenerarArchivosExcel
         * =================================================================================*/
        public List<TablaTbBienes> ListarTbBienesEtiquetas(Session_Movi objSession,
               int Local, int Area, int Oficina, string codOficina, int Responsable, int TipoBien, string ActivoSerie,
               int NumColumnEtiquet, int CantEtiquetsImp, string AnioInventario, string Impresora,
               ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TablaTbBienes> lista = new List<TablaTbBienes>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TBBIENES_ETIQUETAS_Q00", cn); //TSP_GENERAR_ARCHIVOS_EXCEL  
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                //----------------------------------------------------------

                param.Add("@Local", Local);
                param.Add("@Area", Area);
                param.Add("@Oficina", Oficina);
                param.Add("@codOficina", codOficina);                 
                param.Add("@Responsable", Responsable);
                param.Add("@TipoBien", TipoBien);
                param.Add("@ActivoSerie", ActivoSerie);
                //param.Add("@NumColumnEtiquet", NumColumnEtiquet);
                //param.Add("@CantEtiquetsImp", CantEtiquetsImp);
                //param.Add("@AnioInventario", AnioInventario);
                //param.Add("@Impresora", Impresora);

                //-----------------------------------------------------------

                //salida             
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TablaTbBienes obj = new TablaTbBienes();


                    if (!reader.IsDBNull(0))
                    {
                        obj.descripcion = reader.GetString(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.codigo = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        obj.estado = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        obj.marca = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        obj.modelo = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        obj.serie = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        obj.tipo = reader.GetString(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        obj.color = reader.GetString(7);
                    }
                    if (!reader.IsDBNull(8))
                    {
                        obj.condicion = reader.GetString(8);
                    }
                    if (!reader.IsDBNull(9))
                    {
                        obj.responsable = reader.GetString(9);
                    }
                    if (!reader.IsDBNull(10))
                    {
                        obj.desarea = reader.GetString(10);
                    }
                    if (!reader.IsDBNull(11))
                    {
                        obj.local = reader.GetString(11);
                    }
                    if (!reader.IsDBNull(12))
                    {
                        obj.area = reader.GetString(12);
                    }
                    ////if (!reader.IsDBNull(13))
                    ////{

                        if (!reader.IsDBNull(13))
                            obj.etiqueta = reader.GetString(13);
                        else obj.etiqueta = "";

                    ////}

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        /*================================================================================= 
         * 14.2 COMBOS ETIQUETAS IMPRESION
         * =================================================================================*/
        public List<TablasEnCombos> ListarTablasEnCombos(Session_Movi objSession, string strNomTablaEntidad,
                            ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TablasEnCombos> lista = new List<TablasEnCombos>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_COMBOS_IMPRESION_Q00", cn);  // ESTE SE REUTILIZA EN EL METODO 14.6
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                //----------------------------------------------------------
                param.Add("@strNomTablaEntidad", strNomTablaEntidad);
                param.Add("@intIdFormato", 0 ); //
                //-----------------------------------------------------------
                //salida             
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TablasEnCombos obj = new TablasEnCombos();


                    if (!reader.IsDBNull(0))
                    {
                        obj.intIdEntidad = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.strDeEntidad = reader.GetString(1);
                    }


                    //if (!reader.IsDBNull(2))
                    //{
                    //    obj.estado = reader.GetString(2);
                    //}
                    //if (!reader.IsDBNull(3))
                    //{
                    //    obj.marca = reader.GetString(3);
                    //}
                    //if (!reader.IsDBNull(4))
                    //{
                    //    obj.modelo = reader.GetString(4);
                    //}
                    //if (!reader.IsDBNull(5))
                    //{
                    //    obj.serie = reader.GetString(5);
                    //}
                    //if (!reader.IsDBNull(6))
                    //{
                    //    obj.tipo = reader.GetString(6);
                    //}
                    //if (!reader.IsDBNull(7))
                    //{
                    //    obj.color = reader.GetString(7);
                    //}
                    //if (!reader.IsDBNull(8))
                    //{
                    //    obj.condicion = reader.GetString(8);
                    //}
                    //if (!reader.IsDBNull(9))
                    //{
                    //    obj.responsable = reader.GetString(9);
                    //}
                    //if (!reader.IsDBNull(10))
                    //{
                    //    obj.desarea = reader.GetString(10);
                    //}
                    //if (!reader.IsDBNull(11))
                    //{
                    //    obj.local = reader.GetString(11);
                    //}
                    //if (!reader.IsDBNull(12))
                    //{
                    //    obj.area = reader.GetString(12);
                    //}

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }



        /*================================================================================= 
         * 14.6 RUTA FORMATO BY ID ETIQUETAS IMPRESION
         * =================================================================================*/
        public List<TablasEnCombos> GetRutaFormatoFromTbBienesById(Session_Movi objSession, int intIdFormato, string strNomTablaEntidad,
                            ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string nombreDelSp)
        {
            List<TablasEnCombos> lista = new List<TablasEnCombos>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_COMBOS_IMPRESION_Q00", cn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();
                nombreDelSp = cmd.CommandText;
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                //param.Add("@intIdMenu", objSession.IntIdMenu);
                param.Add("@intIdMenu", objSession.intIdMenu.ToString());
                param.Add("@intIdSoft", objSession.intIdSoft);
                //----------------------------------------------------------
                param.Add("@strNomTablaEntidad", strNomTablaEntidad); 
                param.Add("@intIdFormato", intIdFormato);
                //-----------------------------------------------------------
                //salida             
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TablasEnCombos obj = new TablasEnCombos();


                    if (!reader.IsDBNull(0))
                    {
                        obj.intIdEntidad = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        obj.strDeEntidad = reader.GetString(1);
                    }

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }


        #endregion


    }
}
