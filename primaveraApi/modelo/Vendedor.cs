using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primaveraApi.modelo
{
    // Modelo representando vendedores registado no primavera.
   public  class Vendedor
    {
        public String vendedor { get; set; }
        public String nome { get; set; }
        public String morada { get; set; }
        public String localidade { get; set; }
        public String telefone { get; set; }
        public String email { get; set; }

        public Vendedor()
        {


        }


        public Vendedor(String vendedor, String nome, String morada, String localidade, String telefone, String email)
        {

            this.vendedor = vendedor;
            this.nome = nome;
            this.morada = morada;
            this.localidade = localidade;
            this.telefone = telefone;
            this.email = email;

        }

        public Vendedor(String vendedor, String nome, String telefone)
        {

            this.vendedor = vendedor;
            this.nome = nome;
            this.telefone = telefone;
       

        }


        public void info()
        {
            Console.WriteLine("vendedor : " + this.vendedor);
            Console.WriteLine("nome : " + this.nome);
            Console.WriteLine("morada : " + this.morada);
            Console.WriteLine("telefone : " + this.telefone);
            Console.WriteLine("localidade : " + this.localidade);
            Console.WriteLine("email : " + this.email);
            Console.WriteLine("_________________________________ ");

        }




    }
}
