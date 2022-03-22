using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Sistema
{
    [DataContract]
    public class TSParamsSaf
    {

        [DataMember] public string prmSalidaApp       { get; set; }
        [DataMember] public string prmAddOfic         { get; set; }
        [DataMember] public string prmAddResp         { get; set; }
        [DataMember] public string prmFilUbica        { get; set; }
        [DataMember] public string prmOpcOpera        { get; set; }
        [DataMember] public string prmAreaxLocal      { get; set; }
        [DataMember] public string prmModaTrab        { get; set; }
        [DataMember] public string prmOutExcelxLocal  { get; set; }
        [DataMember] public string prmImpresora       { get; set; }

        [DataMember] public string strServidor        { get; set; }
        [DataMember] public string strBaseDatos       { get; set; }
        [DataMember] public string strUsuario         { get; set; }
        [DataMember] public string strContrasenia     { get; set; }
        [DataMember] public string strAutenticacion   { get; set; }
        [DataMember] public string strDirExcelCarga   { get; set; }
        [DataMember] public string strExcelGenerado   { get; set; }







        //[DataMember] public int intIdConfi { get; set; }
        //[DataMember] public string strCoConfi { get; set; }
        //[DataMember] public string strDesConfi { get; set; }
        //[DataMember] public string strValorConfi { get; set; }
        //[DataMember] public int intIdSoft { get; set; }
        //[DataMember] public string strPosibValor { get; set; }
        //[DataMember] public bool bitFlActivo { get; set; }
        //[DataMember] public DateTime? dttFeRegistro { get; set; }
        //[DataMember] public string tipoControl { get; set; }
    }
}
