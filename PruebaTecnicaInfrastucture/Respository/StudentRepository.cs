using Microsoft.EntityFrameworkCore;
using PruebaTecnicaInfrastucture.context;
using PruebaTecnicaModel.Interfaces;
using PruebaTecnicaModel.Model;
using PruebaTecnicaShared.Dtos;

namespace PruebaTecnicaInfrastucture.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PruebaDbContext _context;
        public StudentRepository(PruebaDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateStudent(StudentDto student)
        {
            if(student == null) throw new ArgumentNullException(nameof(student));

            var modelPerson = new Person
            {
                Person_LastName = student.LastName,
                Person_FirstName = student.Name,
                Person_BirthDate = DateTime.Now.Date,
                Email = "",
                Person_DocumentId = "",
                Person_Addres = "",
                Person_Phone = "",
                Genero = "",
                Nacionalidad = "",
                DateCreate = DateTime.Now,
                Act = true
            };

            _context.Persons.Add(modelPerson);
           await _context.SaveChangesAsync();

            var personDt = await _context.Persons.OrderByDescending(x => x.DateCreate).FirstOrDefaultAsync();

            if (personDt == null) throw new Exception("Ha ocurrido un error");

            var model = new Students
            {
                PersonId = personDt?.PersonId == null ? 1 : personDt.PersonId,
                Matricula = student.EnrollMent,
                DateCreate = DateTime.Now,
                Act = true
            };

            _context.Students.Add(model);


            return await _context.SaveChangesAsync();        
        }

        public async Task<int> DeleteStudent(StudentDto student)
        {
            if (student == null) throw new Exception("Valide la informacion enviada");

            var studentDt = await _context.Students.Where(x => x.StudentId == student.Id).FirstOrDefaultAsync();
            if (studentDt == null) throw new Exception("Esa Persona no existe");

            studentDt.Act = false;
            _context.Students.Update(studentDt);
            return await _context.SaveChangesAsync();
        }

        public async Task<StudentDto> GetStudentbyId(int id)
        {
            
            var StudentDt = await _context.Students.AsNoTracking().Where(x => x.StudentId == id && x.Act == true).Select(x => new StudentDto
            {
                Id = x.StudentId,
                PersonaId = x.PersonId,
                Name = _context.Persons.Where(pe => pe.PersonId == x.PersonId).Select(x => x.Person_FirstName).First(),
                LastName = _context.Persons.Where(pe => pe.PersonId == x.PersonId).Select(x => x.Person_LastName).First(),
                EnrollMent = x.Matricula,
                Estado = x.Act
            }).FirstOrDefaultAsync();

            return StudentDt;
        }

        public async Task<List<StudentDto>> GetStudents()
        {
            var StudentDt = await _context.Students.AsNoTracking().Where(x => x.Act == true).Select(x => new StudentDto
            {
                Id = x.StudentId,
                PersonaId = x.PersonId,
                Name = _context.Persons.Where(pe => pe.PersonId == x.PersonId).Select(x => x.Person_FirstName).First(),
                LastName = _context.Persons.Where(pe => pe.PersonId == x.PersonId).Select(x => x.Person_LastName).First(),
                EnrollMent = x.Matricula,
                Estado = x.Act
            }).ToListAsync();

            return StudentDt;
        }

        public async Task<int> UpdateStudent(StudentDto student)
        {
            if (student == null) throw new Exception("Valide la informacion enviada");

            var studentDt = await _context.Students.Where(x => x.StudentId == student.Id).FirstOrDefaultAsync();
            if (studentDt == null) throw new Exception("Esa Persona no existe");

            var personDt = await _context.Persons.Where(per => per.PersonId == student.PersonaId).FirstOrDefaultAsync();
            if (personDt == null) throw new Exception("Esa Persona no existe");

            studentDt.Act = student.Estado;
            studentDt.Matricula = student.EnrollMent;
            personDt.Person_FirstName = student.Name;
            personDt.Person_LastName = student.LastName;

            _context.Students.Update(studentDt);
            _context.Persons.Update(personDt);

            return await _context.SaveChangesAsync();

        }
    }
}
