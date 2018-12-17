using System;
using System.Collections.Generic;
using System.Text;
using Xadrez.TabuleiroEntities;
using Xadrez.TabuleiroEntities.Enums;
using Xadrez.PecasEntities;

namespace Xadrez
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < tabuleiro.NumLinhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.NumColunas; j++)
                {
                    if (tabuleiro.GetPeca(i,j) == null)
                    {
                        Console.Write("- ");
                    } else
                    {
                        ImprimirPeca(tabuleiro.GetPeca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca.Cor == Cor.Branca)
            {
                Console.Write(peca);
            } else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
