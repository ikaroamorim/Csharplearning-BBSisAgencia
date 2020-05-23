using Bytebank.Sistemas;
using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank
{
  public class ParceiroComercial : IAutenticavel
  {
    private AutenticacaoHelper _autenticacoHelper = new AutenticacaoHelper();
    public string Senha { get; set; }

    public bool Autenticar(string senha)
    {
      return _autenticacoHelper.CompararSenhas(Senha, senha);
    }
  }
}
