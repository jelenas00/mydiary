using MyDiary.Models;
using MyDiary.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyDiary.Controllers{
    [Route("/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase{
        private readonly UsersService _usersService;
        private readonly DiariesService _diariesService;
        private readonly PagesService _pagesService;

        public UsersController(UsersService userService,DiariesService diariesService,PagesService pagesService){
            _usersService=userService;
            _diariesService=diariesService;
            _pagesService=pagesService;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<List<User>> Get() =>await _usersService.GetAsync();

        [Route("GetUserById/{id}")]
        [HttpGet]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _usersService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [Route("CreateUser")]
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User korisnik)
        {
                var user= await _usersService.CreateAsync(korisnik);
            if(user==null)
                return NotFound();
            else
                return user;
        }

        [Route("UpdateUser")]
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User korisnik)
        {
            var user=await _usersService.UpdateAsync(korisnik);
            if(user==null)
                return NotFound();
            else
                return user;
        }

        [Route("UpdateUserEmail")]
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUserEmail(User korisnik)
        {
            var user=await _usersService.UpdateEmailAsync(korisnik);
            if(user==null)
                return BadRequest("Postoji korisnik sa tom email adresom!");
            else
                return user;
        }

        [Route("UpdateUserUsername")]
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUserUsername(User korisnik)
        {
            var user=await _usersService.UpdateUsernameAsync(korisnik);
            if(user==null)
                return BadRequest("Postoji korisnik sa tim username-om!");
            else
                return user;
        }

        [Route("DeleteUser/{id}")]
        [HttpDelete]
        public async Task<ActionResult<User>> DeleteAsync(string id)
        {
            var user=await _usersService.GetAsync(id);
            if(user==null)
                return NotFound();
            else
            {
                var diary=await _diariesService.GetAsync(user.Diary);
                if(diary!=null)
                if(diary.Pages!=null)
                    foreach(var x in diary.Pages)
                        await _pagesService.DeleteAsync(x);
                await _diariesService.DeleteAsync(user.Diary);
                await _usersService.DeleteAsync(id);
                return user;
            }
        }
        [HttpGet]
        [Route("prijaviSeNaSajt/{email}/{pass}")]
        public async Task<ActionResult<User>> prijaviSeNaSajt(string email,string pass)
        {
            var users=await _usersService.GetAsync();
            var nalog=users.Find(x=>(x.Email==email&&x.Password==pass));
            if(nalog==null)
                return NotFound();
            else
                return nalog;
        } 
    }
}