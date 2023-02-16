using System.ComponentModel.DataAnnotations;

namespace CreacionEncuesta.Models.Request
{
    public class SelectEncuestaRequest
    {
        [Required]
        public string Name{ get; set; }
    }
}
