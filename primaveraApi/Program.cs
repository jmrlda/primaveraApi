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
            //ClienteCRUD clienteCrud = new ClienteCRUD();
            //UsuarioCRUD usuarioCrud = new UsuarioCRUD();
            Init.TabelaUtilizador();
            Init.TabelaEncomenda();
            Init.TabelaItemEncomenda();

            Usuario usuario = new Usuario("", "guirruta", "12345", "vd1", "vendedor");
            UsuarioCRUD usuarioCRUD = new UsuarioCRUD();
            //usuarioCRUD.create(usuario);
            //usuario = usuarioCRUD.login("der", "121212");
            //if (usuario != null)
            //{
            //    usuario.info();

            //} else
            //{
            //    Console.WriteLine("Erro de login");
            //}

            //usuario = usuarioCRUD.readById("276D1CB0-6C8F-4078-8904-2E119D13B4FB");
            //if (usuario != null)
            //{
            //    usuario.info();

            //}
            //else
            //{
            //    Console.WriteLine("Erro de login");
            //}

            EncomendaCRUD encomendaCrud = new EncomendaCRUD();
            List<Encomenda> lista_encomenda =  encomendaCrud.read();


            Console.ReadKey(true);


        

    }
    }
}
