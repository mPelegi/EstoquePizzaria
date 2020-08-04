using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace EstoquePizzaDLL
{
    internal class RepositorioMontagemPizza
    {
        private readonly string sqlitecon = @"DataSource = C:\Users\muril\Documents\C# Apps\EstoquePizzaDLL\bin\Debug\SQL Databases\EstoquePizzaria.db; Version = 3";

        internal bool InsertMontagemPizza(MontagemPizza montagemPizza)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("INSERT INTO MONTAGEMPIZZA VALUES({0}, {1}, '{2}')", montagemPizza.Id_Pizza, montagemPizza.Id_Ingrediente, montagemPizza.Qnt_Ingrediente);

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal bool UpdateQuantidadeIngredienteMontagemPizza(MontagemPizza montagemPizza)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("UPDATE MONTAGEMPIZZA SET QNT_INGREDIENTE = '{0}' WHERE ID_PIZZA = {1} AND ID_INGREDIENTE = {2}", montagemPizza.Qnt_Ingrediente, montagemPizza.Id_Pizza, montagemPizza.Id_Ingrediente);

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal bool DeleteMontagemPizza(MontagemPizza montagemPizza)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("DELETE FROM MONTAGEMPIZZA WHERE ID_PIZZA = {0} AND ID_INGREDIENTE = {1}", montagemPizza.Id_Pizza, montagemPizza.Id_Ingrediente);

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }


    }
}
