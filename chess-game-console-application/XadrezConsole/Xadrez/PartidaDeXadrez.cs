using tabuleiro;
using tabuleiro.Enums;
using tabuleiro.Exceptions;
using System.Collections.Generic;
using XadrezConsole.Xadrez;
using System.Security.Cryptography;

namespace Xadrez
{
    class PartidaDeXadrez
    { 
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }
        public Peca PecaVulneravelEnPassant { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            Xeque = false;
            PecaVulneravelEnPassant = null;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQuantidadeMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }

            // roque pequeno
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);
                Peca torre = tab.RetirarPeca(origemTorre);
                torre.IncrementarQuantidadeMovimentos();
                tab.ColocarPeca(torre, destinoTorre);
            }

            // roque grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna - 1);
                Peca torre = tab.RetirarPeca(origemTorre);
                torre.IncrementarQuantidadeMovimentos();
                tab.ColocarPeca(torre, destinoTorre);
            }

            // en passant 
            if (p is Peao)
            {
                if (origem.coluna != destino.coluna && pecaCapturada == null)
                {
                    Posicao posicaoPeao;
                    if (p.cor == Cor.Branca)
                    {
                        posicaoPeao = new Posicao(destino.linha + 1, destino.coluna);
                    }
                    else
                    {
                        posicaoPeao = new Posicao(destino.linha - 1, destino.coluna);
                    }

                    pecaCapturada = tab.RetirarPeca(posicaoPeao);
                    Capturadas.Add(pecaCapturada);
                }
            }

            return pecaCapturada;
        }

        private void MudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in Capturadas)
            {
                if (peca.cor == cor)
                {
                    aux.Add(peca);
                }
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in Pecas)
            {
                if (peca.cor == cor)
                {
                    aux.Add(peca);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.RetirarPeca(destino);
            p.DecrementarQuantidadeMovimentos();
            if (pecaCapturada != null)
            {
                tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }

            tab.ColocarPeca(p, origem);

            // roque pequeno
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);
                Peca torre = tab.RetirarPeca(destinoTorre);
                torre.IncrementarQuantidadeMovimentos();
                tab.ColocarPeca(torre, origemTorre);
            }

            // roque grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna - 1);
                Peca torre = tab.RetirarPeca(destinoTorre);
                torre.IncrementarQuantidadeMovimentos();
                tab.ColocarPeca(torre, origemTorre);
            }

            // en passant 
            if (p is Peao)
            {
                if (origem.coluna != destino.coluna && pecaCapturada == PecaVulneravelEnPassant)
                {
                    Peca peao = tab.RetirarPeca(destino);

                    Posicao posicaoPeao;
                    if (p.cor == Cor.Branca)
                    {
                        posicaoPeao = new Posicao(3, destino.coluna);
                    }
                    else
                    {
                        posicaoPeao = new Posicao(4, destino.coluna);
                    }

                    tab.ColocarPeca(peao, posicaoPeao);
                }
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(jogadorAtual))
            {
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            Peca p = tab.peca(destino);

            // jogada especial promoção
            if (p is Peao)
            {
                if ((p.cor == Cor.Branca && destino.linha == 0) || (p.cor == Cor.Preta && destino.linha == 7))
                {
                    p = tab.RetirarPeca(destino);
                    Pecas.Remove(p);
                    Peca dama = new Dama(tab, p.cor);
                    tab.ColocarPeca(dama, destino);
                    Pecas.Add(dama);
                }
            }

            if (EstaEmXeque(CorAdversaria(jogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (TesteXequeMate(CorAdversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                MudaJogador();
            }

            // jogada especial - en passant
            if (p is Peao && (destino.linha == origem.linha - 2 || destino.linha == origem.linha + 2))
            {
                PecaVulneravelEnPassant = p;
            }
            else
            {
                PecaVulneravelEnPassant = null;
            }
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private Cor CorAdversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca RetornaRei(Cor cor)
        {
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = RetornaRei(cor);
            if (R == null)
            {
                throw new TabuleiroException($"Não tem rei da cor { cor } no tabuleiro!");
            }

            foreach (Peca x in PecasEmJogo(CorAdversaria(cor)))
            {
                bool[,] mat = x.MovimentosPosiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }

            foreach (Peca x in PecasEmJogo(cor))
            {
                bool[,] mat = x.MovimentosPosiveis();
                for (int i = 0; i < tab.linhas; i++)
                {
                    for (int j = 0; j < tab.colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);

                            bool testeXeque = EstaEmXeque(cor);
                            DesfazerMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosition());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(tab, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovaPeca('b', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(tab, Cor.Branca, this));

            ColocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(tab, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('g', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovaPeca('h', 7, new Peao(tab, Cor.Preta, this));
        }
    }
}
