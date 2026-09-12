using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaModel.Model
{
    public class Person
    {
        [Key]
        public int PersonId {  get; set; }
        public string Person_FirstName { get; set; } = string.Empty;
        public string Person_LastName { get; set;} = string.Empty;
        public DateTime Person_BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Person_DocumentId {  get; set; } = string.Empty;
        public string Person_Addres { get; set; } = string.Empty;
        public string Person_Phone { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Nacionalidad { get; set; } = string.Empty;
        public DateTime DateCreate { get; set; }
        public bool Act {  get; set; }
    }
}
