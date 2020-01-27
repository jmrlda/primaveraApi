using primaveraApi.modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Json;
namespace primaveraApi.crud
{
    public class ArtigoCRUD
    {
        Basedados bd;
        String[] colunas = new String[]{"a.artigo", "a.descricao", "a.STKActual", "a.unidadeVenda", "am.PVP1", "a.iva", "a.iva"};
        List<object[]> resultado = new List<object[]>();
        Artigo artigo = new Artigo();
        List<Artigo> artigo_lista = new List<Artigo>();
       String sql_select = "";

        public ArtigoCRUD()
        {
             this.bd = new Basedados();
            sql_select = "use PRIPRITERRA; SELECT " + string.Join(",", colunas) + " FROM Artigo a, ArtigoMoeda am where a.STKActual > 0.0 and a.artigo = am.Artigo and am.Moeda = 'MT';";
        }

        public List<Artigo> read()
        {
            List<Artigo> artigo_lista = new  List<Artigo>();
          resultado = this.bd.GetObjecto(this.sql_select, colunas.Length);
            //resultado.ForEach();


            foreach(object[] obj in resultado)
            {
                artigo = new Artigo(obj[0].ToString(), obj[1].ToString(), double.Parse(obj[2].ToString()),
                    obj[3].ToString(), double.Parse(obj[4].ToString()), 
                    double.Parse(obj[5].ToString()), double.Parse(obj[6].ToString())
                );

                artigo_lista.Add(artigo);
            }
            
            


            return artigo_lista;
        }

    }

}
