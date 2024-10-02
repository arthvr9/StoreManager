using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager
{
    public class CarrinhoDeCompras
    {
        public List<Produto> ProdutosnoCarrinho = new List<Produto>();
        public string UserEmail { get; set; }
        private Loja _loja;

        public CarrinhoDeCompras(Loja loja) 
        {
            _loja = loja;
        }


        public void AdicionarnoCarrinho()
        {
            var loja = _loja;

            ///Exemplos
            loja.CadastraProduto(43, "Leite 1L");
            loja.CadastraProduto(11, "Bala fini");
            loja.CadastraProduto(5, "Lâmina de barbear");
            loja.CadastraProduto(10, "Pastel de carne");

            loja.ListarProdutos();

            Console.WriteLine("Digite o id do produto que você deseja adicionar no carrinho: ");
            var id = int.Parse(Console.ReadLine());
            var produtocarrinho = loja.CopyCat(id);

            Console.WriteLine("Digite a quantidade que você deseja adicionar: ");
            var quantidade = int.Parse(Console.ReadLine());

            produtocarrinho.Quantidade = quantidade;

            var produtofinal = loja.ReduzirEstoque(produtocarrinho);


            if (produtofinal)
            {
                ProdutosnoCarrinho.Add(produtocarrinho);
            }
            else
            {
                Console.WriteLine("Quantidade maior do que o estoque possui.");
            }
        }

        public void ListarProdutosNoCarrinho()
        {
            Console.WriteLine("ID                   NOME                  QUANTIDADE");
            foreach(var produto in ProdutosnoCarrinho)
            {
                Console.WriteLine($"{produto.ID}                    {produto.Nome}                      {produto.Quantidade}");
            }
        }
    }
}
