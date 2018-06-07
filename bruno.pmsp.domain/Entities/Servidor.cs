using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bruno.pmsp.domain.Entities
{
    public class Servidor : Base
    {
        [Required(ErrorMessage="O nome completo é obrigatório.")]
        [StringLength(50, MinimumLength=3, ErrorMessage="O nome completo deve ter no minimo 3 caracteres.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage="O Estado Civil é obrigatório.")]
        [StringLength(50, MinimumLength=3, ErrorMessage="O EstadoCivil deve ter no minimo 3 caracteres.")]
        public string EstadoCivil { get; set; }

        [Required(ErrorMessage="O Genero é obrigatório.")]
        [StringLength(50, MinimumLength=3, ErrorMessage="O Genero deve ter no minimo 3 caracteres.")]
        public string Genero { get; set; }

        [Required(ErrorMessage="O RF é obrigatório.")]
        [StringLength(50, MinimumLength=7, ErrorMessage="O RF deve ter no minimo 7 caracteres.")]
        public string RF { get; set; }

        [Required(ErrorMessage="A data de nascimento é obrigatória.")]
        [DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }    

        [Required(ErrorMessage="O email é obrigatório.")]
        [DataType(DataType.EmailAddress, ErrorMessage="Favor inserir um email válido.")]
        public string Email { get; set; } 

        [Required]
        [StringLength(50, MinimumLength=7, ErrorMessage="A preferencia de contato deve ter no minimo 7 caracteres.")]
        public string PreferenciaContato { get; set; }     
        
        [ForeignKey("IdLogin")]
        public Login Login { get; set; }
        public int IdLogin { get; set; }
        public Telefone Telefones { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Vinculo> Vinculos { get; set; }

        public Servidor() { }

        public Servidor(int IdLogin, string NomeCompleto, string EstadoCivil, string Genero, string RF, DateTime DataNascimento, string Email, string PreferenciaContato)
        {
            this.CriadoEm = DateTime.Now;
            this.IdLogin = IdLogin;
            this.NomeCompleto = NomeCompleto;
            this.EstadoCivil = EstadoCivil;
            this.Genero = Genero;
            this.RF = RF;
            this.DataNascimento = DataNascimento;
            this.Email = Email;
            this.PreferenciaContato = PreferenciaContato;
        }
    }
}