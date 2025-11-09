using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; // ¡Importante para las Listas!
//prueba comentario lucas

namespace GimnasioGrupo2.Models
{
    // Hereda de Persona (Dni, Nombre, etc.)
    public class Cliente : Persona
    {
        // --- Propiedades Propias de Cliente ---

        public bool Habilitado { get; set; }
        public bool MembresiaVigente { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Se requiere el Objetivo")]
        [Display(Name = "Objetivo")]
        public string Objetivo { get; set; }

        // --- INICIO DE LA CORRECCIÓN ---
        // ¡AGREGA ESTA LÍNEA AQUÍ!
        // Esta es la FK "fantasma" que vio el log.[Dni], ..., [c].[GimnasioId], ... FROM [Clientes] AS [c]"]
        // La hacemos opcional con '?' para que no sea requerida en el formulario.
        public int? GimnasioId { get; set; }
        // --- FIN DE LA CORRECCIÓN ---


        // --- Relaciones ---

        // 1. Relación 1-a-N con Rutina (¡CORRECTO!)
        public List<Rutina>? Rutinas { get; set; }

        // 2. Relación N-a-M con TipoMembresia (¡CORRECTO!)
        public List<ClienteMembresia>? ClienteMembresias { get; set; }
    }
}