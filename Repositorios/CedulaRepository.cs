using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorios
{
    public class CedulaRepository
    {
        public CedulaRepository()
        {

        }

        public int[] RetornaOpcoesCedula()
        {
            return Cedulas.Opcoes;
        }

    }
}
