﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank.Funcionarios
{
  public class Desenvolvedor : Funcionario
  {
    public Desenvolvedor(string cpf) : base(cpf, 3500)
    {
       
    }

    public override void AumentarSalario()
    {
      Salario *= 1.05;
    }

    internal protected override double getBonificacao()
    {
      return Salario * 0.25;
    }
  }
}
