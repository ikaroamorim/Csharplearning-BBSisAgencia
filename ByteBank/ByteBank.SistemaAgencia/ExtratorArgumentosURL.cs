using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
      else
      {
        URL = url;
        _argumentos = url.Substring(url.IndexOf('?')+1);
      }
    }

    public string getValor(string nomeParametro)
    {
      int inicParam = _argumentos.IndexOf(nomeParametro) + nomeParametro.Length +1;
      string resposta = _argumentos.Substring(inicParam);
      // trim que não funcionou : resposta = resposta.Trim('&');
      return resposta;
    }
  }
}
