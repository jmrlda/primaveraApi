using primaveraApi.modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Json;

namespace primaveraApi.crud
{
    public class ClienteCRUD
    {
        Basedados bd;
        String[] colunas; // = new String[]{"Cliente", "Nome", "NumContrib", "Fac_Mor"};
        List<object[]> resultado = new List<object[]>();
        Cliente cliente = new Cliente();
        List<Cliente> cliente_lista = new List<Cliente>();
       String sql_select = "";

        public ClienteCRUD()
        {
             this.bd = new Basedados();
             colunas = new String[] { "Cliente", "Nome", "NumContrib", "Fac_Mor" };
            sql_select = " SELECT " + string.Join(",", colunas) + " FROM clientes;";
        }

        public List<Cliente> read()
        {

            List<Cliente> cliente_lista = new  List<Cliente>();
          resultado = this.bd.GetObjecto(this.sql_select, colunas.Length);
            //resultado.ForEach();


            foreach(object[] obj in resultado)
            {
                cliente = new Cliente(obj[0].ToString(), obj[1].ToString(), obj[2].ToString(), obj[3].ToString());
                cliente_lista.Add(cliente);
            }
            


            return cliente_lista;
        }

    }

}
