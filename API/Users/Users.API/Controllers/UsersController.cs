using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.API.Data;
using Users.API.Models;

namespace Users.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UsersDbContext usersDbContext;

        public UsersController(UsersDbContext usersDbContext)
        {
            this.usersDbContext = usersDbContext;
        }

        //Get All Cards
        [HttpGet]
        public async Task<IActionResult> GettAllCards()
        {
            var users = await usersDbContext.Users.ToListAsync();
            return Ok(users);
        }

        //Get Single Card
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCard")]
        public async Task<IActionResult> GetCard([FromRoute] Guid id)
        {
            var user = await usersDbContext.Users.FirstOrDefaultAsync(x=>x.Id==id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User Not Found");
        }

        //Add Card
        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] User user)
        {
            user.Id = Guid.NewGuid();

            await usersDbContext.Users.AddAsync(user);
            await usersDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCard), new {id = user.Id },user);
        }

        //Updating A Card
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] User user)
        {
            var existingUser = await usersDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.UserSurname = user.UserSurname;
                existingUser.UserAge = user.UserAge;
                await usersDbContext.SaveChangesAsync();
                return Ok(existingUser);
            }

            return NotFound("User Not Found");
        }

        //Delete A Card
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromBody] Guid id)
        {
            var existingUser = await usersDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser != null)
            {
                usersDbContext.Remove(existingUser);
                await usersDbContext.SaveChangesAsync();
                return Ok(existingUser);
            }

            return NotFound("User Not Found");
        }
    }
}
