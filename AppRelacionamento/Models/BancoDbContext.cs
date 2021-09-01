using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppRelacionamento.Models
{
    public class BancoDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<TipoTransacao> TipoTransacoes { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=S1189;Initial Catalog=SilvioBbAppBanco;User Id=axel; Password=axel123;");
        }
    }
}
