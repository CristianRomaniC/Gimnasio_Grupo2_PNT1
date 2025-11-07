using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Lo necesitamos para [ForeignKey]

namespace GimnasioGrupo2.Models
{
    public class Rutina
    {
        [Key]
        public int Id { get; set; } // La Clave Primaria (PK) de la Rutina

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } // ej: "Rutina Lunes - Pecho"

        public double TiempoEstimado { get; set; }

        public int CantidadDeEjercicios { get; set; }

        // --- Relaciones ---

        // 1. Relación con TipoRutina (1-a-N)
        // (Asumimos que crearás TipoRutina.cs después)
        // "Esta Rutina es de UN Tipo de Rutina"
        public int TipoRutinaId { get; set; } // La llave (FK)
        public TipoRutina TipoRutina { get; set; } // El objeto

        // 2. Relación con Cliente (N-a-1)
        // "Esta Rutina pertenece a UN Cliente"

        // Esta es la Clave Foránea (FK) que apunta a Cliente
        // Debe coincidir con el tipo de la PK de Persona (que es 'int')
        public int? ClienteDni { get; set; }

        // Esta es la "Propiedad de Navegación" que apunta al "dueño"
        public Cliente Cliente { get; set; }
    }
}