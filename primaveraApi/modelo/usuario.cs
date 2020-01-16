using System;


namespace primaveraApi.modelo
{
    public class Usuario
    {
        public String usuario { get; set; }
        public String nome { get; set; }

        public String senha { get; set; }
        public String documento { get; set; }
        public String nivel { get; set; }

        public Usuario()
        {

        }

        public Usuario(String usuario, String nome, String senha, String documento, String nivel)
        {
            this.usuario = usuario;
            this.nome = nome;
            this.senha = senha;
            this.documento = documento;
            this.nivel = nivel;
        }



        public void info()
        {
            Console.WriteLine("usuario: " + this.usuario);
            Console.WriteLine("nome: " + this.nome);
            Console.WriteLine("documento: " + this.documento);
            Console.WriteLine("nivel: " + this.nivel);

        }

    }
}
