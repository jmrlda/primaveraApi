using System;


namespace primaveraApi.modelo
{
   public class Cliente
    {

        public String cliente { get; set; }
        public String nome { get; set; }
        public String numContrib { get; set; }
        public String endereco { get; set; }
        public Boolean anulado { get; set; }
        public int tipoCred { get; set; }
        public Double totalDeb { get; set; }
        public Double encomendaPendente { get; set; }
        public Double vendaNaoConvertida { get; set; }
        public Double limiteCredito { get; set; }
        public String imagemBuffer { get; set; }

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
        public Cliente(String cliente, String nome, String numContrib, String endereco, Boolean anulado, int tipoCred, Double totalDeb, Double encomendaPendente, Double vendaNaoConvertida, Double limiteCred)
        {
            this.cliente = cliente;
            this.nome = nome;
            this.numContrib = numContrib;
            this.endereco = endereco;
            this.anulado = anulado;
            this.tipoCred = tipoCred;
            this.totalDeb = totalDeb;
            this.encomendaPendente = encomendaPendente;
            this.vendaNaoConvertida = vendaNaoConvertida;
            this.limiteCredito = limiteCred;


        }
        public Cliente(String cliente, String nome, String numContrib, String endereco, Boolean anulado, int tipoCred, Double totalDeb, Double encomendaPendente, Double vendaNaoConvertida, Double limiteCred, String imagemBuffer)
        {
            this.cliente = cliente;
            this.nome = nome;
            this.numContrib = numContrib;
            this.endereco = endereco;
            this.anulado = anulado;
            this.tipoCred = tipoCred;
            this.totalDeb = totalDeb;
            this.encomendaPendente = encomendaPendente;
            this.vendaNaoConvertida = vendaNaoConvertida;
            this.limiteCredito = limiteCred;
            this.imagemBuffer = imagemBuffer;


        }

        public void info()
        {
            Console.WriteLine("cliente: " + this.cliente);
            Console.WriteLine("nome: " + this.nome);
            Console.WriteLine("numContrib: " + this.numContrib);
            Console.WriteLine("endereco: " + this.endereco);
            Console.WriteLine("TipoCred: " + this.endereco);
            Console.WriteLine("anulado: " + this.anulado);
            Console.WriteLine("total deb: " + this.totalDeb);
            Console.WriteLine("encomenda pendente: " + this.encomendaPendente);
            Console.WriteLine("vendas nao convertidas: " + this.vendaNaoConvertida);
            Console.WriteLine("limiteCredito: " + this.limiteCredito);

        }

    }
}
