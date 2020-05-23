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
      // Testes com TimeSpan e Humanize
      /*
      DateTime dataFimPagamento = new DateTime(2021, 7, 12);
      DateTime dataCorrente = DateTime.Now;

      TimeSpan diferenca = dataFimPagamento - dataCorrente;

      string mensagem = "Vencimento em: " + TimeSpanHumanizeExtensions.Humanize(diferenca);

      Console.WriteLine(dataCorrente);
      Console.WriteLine(dataFimPagamento);
      Console.WriteLine(mensagem);
      */

      string url = "https://www.bytebank.org/cotacao.aspx?moedaorg=0213&moedadest=0349";
      string Surl = url.Substring(url.IndexOf('?')+1);

      ExtratorArgumentosURL ex = new ExtratorArgumentosURL(url);
      

      Console.WriteLine(ex.getValor("moedaorg"));
      
    }


  }
}
