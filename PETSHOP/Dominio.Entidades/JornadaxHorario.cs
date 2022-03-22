using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class JornadaxHorario
    {

        [DataMember] public string strLinea1{ get; set; }
        [DataMember] public string strLinea2{ get; set; }
        [DataMember] public string strLinea3{ get; set; }
        [DataMember] public string strLinea4{ get; set; }
        [DataMember] public string strLinea5{ get; set; }
        [DataMember] public string strLinea6{ get; set; }
        [DataMember] public string strLinea7{ get; set; }
        [DataMember] public string strColor { get; set; }
        [DataMember] public int intIdJornada { get; set; }
        [DataMember] public int intIdHorario { get; set; }
        [DataMember] public string strTipoServicio { get; set; }//21.04.2021
    }
}
