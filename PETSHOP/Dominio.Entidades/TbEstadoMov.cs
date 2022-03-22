using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TbEstadoMov
    {
        //MODELO DE TBESTADO  
        [DataMember] public int    intIdEstado { get; set; }
        [DataMember] public string strCodEstado { get; set; }
        [DataMember] public string strDescEstado { get; set; }

    }
}