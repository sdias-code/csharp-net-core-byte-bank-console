using AppRelacionamento.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppRelacionamento.Controller
{
    class ClienteController
    {
        private BancoDbContext contexto = new BancoDbContext();
        public bool CadastrarClientes()
        {

            Cliente cliente = new Cliente();

            Console.Write("Digite o Nome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Digite o Sobrenome: ");
            cliente.Sobrenome = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Digite o Cpf: ");
            string cpfCliente = Console.ReadLine();
            
            var temCpf = contexto.Clientes.FirstOrDefault(c => c.Cpf == cpfCliente);

            if (temCpf != null)
            {
                Console.WriteLine("Já existe um cpf cadastrado! Entre com outro CPF!");

                return false;
            }
            
            cliente.Cpf = cpfCliente;
            Console.WriteLine();

            contexto.Clientes.Add(cliente);
            contexto.SaveChanges();

            Console.WriteLine("Cadastro completado com sucesso!");

            return true;
        }

        public void ListarClientes()
        {
            List<Cliente> clientes = contexto.Clientes.ToList();
            foreach (Cliente c in clientes)
            {
                Console.WriteLine("Id = {0} Nome: {1} Sobrenome: {2} CPF: {3}", c.Id, c.Nome, c.Sobrenome, c.Cpf);
            }
        }

        public bool AtualizarCliente()
        {
            Cliente cliente = new Cliente();

            Console.WriteLine("Digite o Id do usuário:");
            int clienteId = Convert.ToInt32(Console.ReadLine());

            var clienteDB = contexto.Clientes.Find(clienteId);

            if (clienteDB == null)
            {
                Console.WriteLine("Id fornecido não existe! Entre com um Id válido!");
                return false;
                
            }

            Console.Write("Digite o Nome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Digite o Sobrenome: ");
            cliente.Sobrenome = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Digite o Cpf: ");
            cliente.Cpf = Console.ReadLine();
            Console.WriteLine();


            clienteDB.Nome = cliente.Nome;
            clienteDB.Sobrenome = cliente.Sobrenome;
            clienteDB.Cpf = cliente.Cpf;

            contexto.SaveChanges();

            Console.WriteLine("Cadastro atualizado com sucesso!");
            return true;
        }

        public bool ExcluirCliente()
        {
            Console.WriteLine("Digite o Id do usuário:");
            int clienteId = Convert.ToInt32(Console.ReadLine());

            var clienteDB = contexto.Clientes.Find(clienteId);
            if(clienteDB == null)
            {
                Console.WriteLine("Registro não encontrado:");
                return false;
            }
            contexto.Clientes.Remove(clienteDB);
            contexto.SaveChanges();

            Console.WriteLine("Cliente excluído com sucesso!");

            return true;
        }

    }
}
