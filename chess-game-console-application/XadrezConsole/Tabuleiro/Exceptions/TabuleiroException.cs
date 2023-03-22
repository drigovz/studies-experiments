using System;

namespace tabuleiro.Exceptions
{  
    class TabuleiroException : Exception
    {
        public TabuleiroException(string mensagem) : base(mensagem)
        {
        }
    }
}
