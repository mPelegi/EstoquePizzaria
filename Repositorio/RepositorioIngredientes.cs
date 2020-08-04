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

                    string query = string.Format("INSERT INTO INGREDIENTES (nome, custo, quantidade, grandeza) VALUES('{0}', '{1}', '{2}', '{3}')", ingredientes.Nome, ingredientes.Custo, ingredientes.Quantidade, ingredientes.Grandeza);

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

        internal bool DeleteIngrediente(Ingredientes ingredientes)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("DELETE FROM INGREDIENTES WHERE ID= {0}", ingredientes.Id);

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

        internal bool UpdateIngrediente(Ingredientes ingredientes)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("UPDATE INGREDIENTES SET NOME = '{0}', CUSTO = {1}, QUANTIDADE = {2}, GRANDEZA = {3} WHERE ID= {4}", ingredientes.Nome, ingredientes.Custo, ingredientes.Quantidade, ingredientes.Grandeza, ingredientes.Id);

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

        internal bool GetIdIngrediente(Ingredientes ingredientes)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("SELECT * FROM INGREDIENTES WHERE ID= {0}", ingredientes.Id);

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

        internal List<Ingredientes> SelectIdIngredientes(Ingredientes ingredientes)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("SELECT * FROM INGREDIENTES WHERE ID = {0}", ingredientes.Id);

                    List<Ingredientes> retorno = new List<Ingredientes>();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
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

                    string query = string.Format("SELECT GRANDEZA FROM INGREDIENTES WHERE ID = {0}", ingredientes.Id);

                    string retorno = null;

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
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
