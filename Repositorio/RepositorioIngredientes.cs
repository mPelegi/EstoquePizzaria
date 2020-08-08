using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace EstoquePizzaDLL
{
    internal class RepositorioIngredientes
    {
        private readonly string sqlitecon = @"DataSource = C:\Users\muril\Documents\C# Apps\EstoquePizzaDLL\bin\Debug\SQL Databases\EstoquePizzaria.db; Version = 3";

        internal bool InsertIngrediente(Ingredientes ingredientes)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("INSERT INTO INGREDIENTES (nome, custo, quantidade, grandeza) VALUES(@NOME, @CUSTO, @QUANTIDADE, @GRANDEZA)");

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NOME", ingredientes.Nome);
                        cmd.Parameters.AddWithValue("@CUSTO", ingredientes.Custo);
                        cmd.Parameters.AddWithValue("@QUANTIDADE", ingredientes.Quantidade);
                        cmd.Parameters.AddWithValue("@GRANDEZA", ingredientes.Grandeza);

                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal bool DeleteIngrediente(Ingredientes ingredientes)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("DELETE FROM INGREDIENTES WHERE ID= @ID");

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", ingredientes.Id);

                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal bool UpdateIngrediente(Ingredientes ingredientes)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("UPDATE INGREDIENTES SET NOME = @NOME, CUSTO = @CUSTO, QUANTIDADE = @QUANTIDADE, GRANDEZA = @GRANDEZA WHERE ID = @ID");

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NOME", ingredientes.Nome);
                        cmd.Parameters.AddWithValue("@CUSTO", ingredientes.Custo);
                        cmd.Parameters.AddWithValue("@QUANTIDADE", ingredientes.Quantidade);
                        cmd.Parameters.AddWithValue("@GRANDEZA", ingredientes.Grandeza);
                        cmd.Parameters.AddWithValue("@ID", ingredientes.Id);

                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal bool GetIdIngrediente(Ingredientes ingredientes)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("SELECT * FROM INGREDIENTES WHERE ID = @ID");

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", ingredientes.Id);

                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal List<Ingredientes> GetIngredientes()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("SELECT ID, NOME FROM INGREDIENTES");

                    List<Ingredientes> retorno = new List<Ingredientes>();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Ingredientes aux = new Ingredientes()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = dr["NOME"].ToString()
                            };

                            retorno.Add(aux);
                        }

                        return retorno.Count > 0 ? retorno : null;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal List<Ingredientes> GetInfoIngredientes()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("SELECT ID, NOME, GRANDEZA FROM INGREDIENTES");

                    List<MostrarIngredientes> retorno = new List<MostrarIngredientes>();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            MostrarIngredientes aux = new MostrarIngredientes()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = dr["NOME"].ToString(),
                                Grandeza = dr["GRANDEZA"].ToString()
                            };

                            retorno.Add(aux);
                        }

                        return retorno.Count > 0 ? retorno : null;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal List<Ingredientes> SelectIdIngredientes(Ingredientes ingredientes)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("SELECT * FROM INGREDIENTES WHERE ID = @ID");

                    List<Ingredientes> retorno = new List<Ingredientes>();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", ingredientes.Id);

                        SQLiteDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Ingredientes aux = new Ingredientes()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = dr["NOME"].ToString(),
                                Quantidade = Convert.ToDouble(dr["QUANTIDADE"]),
                                Grandeza = dr["GRANDEZA"].ToString(),
                                Custo = Convert.ToDouble(dr["CUSTO"])

                            };

                            retorno.Add(aux);
                        }

                        return retorno.Count > 0 ? retorno : null;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
}

        internal string GetGrandezaIngrediente(Ingredientes ingredientes)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("SELECT GRANDEZA FROM INGREDIENTES WHERE ID = @ID");

                    string retorno = null;

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", ingredientes.Id);

                        SQLiteDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            retorno = dr["GRANDEZA"].ToString();
                        }

                        return retorno != null ? retorno : null;
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
