using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospisim.Domain.Entities
{
    public class Prontuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Numero { get; set; } = string.Empty;

        [Required]
        public DateTime DataAbertura { get; set; }

        public string? ObservacoesGerais { get; set; }

        // FK e Navegação
        [Required]
        public Guid PacienteId { get; set; }

        public Paciente? Paciente { get; set; }

        public ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();
    }
}
