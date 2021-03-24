using System;

namespace Lab_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Corrente BobNelson = new Corrente("Bob Nelson", "12345", 0);
            Corrente LisaLeite = new Corrente("Lisa Leite", "65432", 0);
            Poupança Testolfo = new Poupança("Testolfo Rocha", "71717", 0);

            BobNelson.Depositar(5000);
            LisaLeite.Depositar(2000);
            Testolfo.Depositar(1500);
            BobNelson.Transferir(600, Testolfo);
            LisaLeite.Sacar(250);
            LisaLeite.Transferir(400, Testolfo);
            Testolfo.Transferir(1000, BobNelson);
            BobNelson.Sacar(900);
            BobNelson.Transferir(1500, LisaLeite);
            Testolfo.Transferir(1200, LisaLeite);
            BobNelson.Sacar(2000);
            LisaLeite.Depositar(100);
            Testolfo.Transferir(700, BobNelson);

            Console.WriteLine($"Saldo de Bob Nelson: {BobNelson.Saldo.ToString("N2")}");
            Console.WriteLine($"Saldo de Testolfo Rocha: {Testolfo.Saldo.ToString("N2")}");
            Console.WriteLine($"Saldo de Lisa Leite: {LisaLeite.Saldo.ToString("N2")}");
            Console.ReadKey();
        }
    }


    public abstract class Conta
    {
        public string NumeroDaConta { get; protected set; }
        public string NomeDoCliente { get; protected set; }
        public float Saldo { get; protected set; }

        public abstract float TaxaDoSaque { get; }
        public abstract float TaxaDaTransferencia { get; }

        public void Sacar(float valor)
        {
            if (valor <= 0 || (this.Saldo < valor + this.TaxaDoSaque * valor))
            {
                return;
            }
            this.Saldo -= (valor + this.TaxaDoSaque * valor);
        }

        public void Depositar(float valor)
        {
            if (valor <= 0)
            {
                return;
            }
            this.Saldo += valor;
        }

        public void Transferir(float valor, Conta destinario)
        {
            if (valor <= 0 || (this.Saldo < valor + valor * this.TaxaDaTransferencia))
            {
                return;
            }
            this.Saldo -= (valor + valor * this.TaxaDaTransferencia);
            destinario.Saldo += valor;
        }

    }

    public class Corrente : Conta
    {
        public override float TaxaDoSaque { get => 0.0037f; }
        public override float TaxaDaTransferencia { get => 0.0010f; }

        public Corrente(string Nome, string NumeroDaConta, float Saldo)
        {
            this.NomeDoCliente = Nome;
            this.NumeroDaConta = NumeroDaConta;
            this.Saldo = Saldo;
        }
    }


    public class Poupança : Conta
    {
        public override float TaxaDoSaque { get => 0.0020f; }
        public override float TaxaDaTransferencia { get => 0.0015f; }

        public Poupança(string Nome, string NumeroDaConta, float Saldo)
        {
            this.NomeDoCliente = Nome;
            this.NumeroDaConta = NumeroDaConta;
            this.Saldo = Saldo;
        }
    }
}