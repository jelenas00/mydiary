using MyDiary.Models;
using MyDiary.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyDiary.Controllers{
    [Route("api/[controller]")]
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
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User korisnik)
        {
                var user= await _usersService.CreateAsync(korisnik);
            if(user==null)
                return NotFound();
            else
                return user;
        }
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User korisnik)
        {
            var user=await _usersService.UpdateAsync(korisnik);
            if(user==null)
                return NotFound();
            else
                return user;
        }
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
        [Route("prijaviSeNaSajt")]
        public async Task<ActionResult<User>> prijaviSeNaSajt(string ema,string pass)
        {
            var users=await _usersService.GetAsync();
            var nalog=users.Find(x=>(x.Email==ema&&x.Password==pass));
            if(nalog==null)
                return NotFound();
            else
                return nalog;
        } 
    }
}