using System.ComponentModel.DataAnnotations;

namespace CreacionEncuesta.Models.Request
{
    public class SelectEncuestaRequest
    {
        [Required]
        public string NombreEncuesta { get; set; }

        [Required]
        public List<RespuestaEncuestum> respuestaencuesta { get; set; }
    }
}
