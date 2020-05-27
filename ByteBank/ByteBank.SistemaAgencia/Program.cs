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
      var enderecoArquivo = "contas.txt";

      using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.OpenOrCreate))
      using (var leitor = new StreamReader(fluxoArquivo))
      {
        while (!leitor.EndOfStream)
        {
          var linha = leitor.ReadLine();

          Console.WriteLine(linha);
        }
      }
      //var linha = leitor.ReadToEnd();

    }
  }
}
