using Entities.Funcionario;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AtividadeLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter Salary:");
            double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            List<Funcionario> lista = new List<Funcionario>();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] vetor = sr.ReadLine().Split(',');
                        string name = vetor[0];
                        string email = vetor[1];
                        double salary = double.Parse(vetor[2]);
                        lista.Add(new Funcionario(name, email, salary));
                    }
                }
                Console.WriteLine($"Email of people whose salary is more than {salario.ToString("F2", CultureInfo.InvariantCulture)}");
                var listas = lista.Where(p => p.Salario > salario).OrderBy(p => p.Email).Select(p => p.Email);
                foreach (string name in listas)
                {
                    Console.WriteLine(name);
                }
                var sum = lista.Where(p => p.Name.Substring(0, 1) == "M").Sum(p => p.Salario);
                Console.WriteLine("Sum of salary of people whose name starts with 'M': ");

            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);

            }
        }
    }
}
