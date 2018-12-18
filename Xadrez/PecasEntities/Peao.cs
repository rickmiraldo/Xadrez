using System;
using System.Collections.Generic;
using System.Text;
using Xadrez.TabuleiroEntities;
using Xadrez.TabuleiroEntities.Enums;

namespace Xadrez.PecasEntities
{
    class Peao : Peca
    {
        private PartidaDeXadrez partida;

        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = Tabuleiro.GetPeca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool livre(Posicao pos)
        {
            return Tabuleiro.GetPeca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.NumLinhas, Tabuleiro.NumColunas];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoEValida(pos) && livre(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoEValida(pos) && livre(pos) && QtdeMovimentos == 0 && !existeInimigo(new Posicao(Posicao.Linha - 1, Posicao.Coluna)))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoEValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoEValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                // En passant
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoEValida(esquerda) && existeInimigo(esquerda) && Tabuleiro.GetPeca(esquerda) == partida.VulneravelEnPassant)
                    {
                        matriz[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoEValida(direita) && existeInimigo(direita) && Tabuleiro.GetPeca(direita) == partida.VulneravelEnPassant)
                    {
                        matriz[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            } else {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoEValida(pos) && livre(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoEValida(pos) && livre(pos) && QtdeMovimentos == 0 && !existeInimigo(new Posicao(Posicao.Linha + 1, Posicao.Coluna)))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoEValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoEValida(pos) && existeInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                // En passant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoEValida(esquerda) && existeInimigo(esquerda) && Tabuleiro.GetPeca(esquerda) == partida.VulneravelEnPassant)
                    {
                        matriz[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoEValida(direita) && existeInimigo(direita) && Tabuleiro.GetPeca(direita) == partida.VulneravelEnPassant)
                    {
                        matriz[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return matriz;
        }
    }
}
