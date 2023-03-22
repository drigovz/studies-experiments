using tabuleiro.Exceptions;

namespace tabuleiro
{
    class Tabuleiro
    { 
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool ExistePecaNaPosicao(Posicao pos)
        {
            ValidaPosicao(pos);
            return peca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePecaNaPosicao(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }

            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            else
            {
                Peca p = peca(pos);
                p.posicao = null;
                pecas[pos.linha, pos.coluna] = null;
                return p;
            }
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ValidaPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!!");
            }
        }
    }
}
