using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bruno.pmsp.domain.Entities
{
    public class Endereco : Base
    {
        [Required]
        [StringLength(50, MinimumLength=9)]
        public string CEP { get; set; }    

        [Required]
        [StringLength(50, MinimumLength=5)]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [StringLength(50, MinimumLength=5)]
        public string Complemento { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength=3)]
        public string Bairro { get; set; } 

        [Required]
        [StringLength(50, MinimumLength=3)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(50, MinimumLength=2)]
        public string Estado { get; set; }

        [ForeignKey("IdServidor")]
        public Servidor Servidor { get; set; }
        public int IdServidor { get; set; }
        public Endereco() { }
        public Endereco(int IdServidor, string CEP,string Logradouro, int Numero, string Complemento, string Bairro, string Cidade, string Estado)
        {
            this.CriadoEm = DateTime.Now;
            this.IdServidor = IdServidor;
            this.CEP = CEP;
            this.Logradouro = Logradouro;
            this.Numero = Numero;
            this.Complemento = Complemento;
            this.Bairro = Bairro;
            this.Cidade = Cidade;
            this.Estado = Estado;
        }
    }
}