using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Local
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Item ItemParaEntrar { get; set; }
        public Quest QuestDisponivel { get; set; }
        public Monstro MonstroPresente { get; set; }
        public Local LocalAoNorte { get; set; }
        public Local LocalAoLeste { get; set; }
        public Local LocalAoSul { get; set; }
        public Local LocalAoOeste { get; set; }

        public Local(int id, string nome, string descricao, Item itemPEntrar = null, Quest questDisponivel = null, Monstro monstroPresente = null)
        {
            ID = id;
            Nome = nome;
            Descricao = descricao;
            ItemParaEntrar = itemPEntrar;
            QuestDisponivel = questDisponivel;
            MonstroPresente = monstroPresente;
        }
    }
}
