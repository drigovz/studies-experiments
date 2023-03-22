using tabuleiro;
using tabuleiro.Enums;
using Xadrez;

namespace XadrezConsole.Xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez Partida;
         
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != this.cor;
        }

        private bool Livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] MovimentosPosiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.DefinirValores(posicao.linha - 1, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 2, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // jogada especial - en passant 
                if (posicao.linha == 3)
                {
                    Posicao posicaoEsquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.PosicaoValida(posicaoEsquerda) && ExisteInimigo(posicaoEsquerda) && tab.peca(posicaoEsquerda) == Partida.PecaVulneravelEnPassant)
                    {
                        mat[posicaoEsquerda.linha - 1, posicaoEsquerda.coluna] = true;
                    }

                    Posicao posicaoDireita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.PosicaoValida(posicaoDireita) && ExisteInimigo(posicaoDireita) && tab.peca(posicaoDireita) == Partida.PecaVulneravelEnPassant)
                    {
                        mat[posicaoDireita.linha - 1, posicaoDireita.coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(posicao.linha + 1, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 2, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // jogada especial - en passant 
                if (posicao.linha == 4)
                {
                    Posicao posicaoEsquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.PosicaoValida(posicaoEsquerda) && ExisteInimigo(posicaoEsquerda) && tab.peca(posicaoEsquerda) == Partida.PecaVulneravelEnPassant)
                    {
                        mat[posicaoEsquerda.linha + 1, posicaoEsquerda.coluna] = true;
                    }

                    Posicao posicaoDireita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.PosicaoValida(posicaoDireita) && ExisteInimigo(posicaoDireita) && tab.peca(posicaoDireita) == Partida.PecaVulneravelEnPassant)
                    {
                        mat[posicaoDireita.linha + 1, posicaoDireita.coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
