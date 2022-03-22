using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CBX_Web_PetShopWeb
{
    //public Dominio.Repositorio.AccesoMovilBL objAccesoMovilBL = new Dominio.Repositorio.AccesoMovilBL();
    /// <summary>
    /// Summary description for AccesoMovil
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AccesoMovil : System.Web.Services.WebService
    {

        ////[WebMethod]
        ////public string HelloWorld()
        ////{
        ////    return "Hello World";
        ////}        

        public Dominio.Repositorio.AccesoMovilBL objAccesoMovilBL = new Dominio.Repositorio.AccesoMovilBL();
        //40.1
        [WebMethod]
        public List<Dominio.Entidades.TMPRODU_MOVIL> ListarTablaTmProdu(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            try
            {
                return objAccesoMovilBL.ListarTablaTmProdu(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, strTerminal, ref intResult, ref strMsjDB, ref strMsjUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //40.2
        [WebMethod]
        public List<Dominio.Entidades.TMPRODU_MOVIL> ListarTablaTmProduII(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, string strTerminal, string strCoProdu, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {            

            try
            {
                return objAccesoMovilBL.ListarTablaTmProduII(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, strTerminal, strCoProdu, ref intResult, ref strMsjDB, ref strMsjUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //40.3 TMINVENTARIO INSERT/UPDATE
        [WebMethod]
        //public bool InsertarActualizarTmInventarioMovil(int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario,  ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        public bool InsertarActualizarTmInventarioMovil(  int intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int id, string nvcNoAlmac, string nvcNoUbica, string nvcCoCampoAux, string nvcCoProdu, int intNuRegis, string intNuTermi,  string dttFeRegis, int intFLNuevo, int intFLRepetido, string deleted_at, string created_at, string updated_at,  ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                //return objAccesoMovilBL.InsertarActualizarTmInventarioMovil(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);
                return objAccesoMovilBL.InsertarActualizarTmInventarioMovil( intIdSesion, intIdMenu, intIdSoft, intIdUsuario, id, nvcNoAlmac, nvcNoUbica, nvcCoCampoAux, nvcCoProdu, intNuRegis, intNuTermi,  dttFeRegis, intFLNuevo, intFLRepetido, deleted_at, created_at, updated_at, ref intResult, ref strMsjDB, ref strMsjUsuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
