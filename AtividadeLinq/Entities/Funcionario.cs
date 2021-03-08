using System;

namespace Entities.Funcionario
{
    class Funcionario
    {

        public String Name { get; private set; }
        public String Email { get; private set; }
        public Double Salario { get; private set; }

        public Funcionario(string name, string email, double salario)
        {
            Name = name;
            Email = email;
            Salario = salario;
        }
    }
}

	