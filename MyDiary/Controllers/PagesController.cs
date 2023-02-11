using MyDiary.Models;
using MyDiary.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyDiary.Controllers{
    [Route("/[controller]")]
    [ApiController]
    public class PagesController: ControllerBase{
        private readonly UsersService _usersService;
        private readonly DiariesService _diariesService;
        private readonly PagesService _pagesService;

        public PagesController(UsersService userService,DiariesService diariesService,PagesService pagesService){
            _usersService=userService;
            _diariesService=diariesService;
            _pagesService=pagesService;
        }

        [Route("GetAllPages")]
        [HttpGet]
        public async Task<List<Page>> Get() =>await _pagesService.GetAsync();

        [Route("GetPageById/{id}")]
        [HttpGet]
        public async Task<ActionResult<Page>> Get(string id)
        {
            var page = await _pagesService.GetAsync(id);

            if (page is null)
            {
                return NotFound();
            }
            return page;
        }
        [Route("GetPageByDate/{date}")]
        [HttpGet]
        public async Task<ActionResult<List<Page>>> getPageByDate(string date)
        {
            var page = await _pagesService.GetAsyncDate(date);

            if (page is null)
            {
                return NotFound();
            }
            return page;
        }

        [Route("CreatePage")]
        [HttpPost]
        public async Task<ActionResult<Page>> CreatePage(Page stranice)
        {
                var user= await _pagesService.CreateAsync(stranice);
            if(user==null)
                return NotFound();
            else
            {
                var noco = await _diariesService.GetAsync(stranice.Diary);
                if(noco!=null)
                {
                    noco.Pages.Add(user.Id);
                    await _diariesService.UpdateAsync(noco);
                }
                return user;
            }
        }

        [Route("UpdatePage")]
        [HttpPut]
        public async Task<ActionResult<Page>> UpdatePage(Page stranice)
        {
            var user=await _pagesService.UpdateAsync(stranice);
            if(user==null)
                return NotFound();
            else
                return user;
        }

        [Route("DeletePage/{id}")]
        [HttpDelete]
        public async Task<ActionResult<Page>> DeleteAsync(string id)
        {
            var user=await _pagesService.GetAsync(id);
            if(user==null)
                return NotFound();
            else
            {
                var diary=await _diariesService.GetAsync(user.Diary);
                if(diary!=null)
                    diary.Pages.Remove(id);
                await _pagesService.DeleteAsync(id);
                return user;
            }
        }
        
    }
}