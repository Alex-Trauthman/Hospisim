using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospisim.Domain.Entities
{
    public class ProfissionalSaude
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required]
        [StringLength(11)]
        public string CPF { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        public string RegistroConselho { get; set; } = string.Empty;

        [Required]
        public string TipoRegistro { get; set; } = string.Empty;

        public Guid EspecialidadeId { get; set; }
        public Especialidade? Especialidade { get; set; }

        public DateTime DataAdmissao { get; set; }

        public int CargaHorariaSemanal { get; set; }

        public string Turno { get; set; } = string.Empty;

        public bool Ativo { get; set; }

        public ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();
    }
}
