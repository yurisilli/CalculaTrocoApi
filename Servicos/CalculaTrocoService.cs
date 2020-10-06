using CalculaTroco.Models;
using CalculaTroco.Validators;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaTroco.Services
{
    public class CalculaTrocoService
    {

        private CalculaTrocoValidator _validator;
        private CedulaRepository _cedulasRepo;
        private MoedaRepository _moedasRepo;

        public CalculaTrocoService()
        {
            _validator = new CalculaTrocoValidator();
            _cedulasRepo = new CedulaRepository();
            _moedasRepo = new MoedaRepository();
        }

        public Troco CalculaTroco(double vlrCompra, double vlrPago)
        {

            Troco result = new Troco();

            var resultadoValidador = _validator.Validar(vlrCompra, vlrPago);

            // Verifica se os valores enviados representam um cenário real
            if (resultadoValidador.Ok == false)
            {
                result.VlrCompra = vlrCompra;
                result.VlrPago = vlrPago;
                result.Mensagem = resultadoValidador.Mensagem;
                return result;
            }

            // Calcula o valor do troco a ser pago
            double vlrTroco = vlrPago - vlrCompra;

            int numero;

            result.ItensTroco = new List<ItemTroco>();

            result.VlrCompra = vlrCompra;
            result.VlrPago = vlrPago;
            result.VlrTroco = vlrTroco;

            // Obtem apenas o número inteiro do troco
            numero = (int)vlrTroco;
            result.ItensTroco.AddRange(CompoeTroco(numero, 'C'));

            // Obtem apenas o número decimal do troco
            numero = (int)Math.Round((vlrTroco - (int)vlrTroco) * 100);
            result.ItensTroco.AddRange(CompoeTroco(numero, 'M'));

            result.Mensagem = "";

            return result;

        }

        public List<ItemTroco> CompoeTroco(int valor, char tipo)
        {

            int i, quantidade;
            string descTipo = "";
            string resultado = "";
            int[] opcoes = { };

            if (tipo == 'C')
            {
                opcoes = _cedulasRepo.RetornaOpcoesCedula();
                descTipo = "Cédula";
            }
            else if (tipo == 'M')
            {
                opcoes = _moedasRepo.RetornaOpcoesMoeda();
                descTipo = "Moeda";
            };

            List<ItemTroco> itens = new List<ItemTroco>();

            i = 0;

            while (valor != 0)
            {
                quantidade = valor / opcoes[i]; // Quantidade de cédulas ou moedas
                if (quantidade != 0)
                {

                    itens.Add(new ItemTroco
                    {
                        Quantidade = quantidade,
                        Tipo = descTipo,
                        Valor = opcoes[i]
                    });

                    resultado += quantidade + " " + descTipo + "(s) de $" + opcoes[i] + "\n";
                    valor = valor % opcoes[i]; // O que ainda sobrou para ser definido
                }
                i++;
            }

            return itens;

        }

    }
}
