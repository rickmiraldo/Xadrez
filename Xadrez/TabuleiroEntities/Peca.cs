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

        public abstract bool[,] MovimentosPossiveis();

        public void IncrementarQtdeMovimento()
        {
            QtdeMovimentos++;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] matriz = MovimentosPossiveis();
            for (int i = 0; i < Tabuleiro.NumLinhas; i++)
            {
                for (int j = 0; j < Tabuleiro.NumColunas; j++)
                {
                    if (matriz[i, j]) return true;
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
    }
}
