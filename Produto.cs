using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager
{
    public class Produto
    {
        public int Quantidade { get; set; }
        public string Nome {  get; set; }
        public int ID { get; set; }

        private Loja loja;
        
        public Produto(int quantidade, string nome, Loja loja)
        {
            Quantidade = quantidade;
            Nome = nome;
            this.loja = loja;
            ID = loja.DetermineID();
        }
    }
}
