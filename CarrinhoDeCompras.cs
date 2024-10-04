using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager
{
    public class CarrinhoDeCompras
    {
        public List<Produto> ProdutosnoCarrinho = new List<Produto>();
        public string UserEmail { get; set; }
        private Loja _loja;
        public int ID { get; set; }


        public CarrinhoDeCompras(Loja loja, string email) 
        {
            _loja = loja;
            ID = loja.DetermineIDCarrinho();
            this.UserEmail = email;
        }
        public void AdicionarnoCarrinho()
        {
            var loja = _loja;

            // Exemplos de cadastro de produtos
            loja.CadastraProduto(43, "Leite 1L");
            loja.CadastraProduto(11, "Bala fini");
            loja.CadastraProduto(5, "Lâmina de barbear");
            loja.CadastraProduto(10, "Pastel de carne");

            loja.ListarProdutos();

            try
            {
                Console.WriteLine("Digite o id do produto que você deseja adicionar no carrinho: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("ID inválido. Por favor, insira um número.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }

                var produtoloja = loja.CopyCat(id);
                if (produtoloja == null)
                {
                    Console.WriteLine("Produto não encontrado.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }

                Console.Clear();
                loja.ListarProdutos();

                Console.WriteLine("Digite a quantidade que você deseja adicionar: ");
                if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
                {
                    Console.WriteLine("Quantidade inválida. Por favor, insira um número positivo.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }

                // Verifica se o estoque é suficiente
                if (produtoloja.Quantidade >= quantidade)
                {
                    // Adiciona uma nova instância do produto ao carrinho com a quantidade solicitada
                    var produtoCarrinho = new Produto(quantidade, produtoloja.Nome, loja) { ID = produtoloja.ID };

                    ProdutosnoCarrinho.Add(produtoCarrinho);
                    // Reduz o estoque do produto na loja
                    produtoloja.Quantidade -= quantidade;

                    Console.WriteLine("Produto adicionado ao carrinho com sucesso!");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Quantidade maior do que o estoque possui.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Entrada inválida, erro:\n{ex}");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ListarProdutosNoCarrinho()
        {
            Console.WriteLine("ID                   NOME                  QUANTIDADE");
            foreach(var produto in ProdutosnoCarrinho)
            {
                Console.WriteLine($"{produto.ID}                    {produto.Nome}                      {produto.Quantidade}");
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
