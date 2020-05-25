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
      int[] idades = new int[5];
      ContaCorrente[] contas = new ContaCorrente[3];

      contas[0] = new ContaCorrente(1212, 43497);
      contas[1] = new ContaCorrente(7812, 46468);
      contas[2] = new ContaCorrente(1612, 97885);

      for (int i = 0; i < contas.Length; i++)
      {
        Console.WriteLine($"Conta corrente {i} : {contas[i].Agencia} {contas[i].Numero}");
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
