using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaService.InterfaceService;
using PruebaTecnicaShared.Dtos;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _services;
        public StudentController(IStudentServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                return Ok(await _services.GetStudents());
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                return Ok(await _services.GetStudentbyId(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> DeleteStudent(StudentDto dto)
        {
            try
            {
                return Ok(await _services.DeleteStudent(dto));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateStudent(StudentDto dto)
        {
            try
            {
                return Ok(await _services.UpdateStudent(dto));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDto dto)
        {
            try
            {
                return Ok(await _services.CreateStudent(dto));
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
