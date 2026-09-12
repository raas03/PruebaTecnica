using PruebaTecnicaModel.Interfaces;
using PruebaTecnicaService.InterfaceService;
using PruebaTecnicaShared.Dtos;

namespace PruebaTecnicaService.Service
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _repository;
        public StudentServices(IStudentRepository studentRepository)
        {
            _repository = studentRepository;
        }

        public async Task<int> CreateStudent(StudentDto student)
        {
            return await _repository.CreateStudent(student);
        }

        public async Task<int> DeleteStudent(StudentDto student)
        {
            return await _repository.DeleteStudent(student);
        }

        public async Task<StudentDto> GetStudentbyId(int id)
        {
            return await _repository.GetStudentbyId(id);
        }

        public async Task<List<StudentDto>> GetStudents()
        {
            return await _repository.GetStudents();
        }

        public async Task<int> UpdateStudent(StudentDto student)
        {
            return await _repository.UpdateStudent(student);
        }
    }
}
