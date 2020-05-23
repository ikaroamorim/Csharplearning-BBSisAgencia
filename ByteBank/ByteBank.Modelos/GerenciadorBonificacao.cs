using Bytebank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank
{
  public class GerenciadorBonificacao
  {
    private double _totalBonificacao;

    public void Registrar(Funcionario funcionario)
    {
      _totalBonificacao += funcionario.getBonificacao();
    }

    public double GetTotalBonificacao()
    {
      return _totalBonificacao;
    }
  }
}
