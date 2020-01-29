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
        public double pvp1 { get; set; }
        public bool pvp1Iva { get; set; }

        public double pvp2 { get; set; }
        public bool pvp2Iva { get; set; }
        public double pvp3 { get; set; }
        public bool pvp3Iva { get; set; }
        public double pvp4 { get; set; }
        public bool pvp4Iva { get; set; }
        public double pvp5 { get; set; }
        public bool pvp5Iva { get; set; }
        public double pvp6 { get; set; }
        public bool pvp6Iva { get; set; }


        public Artigo()
        {
        }

        public Artigo(String artigo, String descricao, double quantidade, String unidade, double preco, double civa, double iva,
            double pvp1, bool pvp1Iva, double pvp2, bool pvp2Iva, double pvp3, bool pvp3Iva, double pvp4, bool pvp4Iva, double pvp5,
            bool pvp5Iva, double pvp6, bool pvp6Iva)
        {
            this.artigo = artigo;
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.unidade = unidade;
            this.preco = preco;
            this.civa = civa;
            this.iva = iva;
            this.pvp1 = pvp1;
            this.pvp1Iva = pvp1Iva;
            this.pvp2 = pvp2;
            this.pvp2Iva = pvp2Iva;
            this.pvp3 = pvp3;
            this.pvp3Iva = pvp3Iva;
            this.pvp4 = pvp4;
            this.pvp4Iva = pvp4Iva;
            this.pvp5 = pvp5;
            this.pvp5Iva = pvp5Iva;
            this.pvp6 = pvp6;
            this.pvp6Iva = pvp6Iva;


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
            Console.WriteLine("pvp1: " + this.pvp1);
            Console.WriteLine("pvp1Iva: " + this.pvp1Iva);
            Console.WriteLine("pvp2: " + this.pvp2);
            Console.WriteLine("pvp2Iva: " + this.pvp2Iva);
            Console.WriteLine("pvp3: " + this.pvp3);
            Console.WriteLine("pvp3Iva: " + this.pvp3Iva);
            Console.WriteLine("pvp4: " + this.pvp4);
            Console.WriteLine("pvp4Iva: " + this.pvp4Iva);
            Console.WriteLine("pvp5: " + this.pvp5);
            Console.WriteLine("pvp5Iva: " + this.pvp5Iva);
            Console.WriteLine("pvp6: " + this.pvp6);
            Console.WriteLine("pvp6Iva: " + this.pvp6Iva);


        }


    }
}