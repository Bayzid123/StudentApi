using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Model;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.Students.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> Get(int id)
        {
            var data = await _context.Students.FindAsync(id);
            if (data == null)
                return BadRequest("id not found");
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddData(Student data)
        {
            _context.Students.Add(data);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateData(Student request) 
        {
            var dbdata = await _context.Students.FindAsync(request.Id); 
            if (dbdata == null)
                return BadRequest("Id not found");
            dbdata.Id = request.Id;
            dbdata.Name = request.Name;
            dbdata.Department = request.Department;
            dbdata.CGPA = request.CGPA;

            await _context.SaveChangesAsync();
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteData(int id)
        {
            var dbdata = await _context.Students.FindAsync(id);
            if (dbdata == null)
                return BadRequest("Id not found");

            _context.Students.Remove(dbdata);
            await _context.SaveChangesAsync();
            return Ok(await _context.Students.ToListAsync());
        }
    }
}
