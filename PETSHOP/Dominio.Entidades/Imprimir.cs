using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Imprimir
    {
        //[DataMember]  public string ndocu { get; set; }
        //[DataMember]  public string fecha { get; set; }
        //[DataMember]  public string nomcli { get; set; }
        [DataMember] public string empresa { get; set; }
        [DataMember] public string comensal { get; set; }
        [DataMember] public string numdoc { get; set; }
        [DataMember] public string tipdoc { get; set; }
        [DataMember] public string fecha { get; set; }
        [DataMember] public string tipServ { get; set; }

        //[DataMember]  public decimal cant { get; set; }
        [DataMember] public int cant { get; set; }
        //[DataMember]  public string codf { get; set; }
        [DataMember] public string precio { get; set; }
        [DataMember] public string descr { get; set; }
        [DataMember] public decimal uca1 { get; set; }
        [DataMember] public string rollos { get; set; }
        [DataMember] public string simbolo { get; set; }
        
    }
}
