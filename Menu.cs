using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager
{
    public class Menu
    { 
        public Menu()
        {
            var loja = new Loja();
            var carrinho = new CarrinhoDeCompras(loja);
            var opc = 0;

            do
            {
                Console.WriteLine("1 - Adicionar Produtos no Carrinho\n2 - Listar Produtos no Carrinho\n3 - Sair\nO Que você deseja fazer? ");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        carrinho.AdicionarnoCarrinho();
                        break;
                    case 2:
                        carrinho.ListarProdutosNoCarrinho();
                        break;
                    default:
                        break;
                }
            } while (opc != 3);
        }
    }
}
