using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [DataContract]
    public class EN_TMEncuesta
    {
        [DataMember] public string ID_ENCUESTA_PREGUNTA_OPCION_RESPUESTA { get; set; }
        [DataMember] public string ID_ENCUESTA_PREGUNTA { get; set; }
        [DataMember] public string NOM_ENCUESTA_PREGUNTA_OPCION { get; set; }
        [DataMember] public int IND_OPERACION { get; set; }
        [DataMember] public string FEC_ENCUESTA_COMPLETADA { get; set; }
    }
}
