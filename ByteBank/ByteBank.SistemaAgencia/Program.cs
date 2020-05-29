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
    static void Main(string[] args)
    {
      //var linhas3 = File.ReadAllBytes("contas.txt");
      //var linhas2 = File.ReadAllText("contas.txt");

      File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");
      
      var linhas = File.ReadAllLines("contas.txt");
      Console.WriteLine(linhas.Length);

      foreach (var linha in linhas)
      {
        Console.WriteLine(linha);
      }



      Console.WriteLine("Digite seu nome");
      var nome = Console.ReadLine();
      Console.WriteLine(nome);
/*      var enderecoArquivo = "contas.txt";
      var caminhoArquivo = "contas.csv";


      using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.OpenOrCreate))
      using (var leitor = new StreamReader(fluxoArquivo))
      {
        while (!leitor.EndOfStream)
        {
          var linha = leitor.ReadLine();
          var contaCorrente = ConvertStringCC(linha);

          //Console.WriteLine(linha);
          Console.WriteLine($"Ag: {contaCorrente.Agencia} CC: {contaCorrente.Numero} Saldo:{contaCorrente.Saldo} Titular: {contaCorrente.Titular.Nome}.");
        }
      }

      using (var fluxoArquivo2 = new FileStream(caminhoArquivo, FileMode.Create))
      using (var escritor = new StreamWriter(fluxoArquivo2))
      {
        escritor.Write("456, 78945, 4785.50, Gustavo Santos");
      }
*/
      //CriarArquivo();
      //CriarArquivoFlushing();
      //EscritaBinaria();
      //LeituraBinaria();
      //UsarStreamEntrada();
      //var linha = leitor.ReadToEnd();
    }

    static void CriarArquivoFlushing()
    {
      var caminhoNovoArquivo = "contasExportadasFlushing.csv";
      using (var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
      using (var escritor = new StreamWriter(fluxoArquivo))
      {
        for (int i = 0; i < 10000; i++)
        {
          escritor.WriteLine($"Linha {i}");

          escritor.Flush();

          Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter para adicionar mais uma");
          Console.ReadLine();
        }
      }
    }

    static void CriarArquivo()
    {
      var caminhoNovoArquivo = "contasExportadas.csv";
      using (var fluxoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
      {
        var contaComoString = "456, 78945, 4785.50, Gustavo Santos";
        var encoding = Encoding.UTF8;

        var bytes = encoding.GetBytes(contaComoString);

        fluxoArquivo.Write(bytes, 0, bytes.Length);
      }


    }

    static ContaCorrente ConvertStringCC(string linha)
    {
      var campos = linha.Split(',');

      var agencia = campos[0];
      var numero = campos[1];
      var saldo = campos[2].Replace('.',',');
      var nomeTitular = campos[3];

      var intAg = int.Parse(agencia);
      var intCC = int.Parse(numero);
      var dbSaldo = double.Parse(saldo);

      var titular = new Cliente();
      titular.Nome = nomeTitular;

      var resultado = new ContaCorrente(intAg, intCC);
      resultado.Titular = titular;
      resultado.Depositar(dbSaldo);

      return resultado;
    }
  }
}
