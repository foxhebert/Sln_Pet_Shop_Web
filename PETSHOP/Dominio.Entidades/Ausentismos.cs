using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace Dominio.Entidades
{
    public class Ausentismos
    {
        [DataMember] public int intIdPerConcepto { get; set; }
        ////PARA EL DETALLE VER
        [DataMember] public string strCoConcepto { get; set; }
        [DataMember] public string strDesConcepto { get; set; }
        [DataMember] public string dttFecha { get; set; }
        [DataMember] public string strDeTipo { get; set; }
        [DataMember] public int intIdConcepto { get; set; }
    }
}
