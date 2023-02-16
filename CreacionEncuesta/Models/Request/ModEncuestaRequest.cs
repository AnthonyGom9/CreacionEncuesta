using System.ComponentModel.DataAnnotations;

namespace CreacionEncuesta.Models.Request
{
    public class ModEncuestaRequest
    {
        [Required]
        public string Nombre_Encuesta { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public int Requerido { get; set; }
    }
}
