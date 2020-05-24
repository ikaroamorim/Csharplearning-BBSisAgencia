using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank
{
  public class Cliente
  {
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Profissao { get; set;}

    public override bool Equals(object obj)
    {
      //Cliente objCliente = (Cliente)obj;
      Cliente objCliente = obj as Cliente;

      if (objCliente == null)
      {
        return false;
      }

      return Cpf == objCliente.Cpf;
    }
  }
}
