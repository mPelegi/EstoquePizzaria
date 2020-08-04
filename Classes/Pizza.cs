using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoquePizzaDLL
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Tamanho { get; set; }
        public string Sabor { get; set; }
        public double Valor { get; set; }
        public double Custo { get; set; }
    }
}
