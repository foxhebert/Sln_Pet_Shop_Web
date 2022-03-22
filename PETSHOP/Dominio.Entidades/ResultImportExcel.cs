using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections;

namespace Dominio.Entidades
{
    public class ResultImportExcel
    {

        [DataMember] public int intInsertado { get; set; } 
        [DataMember] public int intActualizado { get; set; }
        [DataMember] public int intInconsistente { get; set; }
        [DataMember] public String strInconsistente { get; set; }
        [DataMember] public String strNombreTabla { get; set; }
        [DataMember] public List<string> arrListInconsistentes;



    }
}
