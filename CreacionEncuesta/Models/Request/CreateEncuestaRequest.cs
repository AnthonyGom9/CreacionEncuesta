using System.ComponentModel.DataAnnotations;

namespace CreacionEncuesta.Models.Request
{
    public class CreateEncuestaRequest
    {
        [Required]
        public string titulo { get; set; }

        [Required]
        public string descripcion { get;set; }

        [Required]
        public List<DetalleEncuestum> detalle { get; set; }

        [Required]
        public int usuario_registro { get; set; }

        [Required]
        public int estado_registro { get; set; }    
    }
}
