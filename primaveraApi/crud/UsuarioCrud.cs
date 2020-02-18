using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Json;
using primaveraApi.modelo;

namespace primaveraApi.crud
{
    public class UsuarioCRUD
    {
        Basedados bd;

        String[] colunas = new String[] { "CDU_utilizador", "CDU_nome", "CDU_senha", "CDU_documento", "CDU_perfil" };
        List<object[]> resultado = new List<object[]>();
        Usuario usuario = new Usuario();
        List<Usuario> usuario_lista = new List<Usuario>();
        String sql_select = "";

        public UsuarioCRUD()
        {
            this.bd = new Basedados();
            sql_select = "use PRIPRITERRA; SELECT " + string.Join(",", colunas) + " FROM TDU_primobUtilizador where LEN(CDU_nome) > 2 and LEN(CDU_senha) >= 4; ";
        }

        public List<Usuario> read()
        {
            List<Usuario> usuario_lista = new List<Usuario>();
            resultado = this.bd.GetObjecto(this.sql_select, colunas.Length);
            //resultado.ForEach();


            foreach (object[] obj in resultado)
            {
                usuario = new Usuario(obj[0].ToString(), obj[1].ToString(), obj[2].ToString(), obj[3].ToString(), obj[4].ToString());
                usuario_lista.Add(usuario);
            }



            return usuario_lista;
        }
        public Usuario readById(String utilizador_id)
        {


            Usuario usuario = null;
            String sql = "use PRIPRITERRA;";
            sql += "select  " + string.Join(",", colunas) + " from TDU_primobUtilizador where CDU_utilizador = '" + utilizador_id + "'";
            resultado = this.bd.GetObjecto(sql, colunas.Length);
            if (resultado.Count > 0)
            {
                object[] obj = resultado[0];
                usuario = new Usuario(obj[0].ToString(), obj[1].ToString(), obj[2].ToString(), obj[3].ToString(), obj[4].ToString());
            }
            else
            {
                usuario = null;
            }
            return usuario;

        }

        public Usuario readByNome(String utilizador_nome)
        {


            Usuario usuario = null;
            String sql = "use PRIPRITERRA;";
            sql += "select  " + string.Join(",", colunas) + " from TDU_primobUtilizador where CDU_nome = '" + utilizador_nome + "'";
            resultado = this.bd.GetObjecto(sql, colunas.Length);
            if (resultado.Count > 0)
            {
                object[] obj = resultado[0];
                usuario = new Usuario(obj[0].ToString(), obj[1].ToString(), obj[2].ToString(), obj[3].ToString(), obj[4].ToString());
            }
            else
            {
                usuario = null;
            }
            return usuario;

        }
        public bool create(Usuario usuario)
        {
            bool rv = false ;
            String sql = "use PRIPRITERRA; insert into TDU_primobUtilizador (CDU_nome, CDU_senha, CDU_documento, CDU_perfil) " +
                         "VALUES ('" + usuario.nome + "', '" + usuario.senha + "', '" + usuario.documento + "', '" + usuario.nivel + "') ";

            rv = this.bd.ExecuteNonQuery(sql);
     
            return rv;
        }


        public bool update(Usuario usuario)
        {
            bool rv = false;
            String sql = "use PRIPRITERRA; UPDATE TDU_primobUtilizador set CDU_nome = '" + usuario.nome + "', CDU_senha = '" + usuario.senha + "', CDU_documento = '" + usuario.documento + "', CDU_perfil = '" + usuario.nivel + "' where CDU_utilizador = '" + usuario.usuario + "'";
            rv = this.bd.ExecuteNonQuery(sql);
            return rv;
        }

        public bool delete(Usuario usuario)
        {
            bool rv;
            String sql = "use PRIPRITERRA;";
            sql += "delete from TDU_primobUtilizador where CDU_utilizador = '"+ usuario.usuario +"'";
            rv = this.bd.ExecuteNonQuery(sql);
            return rv;

        }

        public Usuario login(String nome, String senha)
        {


            Usuario usuario = null;
            String sql = "use PRIPRITERRA;";
            sql += "select  " + string.Join(",", colunas) + " from TDU_primobUtilizador where CDU_nome = '" + nome +"' and CDU_senha = '"+ senha +"' ";
            resultado = this.bd.GetObjecto(sql, colunas.Length);
            if (resultado.Count > 0)
            {
                object[] obj = resultado[0];
                usuario = new Usuario(obj[0].ToString(), obj[1].ToString(), obj[2].ToString(), obj[3].ToString(), obj[4].ToString());
            } else
            {
                usuario = null;
            }
            return usuario;

        }



    }

}
