using Bytebank;
using ByteBank.Modelos.Comparadores;
using ByteBank.Modelos.Extensoes;
using Humanizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ByteBank.SistemaAgencia
{
  partial class Program
  {
    public static void trabalhandoStream()
    {
      var enderecoArquivo = "contas.txt";

      using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
      {
        var buffer = new byte[1024]; //1kb

        var numeroBytesLidos = -1;

        while (numeroBytesLidos != 0)
        {
          numeroBytesLidos = fluxoArquivo.Read(buffer, 0, 1024);
          EscreverBuffer(buffer, numeroBytesLidos);
        }

      }
    }

    static void EscreverBuffer(byte[] buffer, int byteslidos)
    {
      Encoding utf8 = new UTF8Encoding();


      var texto = utf8.GetString(buffer, 0, byteslidos);

      Console.Write(texto);

      //foreach (var meuByte in buffer)
      //{
      //  Console.Write(meuByte + " ");

      //}
    }

    static void ListasSort()
    {
      //
      var cc = new ContaCorrente(1112, 11674);
      var gerenciador = new GerenciadorBonificacao();
      var gerenciadores = new List<GerenciadorBonificacao>();


      // Utilizando lists
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

      idades.Sort();

      var nomes = new List<string>()
      {
        "Guilherme",
        "Luana",
        "Wellington",
        "Ana"
      };

      nomes.Sort();

      foreach (var item in nomes)
      {
        Console.WriteLine(item);
      }

      var contas = new List<ContaCorrente>()
      {
        new ContaCorrente(134, 57480),
        new ContaCorrente(125, 47480),
        new ContaCorrente(224, 97880),
        new ContaCorrente(789, 11180),
        null,
        new ContaCorrente(921, 87111),
        new ContaCorrente(164, 31480),
        null,
        null,
        new ContaCorrente(664, 67480),
        new ContaCorrente(121, 99990)
      };

      //contas.Sort(new ComparadorCCValores());
      //IOrderedEnumerable<ContaCorrente> contasord= contas.OrderBy(item => item.Agencia);


      var contasSemNulos = contas.Where(conta => conta != null);

      //IOrderedEnumerable<ContaCorrente> contasord = contasSemNulos.OrderBy(conta => conta.Agencia);

      var contasord = contas.Where(conta => conta != null).OrderBy(conta => conta.Numero);

      foreach (var conta in contasord)
      {

        Console.WriteLine($"Agencia: {conta.Agencia} Conta: {conta.Numero}");
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
      string Surl = url.Substring(url.IndexOf('?') + 1);

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
