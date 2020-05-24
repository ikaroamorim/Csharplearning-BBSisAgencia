using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
  public class ExtratorArgumentosURL
  {
    private readonly string _argumentos;
    public string URL { get; }

    public ExtratorArgumentosURL(string url)
    {
      
      if (string.IsNullOrEmpty(url))
      {
        throw new ArgumentException("O argumento url não pode ser vazio", nameof(url));
      }
      if (!url.StartsWith("https://www.bytebank.com"))
      {
        throw new ArgumentException("O site não é o do banco", nameof(url));
      }
      else
      {
        URL = url;
        _argumentos = url.Substring(url.IndexOf('?')+1);
      }
    }

    public string getValor(string nomeParametro)
    {
      string parametros = _argumentos.ToLower();
      nomeParametro = nomeParametro.ToLower();
      nomeParametro += "=";
      int inicParam = parametros.IndexOf(nomeParametro) + nomeParametro.Length;
      string resposta = parametros.Substring(inicParam);
      
      int fimParam = resposta.IndexOf('&');
      if (fimParam == -1)
      {
        return resposta;
      }
      else
      {
        resposta = resposta.Remove(fimParam);
        return resposta;
      }
    }
  }
}
