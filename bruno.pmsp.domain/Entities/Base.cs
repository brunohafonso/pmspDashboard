using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bruno.pmsp.domain.Entities
{
    public abstract class Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CriadoEm { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AtualizadoEm { get; set; }
        public int QtdAtualizacoes { get; set; }
        public string AtualizadoPor { get; set; }
    }
}