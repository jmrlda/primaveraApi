using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using primaveraApi.modelo;

namespace primaveraApi.crud
{
    public class EncomendaCRUD
    {

        Basedados bd;

        String[] colunas = new String[] { "CDU_encomenda", "CDU_cliente", "CDU_vendedor", "CDU_data_hora",
                                            "CDU_valor", "CDU_documento", "CDU_estado" };
        List<object[]> resultado = new List<object[]>();
        Encomenda encomenda = new Encomenda();
        List<Encomenda> encomenda_lista = new List<Encomenda>();
        String sql_select = "";

        public EncomendaCRUD()
        {
            this.bd = new Basedados();
            sql_select = "use PRIPRITERRA;"; // SELECT " + string.Join(",", colunas) + " FROM TDU_primobEncomenda;";
            //sql_select += "select enc.CDU_encomenda, enc.CDU_cliente, enc.CDU_vendedor, enc.CDU_valor,enc.CDU_data_hora, enc.CDU_documento,";
            //sql_select += "enc.CDU_estado, encItem.CDU_artigo,a.descricao, a.stkActual as quantidade, am.pvp1 as preco_unitario,";
            //sql_select += "a.unidadeVenda, mr.descricao as marca";
            //sql_select += "  from TDU_primobEncomenda as enc, TDU_primobItemEncomenda encItem, Artigo a, artigoMoeda am, Marcas mr";
            //sql_select += "  where enc.CDU_encomenda = encItem.CDU_encomenda and encItem.CDU_artigo = a.Artigo and";
            //sql_select += "    a.Marca = mr.Marca and a.artigo = am.artigo and am.moeda= 'MT' ;";

            sql_select += " select enc.CDU_encomenda, enc.CDU_cliente, enc.CDU_vendedor, enc.CDU_valor,enc.CDU_estado , enc.CDU_data_hora, enc.CDU_documento, enc.CDU_estado,";
            sql_select += " util.CDU_nome, util.CDU_senha, util.CDU_documento, util.CDU_perfil,";
            sql_select += " cli.nome, cli.NumContrib, cli.Fac_Mor,  ";
            sql_select += " encItem.CDU_artigo,a.descricao, ";
            sql_select += " a.stkActual as quantidade, am.pvp1 as preco_unitario,a.unidadeVenda, mr.descricao as marca,   a.Iva ";
            sql_select += " from TDU_primobEncomenda as enc, TDU_primobItemEncomenda encItem, TDU_primobUtilizador util, Artigo a, artigoMoeda am, Marcas mr, Clientes cli ";
            sql_select += " where enc.CDU_encomenda = encItem.CDU_encomenda and encItem.CDU_artigo = a.Artigo and ";
            sql_select += " enc.CDU_vendedor = util.CDU_utilizador and enc.CDU_cliente = cli.Cliente and ";
            sql_select += " a.Marca = mr.Marca and a.artigo = am.artigo and am.moeda = 'MT' order by CDU_encomenda; ";

        }

        public List<Encomenda> read()
        {
            resultado = this.bd.GetObjecto(this.sql_select, 22);
            //resultado.ForEach();
            Encomenda encomenda = new Encomenda();
            Cliente cliente;
            Usuario vendedor;
            Artigo artigo;
            foreach (object[] obj in resultado)
            {
                vendedor = new Usuario(obj[2].ToString(), obj[8].ToString(), obj[9].ToString(), obj[10].ToString(), obj[11].ToString());
                cliente = new Cliente(obj[12].ToString(), obj[13].ToString(), obj[14].ToString(), obj[15].ToString());
                
                encomenda = new Encomenda(obj[0].ToString(), cliente, vendedor, new List<Artigo>() , double.Parse(obj[3].ToString()), obj[4].ToString(), obj[5].ToString());
                artigo = new Artigo(obj[15].ToString(), obj[16].ToString(), double.Parse(obj[17].ToString()), obj[19].ToString(), double.Parse(obj[18].ToString()), double.Parse(obj[21].ToString()), double.Parse(obj[21].ToString()));
                if (!existe_encomenda(encomenda))
                {
                    encomenda_lista.Add(encomenda);
                }
                addArtigo(encomenda, artigo);



                //encomenda = new Encomenda(obj[0].ToString(), obj[1].ToString(), obj[2].ToString(), obj[3].ToString(), obj[4].ToString(),
                //    obj[5].ToString, obj[6]);d

                //encomenda_lista.Add(encomenda);
                Console.WriteLine(obj);
            }



            return encomenda_lista;
        }

        bool existe_encomenda(Encomenda encomenda)
        {
            foreach ( Encomenda enc in encomenda_lista)
            {
                if ( enc.encomenda == encomenda.encomenda)
                {
                    return true;
                }
            }

            return false;
        }

        bool existe_artigo(Artigo artigo)
        {
            return false;
        }


        bool addArtigo(Encomenda encomenda, Artigo artigo)
        {
            foreach (Encomenda enc in encomenda_lista)
            {
                if (enc.encomenda == encomenda.encomenda)
                {
                    enc.artigos.Add(artigo);
                    return true;
                }
            }

            return false;
        }
    }


        
}
