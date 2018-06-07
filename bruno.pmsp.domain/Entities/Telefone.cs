using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bruno.pmsp.domain.Entities
{
    public class Telefone : Base
    {
        [StringLength(50, MinimumLength=11, ErrorMessage="O número deve ter no minimo 11 caracteres.")]
        public string TelefoneResidencial { get; set; }
        
        [StringLength(50, MinimumLength=12, ErrorMessage="O número deve ter no minimo 12 caracteres.")]
        public string Celular { get; set; }

        [StringLength(50, MinimumLength=12, ErrorMessage="O número deve ter no minimo 12 caracteres.")]
        public string WhatsApp { get; set; }

        [StringLength(50, MinimumLength=11, ErrorMessage="O número deve ter no minimo 11 caracteres.")]
        public string Recado { get; set; }

        [StringLength(50, MinimumLength=11, ErrorMessage="O número deve ter no minimo 11 caracteres.")]
        public string OutroTelefone { get; set; }
        
        [ForeignKey("IdServidor")]
        public Servidor Servidor { get; set; }
        public int IdServidor { get; set; }
        public Telefone() { }
        public Telefone(int IdServidor, string TelefoneResidencial, string Celular, string WhatsApp, string Recado, string OutroTelefone)
        {
            this.CriadoEm = DateTime.Now;
            this.IdServidor = IdServidor;
            this.TelefoneResidencial = TelefoneResidencial;
            this.Celular = Celular;
            this.WhatsApp = WhatsApp;
            this.Recado = Recado;
            this.OutroTelefone = OutroTelefone;
        }
    }
}