using Newtonsoft.Json.Linq;

namespace FormSigmaDevelopers.Models
{
    public class ResultResponse
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string DetalleError { get; set; }
        public JObject Data { get; set; } = new JObject();
    }
}
