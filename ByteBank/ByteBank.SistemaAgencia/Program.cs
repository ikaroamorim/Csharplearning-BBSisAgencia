using Bytebank;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ByteBank.SistemaAgencia
{
  class Program
  {
    static void Main(string[] args)
    {
      ContaCorrente c1 = new ContaCorrente(2121, 35847);
      ContaCorrente c2 = new ContaCorrente(1212, 21598);
      Console.WriteLine(c1.Agencia);
      Console.WriteLine(c1.Numero);


      DateTime dataFimPagamento = new DateTime(2021, 7, 12);
      DateTime dataCorrente = DateTime.Now;

      TimeSpan diferenca = dataFimPagamento - dataCorrente;

      string mensagem = "Vencimento em: " + TimeSpanHumanizeExtensions.Humanize(diferenca);

      Console.WriteLine(dataCorrente);
      Console.WriteLine(dataFimPagamento);
      Console.WriteLine(mensagem);
      
    }


  }
}
