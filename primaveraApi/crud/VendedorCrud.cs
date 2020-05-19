using primaveraApi.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primaveraApi.crud
{
    public class VendedorCrud
    {
        Basedados bd;
        String[] colunas; // = new String[]{"Cliente", "Nome", "NumContrib", "Fac_Mor"};
        List<object[]> resultado = new List<object[]>();
        Vendedor vendedor = new Vendedor();
        List<Vendedor> vendedor_lista = new List<Vendedor>();
        String sql_select = "";

        public VendedorCrud()
        {
            this.bd = new Basedados();
            colunas = new String[] { "Vendedor", "Nome", "Telefone", "Morada" };
            sql_select = " SELECT " + string.Join(",", colunas) + " FROM Vendedores;";
        }
        public List<Vendedor> read()
        {

            List<Vendedor> vendedor_lista = new List<Vendedor>();
            resultado = this.bd.GetObjecto(this.sql_select, colunas.Length);
            //resultado.ForEach();


            foreach (object[] obj in resultado)
            {
                vendedor = new Vendedor(obj[0].ToString(), obj[1].ToString(), obj[2].ToString());
                vendedor_lista.Add(vendedor);
            }



            return vendedor_lista;
        }

        public Vendedor readByVendedor(String vendedor_id)
        {


            Vendedor vendedor = null;
            String sql = " ";
            sql += "select top 1 " + string.Join(",", colunas) + " from Vendedores where vendedor = '" + vendedor_id + "'";
            resultado = this.bd.GetObjecto(sql, colunas.Length);

            foreach (object[] obj in resultado)
            {
                vendedor = new Vendedor(obj[0].ToString(), obj[1].ToString(), obj[2].ToString());
            }



            return vendedor;
        }

        public List<Vendedor> getTodosNaoRegistado()
        {

            sql_select = " SELECT " + string.Join(",", colunas) + " FROM Vendedores vend left join TDU_primobUtilizador usr  on vend.Vendedor = usr.CDU_vendedor where usr.CDU_vendedor is null";

            List<Vendedor> vendedor_lista = new List<Vendedor>();
            resultado = this.bd.GetObjecto(this.sql_select, colunas.Length);
            //resultado.ForEach();


            foreach (object[] obj in resultado)
            {
                vendedor = new Vendedor(obj[0].ToString(), obj[1].ToString(), obj[2].ToString());
                vendedor_lista.Add(vendedor);
            }



            return vendedor_lista;
        }


    }
}
