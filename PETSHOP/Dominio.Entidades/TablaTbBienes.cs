using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    public class TablaTbBienes
    {

        //MODELO DE TBBIENES PARA EL MANT. ETIQUETAS    
        [DataMember] public string descripcion   { get; set; }
        [DataMember] public string codigo        { get; set; }
        [DataMember] public string estado        { get; set; }
        [DataMember] public string marca         { get; set; }
        [DataMember] public string modelo        { get; set; }
        [DataMember] public string serie         { get; set; }
        [DataMember] public string tipo          { get; set; }
        [DataMember] public string color         { get; set; }
        [DataMember] public string condicion     { get; set; }
        [DataMember] public string responsable   { get; set; }
        [DataMember] public string desarea       { get; set; }
        [DataMember] public string local         { get; set; }
        [DataMember] public string area          { get; set; }
        [DataMember] public string etiqueta      { get; set; }
       



    }
}
