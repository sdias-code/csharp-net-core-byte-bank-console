using System;
using System.Collections.Generic;
using System.Text;

namespace AppRelacionamento.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public Conta Conta { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }        

    }
}
