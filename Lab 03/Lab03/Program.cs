using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    class Program
    {
        /*
        1. Defina a classe “Produto” com os métodos “InformarDescrição” e “InformarPreço”.     
        2. A descrição padrão de todos os produtos deve ser “Item da loja”.
        3. Defina as classe ”Livro” e “JogoDigital” que herdam da classe “Produto” que possuam, respectivamente, as propriedades “Autor” e “Console”, e ainda a propriedade “Título”.
        4. As classes Livro e JogoDigital devem informar a descrição compondo as informações dos títulos com o autor ou console quando for o caso.
        5. Com uma classe de teste simule a compra de vários desses itens os inserindo em um array e imprima as respectivas descrições e preços
        */

        static void Main(string[] args)
        {
            List<Produto> ProdutosDaLoja = new List<Produto>();

            ProdutosDaLoja.Add(new JogoDigital("God of War", "Careca revoltado", 69.90f, "PS4" ));
            ProdutosDaLoja.Add(new Livro("O fantasma da ópera", "Sem criatividade", 40.32f, "Gaston Leroux"));
            ProdutosDaLoja.Add(new JogoDigital("Dark Souls 3", "Você morreu", 159.90f, "PC"));
            ProdutosDaLoja.Add(new JogoDigital("Iratus: Lord of the Dead", "Dark stand reverso", 50.99f, "PC"));

            ProdutosDaLoja.ForEach(item => Comprar(item));

            void Comprar(Produto produto)
            {
                produto.InformarDescricao();
                produto.InformarPreco();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }

    class Produto
    {
        public string Titulo { get; protected set; }
        public string Descricao { get; protected set; }
        public float Preco { get; protected set; }

        public virtual void InformarDescricao()
        {
            Console.WriteLine("Item da loja");
        }

        public void InformarPreco()
        {
            Console.WriteLine(Preco);
        }
    }

    class Livro : Produto
    {
        public Livro(string titulo, string descricao, float preco, string autor)
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Preco = preco;
            this.Autor = autor;
        }

        public string Autor { get; private set; }

        public override void InformarDescricao()
        {
            Console.WriteLine($"{Titulo} {Autor} \n{Descricao}");
        }
    }

    class JogoDigital : Produto
    {
        public JogoDigital(string titulo, string descricao, float preco, string _console)
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Preco = preco;
            this.console = _console;
        }

        public string console { get; private set; }

        public override void InformarDescricao()
        {
            Console.WriteLine($"{Titulo} {console} \n{Descricao}");
        }
    }
}