using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Hospisim.Domain.Entities
{
    public class Paciente
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required]
        [StringLength(11)]
        public string CPF { get; set; } = string.Empty;

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Sexo { get; set; } = string.Empty;

        public string TipoSanguineo { get; set; } = string.Empty;

        [Phone]
        public string Telefone { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string EnderecoCompleto { get; set; } = string.Empty;

        public string NumeroCartaoSUS { get; set; } = string.Empty;

        public string EstadoCivil { get; set; } = string.Empty;

        public bool PossuiPlanoSaude { get; set; }

        // Navegação
        public ICollection<Prontuario> Prontuarios { get; set; } = new List<Prontuario>();
    }
}
