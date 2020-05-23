using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank.Funcionarios
{
  public class Designer : Funcionario
  {
    public Designer(string cpf) : base(cpf, 3000)
    {

    }

    public override void AumentarSalario()
    {
      Salario *= 1.11;
    }

    internal protected override double getBonificacao()
    {
      return Salario*0.17;
    }

  }
}
