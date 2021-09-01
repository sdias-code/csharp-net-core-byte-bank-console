using AppRelacionamento.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppRelacionamento.Controller
{
    class TransacaoController
    {
        private BancoDbContext contexto = new BancoDbContext();        

        public bool Depositar()
        {
            Transacao transacao = new Transacao();

            Console.WriteLine("Digite o Id da Conta: ");
            int contaId = Convert.ToInt32(Console.ReadLine());

            Conta contaDB = contexto.Contas.Find(contaId);
            if (contaDB == null)
            {
                Console.WriteLine("Id fornecido não existe!");
                return false;
            }

            transacao.TipoTransacao = contexto.TipoTransacoes.Find(1);

            Console.WriteLine("Digite um valor para depósito: ");
            double valor = Convert.ToDouble(Console.ReadLine());
            // double valorDB = contaDB.Saldo;

            if(valor <= 0)
            {
                Console.WriteLine("Valor 0 ou negativo não é permitido!");
                return false;
            }

            double SaldoTotal =  contaDB.Saldo += valor;

            transacao.Data = DateTime.Now;
            transacao.Conta = contexto.Contas.Find(contaId);
            transacao.Valor = valor;
            contaDB.Saldo = SaldoTotal;

            contexto.Transacoes.Add(transacao);
            contexto.SaveChanges();

            Console.WriteLine("Deposito concluído com sucesso!");

            return true;
        }

        public bool Retirar()
        {
            Transacao transacao = new Transacao();                      

            Console.WriteLine("Digite o Id da Conta: ");
            int contaId = Convert.ToInt32(Console.ReadLine());

            Conta contaDB = contexto.Contas.Find(contaId);
            if (contaDB == null)
            {
                Console.WriteLine("Id fornecido não existe!");
                return false;
            }

            transacao.TipoTransacao = contexto.TipoTransacoes.Find(2);

            Console.WriteLine("Digite um valor para retirada: ");
            double valor = Convert.ToDouble(Console.ReadLine());
            

            if (valor <= 0)
            {
                Console.WriteLine("Valor 0 ou negativo não é permitido!");
                return false;
            }

            double saldoAtual = contaDB.Saldo;

            if(valor > saldoAtual)
            {
                Console.WriteLine("O valor a ser retirado é maior que o saldo em conta!");
                return false;
            }

            double saldoTotal = saldoAtual - valor;

            transacao.Data = DateTime.Now;
            transacao.Conta = contexto.Contas.Find(contaId);
            transacao.Valor = valor;
            contaDB.Saldo = saldoTotal;

            contexto.Transacoes.Add(transacao);
            contexto.SaveChanges();

            Console.WriteLine("Saque concluído com sucesso!");

            return true;
        }

        public void MaiorDeposito()
        {


            double maiorValor = contexto.Transacoes.Max(contexto => contexto.Valor);            

            Console.WriteLine("O maior valor depositado foi de: R$ " + maiorValor + " reais.");
            Console.WriteLine();

        }

        
    }
}
