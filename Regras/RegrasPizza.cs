using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoquePizzaDLL
{
    public class RegrasPizza
    {
        private RepositorioPizza repositorioPizza;

        public RegrasPizza()
        {
            repositorioPizza = new RepositorioPizza();
        }

        public bool InserirPizza(Pizza pizza)
        {
            try
            {
                bool retorno = false;

                if (ValidaPizza(pizza))
                {
                    retorno = repositorioPizza.InsertPizza(pizza);
                }

                return retorno;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Pizza> ListarPizzas()
        {
            try
            {
                return repositorioPizza.SelectPizza();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Pizza> ListarPizzasId(Pizza pizza)
        {
            try
            {
                return repositorioPizza.SelectIdPizza(pizza);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public double RetornaValorPizza(Pizza pizza)
        {
            try
            {
                return repositorioPizza.GetValorPizza(pizza);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int RetornaUltimoIdPizza()
        {
            try
            {
                return repositorioPizza.GetIdPizza();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private bool ValidaPizza(Pizza pizza)
        {
            if (pizza.Id <= 0)
            {
                return false;
            }
            else if(pizza.Tamanho == null)
            {
                return false;
            }
            else if(pizza.Sabor == null)
            {
                return false;
            }
            else if(pizza.Valor <= 0)
            {
                return false;
            }
            else if(pizza.Custo <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
