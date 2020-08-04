using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoquePizzaDLL
{
    public class RegrasIngredientes
    {
        private RepositorioIngredientes repositorioIngredientes;

        public RegrasIngredientes()
        {
            repositorioIngredientes = new RepositorioIngredientes();
        }

        public bool InserirIngrediente(Ingredientes ingredientes)
        {
            try
            {
                bool retorno = false;

                if (ValidaIngrediente(ingredientes))
                {
                    retorno = repositorioIngredientes.InsertIngrediente(ingredientes);
                }

                return retorno;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool DeletarIngredientes(Ingredientes ingredientes)
        {
            try
            {
                bool retorno = false;

                if(repositorioIngredientes.GetIdIngrediente(ingredientes))
                {
                    retorno = repositorioIngredientes.DeleteIngrediente(ingredientes);
                }

                return retorno;
            }
            catch (Exception e)
            {
                throw;
            }
        }



        public List<Ingredientes> ListarIngredientes()
        {
            try
            {
                return repositorioIngredientes.GetIngredientes();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Ingredientes> ListarIngredientesId(Ingredientes ingredientes)
        {
            try
            {
                return repositorioIngredientes.SelectIdIngredientes(ingredientes);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public string RetornaGrandezaIngrediente(Ingredientes ingredientes)
        {
            try
            {
                return repositorioIngredientes.GetGrandezaIngrediente(ingredientes);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private bool ValidaIngrediente(Ingredientes ingredientes)
        {
            if (ingredientes.Nome == null || ingredientes.Nome.Length > 255)
            {
                return false;
            }
            else if (ingredientes.Custo <= 0)
            {
                return false;
            }
            else if (ingredientes.Quantidade < 0)
            {
                return false;
            }
            else if (ingredientes.Grandeza == null || ingredientes.Grandeza.Length > 255)
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
