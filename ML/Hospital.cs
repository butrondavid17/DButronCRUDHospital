using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ML
{
    public class Hospital
    {
        public int IdHospital { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true,
               DataFormatString = "{0:yyyy}")]
        public DateTime AnioConstruccion { get; set; }
        public int Capacidad { get; set; }
        public List<Object> Hospitales { get; set; }
        public ML.Especialidad Especialidad { get; set; }
    }
}