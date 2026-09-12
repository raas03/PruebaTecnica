
namespace PruebaTecnicaShared.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EnrollMent {  get; set; } = string.Empty;
        public bool Estado { get; set; }

    }
}
