using System;
using System.Collections.Generic;
using System.Text;
using Xadrez.TabuleiroEntities;
using Xadrez.TabuleiroEntities.Enums;

namespace Xadrez.PecasEntities
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.NumLinhas, Tabuleiro.NumColunas];

            Posicao pos = new Posicao(0, 0);

            // N
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor) break;
                pos.Linha--;
            }
            // S
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor) break;
                pos.Linha++;
            }
            // E
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor) break;
                pos.Coluna++;
            }
            // O
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor) break;
                pos.Coluna--;
            }
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
