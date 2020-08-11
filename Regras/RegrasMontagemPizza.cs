using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoquePizzaDLL
{
    public class RegrasMontagemPizza
    {
        private RepositorioMontagemPizza repositorioMontagemPizza;

        public RegrasMontagemPizza()
        {
            repositorioMontagemPizza = new RepositorioMontagemPizza();
        }

        public bool InserirMontagemPizza(MontagemPizza montagemPizza)
        {
            try
            {
                bool retorno = false;

                if (ValidaMontagemPizza(montagemPizza))
                {
                    retorno = repositorioMontagemPizza.InsertMontagemPizza(montagemPizza);
                }

                return retorno;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private bool ValidaMontagemPizza(MontagemPizza montagemPizza)
        {
            if (montagemPizza.Id_Ingrediente <= 0 || montagemPizza.Id_Pizza <= 0 || montagemPizza.Qnt_Ingrediente <= 0)
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
