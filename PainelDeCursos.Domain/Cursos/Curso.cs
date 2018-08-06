
namespace PainelDeCursos.Domain.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }                    
    }
}