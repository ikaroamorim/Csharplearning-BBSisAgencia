using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank.Funcionarios
{
  public class Auxiliar : Funcionario
  {
    public Auxiliar (string cpf):base(cpf, 2000)
    {

    }

    public override void AumentarSalario()
    {
      Salario *= 1.10;
    }
    internal protected override double getBonificacao()
    {
      return Salario * 0.2;
    }
  }
}
