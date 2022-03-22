using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class AsistenciaData
    {
        [DataMember] public long intIdAsistencia { get; set; }
        [DataMember] public int intIdPersonal { get; set; }
        [DataMember] public string dttFechaHora { get; set; }
        [DataMember] public string strMarcador { get; set; }
        [DataMember] public string strTipoMarca { get; set; }
    }
}
