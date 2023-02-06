using MyDiary.Models;
using MyDiary.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyDiary.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase{
        private readonly UsersService _usersService;

        public UsersController(UsersService userService){
            _usersService=userService;
        }
        [HttpGet]
        public async Task<List<User>> Get() =>await _usersService.GetAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _usersService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }
    }
}