using MyDiary.Models;
using MyDiary.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyDiary.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class DiariesController: ControllerBase{
         private readonly UsersService _usersService;
        private readonly DiariesService _diariesService;
        private readonly PagesService _pagesService;

        public DiariesController(DiariesService diariesService,UsersService usersServices,PagesService pagesService){
            _diariesService=diariesService;
            _usersService=usersServices;
            _pagesService=pagesService;
        }
        [HttpGet]
        public async Task<List<Diary>> Get() =>await _diariesService.GetAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<Diary>> Get(string id)
        {
            var diary = await _diariesService.GetAsync(id);

            if (diary is null)
            {
                return NotFound();
            }

            return diary;
        }
                [HttpPost]
        public async Task<ActionResult<Diary>> CreateDiary(Diary dnevnik)
        {
                var user= await _diariesService.CreateAsync(dnevnik);
            if(user==null)
                return NotFound();
            else
            {
                var noco=await _usersService.GetAsync(dnevnik.User);
                if(noco!=null)
                {
                    noco.Diary=dnevnik.Id;
                    await _usersService.UpdateAsync(noco);
                }
                return user;
            }
                
        }
        [HttpPut]
        public async Task<ActionResult<Diary>> UpdateUser(Diary dnevnik)
        {
            var user=await _diariesService.UpdateAsync(dnevnik);
            if(user==null)
                return NotFound();
            else
                return user;
        }
        [HttpDelete]
        public async Task<ActionResult<Diary>> DeleteAsync(string id)
        {
            var diary=await _diariesService.GetAsync(id);
            if(diary==null)
                return NotFound();
            else
            {
                if(diary.Pages!=null)
                    foreach(var x in diary.Pages)
                        await _pagesService.DeleteAsync(x);
                var userr=await _usersService.GetAsync(diary.User);
                if(userr!=null)
                    {
                        userr.Diary="";
                        await _usersService.UpdateAsync(userr);
                    }
                await _diariesService.DeleteAsync(diary.Id);
                
                return diary;
            }
                
        }
        [HttpGet]
        [Route("unlockDiary")]
        public async Task<ActionResult<Diary>> unlockDiary(string idd,string pass)
        {
            var diary=await _diariesService.GetAsync(idd);
            if(diary==null)
                return NotFound();
            else
            {
                if(diary.Password==pass)
                    return diary;
                else 
                    return NotFound("incorrect password");
            }          
        }
    }
}