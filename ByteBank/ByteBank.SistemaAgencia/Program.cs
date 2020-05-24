using Bytebank;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ByteBank.SistemaAgencia
{
  class Program
  {
    static void Main(string[] args)
    {
      foreach (var item in collection)
      {

      }

    }

    static void TestaHumanize()
    {
      DateTime dataFimPagamento = new DateTime(2021, 7, 12);
      DateTime dataCorrente = DateTime.Now;

      TimeSpan diferenca = dataFimPagamento - dataCorrente;

      string mensagem = "Vencimento em: " + TimeSpanHumanizeExtensions.Humanize(diferenca);

      Console.WriteLine(dataCorrente);
      Console.WriteLine(dataFimPagamento);
      Console.WriteLine(mensagem);

      string url = "https://www.bytebank.org/cotacao.aspx?moedaorg=0213&moedadest=0349";
      string Surl = url.Substring(url.IndexOf('?')+1);

      ExtratorArgumentosURL ex = new ExtratorArgumentosURL(url);

      Console.WriteLine(ex.getValor("moedaorg"));
      Console.WriteLine(ex.getValor("moedadest"));
    }

    static void TestaRegex()
    {
      string padraotel = "[0-9]{4,5}-?[0-9]{4}";
      string textoTeste = "Meu nome é Fulano, em 99645-1089 você pode me encontrar";
      Regex.IsMatch(textoTeste, padraotel);

      Match resultado = Regex.Match(textoTeste, padraotel);

    }
  }
}
