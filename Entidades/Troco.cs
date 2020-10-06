using System;
using System.Collections;
using System.Collections.Generic;

namespace CalculaTroco
{
    public class Troco
    {
        public string Mensagem { get; set; }
        public double VlrCompra { get; set; }
        public double VlrPago { get; set; }
        public double? VlrTroco { get; set; }
        public List<ItemTroco> ItensTroco { get; set; }
    }

}
