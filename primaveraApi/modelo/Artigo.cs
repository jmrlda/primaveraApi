using System;

namespace primaveraApi.modelo
{

    public class Artigo
    {
        public String artigo { get; set; }
        public String descricao { get; set; }
        public double civa { get; set; }
        public double iva { get; set; }
        public double quantidade { get; set; }
        public double preco { get; set; }
        public String unidade { get; set; }

        public Artigo()
        {
        }

        public Artigo(String artigo, String descricao, double quantidade, String unidade, double preco, double civa, double iva)
        {
            this.artigo = artigo;
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.unidade = unidade;
            this.preco = preco;
            this.civa = civa;
            this.iva = iva;
        }

        public void info()
        {
            Console.WriteLine("artigo: " + this.artigo);
            Console.WriteLine("descricao: " + this.descricao);
            Console.WriteLine("quantidade: " + this.quantidade);
            Console.WriteLine("unidade: " + this.unidade);
            Console.WriteLine("preco: " + this.preco);
            Console.WriteLine("civa: " + this.civa);
            Console.WriteLine("iva: " + this.iva);

        }


    }
}