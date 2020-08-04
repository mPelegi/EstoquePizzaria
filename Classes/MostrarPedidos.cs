using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoquePizzaDLL
{
    public class MostrarPedidos
    {
        public int Id_Pedido { get; set; }
        public int Id_Pizza { get; set; }
        public string Tamanho_Pizza { get; set; }
        public string Sabor_Pizza { get; set; }
        public double Valor_Pizza { get; set; }
        public string Data_Pedido { get; set; }
    }
}
