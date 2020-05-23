using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank
{
  public class LeitordeArquivo : IDisposable
  {
    public string Arquivo { get; }

    public LeitordeArquivo(string arquivo)
    {
      Arquivo = arquivo;
      Console.WriteLine("Abrindo arquivo: " + arquivo);
      throw new FileNotFoundException();
    }

    public string LerProximaLinha()
    {
      Console.WriteLine("Lendo linha...");
      throw new IOException();
      return "Linha do arquivo";
    }

    public void Dispose()
    {
      Console.WriteLine("Fechando arquivo.");
    }

  }
}
