using System.ComponentModel.DataAnnotations;

namespace GimnasioGrupo2.Models
{
    // Esta es la TABLA INTERMEDIA que conecta Cliente y TipoMembresia
    public class ClienteMembresia
    {
        [Key]
        public int Id { get; set; } // PK de esta tabla

        // --- Clave Foránea (FK) a Cliente ---
        // Le dice a EF: "Esta inscripción pertenece a UN Cliente"
        public int ClienteDni { get; set; } // La llave del Cliente
        public Cliente Cliente { get; set; } // El objeto Cliente

        // --- Clave Foránea (FK) a TipoMembresia ---
        // Le dice a EF: "Esta inscripción es de UN TipoMembresia"
        public int TipoMembresiaId { get; set; } // La llave del TipoMembresia
        public TipoMembresia TipoMembresia { get; set; } // El objeto TipoMembresia

        // --- Datos extra de la relación ---
        // (Aquí podemos guardar cuándo se compró la membresía)
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}