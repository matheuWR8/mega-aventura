using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int RecompensaXP { get; set; }
        public int RecompensaOuro { get; set; }
        public Item RecompensaItem { get; set; }
        public List<ItemConclusaoQuest> ItensConclusaoQuest { get; set; }

        public Quest(int id, string nome, string descricao, int recompensaXp, int recompensaOuro, Item recompensaItem = null){
            ID = id;
            Nome = nome;
            Descricao = descricao;
            RecompensaXP = recompensaXp;
            RecompensaOuro = recompensaOuro;
            RecompensaItem = recompensaItem;
            ItensConclusaoQuest = new List<ItemConclusaoQuest>();
        }
    }
}
