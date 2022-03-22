using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TGREGLANEG_SERV_DET
    {
        [DataMember] public int IntIdReglaNeg { get; set; }
        [DataMember] public int intIdServicio { get; set; } //***
        [DataMember] public bool bitFlEliminado { get; set; }
        [DataMember] public int intIdUsuarReg { get; set; }
        [DataMember] public DateTime? dttFeReg { get; set; }
        [DataMember] public int intIdUsuarModif { get; set; }
        [DataMember] public DateTime? dttFeModif { get; set; }

        //PARA REGLA DE NEGOCIO - HG 26.02.21 13:05PM
        [DataMember] public string strCoServicio { get; set; } 
        [DataMember] public string strDesTipoServicio { get; set; } //***
        [DataMember] public string strDesMenu { get; set; }

        //DE LA TABLA SERVICIOS(para mant Toma de Consumos)
        [DataMember] public string  strDesServicio { get; set; }
        [DataMember] public string  intIdTipServ { get; set; }
        [DataMember] public string  intIdTipoMenu { get; set; }
        [DataMember] public decimal monCostoServ { get; set; } //***
        [DataMember] public int     intIdMoneda { get; set; }
        [DataMember] public int intConsumidos { get; set; } //int  

        //complementos 19.03.2021
        [DataMember] public string strCategoria { get; set; }
        [DataMember] public string strCoMoneda { get; set; }
        [DataMember] public decimal dcTipoCambio { get; set; }
        [DataMember] public string simbolo { get; set; }

    }
}
