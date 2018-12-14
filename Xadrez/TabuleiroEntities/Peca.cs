using System;
using System.Collections.Generic;
using System.Text;
using Xadrez.TabuleiroEntities.Enums;

namespace Xadrez.TabuleiroEntities
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = null;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QtdeMovimentos = 0;
        }
    }
}
