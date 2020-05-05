using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primaveraApi.load
{
    public class Init
    {

        public static void TabelaUtilizador()
        {
            String sql = "use PRIPRITERRA; create table dbo.TDU_primobUtilizador ( CDU_utilizador uniqueidentifier default (newId()) primary key not null," +
                " CDU_nome nvarchar(50) unique , CDU_senha nvarchar(200), CDU_documento nvarchar(16), CDU_perfil nvarchar(16), CDU_vendedor nvarchar(3) unique,  " +
                        "foreign key(CDU_vendedor) references Vendedores(vendedor))";
            Basedados bd = new Basedados();
            bool rv = bd.ExecuteNonQuery(sql);
        }


        public static void TabelaEncomenda()
        {
            String sql = "use PRIPRITERRA;   create table dbo.TDU_primobEncomenda ( CDU_encomenda uniqueidentifier default (newId()) primary key not null unique," +
                        "CDU_cliente nvarchar(12), CDU_vendedor nvarchar(3)," +
                        "CDU_data_hora  Datetime default ( GETUTCDATE()), CDU_valor float, CDU_documento nvarchar(16), CDU_estado nvarchar(16)," +
                        "foreign key(CDU_cliente) references Clientes(Cliente)," +
                        "foreign key(CDU_vendedor) references  Vendedores(vendedor))";
            Basedados bd = new Basedados();
            bool rv = bd.ExecuteNonQuery(sql);
        }

        public static void TabelaItemEncomenda()
        {
            String sql = "use PRIPRITERRA; " +
                "create table dbo.TDU_primobItemEncomenda( CDU_encomenda uniqueidentifier not null unique , CDU_artigo nvarchar(48) not null, CDU_valor_unit float not null," +
                " CDU_quantidade float, CDU_valor_total float," +
                "constraint encomenda_fk foreign key (CDU_encomenda) references TDU_primobEncomenda(CDU_encomenda)," +
                " constraint artigo_fk foreign key (CDU_artigo) references Artigo(Artigo)," +
                " constraint itemEncomenda_pk primary key (CDU_encomenda, CDU_artigo))";


            Basedados bd = new Basedados();
            bool rv = bd.ExecuteNonQuery(sql);
        }



    }


}
