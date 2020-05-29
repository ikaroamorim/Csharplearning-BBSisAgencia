using Bytebank;
using ByteBank.Modelos.Comparadores;
using ByteBank.Modelos.Extensoes;
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
    static void UsandoReadLine()
    {

    }
    
    static void UsarStreamEntrada()
    {
      using (var fe = Console.OpenStandardInput())
      using(var fs = new FileStream("entradaConsole.txt", FileMode.Create))
      {
        var buffer = new byte[1024];

        while (true)
        {
          var bytesLidos = fe.Read(buffer, 0, 1024);

          fs.Write(buffer, 0, bytesLidos);

          fs.Flush();
          //Console.WriteLine($"Bytes lidos do console {bytesLidos}");

        }
      }

    }
    
    static void EscritaBinaria()
    {
      using (var fs = new FileStream("contaCorrente.txt", FileMode.OpenOrCreate))
      using (var escritor = new BinaryWriter(fs))
      {
        escritor.Write(456);
        escritor.Write(546544);
        escritor.Write(4000.50);
        escritor.Write("GustavoBraga");
      }
    }

    static void LeituraBinaria()
    {
      using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
      using (var leitor = new BinaryReader(fs))
      {
        var ag = leitor.ReadInt32();
        var num = leitor.ReadInt32();
        var saldo = leitor.ReadDouble();
        var titular = leitor.ReadString();

        Console.WriteLine($"Agencia:  {ag} Numero: {num} Saldo: {saldo} Titular: {titular}");

      }
    }
  }
}