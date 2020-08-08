using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace EstoquePizzaDLL
{
    internal class RepositorioPizza
    {
        private readonly string sqlitecon = @"DataSource = C:\Users\muril\Documents\C# Apps\EstoquePizzaDLL\bin\Debug\SQL Databases\EstoquePizzaria.db; Version = 3";

        internal bool InsertPizza(Pizza pizza)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("INSERT INTO PIZZA (tamanho, sabor, valor, custo) VALUES(@TAMANHO, @SABOR, @VALOR, @CUSTO)");

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TAMANHO", pizza.Tamanho);
                        cmd.Parameters.AddWithValue("@SABOR", pizza.Sabor);
                        cmd.Parameters.AddWithValue("@VALOR", pizza.Valor);
                        cmd.Parameters.AddWithValue("@CUSTO", pizza.Custo);

                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal bool DeletePizza(Pizza pizza)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("DELETE FROM PIZZA WHERE ID = @ID");

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", pizza.Id);

                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal double GetValorPizza(Pizza pizza)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("SELECT VALOR FROM PIZZA WHERE ID = @ID");

                    double retorno = 0;

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", pizza.Id); 
                        
                        SQLiteDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            retorno = Convert.ToDouble(dr["VALOR"]);
                        }

                        return retorno > 0 ? retorno : 0;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal int GetIdPizza()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("SELECT MAX(ID) AS LATESTID FROM PIZZA");

                    int retorno = 0;

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            retorno = Convert.ToInt32(dr["LATESTID"]);
                        }

                        return retorno > 0 ? retorno : 0;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal List<Pizza> SelectIdPizza(Pizza pizza)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("SELECT * FROM PIZZA WHERE ID = @ID");

                    List<Pizza> retorno = new List<Pizza>();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", pizza.Id);

                        SQLiteDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Pizza aux = new Pizza()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Tamanho = dr["TAMANHO"].ToString(),
                                Sabor = dr["SABOR"].ToString(),
                                Valor = Convert.ToDouble(dr["VALOR"]),
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

        internal List<Pizza> SelectPizza()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("SELECT * FROM PIZZA");

                    List<Pizza> retorno = new List<Pizza>();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            Pizza aux = new Pizza()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Tamanho = dr["TAMANHO"].ToString(),
                                Sabor = dr["SABOR"].ToString(),
                                Valor = Convert.ToDouble(dr["VALOR"]),
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

        internal bool UpdatePizza(Pizza pizza)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("UPDATE PIZZA SET TAMANHO = @TAMANHO, SABOR = @SABOR, VALOR = @VALOR, CUSTO = @CUSTO WHERE ID = @ID ", pizza.Tamanho, pizza.Sabor, pizza.Valor, pizza.Custo, pizza.Id);

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TAMANHO", pizza.Tamanho);
                        cmd.Parameters.AddWithValue("@SABOR", pizza.Sabor);
                        cmd.Parameters.AddWithValue("@VALOR", pizza.Valor);
                        cmd.Parameters.AddWithValue("@CUSTO", pizza.Custo);
                        cmd.Parameters.AddWithValue("@ID", pizza.Id);


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
