using AppRelacionamento.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppRelacionamento.Controller
{
    class ContaController
    {
        private BancoDbContext contexto = new BancoDbContext();
        public bool CadastrarConta()
        {
            Conta conta = new Conta();

            Console.Write("Digite o Id do Cliente: ");
            int clienteId = Convert.ToInt32(Console.ReadLine());

            Cliente clienteDB = contexto.Clientes.Find(clienteId);
            
            if(clienteDB == null)
            {
                Console.WriteLine("Id fornecido não existe! Entre com um Id válido!");
                return false;
            }

            Console.Write("Digite o numero da Agencia: ");
            conta.Agencia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o numero da conta: ");
            conta.Numero = Convert.ToInt32(Console.ReadLine());

            conta.Saldo = 0;

            conta.Cliente = clienteDB;
            contexto.Contas.Add(conta);
            contexto.SaveChanges();

            Console.WriteLine("Conta cadastrada com sucesso!");
            return true;
        }

        public void ListarContas()
        {
            List<Conta> conta = contexto.Contas.Include(e => e.Cliente).ToList();
            foreach (Conta c in conta)
            {
                Console.WriteLine("Id = {0} Nome: {1} Agencia: {2} Numero: {3} Saldo: {4}", c.Id, c.Cliente.Nome, c.Agencia, c.Numero, c.Saldo);
            }
        }
        public double BuscarContaPorId(int contaId)
        {
            Conta contaDB = contexto.Contas.Find(contaId);
            return contaDB.Saldo;
            
        }
        public bool AtualizarConta()
        {
            Conta conta = new Conta();

            Console.WriteLine("Digite o Id da Conta:");
            int contaId = Convert.ToInt32(Console.ReadLine());

            var contaDB = contexto.Contas.Find(contaId);
            if(contaDB == null)
            {
                Console.WriteLine("Id fornecido não existe!");
                return false;
            }

            Console.Write("Digite o Id do Cliente: ");
            int clienteId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o numero da Agencia: ");
            conta.Agencia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o numero da conta: ");
            conta.Numero = Convert.ToInt32(Console.ReadLine());            
            
            
            contaDB.Cliente = conta.Cliente;
            contaDB.Agencia = conta.Agencia;
            contaDB.Numero = conta.Numero;

            contexto.SaveChanges();

            Console.WriteLine("Conta atualizada com sucesso!");

            return true;
        }

        public bool ExcluirConta()
        {
            Console.WriteLine("Digite o Id da Conta:");
            int contaId = Convert.ToInt32(Console.ReadLine());
            var contaDB = contexto.Contas.Find(contaId);

           if(contaDB == null)
            {
                Console.WriteLine("Id fornecido não existe!");
                return false;
            }
            
            contexto.Contas.Remove(contaDB);
            contexto.SaveChanges();

            Console.WriteLine("Conta excluida com sucesso!");
            return true;
        }

    }
}
