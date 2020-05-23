using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank.Funcionarios
{
  public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
  {
    private AutenticacaoHelper _autenticacoHelper = new AutenticacaoHelper();
    public string Senha { get; set; }

    public FuncionarioAutenticavel(string cpf, double salario) : base(cpf, salario)
    {

    }

    public bool Autenticar(string senha)
    {
      return _autenticacoHelper.CompararSenhas(Senha, senha);
    }
  } 
}
