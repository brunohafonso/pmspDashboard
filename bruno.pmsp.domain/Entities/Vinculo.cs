using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bruno.pmsp.domain.Entities
{
    public class Vinculo : Base
    {
        [Required(ErrorMessage="O vinculo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage="O vinculo deve ser maior que 0.")]
        public int Vinc { get; set; }

        [Required(ErrorMessage="O cargo é obrigatório.")]
        [StringLength(50, MinimumLength=5, ErrorMessage="O cargo deve ter no mínimo 5 caracteres.")]
        public string Cargo { get; set; }

        [Required]
        [StringLength(50, MinimumLength=5, ErrorMessage="O status deve ter no mínimo 5 caracteres.")]
        public string StatusVinculo { get; set; }

        [Required]
        [StringLength(50, MinimumLength=2, ErrorMessage="A jornada deve ter no mínimo 2 caracteres.")]
        public string Jornada { get; set; }

        [Required(ErrorMessage="A unidade de lotação é obrigatória.")]
        [StringLength(50, MinimumLength=5, ErrorMessage="A unidade de lotação deve ter no mínimo 5 caracteres.")]
        public string UnidadeLotacao { get; set; }

        [Required(ErrorMessage="A unidade de exercicio é obrigatória.")]
        [StringLength(50, MinimumLength=5, ErrorMessage="A unidade de exercicio deve ter no mínimo 5 caracteres.")]
        public string UnidadeExercicio { get; set; }

        [Required(ErrorMessage="A DRE é obrigatória.")]
        [StringLength(50, MinimumLength=3, ErrorMessage="A unidade de exercicio deve ter no mínimo 3 caracteres.")]
        public string DRE { get; set; }

        [Required(ErrorMessage="A Referencia é obrigatória.")]
        [StringLength(50, MinimumLength=3, ErrorMessage="A referencia deve ter no mínimo 3 caracteres.")]
        public string Referencia { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataInicioVinculo { get; set; }

        [ForeignKey("IdServidor")]
        public Servidor Servidor { get; set; }
        public int IdServidor { get; set; }
        public Vinculo() { }
        public Vinculo(int IdServidor, int Vinc, string Cargo, string UnidadeLotacao, string UnidadeExercicio, string Referencia, DateTime DataInicioVinculo, string StatusVinculo, string Jornada, string DRE)
        {
            this.CriadoEm = DateTime.Now;
            this.IdServidor = IdServidor;
            this.Vinc = Vinc;
            this.Cargo = Cargo;
            this.UnidadeLotacao = UnidadeLotacao;
            this.UnidadeExercicio = UnidadeExercicio;
            this.Referencia = Referencia;
            this.DataInicioVinculo = DataInicioVinculo;
            this.StatusVinculo = StatusVinculo;
            this.Jornada = Jornada;
            this.DRE = DRE;
        }
    }
}