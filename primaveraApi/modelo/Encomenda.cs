using System;
using System.Collections.Generic;

namespace primaveraApi.modelo
{
   public class Encomenda
    {
        public String encomenda { get; set; }
        public Cliente cliente { get; set; }
        public Usuario vendedor { get; set; }
        public List<Artigo> artigos { get; set; }
        public double valorTotal { get; set; }
        public String estado { get; set; }
        public String dataHora { get; set; }
        public String encomenda_id { get; set; }
        public String latitude { get; set; }
        public String longitude { get; set; }
        public String assinaturaImagemBuffer { get; set; }

        public Encomenda()
        {

        }

        public Encomenda( String encomenda, Cliente cliente, Usuario vendedor, List<Artigo> artigos, double valorTotal, String estado, String dataHora, String encomenda_id )
        {
            this.encomenda = encomenda;
            this.cliente = cliente;
            this.vendedor = vendedor;
            this.artigos = artigos;
            this.valorTotal = valorTotal;
            this.estado = estado;
            this.dataHora = dataHora;
            this.encomenda_id = encomenda_id;

        }


        public Encomenda(String encomenda, Cliente cliente, Usuario vendedor, List<Artigo> artigos, double valorTotal, String estado, String dataHora, String encomenda_id, String latitude, String longitude, String assinaturaImagemBuffer)
        {
            this.encomenda = encomenda;
            this.cliente = cliente;
            this.vendedor = vendedor;
            this.artigos = artigos;
            this.valorTotal = valorTotal;
            this.estado = estado;
            this.dataHora = dataHora;
            this.encomenda_id = encomenda_id;
            this.latitude = latitude;
            this.longitude = longitude;
            this.assinaturaImagemBuffer = assinaturaImagemBuffer;

        }
    }
}
