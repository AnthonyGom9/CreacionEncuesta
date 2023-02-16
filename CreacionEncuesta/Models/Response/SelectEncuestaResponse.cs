namespace CreacionEncuesta.Models.Response
{
    public class SelectEncuestaResponse
    {
        public string Titulo { get; set; } 
        public string Descripcion { get; set; }

        public List<DetalleEncuestum> DetalleEncuesta { get;set; }
    }
}
