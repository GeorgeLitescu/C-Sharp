using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Contracts.Data.InputModels;
using UsersAPI.Contracts.Data.OutputModels;
using UsersAPI.Database.Context;
using UsersAPI.Database.Entities;
using UsersAPI.Database.Validators;

namespace UsersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public UserInputValidator _validator;

        public UserController(DatabaseContext context, UserInputValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserOutput>>> GetUsers()
        {
            IQueryable<User> users = _context.Users.Where(x => x.isActive == true);
            List<UserOutput> output = new List<UserOutput>();

            foreach (var user in users)
            {
                output.Add(new UserOutput
                {
                    Id = user.Id,
                    Name = user.Name,
                    Age = user.Age,
                });
            }

            return Ok(output);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserOutput>> GetUserById(Guid userId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) return NotFound("User was not found!");
            if (!user.isActive) return Forbid("User has been deleted!");

            UserOutput output = new UserOutput
            {
                Id = userId,
                Name = user.Name,
                Age = user.Age
            };

            return Ok(output);
        }

        [HttpPost]
        public ActionResult<string> PostUser([FromBody] UserInput user)
        {
            ValidationResult result = _validator.Validate(user);
            if (!result.IsValid) return ValidationProblem("User information is invalid!");

            User toAddUser = new User
            {
                Name = user.Name,
                Age = user.Age
            };

            _context.Users.Add(toAddUser);
            _context.SaveChanges();

            return Created("New User Created! ID:{0}", toAddUser.Id);
        }

        [HttpPut("{userId}")]
        public ActionResult<string> PutUser(Guid userId, [FromBody] UserInput user)
        {
            ValidationResult result = _validator.Validate(user);
            if (!result.IsValid) return ValidationProblem("User information is invalid!");

            User userFromDatabase = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (userFromDatabase == null) return NotFound("User does not exist!");
            //if (!userFromDatabase.isActive) return Forbid("User has been deleted!");

            userFromDatabase.Name = user.Name;
            userFromDatabase.Age = user.Age;
            userFromDatabase.isActive = true;
            _context.SaveChanges();

            return Ok("User Updated!");
        }

        [HttpDelete("{userId}")]
        public ActionResult<string> DeleteUser(Guid userId)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null) return NotFound("User does not exist!");

            user.isActive = false;
            _context.SaveChanges();

            return Ok("User Deleted!");
        }
    }
}