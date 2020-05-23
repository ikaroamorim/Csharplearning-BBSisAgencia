using Bytebank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank.Funcionarios
{
  public class Diretor : FuncionarioAutenticavel, IAutenticavel
  {
    public Diretor(string cpf) : base(cpf, 5000)
    {

    }

    public bool Autenticar(string senha)
    {
      return true;
    }
     
    public override void AumentarSalario()
    {
      Salario *= 1.15;
    }

    internal protected override double getBonificacao()
    {
      return Salario * 0.5;
    }
  }
}
