using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TMPRODU_MOVIL
    {
        //MODELO DE TMPRODU
        //[DataMember] public int    intIdProd     { get; set; }
        [DataMember] public string strCoProdu    { get; set; }
        [DataMember] public string strDeProdu    { get; set; }
        //[DataMember] public string deleted_at    { get; set; }
        //[DataMember] public string updated_at    { get; set; }

    }
}