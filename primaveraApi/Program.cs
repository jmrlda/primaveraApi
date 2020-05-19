using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using primaveraApi.load;
using primaveraApi.crud;
using primaveraApi.modelo;

namespace primaveraApi
{
    class Program
    {
        static void Main(string[] args)
        {

            //ArtigoCRUD artigoCrud = new ArtigoCRUD();
            //artigoCrud.read();
            //ClienteCRUD clienteCrud = new ClienteCRUD();
            //UsuarioCRUD usuarioCrud = new UsuarioCRUD();

            //Init.TabelaUtilizador();
            //Init.TabelaEncomenda();
            //  Init.TabelaItemEncomenda();



            //usuario = usuarioCRUD.readById("276D1CB0-6C8F-4078-8904-2E119D13B4FB");
            //if (usuario != null)
            //{
            //    usuario.info();

            //}
            //else
            //{
            //    Console.WriteLine("Erro de login");
            //}

            //VendedorCrud vendedorCrud = new VendedorCrud();
            //Vendedor lista = vendedorCrud.readByVendedor("ALB");

            //lista.info();

            //Usuario usuario = null; // new Usuario("", "dercio.guirruta", "12345", "vd1", "vendedor", lista[1]);
            //UsuarioCRUD usuarioCRUD = new UsuarioCRUD();
            //List<Usuario> lista_usuario;
            //lista_usuario = usuarioCRUD.read();

            //usuarioCRUD.create(usuario);
            //usuario = usuarioCRUD.login("dercio.guirruta", "12345");
            //if (usuario != null)
            //{
            //    Console.WriteLine("Login sucesso");

            //    usuario.info();

            //}
            //else
            //{
            //    Console.WriteLine("Erro de login");
            //}

            //EncomendaCRUD encomendaCrud = new EncomendaCRUD();
            //List<Encomenda> lista_encomenda = encomendaCrud.read();
            // if (lista_encomenda.Count > 0)
            // {
            //     Encomenda encomenda = lista_encomenda[0];
            //     encomenda.cliente.cliente = "ABO001";
            //     encomenda.cliente.endereco = "Matola";
            //     encomenda.cliente.nome = "Aboubakar Ntakirutimana";
            //     encomenda.cliente.numContrib = "135463191";



            ////     encomendaCrud.delete(encomenda);
            // }
            //Console.ReadKey(true);




        }
    }
}
