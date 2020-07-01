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
             colunas = new String[] { "Cliente", "Nome", "NumContrib", "Fac_Mor",  "ClienteAnulado", "TipoCred", "TotalDeb", "EncomendasPendentes", "VendasNaoConvertidas", "LimiteCred" , "CDU_imagemBuffer" };
            sql_select = " SELECT " + string.Join(",", colunas) + " FROM clientes;";
        }

        public List<Cliente> read()
        {

            List<Cliente> cliente_lista = new  List<Cliente>();
          resultado = this.bd.GetObjecto(this.sql_select, colunas.Length);
            //resultado.ForEach();


            foreach(object[] obj in resultado)
            {
               // cliente = new Cliente(obj[0].ToString(), obj[1].ToString(), obj[2].ToString(), obj[3].ToString());
                cliente = new Cliente(obj[0].ToString(), obj[1].ToString(), obj[2].ToString(), obj[3].ToString(), Boolean.Parse(obj[4].ToString()), int.Parse(obj[5].ToString()),  Double.Parse(obj[6].ToString()), Double.Parse(obj[7].ToString()),Double.Parse(obj[8].ToString()), Double.Parse(obj[9].ToString()), obj[10].ToString());

                cliente_lista.Add(cliente);
            }
            


            return cliente_lista;
        }

        public bool update(Cliente cliente)
        {
            bool rv = false;
            //CDU_vendedor = '" + encomenda.vendedor.usuario + "',
            String sql = "UPDATE Clientes set CDU_imagemBuffer = '" + cliente.imagemBuffer + "' where Cliente = '" + cliente.cliente + "'";
            rv = this.bd.ExecuteNonQuery(sql);

            return rv;
        }

        public Cliente readById(String id)
        {
            sql_select = " SELECT " + string.Join(",", colunas) + " FROM clientes where Cliente= '" + id + "';";

            Cliente cliente = new Cliente();
            resultado = this.bd.GetObjecto(this.sql_select, colunas.Length);
            //resultado.ForEach();


            foreach (object[] obj in resultado)
            {
                // cliente = new Cliente(obj[0].ToString(), obj[1].ToString(), obj[2].ToString(), obj[3].ToString());
                cliente = new Cliente(obj[0].ToString(), obj[1].ToString(), obj[2].ToString(), obj[3].ToString(), Boolean.Parse(obj[4].ToString()), int.Parse(obj[5].ToString()), Double.Parse(obj[6].ToString()), Double.Parse(obj[7].ToString()), Double.Parse(obj[8].ToString()), Double.Parse(obj[9].ToString()), obj[10].ToString());

               
            }



            return cliente;
        }


    }

}
