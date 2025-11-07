using System.ComponentModel.DataAnnotations;

namespace GimnasioGrupo2.Models
{
    // Esta clase será una tabla en la BD con los tipos de rutina
    public class TipoRutina
    {
        [Key]
        public int Id { get; set; } // La PK (ej: 1)

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } // ej: "PIERNA", "BRAZO", "ESPALDA"

        // --- Relación 1-a-N ---
        // Un TipoRutina (ej: "PIERNA") puede estar en MUCHAS Rutinas.
        // Por eso, definimos la lista de rutinas que son de este tipo.
        public List<Rutina> Rutinas { get; set; }
    }
}