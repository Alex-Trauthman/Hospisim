using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospisim.Domain.Entities
{
    public class AltaHospitalar
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid InternacaoId { get; set; }
        public Internacao? Internacao { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string CondicaoPaciente { get; set; } = string.Empty;

        public string? InstrucoesPosAlta { get; set; }
    }
}