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
        // Cores
        private static ConsoleColor corLegendaTabuleiro = ConsoleColor.Cyan;
        private static ConsoleColor corFundoPadrao = ConsoleColor.Black;
        private static ConsoleColor corTextoPadrao = ConsoleColor.White;
        private static ConsoleColor corPecasPretas = ConsoleColor.Yellow;
        private static ConsoleColor corFundoAlterado = ConsoleColor.DarkGray;
        private static ConsoleColor corTextoDestaque = ConsoleColor.Red;
        private static ConsoleColor corInformacoes = ConsoleColor.Green;

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tabuleiro);
            imprimirPecasCapturadas(partida);
            Console.ForegroundColor = corInformacoes;
            Console.Write("\nTurno: ");
            Console.ForegroundColor = corTextoPadrao;
            Console.WriteLine(partida.Turno);
            Console.ForegroundColor = corInformacoes;
            Console.Write("Aguardando jogada: ");
            Console.ForegroundColor = corTextoPadrao;
            if (partida.JogadorAtual == Cor.Preta) Console.ForegroundColor = corPecasPretas;
            else Console.ForegroundColor = corTextoPadrao;
            Console.WriteLine(partida.JogadorAtual);
            Console.ForegroundColor = corTextoPadrao;

            if (partida.Xeque)
            {
                Console.WriteLine("Xeque!");
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.ForegroundColor = corTextoDestaque;
            Console.WriteLine("Peças capturadas:");
            Console.ForegroundColor = corTextoPadrao;
            Console.Write("Brancas: ");
            imprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.ForegroundColor = corPecasPretas;
            Console.Write("Pretas: ");
            imprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = corTextoPadrao;
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[ ");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            Console.BackgroundColor = corFundoPadrao;
            Console.ForegroundColor = corTextoPadrao;
            for (int i = 0; i < tabuleiro.NumLinhas; i++)
            {
                Console.ForegroundColor = corLegendaTabuleiro;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = corTextoPadrao;
                for (int j = 0; j < tabuleiro.NumColunas; j++)
                {
                    ImprimirPeca(tabuleiro.GetPeca(i, j));
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = corLegendaTabuleiro;
            Console.WriteLine("  a b c d e f g h\n");
            Console.ForegroundColor = corTextoPadrao;
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            Console.BackgroundColor = corFundoPadrao;
            Console.ForegroundColor = corTextoPadrao;

            for (int i = 0; i < tabuleiro.NumLinhas; i++)
            {
                Console.ForegroundColor = corLegendaTabuleiro;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = corTextoPadrao;
                for (int j = 0; j < tabuleiro.NumColunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = corFundoAlterado;
                    } else
                    {
                        Console.BackgroundColor = corFundoPadrao;
                    }
                    ImprimirPeca(tabuleiro.GetPeca(i, j));
                    Console.BackgroundColor = corFundoPadrao;
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = corLegendaTabuleiro;
            Console.WriteLine("  a b c d e f g h\n");
            Console.ForegroundColor = corTextoPadrao;
            Console.BackgroundColor = corFundoPadrao;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            if (s == null || s == "") throw new TabuleiroException("Digite uma posição válida!");
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    Console.ForegroundColor = corPecasPretas;
                    Console.Write(peca);
                    Console.ForegroundColor = corTextoPadrao;
                }
                Console.Write(" ");
            }
        }
    }
}
