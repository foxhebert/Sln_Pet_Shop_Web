using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBX_Web_PetShopWeb.Models
{   //HGM_COMENTADO_19.08.21
    //////public class ConfiguracionModel
    //////{
    //////    #region Jerarquía Organizacional
    //////    public Dictionary<int, int> getNivelMáximoJerarquia(List<int> data, int current = 0)
    //////    {
    //////        if (current > 0)
    //////        {
    //////            data.Add(current);
    //////            data = data.OrderBy(p=> p).ToList();
    //////        }             

    //////        Dictionary<int, int> lista = new Dictionary<int, int>();
    //////        foreach (var item in data)
    //////        {
    //////            lista.Add(item, item);
    //////        }

    //////        return lista;
    //////    }
    //////    #endregion Jerarquía Organizacional

    //////}
}
