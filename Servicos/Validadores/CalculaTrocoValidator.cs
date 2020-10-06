using CalculaTroco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaTroco.Validators
{
    public class CalculaTrocoValidator
    {

        public ValidatorResultado Validar(double? vlrCompra, double? vlrPago)
        {

            ValidatorResultado resultado = new ValidatorResultado();

            if (vlrCompra == 0 || vlrCompra < 0)
            {
                resultado.Ok = false;                
                resultado.Mensagem = "O valor da compra deve ser maior que zero.";
                return resultado;
            }
            else if (vlrCompra == null)
            {
                resultado.Ok = false;
                resultado.Mensagem = "O valor da compra não pode ser nulo.";
                return resultado;
            }
            else if (vlrPago == 0 || vlrPago < 0)
            {
                resultado.Ok = false;
                resultado.Mensagem = "O valor do pagamento deve ser maior que zero.";
                return resultado;
            }
            else if (vlrCompra == null)
            {
                resultado.Ok = false;
                resultado.Mensagem = "O valor do pagamento não pode ser nulo.";
                return resultado;
            }
            else if (vlrCompra > vlrPago)
            {
                resultado.Ok = false;
                resultado.Mensagem = "O valor do pagamento deve ser maior ou igual a compra.";
                return resultado;
            }
            else if (vlrCompra - vlrPago == 0)
            {
                resultado.Ok = false;
                resultado.Mensagem = "Não existe troco a ser devolvido.";
                return resultado;
            }

            resultado.Ok = true;
            resultado.Mensagem = "";

            return resultado;

        }
    }


}
