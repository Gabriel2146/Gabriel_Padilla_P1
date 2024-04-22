using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gabriel_Padilla_P1.Models
{
    public class PadillaG   
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required, Range(30, 300)]
        public decimal Estatura { get; set; } // Suponiendo que represente la estatura en centímetros

        [Required]
        public bool EsActivo { get; set; } // Indica si el estudiante está activo en la universidad o no

        [Required, DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }
    }

    public class Carrera
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; }

        [Required, StringLength(50)]
        public string Campus { get; set; }

        [Required, Range(1, 10)]
        public int NumeroSemestres { get; set; } // Duración de la carrera en semestres
    }
}
