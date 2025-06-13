using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospisim.Domain.Entities
{
    public class Prescricao
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid AtendimentoId { get; set; }
        public Atendimento? Atendimento { get; set; }

        [Required]
        public Guid ProfissionalId { get; set; }
        public ProfissionalSaude? Profissional { get; set; }

        [Required]
        public string Medicamento { get; set; } = string.Empty;

        [Required]
        public string Dosagem { get; set; } = string.Empty;

        [Required]
        public string Frequencia { get; set; } = string.Empty;

        [Required]
        public string ViaAdministracao { get; set; } = string.Empty;

        [Required]
        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public string? Observacoes { get; set; }

        [Required]
        public string StatusPrescricao { get; set; } = string.Empty;

        public string? ReacoesAdversas { get; set; }
    }
}
