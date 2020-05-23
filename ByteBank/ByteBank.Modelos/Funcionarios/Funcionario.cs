using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank.Funcionarios
{
  public abstract class Funcionario
  {
    public static int TotalFuncionarios { get; private set; }

    public string Nome { get; set; }
    public string Cpf { get; private set; }
    public double Salario { get; protected set; }

    public Funcionario(string cpf, double salario)
    {
      Cpf = cpf;
      Salario = salario;
      TotalFuncionarios++;
    }

    public abstract void AumentarSalario();

    internal protected abstract double getBonificacao();
  }
}
