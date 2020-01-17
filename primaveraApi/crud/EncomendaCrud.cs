﻿using System;
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

        public bool create(Encomenda encomenda)
        {
            insertEncomenda(encomenda);
            return false;
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
                cliente = new Cliente(obj[1].ToString(), obj[12].ToString(), obj[13].ToString(), obj[14].ToString());
                
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




        public void update(Encomenda encomenda)
        {
            bool rv = false;
            String sql = "use PRIPRITERRA; UPDATE TDU_primobEncomenda set CDU_cliente = '" + encomenda.cliente.cliente + "', CDU_vendedor = '" + encomenda.vendedor.usuario + "', CDU_valor = '" + encomenda.valorTotal.ToString().Replace(',', '.')  +
                "', CDU_documento = '" + encomenda.vendedor.documento + "' , CDU_estado = '" + encomenda.estado  + "' where CDU_encomenda = '" + encomenda.encomenda + "'";
            rv = this.bd.ExecuteNonQuery(sql);
            if (rv != false)
            {
                foreach (Artigo artigo in encomenda.artigos)
                {
                    insertItemEncomenda(encomenda.encomenda, artigo);

                }
                Console.WriteLine("actualizado encomenda sucesso");
            }

        }


        public void delete(Encomenda encomenda)
        {
            if (deleteItemEncomenda(encomenda) == true )
            {
                Console.WriteLine("itens removidos");

                if (deleteEncomenda(encomenda) == true )
                {
                    Console.WriteLine("Encomenda removido");
                }
            }
        }




        void insertEncomenda(Encomenda encomenda)
        {
            bool rv = false;
            String sql_encomenda = "use PRIPRITERRA; insert into  TDU_primobEncomenda (CDU_cliente, CDU_vendedor, CDU_valor, CDU_documento, CDU_estado) " +
                         "VALUES ('" + encomenda.cliente.cliente + "', '" + encomenda.vendedor.usuario + "', '" + encomenda.valorTotal.ToString().Replace(',','.') + "', '" + encomenda.vendedor.documento + "', 'pendente') ";

            rv = this.bd.ExecuteNonQuery(sql_encomenda);
            if (rv != false)
            {
                String encomenda_id = ultima_encomenda();
                foreach (Artigo artigo in encomenda.artigos)
                {
                    insertItemEncomenda(encomenda_id, artigo);

                }
                Console.WriteLine("inserido encomenda sucesso");
            } else
            {
                Console.WriteLine("inserido encomenda erro");

            }
        }
        bool insertItemEncomenda(String encomenda, Artigo artigo)
        {
            bool rv = false;
            String sql_encomenda = "use PRIPRITERRA; insert into TDU_primobItemEncomenda ( CDU_encomenda, CDU_artigo," +
                        " CDU_valor_unit, CDU_quantidade, CDU_valor_total) " +
                         "VALUES ('" + encomenda + "', '" + artigo.artigo + "', '" +
                         artigo.preco.ToString().Replace(',', '.') + "', '" + artigo.quantidade.ToString().Replace(',', '.') + "', '" +
                         (artigo.quantidade * artigo.preco).ToString().Replace(',', '.') + "') ";

            rv = this.bd.ExecuteNonQuery(sql_encomenda);
            if (rv == true)
            {
                Console.WriteLine("inserido item encomenda sucesso");
            }
            return rv;
        }

        bool deleteEncomenda(Encomenda encomenda)
        {

            bool rv;
            String sql = "use PRIPRITERRA;";
            sql += "delete from TDU_primobEncomenda where CDU_encomenda = '" + encomenda.encomenda + "'";
            rv = this.bd.ExecuteNonQuery(sql);

            return rv;
        }


        bool deleteItemEncomenda(Encomenda encomenda)
        {

            bool rv;
            String sql = "use PRIPRITERRA;";
            sql += "delete from TDU_primobItemEncomenda where CDU_encomenda = '" + encomenda.encomenda + "'";
            rv = this.bd.ExecuteNonQuery(sql);
            return rv;
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


        String ultima_encomenda()
        {

            string rv = null;
            string sql = "use PRIPRITERRA; SELECT TOP(1) CDU_encomenda FROM TDU_primobEncomenda ORDER BY 1 DESC";
            resultado = this.bd.GetObjecto(sql, 1);
            if ( resultado.Count > 0)
            {
                rv = resultado[0][0].ToString();
            }

            return rv;
        }

    }



}