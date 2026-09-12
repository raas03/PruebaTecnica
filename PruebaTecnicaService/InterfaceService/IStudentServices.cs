
using PruebaTecnicaShared.Dtos;

namespace PruebaTecnicaService.InterfaceService
{
    public interface IStudentServices
    {
        Task<List<StudentDto>> GetStudents();
        Task<int> UpdateStudent(StudentDto student);
        Task<int> DeleteStudent(StudentDto student);
        Task<int> CreateStudent(StudentDto student);
        Task<StudentDto> GetStudentbyId(int id);

    }
}
