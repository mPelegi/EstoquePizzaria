using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoquePizzaDLL
{
    public class RegrasPedidos
    {
        private RepositorioPedidos repositorioPedidos;

        public RegrasPedidos()
        {
            repositorioPedidos = new RepositorioPedidos();
        }

        public List<MostrarPedidos> ListarPedidos()
        {
            try
            {
                return repositorioPedidos.GetPedidos();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool InserirNovoPedido (Pedidos pedidos)
        {
            try
            {
                bool retorno = false;

                if(ValidaNovoPedido(pedidos))
                {
                    retorno = repositorioPedidos.InsertPedidos(pedidos);
                }

                return retorno;
            }
            catch (Exception e)
            {
                throw;                
            }
        }

        #region Validacoes
        private bool ValidaNovoPedido(Pedidos pedidos)
        {
            if(pedidos.Id <= 0)
            {
                return false;
            }
            else if(pedidos.Id_Pizza <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}

