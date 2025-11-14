    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace GimnasioGrupo2.Models
{
    public class Gimnasio
    {
        // Cambiado a int para que coincida con Cliente.GimnasioId
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se requiere el Nombre del gimnasio")]
        [Display(Name = "Nombre")]
        [StringLength(15)]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Se requiere la direccion")]
        [Display(Name = "Direccion")]
        [StringLength(50)]
        public string Direccion { get; set; } = null!;

        [Required(ErrorMessage = "Se requiere el telefono")]
        [Display(Name = "Telefono")]
        [StringLength(20)]
        public string Telefono { get; set; } = null!;

        // --- RELACIONES (¡MUY IMPORTANTE!) ---

        // Esto le dice a Entity Framework que "Un Gimnasio tiene MUCHOS Clientes".
        // Es la implementación de la relación 1-a-N (Uno a Muchos).
        //
        public List<Cliente> Clientes { get; set; }

        // Y "Un Gimnasio tiene MUCHAS Rutinas (plantillas de rutinas)".
        public List<Rutina> Rutinas { get; set; }
    }
}