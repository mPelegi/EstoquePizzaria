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
    }
}
