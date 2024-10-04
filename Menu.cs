using System;
using System.Linq;

namespace StoreManager
{
    public class Menu
    {
        public Menu()
        {
            var loja = new Loja();
            int escolha1 = 0;

            do
            {
                try
                {
                    Console.WriteLine("1 - Gerenciar carrinhos de compra\n0 - Sair\nO que você deseja fazer?");
                    escolha1 = int.Parse(Console.ReadLine());

                    switch (escolha1)
                    {
                        case 1:
                            Console.Clear();
                            GerenciarCarrinhos(loja);
                            break;
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número.");
                }

            } while (escolha1 != 0);
        }

        private void GerenciarCarrinhos(Loja loja)
        {
            int escolha2 = 0;

            do
            {
                try
                {
                    Console.WriteLine("1 - Novo carrinho\n2 - Listar carrinhos\n3 - Gerenciar carrinho existente\n4 - Sair\nO que você deseja fazer?");
                    escolha2 = int.Parse(Console.ReadLine());

                    switch (escolha2)
                    {
                        case 1:
                            Console.Clear();
                            CriarNovoCarrinho(loja);
                            break;
                        case 2:
                            Console.Clear();
                            ListarCarrinhos(loja);
                            break;
                        case 3:
                            Console.Clear();
                            GerenciarCarrinhoEspecifico(loja);
                            break;
                        case 4:
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número.");
                }

            } while (escolha2 != 4);
        }

        private void CriarNovoCarrinho(Loja loja)
        {
            Console.WriteLine("Digite seu email:");
            var email = Console.ReadLine();

            var carrinho = new CarrinhoDeCompras(loja, email);

            loja.Carrinhos.Add(carrinho);

            GerenciarCarrinho(carrinho);
        }

        private void ListarCarrinhos(Loja loja)
        {
            if (loja.Carrinhos.Count == 0)
            {
                Console.WriteLine("Nenhum carrinho criado ainda.");
            }
            else
            {
                Console.WriteLine("ID        Email do Usuário");
                foreach (var carrinho in loja.Carrinhos)
                {
                    Console.WriteLine($"{carrinho.ID}        {carrinho.UserEmail}");
                }
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        private void GerenciarCarrinhoEspecifico(Loja loja)
        {
            if (loja.Carrinhos.Count == 0)
            {
                Console.WriteLine("Nenhum carrinho disponível para gerenciar.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            loja.ListarCarrinhos();
            Console.WriteLine("Digite o ID do carrinho que você deseja gerenciar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Por favor, insira um número válido.");
                return;
            }

            var carrinho = loja.Carrinhos.FirstOrDefault(c => c.ID == id);

            if (carrinho == null)
            {
                Console.WriteLine("Carrinho não encontrado.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            GerenciarCarrinho(carrinho);
        }

        private void GerenciarCarrinho(CarrinhoDeCompras carrinho)
        {
            int opc = 0;

            Console.Clear();

            do
            {
                try
                {
                    Console.WriteLine("1 - Adicionar Produtos no Carrinho\n2 - Listar Produtos no Carrinho\n3 - Remover Produto\n4 - Esvaziar Carrinho\n5 - Voltar\nO que você deseja fazer?");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            Console.Clear();
                            carrinho.AdicionarnoCarrinho();
                            break;
                        case 2:
                            Console.Clear();
                            carrinho.ListarProdutosNoCarrinho();
                            break;
                        case 3:
                            Console.Clear();
                            RemoverProdutoDoCarrinho(carrinho);
                            break;
                        case 4:
                            Console.Clear();
                            EsvaziarCarrinho(carrinho);
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número.");
                }

            } while (opc != 5);
        }

        private void RemoverProdutoDoCarrinho(CarrinhoDeCompras carrinho)
        {
            if (carrinho.ProdutosnoCarrinho.Count == 0)
            {
                Console.WriteLine("O carrinho está vazio.");
                return;
            }

            carrinho.ListarProdutosNoCarrinho();
            Console.WriteLine("Digite o ID do produto que deseja remover:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Por favor, insira um número válido.");
                return;
            }

            var produto = carrinho.ProdutosnoCarrinho.FirstOrDefault(p => p.ID == id);

            if (produto != null)
            {
                carrinho.ProdutosnoCarrinho.Remove(produto);
                Console.WriteLine("Produto removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Produto não encontrado no carrinho.");
            }
        }

        private void EsvaziarCarrinho(CarrinhoDeCompras carrinho)
        {
            carrinho.ProdutosnoCarrinho.Clear();
            Console.WriteLine("Carrinho esvaziado com sucesso.");
        }
    }
}
