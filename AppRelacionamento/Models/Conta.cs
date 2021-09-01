using System;
using System.Collections.Generic;
using System.Text;

namespace AppRelacionamento.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public double Saldo { get; set; }            

    }
}
