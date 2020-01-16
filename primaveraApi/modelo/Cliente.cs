using System;


namespace primaveraApi.modelo
{
   public class Cliente
    {

        public String cliente { get; set; }
        public String nome { get; set; }
        public String numContrib { get; set; }
        public String endereco { get; set; }

        public Cliente()
        {

        }

        public Cliente(String cliente, String nome, String numContrib, String endereco)
        {
            this.cliente = cliente;
            this.nome = nome;
            this.numContrib = numContrib;
            this.endereco = endereco;
        }


        public void info()
        {
            Console.WriteLine("cliente: " + this.cliente);
            Console.WriteLine("nome: " + this.nome);
            Console.WriteLine("numContrib: " + this.numContrib);
            Console.WriteLine("endereco: " + this.endereco);

        }

    }
}
