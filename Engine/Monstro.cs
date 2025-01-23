using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monstro : Criatura
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int DanoMaximo { get; set; }
        public int RecompensaXP { get; set; }
        public int RecompensaOuro { get; set; }
        public List<ItemLoot> TabelaLoot { get; set; }

        public Monstro(int saudeAtual, int saudeMaxima, int iD, string nome, int danoMaximo, int recompensaXP, int recompensaOuro) : base(saudeAtual, saudeMaxima)
        {
            ID = iD;
            Nome = nome;
            DanoMaximo = danoMaximo;
            RecompensaXP = recompensaXP;
            RecompensaOuro = recompensaOuro;
            TabelaLoot = new List<ItemLoot>();
        }
    }
}
