using System;
using tabuleiro;
using tabuleiro.Exceptions;
using Xadrez;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                 
                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();                        
                        Tela.ImprimirPartida(partida);                        

                        Console.WriteLine();
                        Console.Write("\nOrigem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosition();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).MovimentosPosiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.Write("\nDestino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosition();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException te)
                    {
                        Console.WriteLine(te.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Tela.ImprimirPartida(partida);
            }
            catch (TabuleiroException te)
            {
                Console.WriteLine(te.Message);
            }
        }
    }
}
