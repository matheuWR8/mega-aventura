using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestJogador
    {
        public Quest Detalhes { get; set; }
        public bool EstaCompleta { get; set; }
        public QuestJogador(Quest detalhes)
        {
            Detalhes = detalhes;
            EstaCompleta = false;
        }
    }
}
