using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace EstoquePizzaDLL
{
    internal class RepositorioPedidos
    {
        private readonly string sqlitecon = @"DataSource = C:\Users\muril\Documents\C# Apps\EstoquePizzaDLL\bin\Debug\SQL Databases\EstoquePizzaria.db; Version = 3";

        internal bool InsertPedidos(Pedidos pedidos)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("INSERT INTO PEDIDOS VALUES({0}, {1}, {2})", pedidos.Id, pedidos.Id_Pizza, pedidos.Data_Pedido);

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

        internal bool DeletePedidos(Pedidos pedidos)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("DELETE FROM PEDIDOS WHERE ID = {0} AND ID_PIZZA = {1}", pedidos.Id, pedidos.Id_Pizza);

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

        internal bool UpdatePedidos(Pedidos pedidos, int novoId_Pizza) //Checar se a melhor forma
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("UPDATE PEDIDOS SET ID_PIZZA = {0} WHERE ID = {1} AND ID_PIZZA = {2} AND DATA_PEDIDO = {2}", pedidos.Id_Pizza, pedidos.Id, novoId_Pizza, pedidos.Data_Pedido);

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

        internal List<MostrarPedidos> GetPedidos()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format(@"SELECT PEDIDOS.ID, PIZZA.ID AS ID_PIZZA, PIZZA.TAMANHO, PIZZA.SABOR, PIZZA.VALOR, PEDIDOS.DATA_PEDIDO FROM PEDIDOS
                                                   INNER JOIN PIZZA ON PIZZA.ID = PEDIDOS.ID_PIZZA ");

                    List<MostrarPedidos> retorno = new List<MostrarPedidos>();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();

                        while(dr.Read())
                        {
                            MostrarPedidos aux = new MostrarPedidos()
                            {
                                Id_Pedido = Convert.ToInt32(dr["ID"]),
                                Id_Pizza = Convert.ToInt32(dr["ID_PIZZA"]),
                                Tamanho_Pizza = dr["TAMANHO"].ToString(),
                                Sabor_Pizza = dr["SABOR"].ToString(),
                                Valor_Pizza = Convert.ToDouble(dr["VALOR"])

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

        }
}
