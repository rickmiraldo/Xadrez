using System;
using System.Collections.Generic;
using System.Text;
using Xadrez.TabuleiroEntities;
using Xadrez.TabuleiroEntities.Enums;

namespace Xadrez.PecasEntities
{
    class Cavalo : Peca
    {

        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.NumLinhas, Tabuleiro.NumColunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            return matriz;
        }
    }
}
