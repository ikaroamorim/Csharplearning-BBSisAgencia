using Bytebank;
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
      Console.ReadLine();
    }
  }
}
