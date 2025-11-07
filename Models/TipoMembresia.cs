using System.ComponentModel.DataAnnotations;

namespace GimnasioGrupo2.Models
{
    public class TipoMembresia
    {
        [Key]
        public int Id { get; set; } // PK (ej: 1)

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } // ej: "MENSUAL", "TRIMESTRAL", "ANUAL"

        // --- Relación N-a-M ---
        // Le dice a EF que "un TipoMembresia está en MUCHAS inscripciones"
        // (Apunta a la tabla intermedia)
        public List<ClienteMembresia> ClienteMembresias { get; set; }
    }
}