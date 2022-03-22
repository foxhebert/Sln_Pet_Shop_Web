using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ExcelMasivo
    {

        //EXCEL - TABLA TBENTIDAD
        [DataMember] public string codigo { get; set; }
        [DataMember] public string descripcion { get; set; }

        //EXCEL - TABLA TBAREAS
        //[DataMember] public string codigo { get; set; }
        //[DataMember] public string descripcion { get; set; }

        //EXCEL - TABLA TBLOCAL
        //[DataMember] public string COD_EMP_DSC { get; set; }
        //[DataMember] public string COD_LOC { get; set; }
        //[DataMember] public string COD_LOC_DSC { get; set; }
        //[DataMember] public string COD_GER { get; set; }
        //[DataMember] public string COD_GER_DSC { get; set; }
        //[DataMember] public string COD_ARE { get; set; }

        //[DataMember] public int INTIDPROCESO { get; set; }
        //[DataMember] public string OBSERVACION { get; set; }
        //[DataMember] public bool FLAGOBSERVADO { get; set; }
        //[DataMember] public int ESTADO_FINAL { get; set; }
    }
}
