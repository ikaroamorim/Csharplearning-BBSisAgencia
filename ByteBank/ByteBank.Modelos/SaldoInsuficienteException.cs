using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank
{
  public class SaldoInsuficienteException : OperacaoFinanceiraException
  {
    public double Saldo { get; }
    public double ValorSaque { get; }

    public SaldoInsuficienteException() : base()
    {

    }

    public SaldoInsuficienteException(string message): base(message)
    {
      
    }

    public SaldoInsuficienteException(double saldo, double valorsaque) : this ("Tentativa de saque de R$ : " + valorsaque + "em uma conta com saldo de R$ : " + saldo)
    {
      Saldo = saldo;
      ValorSaque = valorsaque;
    }

    public SaldoInsuficienteException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna)
    {

    }
  }
}
