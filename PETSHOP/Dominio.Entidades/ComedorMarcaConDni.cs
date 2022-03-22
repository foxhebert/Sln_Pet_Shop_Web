using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    public class ComedorMarcaConDni
    {


        [DataMember] public int intIdAsistencia     { get; set; }
        [DataMember] public string strNumDocumento  { get; set; }   
        [DataMember] public string dttFechaMarca    { get; set; }
        [DataMember] public int intNumTerminalRelac { get; set; }
        [DataMember] public bool bitMarcaDNI        { get; set; }
        [DataMember] public int intIdUsuario        { get; set; }
        [DataMember] public int intTipoOperacion    { get; set; }

        //@intIdAsistencia  BIGINT OUTPUT 
        //@strNumDocumento  VARCHAR(15)
        //@dttFechaMarca    DATETIME
        //@intIdUsuario     int
        //@intTipoOperacion int --ENTRA CO

    }
}
