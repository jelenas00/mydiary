using MyDiary.Models;
using MyDiary.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyDiary.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class DiariesController: ControllerBase{
        private readonly DiariesService _diariesService;

        public DiariesController(DiariesService diariesService){
            _diariesService=diariesService;
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
    }
}