using System;
using System.Collections.Generic;

namespace Lab_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Usuario> clientes = new List<Usuario>();
            clientes.Add(new Usuario("Bob Nelson", 37, 78, 1.7f));
            clientes.Add(new Usuario("Testolfo Rocha", 43, 60, 1.65f));
            clientes.Add(new Usuario("Lisa Leite", 22, 92, 1.72f));
            clientes.Sort();

            foreach (Usuario item in clientes)
            {
                Console.WriteLine(item.nome);
                Console.WriteLine($"Idade: {item.idade} anos");
                Console.WriteLine($"Altura: {item.altura}m");
                Console.WriteLine($"{item.IMC} {item.GetIMCSituation(item.IMC)}");
                Console.WriteLine($"O seu peso ideal é: {item.PesoMeta}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

    class Usuario : IComparable<Usuario>
    {
        public string nome { get; private set; }
        public int idade { get; private set; }
        public float peso { get; private set; }
        public float altura { get; private set; }
        public float IMC { get => peso / (altura * altura); }
        public float PesoMeta { get => 22 * (altura * altura); }
        public Usuario(string Nome, int Idade, float Peso, float Altura)
        {
            nome = Nome;
            idade = Idade;
            altura = Altura;
            peso = Peso;
        }
        public string GetIMCSituation(float IMC)
        {
            if (IMC <= 18.4)
                return "Você está abaixo do peso.";
            if (IMC >= 18.5 && IMC <= 24.9)
                return "Parabéns, você está em seu peso normal!";
            if (IMC >= 25 && IMC <= 29.9)
                return "Você está acima de seu peso (sobrepeso).";
            if (IMC >= 30 && IMC <= 34.9)
                return "Obesidade grau I.";
            if (IMC >= 35 && IMC <= 39.9)
                return "Obesidade grau II.";
            if (IMC >= 40)
                return "Obesidade grau III e IV.";
            return null;
        }
        public int CompareTo(Usuario other)
        {
            return this.nome.CompareTo(other.nome);
        }
    }
}
