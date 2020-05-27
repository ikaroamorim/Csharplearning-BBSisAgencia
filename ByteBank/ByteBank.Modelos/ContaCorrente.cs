using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank
{
  /// <summary>
  /// Define uma conta corrente do banco Byte Bank
  /// </summary>
  public class ContaCorrente : IComparable
  {
    public static double TaxaOperacao { get; private set; }
    public static int TotalContas { get; private set; }
    public Cliente Titular { get; set; }

    public int CounterSaqueInvalido { get; private set; }
    public int CounterTransfInvalido { get; private set; }

    //Os campos Número  e Agencia estão equivalentes, o compilador faz com que ambos se comportem da mesma forma
    public int Agencia { get; }

    public int Numero { get; }

    // quando for expandir precisa dessa estrutura
    private double _saldo;
    public double Saldo
    {
      get
      {
        return _saldo;
      }
      set
      {
        if (value < 0)
        {
          return;
        }
        else
        {
          _saldo = value;
        }
      }
    }

    /// <summary>
    /// Cria uma instância de conta corrente com os argumentos utilizados
    /// </summary>
    /// <param name="agencia">Representa o valor da Propriedade <see cref="Agencia"/> e deve ser maior que zero</param>
    /// <param name="numero">Representa o valor da Propriedade <paramref name="numero"/> da Conta e deve ser maior que zero</param>
    public ContaCorrente(int agencia, int numero)
    {
      if (agencia <= 0)
      {
        throw new ArgumentException("Número de Agencia inválido.", nameof(agencia));
      }
      if (numero <= 0)
      {
        throw new ArgumentException("Número da conta inválido.", nameof(numero));
      }
      else
      {
        Agencia = agencia;
        Numero = numero;
        TotalContas++;
        TaxaOperacao = 30 / TotalContas;
      }

    }

    /// <summary>
    /// Realiza o saque e atualiza o saldo da propriedade <see cref="Saldo"/>
    /// </summary>
    /// <exception cref="ArgumentException"> Exceção lançado quando é colocado valor negativo</exception>
    /// <exception cref="SaldoInsuficienteException">Exceção quando o saque é maior que valor
    /// </exception>
    /// <param name="valor">Valor do Saque</param>
    public void Sacar(double valor)
    {
      if (valor <= 0)
      {
        throw new ArgumentException();
      }
      if (_saldo <= valor)
      {
        CounterSaqueInvalido++;
        throw new SaldoInsuficienteException(_saldo, valor);
      }
      else
      {
        Console.WriteLine("Realizado saque de R$" + valor + ". \n Seu novo saldo é R$ " + Saldo);
      }
    }

    public void Depositar(double valor)
    {
      if (valor <= 0)
      {
        throw new ArgumentException();
      }
      else
      {
        _saldo += valor;
        Console.WriteLine("Deposito realizado com sucesso");
      }
    }

    public void Transferir(double valor, ContaCorrente contaDestino)
    {
      //Poderia utilizar o try catch sacar
      if (valor < 0)
      {
        throw new SaldoInsuficienteException(_saldo, valor);
      }
      try
      {
        Sacar(valor);
      }
      catch (SaldoInsuficienteException e)
      {
        CounterTransfInvalido++;
        throw new OperacaoFinanceiraException("Operação não realizada.", e);
      }
      contaDestino.Depositar(valor);
    }

    public override string ToString()
    {
      //return "Conta\n Agencia: " + Agencia + "\nNúmero: " + Numero + "\nSaldo: " + Saldo;
      return $"Número {Numero}, Agência {Agencia}, Saldo {Saldo}";
    }

    public override bool Equals(object obj)
    {
      ContaCorrente c1 = obj as ContaCorrente;
      if (c1 == null)
      {
        return false;
      }
      return c1.Numero == Numero && c1.Agencia == Agencia;
    }

    public int CompareTo(object obj)
    {
      //negativo quando instancia precede o obj
      //zero qdo equivalentes
      //retornar positivo quando a precedencia for de obj

      var outraConta = obj as ContaCorrente;

      if(outraConta == null)
      {
        return -1;
      }
      if(Numero < outraConta.Numero)
      {
        return -1;
      }
      if(Numero == outraConta.Numero)
      {
        return 0;
      }
      return 1;
    }
  }
}
