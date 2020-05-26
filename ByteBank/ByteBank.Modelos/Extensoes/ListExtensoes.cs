using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Extensoes
{
  public static class ListExtensoes
  {
    public static void AdicionarVarios<T>(this List<T> listaInteiros, params T[] itens)
    {
      foreach (T item in itens)
      {
        listaInteiros.Add(item);
      }
    }
  }
}
