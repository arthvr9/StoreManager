using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManager
{
    public class Loja
    {
        public List<CarrinhoDeCompras> Carrinhos { get; set; } = new List<CarrinhoDeCompras>();
        private List<Produto> _produtos { get; set; } = new List<Produto>();

        public int DetermineID()
        {
            return _produtos.Count == 0 ? 1 : _produtos.Max(p => p.ID) + 1;
        }

        public int DetermineIDCarrinho()
        {
            return Carrinhos.Count == 0 ? 1 : Carrinhos.Max(p => p.ID) + 1;
        }

        public void ListarCarrinhos()
        {
            Console.WriteLine("ID                   EMAIL");
            foreach (var carrinho in Carrinhos)
            {
                Console.WriteLine($"{carrinho.ID}                   {carrinho.UserEmail}");
            }
        }

        public void CadastraProduto(int quantidade, string nome)
        {
            Produto novoProduto = new Produto(quantidade, nome, this);
            _produtos.Add(novoProduto);
        }

        public void ListarProdutos()
        {
            Console.WriteLine("ID                   NOME                    QUANTIDADE");
            foreach (var produto in _produtos)
            {
                Console.WriteLine($"{produto.ID}                    {produto.Nome}                  {produto.Quantidade}");
            }
        }

        public Produto CopyCat(int id)
        {
            return _produtos.FirstOrDefault(p => p.ID == id);
        }
    }
}
