using System;

public class Artigo
{
    public String artigo { get; set; }
    public String descricao { get; set; }
    public double civa { get; set; }
    public double iva { get; set; }
    public int quantidade { get; set; }
    public double preco { get; set; }
    public String unidade { get; set; }

    public Artigo()
	{
	}

    public Artigo(String artigo, String descricao, int quantidade, , String unidade, double preco, double civa, double iva)
    {
        this.artigo = artigo;
        this.descricao = descricao;
        this.quantidade = quantidade;
        this.unidade = unidade;
        this.preco = preco;
        this.civa = civa;
        this.iva = iva;
    }
}
