using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Criatura
    {
        public int SaudeAtual { get; set; }
        public int SaudeMaxima { get; set; }

        public Criatura(int saudeAtual, int saudeMaxima)
        {
            SaudeAtual = saudeAtual;
            SaudeMaxima = saudeMaxima;
        }
    }
}
