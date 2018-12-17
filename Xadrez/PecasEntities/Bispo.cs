using System;
using System.Collections.Generic;
using System.Text;
using Xadrez.TabuleiroEntities;
using Xadrez.TabuleiroEntities.Enums;

namespace Xadrez.PecasEntities
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.NumLinhas, Tabuleiro.NumColunas];

            Posicao pos = new Posicao(0, 0);

            // NO
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor) break;
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }
            // NE
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor) break;
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }
            // SE
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor) break;
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }
            // SO
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor) break;
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            return matriz;
        }
    }
}
