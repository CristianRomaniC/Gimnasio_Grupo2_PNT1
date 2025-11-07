// Esta línea es como "importar" un diccionario de herramientas.
// La necesitamos para usar los "DataAnnotations" (las cosas entre [corchetes]).
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Este es el "espacio de nombres", la dirección postal de tu clase.
// Dice "esta clase vive en el proyecto 'GimnasioGrupo2' en la carpeta 'Models'"
namespace GimnasioGrupo2.Models
{
    // public class Persona -> traduce directamente tu caja UML "Persona"
    public class Persona
    {
        // --- PROPIEDADES (Los atributos de tu UML) ---
        //

        // [Key]: Le dice a Entity Framework (el conector de BD) que esta
        // es la Clave Primaria (PK) de la tabla.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dni { get; set; } // Ahora el DNI lo provee el usuario

        // [Required]: Es una regla de validación. El campo no puede estar vacío.
        // [Display]: Es cómo se verá este campo en el HTML (la Vista).
        // [StringLength]: Limita el tamaño del texto en la BD.
        [Required(ErrorMessage = "Se requiere el Nombre")]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Se requiere el Apellido")]
        [Display(Name = "Apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Se requiere el telefono")]
        [Display(Name = "Telefono")]
        [StringLength(50)]
        public string Telefono { get; set; }

        // [Required] y [Display] funcionan igual.
        // Fíjate que el tipo 'Date' de UML es 'DateTime' en C#.
        // ¡Aquí NO usamos [StringLength] porque no es un texto!
        [Required(ErrorMessage = "Se requiere la Fecha de Nacimiento")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }
}