using PruebaTecnicaShared.Dtos;

namespace PruebaTecnicaModel.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<StudentDto>> GetStudents();
        Task<int> UpdateStudent(StudentDto student);
        Task<int> DeleteStudent(StudentDto student);
        Task<int> CreateStudent(StudentDto student);
        Task<StudentDto> GetStudentbyId(int id);

    }
}
