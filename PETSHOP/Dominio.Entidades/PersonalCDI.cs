using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class PersonalCDI
    {
        [DataMember] public int intIdCambioDoc { get; set; }
        [DataMember] public int intIdPerso { get; set; }
        [DataMember] public int intIdTipDocAnt { get; set; }
        [DataMember] public string strNumDocAnt { get; set; }
        [DataMember] public int intIdTipDocNue { get; set; }
        [DataMember] public string strNumDocNue { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public string dttFeRegistro { get; set; }
        [DataMember] public int bitModifUsar { get; set; }
        [DataMember] public string dttFeModif { get; set; }
        [DataMember] public string strFechaNac { get; set; }
        
    }
}
