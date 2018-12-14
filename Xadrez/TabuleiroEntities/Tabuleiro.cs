using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez.TabuleiroEntities
{
    class Tabuleiro
    {
        public int NumLinhas { get; set; }
        public int NumColunas { get; set; }
        private Peca[,] Pecas { get; set; }

        public Tabuleiro(int linhas, int colunas)
        {
            NumLinhas = linhas;
            NumColunas = colunas;
            Pecas = new Peca[NumLinhas, NumColunas];
        }

        public Peca GetPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca GetPeca(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return GetPeca(posicao) != null;
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public Peca RetirarPeca(Posicao posicao)
        {
            if (GetPeca(posicao) == null)
            {
                return null;
            }
            Peca pecaRetirada = GetPeca(posicao);
            pecaRetirada.Posicao = null;
            Pecas[posicao.Linha, posicao.Coluna] = null;
            return pecaRetirada;
        }

        public bool PosicaoEValida(Posicao posicao)
        {
            return (posicao.Linha < 0 || posicao.Linha >= NumLinhas || posicao.Coluna < 0 || posicao.Coluna >= NumColunas) ? false : true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoEValida(posicao))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
