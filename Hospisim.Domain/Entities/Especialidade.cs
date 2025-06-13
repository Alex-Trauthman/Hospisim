using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospisim.Domain.Entities
{
    public class Especialidade
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        // Navegação inversa
        public ICollection<ProfissionalSaude> Profissionais { get; set; } = new List<ProfissionalSaude>();
    }
}
