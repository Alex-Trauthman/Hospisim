using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospisim.Domain.Entities
{
    public class Internacao
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        [Required]
        public Guid AtendimentoId { get; set; }
        public Atendimento? Atendimento { get; set; }

        [Required]
        public DateTime DataEntrada { get; set; }

        public DateTime? PrevisaoAlta { get; set; }

        [Required]
        public string MotivoInternacao { get; set; } = string.Empty;

        [Required]
        public string Leito { get; set; } = string.Empty;

        [Required]
        public string Quarto { get; set; } = string.Empty;

        [Required]
        public string Setor { get; set; } = string.Empty;

        public string? PlanoSaudeUtilizado { get; set; }

        public string? ObservacoesClinicas { get; set; }

        [Required]
        public string StatusInternacao { get; set; } = string.Empty;

        // Navegação: AltaHospitalar (opcional)
        public AltaHospitalar? AltaHospitalar { get; set; }
    }
}
