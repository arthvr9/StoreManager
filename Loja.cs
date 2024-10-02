using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager
{
    public class Loja
    {
        public List<CarrinhoDeCompras> Carrinhos { get; set; } = new List<CarrinhoDeCompras>();
        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public int DetermineID()
        {
            if (Produtos.Count == 0)
            {
                return 1;
            }
            else
            {
                return Produtos.Max(p => p.ID) + 1;
            }
        }



        public void CadastraProduto(int quantidade, string nome)
        {
            //Console.WriteLine("Digite o nome do produto: ");
            //var nome = Console.ReadLine();

            //Console.WriteLine("Digite a quantidade deste produto no estoque: ");
            //var quantidade = int.Parse(Console.ReadLine());


            Produto novoProduto = new Produto(quantidade, nome, this);

            Produtos.Add(novoProduto);
        }

        public void ListarProdutos()
        {
            Console.WriteLine("ID                   NOME                    QUANTIDADE");
            foreach (var produto in Produtos)
            {
                Console.WriteLine($"{produto.ID}                    {produto.Nome}                  {produto.Quantidade}");
            }
        }

        public Produto CopyCat(int id)
        {
            foreach (var produto in Produtos)
            {
                if(produto.ID == id)
                {
                    return produto;
                }
            }
            return null;
        }

        public bool ReduzirEstoque(Produto produtoreduce)
        {
            foreach(var produto in Produtos)
            {
                if (produto.ID == produtoreduce.ID)
                {
                    if(produto.Quantidade >= produtoreduce.Quantidade)
                    {
                        produto.Quantidade -= produtoreduce.Quantidade;
                        return true;
                    }
                }
            }
            return false;
        }


    }
}
