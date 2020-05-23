using Bytebank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank.Sistemas
{
  public class SistemaInterno
  {
    public bool Logar(IAutenticavel funcionario, string senha)
    {
      bool usuarioAutenticado = funcionario.Autenticar(senha);

      if (usuarioAutenticado)
      {
        Console.WriteLine("Bem vindo ao sistema");
        return true;
      }
      else
      {
        Console.WriteLine("Não foi possível autenticar");
        return false;
      }
    }
  }
}
