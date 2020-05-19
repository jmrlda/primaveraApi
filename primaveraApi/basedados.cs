using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace primaveraApi
{
    class Basedados
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        public Basedados()
        {
            using (StreamReader file = File.OpenText("./config/bd.json"))
            {
                string rv = file.ReadToEnd();
                Config config = JsonConvert.DeserializeObject<Config>(rv);

                builder.DataSource = config.datasource;
                builder.UserID = config.usuario;              // update me
                builder.Password = config.senha;
                builder.InitialCatalog = config.tabela;// update m

            }


        }

        public Basedados(String datasource, String usuario, String senha)
        {


                // Build connection string
                builder.DataSource = datasource;   // update me
                builder.UserID = usuario;              // update me
                builder.Password = senha;      // update me
          
        }


        public bool temConexao()
        {
            bool estado = false;
            try
            {             
                // Connect to SQL
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    estado = true;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return estado;
        }

       
        public List<object[]> GetObjecto(String  sql, int numColum)
        {
           String[] rv = new String[numColum];
            Object[] obj = new Object[numColum];

            List<object[]> l = new List<object[]>();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                try
                {

                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rv = new String[numColum];
                            obj = new object[numColum];

                            reader.GetValues(obj);


                            l.Add(obj);
                        }
                    }
                }
                } catch (SqlException sql_erro)
                {
                    Console.WriteLine("Ocorreu um erro");
                    Console.WriteLine(sql_erro);
                }

                connection.Close();

            }

            return l;

        }

        public bool ExecuteNonQuery(String sql)
        {
            bool rv = false;
            try
            {

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.ExecuteNonQuery();
                    rv = true;
                }
                connection.Close();

            }
            } catch (SqlException e)
            {
                Console.Error.WriteLine("[ExecuteNonQuery] Erro:");
                Console.Error.WriteLine("[ExecuteNonQuery] SQL: " + sql);

                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e);

                rv = false;
            }



            return rv;

        }

        public String ExecuteScalar(String sql)
        {
            String rv = null;
            try
            {

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                     
                        rv =  command.ExecuteScalar().ToString();
                    }
                    connection.Close();

                }
            }
            catch (SqlException e)
            {
                Console.Error.WriteLine("[ExecuteScalar] Erro:");
                Console.Error.WriteLine(e);
                rv = null;
            }



            return rv == null ? null : rv;

        }



    }
}
