using System;
using System.Collections;
using System.Collections.Generic;

namespace CalculaTroco
{
    public class ItemTroco
    {
        public int Quantidade { get; set; }
        private string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            set
            {
                _tipo = value;                
            }
        }

        public int Valor { get; set; }        

        private string _especie;

        public string Especie
        {
            get { if (_tipo == "Cédula") { 
                    return "Real";
                } else
                {
                    return "Centavo";
                }
            }
            set { _especie = value; }
        }


    }

}
