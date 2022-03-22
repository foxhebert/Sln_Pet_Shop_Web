using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TbEmpleadoMov
    {
        //MODELO DE TBEMPLEADO       
        [DataMember] public int    intIdEmpleado       { get; set; }
        [DataMember] public int    intIdLocal          { get; set; }
        [DataMember] public int    intIdArea           { get; set; }  
        [DataMember] public string strCodEmpleado      { get; set; }
        [DataMember] public string strDescEmpleado     { get; set; }
    }
}