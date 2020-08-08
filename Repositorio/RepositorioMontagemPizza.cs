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

                    string query = string.Format("INSERT INTO MONTAGEMPIZZA VALUES(@ID_PIZZA, @ID_INGREDIENTE, @QNT_INGREDIENTE)", montagemPizza.Id_Pizza, montagemPizza.Id_Ingrediente, montagemPizza.Qnt_Ingrediente);

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_PIZZA", montagemPizza.Id_Pizza);
                        cmd.Parameters.AddWithValue("@ID_INGREDIENTE", montagemPizza.Id_Ingrediente);
                        cmd.Parameters.AddWithValue("@QNT_INGREDIENTE", montagemPizza.Qnt_Ingrediente);

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

                    string query = string.Format("UPDATE MONTAGEMPIZZA SET QNT_INGREDIENTE = @QNT_INGREDIENTE WHERE ID_PIZZA = @ID_PIZZA AND ID_INGREDIENTE = @ID_INGREDIENTE");

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@QNT_INGREDIENTE", montagemPizza.Qnt_Ingrediente);
                        cmd.Parameters.AddWithValue("@ID_PIZZA", montagemPizza.Id_Pizza);
                        cmd.Parameters.AddWithValue("@ID_INGREDIENTE", montagemPizza.Id_Ingrediente);
                        
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

                    string query = string.Format("DELETE FROM MONTAGEMPIZZA WHERE ID_PIZZA = @ID_PIZZA AND ID_INGREDIENTE = @ID_INGREDIENTE");

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_PIZZA", montagemPizza.Id_Pizza);
                        cmd.Parameters.AddWithValue("@ID_INGREDIENTE", montagemPizza.Id_Ingrediente);

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
