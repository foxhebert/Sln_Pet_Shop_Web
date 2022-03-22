using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class PersonalData
    {
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public string strCoPersonal { get; set; }
        [DataMember] public string strNumDoc { get; set; }
        [DataMember] public string strNombres { get; set; }
        [DataMember] public string dttFecAdmin { get; set; }
        [DataMember] public string bitEspecifica_DESC { get; set; }

    }
}
