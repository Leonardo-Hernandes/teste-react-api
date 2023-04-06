using teste_react_api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teste_react_api.Persistence;

namespace teste_react_api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersDbContext _context;

        public UsersController(UsersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.User.Where(d => !d.IsDeleted).ToList();

            return Ok(users);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            var user = _context.User.SingleOrDefault(d => d.Id == id);

            if(User == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User input)
        {
            var user = _context.User.SingleOrDefault(d => d.Email == input.Email);

            if(user == null)
            {
                _context.User.Add(input);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
            }

            return BadRequest("user has arleady registred");
        }


        [HttpPut("{id}")]

        public IActionResult Update(Guid id, User input)
        {
            var user = _context.User.SingleOrDefault(d => d.Id == id);

            if (User == null)
            {
                return NotFound();
            }

            user.Update(input.Name, input.Email, input.Password, input.Phone);

            _context.User.Update(user);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            var user = _context.User.SingleOrDefault(d => d.Id == id);

            if (User == null)
            {
                return NotFound();
            }

            user.Delete();
            _context.SaveChanges();

            return NoContent();
        }
    }
}
