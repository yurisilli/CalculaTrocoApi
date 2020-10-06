using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorios
{
    public class MoedaRepository
    {
        public MoedaRepository()
        {

        }

        public int[] RetornaOpcoesMoeda()
        {
            return Moedas.Opcoes;
        }
    }
}
