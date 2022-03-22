using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Documento
    {
        [DataMember] public int intIdPerConcepto { get; set; }
        [DataMember] public string strRutaDocumento { get; set; }
        [DataMember] public string strNomDocumento { get; set; }
    }
}
