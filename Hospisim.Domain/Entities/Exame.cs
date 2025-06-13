using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospisim.Domain.Entities
{
    public class Exame
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid AtendimentoId { get; set; }
        public Atendimento? Atendimento { get; set; }

        [Required]
        public string Tipo { get; set; } = string.Empty; // Ex: sangue, imagem, etc.

        [Required]
        public DateTime DataSolicitacao { get; set; }

        public DateTime? DataRealizacao { get; set; }

        public string? Resultado { get; set; }
    }
}
