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
    }
}
