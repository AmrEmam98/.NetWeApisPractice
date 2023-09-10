using LinkedInProjectApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkedInProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(string Name)
        {

            SkillModel Skill= new SkillModel {Name= Name };
            await _context.Skills.AddAsync(Skill);
             _context.SaveChanges();
            return Ok(Skill);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateSkillName(int Id , [FromBody ]string SkillName)
        {
           SkillModel Skill = await GetSkillById(Id);
            if (Skill == null)
                return NotFound($"The task with id = {Id} is not exist");
            Skill.Name= SkillName;
            _context.Skills.Update(Skill);
           _context.SaveChanges();
            return Ok(Skill);     
        }

        private async Task<SkillModel> GetSkillById(int Id)
        {
          SkillModel Skill= await _context.Skills.SingleAsync(s => s.Id == Id);
            return Skill;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var Skills= await _context.Skills.ToListAsync();
            return Ok(Skills);

        }
    }
}
