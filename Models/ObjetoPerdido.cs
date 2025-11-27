using System;
using System.ComponentModel.DataAnnotations;

namespace GimnasioGrupo2.Models
{
 public class ObjetoPerdido
 {
 [Key]
 public int Id { get; set; }

 [Required]
 [StringLength(200)]
 [Display(Name = "Descripción")]
 public string Descripcion { get; set; }

 [Required]
 [Display(Name = "Fecha encontrado")]
 public DateTime FechaEncontrado { get; set; }

 [StringLength(100)]
 [Display(Name = "Ubicación")]
 public string? Ubicacion { get; set; }

 [Display(Name = "Cliente (asignar)")]
 public int? ClienteDni { get; set; }

 public Cliente? Cliente { get; set; }

 // Nuevo campo Entregado
 public bool Entregado { get; set; }
 public DateTime? FechaEntregado { get; set; }
 }
}