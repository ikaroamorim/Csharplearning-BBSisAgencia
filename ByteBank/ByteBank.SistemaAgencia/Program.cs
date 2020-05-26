using Bytebank;
using ByteBank.Modelos.Extensoes;
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
      List<int> idades = new List<int>();

      idades.Add(1);
      idades.Add(5);
      idades.Add(14);
      idades.Add(25);
      idades.Add(38);
      idades.Add(61);

      idades.Remove(25);

      idades.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

      ListExtensoes.AdicionarVarios(idades, 10, 11, 12, 13);
      
      //com método de extensão:
      idades.AdicionarVarios(14, 15, 16, 17);

      idades.AdicionarVarios<int>(18, 19, 20);

      for (int i = 0; i < idades.Count; i++)
      {
        Console.WriteLine(idades[i]);
      }


    }

    static int SomarVarios(params int[] numeros)
    {
      int acumulador = 0;
      foreach (int item in numeros)
      {
        acumulador += item;
      }
      return acumulador;
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
