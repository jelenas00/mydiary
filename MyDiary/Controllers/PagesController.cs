using MyDiary.Models;
using MyDiary.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyDiary.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController: ControllerBase{
        private readonly PagesService _pagesService;

        public PagesController(PagesService pagesService){
            _pagesService=pagesService;
        }
        [HttpGet]
        public async Task<List<Page>> Get() =>await _pagesService.GetAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<Page>> Get(string id)
        {
            var page = await _pagesService.GetAsync(id);

            if (page is null)
            {
                return NotFound();
            }

            return page;
        }
    }
}