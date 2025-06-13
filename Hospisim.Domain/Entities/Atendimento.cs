using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hospisim.Domain.Entities
{
    public class Atendimento
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        public string Tipo { get; set; } = string.Empty; // emergência, consulta, internação...

        [Required]
        public string Status { get; set; } = string.Empty; // realizado, em andamento, cancelado

        [Required]
        public string Local { get; set; } = string.Empty; // ex: Sala 01

        // FK e navegação: Prontuário
        [Required]
        public Guid ProntuarioId { get; set; }
        public Prontuario? Prontuario { get; set; }

        // FK e navegação: Paciente (opcional, caso deseje acesso direto)
        public Guid? PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        // FK e navegação: Profissional
        [Required]
        public Guid ProfissionalSaudeId { get; set; }
        public ProfissionalSaude? ProfissionalSaude { get; set; }

        // Navegação: Prescrições e Exames
        public ICollection<Prescricao> Prescricoes { get; set; } = new List<Prescricao>();
        public ICollection<Exame> Exames { get; set; } = new List<Exame>();

        // Navegação: Internação (opcional)
        public Internacao? Internacao { get; set; }
    }
}
