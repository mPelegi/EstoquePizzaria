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

                    string query = string.Format("INSERT INTO PEDIDOS VALUES(@ID, @ID_PIZZA, @DATA_PEDIDO)");

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", pedidos.Id);
                        cmd.Parameters.AddWithValue("@ID_PIZZA", pedidos.Id_Pizza);
                        cmd.Parameters.AddWithValue("@DATA_PEDIDO", pedidos.Data_Pedido);

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

                    string query = string.Format("DELETE FROM PEDIDOS WHERE ID = @ID AND ID_PIZZA = @ID_PIZZA");

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", pedidos.Id);
                        cmd.Parameters.AddWithValue("@ID_PIZZA", pedidos.Id_Pizza);

                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
        }

        internal bool UpdatePedidos(AtualizarPedido atualizarPedido)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(sqlitecon))
                {
                    connection.Open();

                    string query = string.Format("UPDATE PEDIDOS SET ID_PIZZA = @NOVO_ID_PIZZA WHERE ID = @ID AND ID_PIZZA = @ANTIGO_ID_PIZZA");

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NOVO_ID_PIZZA", atualizarPedido.Novo_Id_Pizza);
                        cmd.Parameters.AddWithValue("@ID", atualizarPedido.Id);
                        cmd.Parameters.AddWithValue("@ANTIGO_ID_PIZZA", atualizarPedido.Antigo_Id_Pizza);

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
                                Valor_Pizza = Convert.ToDouble(dr["VALOR"]),
                                Data_Pedido = dr["DATA_PEDIDO"].ToString()

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
