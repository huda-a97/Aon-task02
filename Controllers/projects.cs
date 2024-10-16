using Aon_Freelance.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aon_Freelance.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class projects : ControllerBase
    {
        private static List<Project> AllProjects = new List<Project>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(AllProjects);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Project pro)
        {
            AllProjects.Add(pro);

            return CreatedAtAction("Create", new { Id = pro.Id }, AllProjects);
        }

       

        [HttpGet ("{id}")]

        public IActionResult GetSpecific(int id)
        {
            Project project = AllProjects.FirstOrDefault(project => project.Id == id);

            if(project == null)
            {
                return NotFound("the project not found");
            }

            return Ok(project);
        }


        [HttpDelete ("{id}")]

        public IActionResult DeleteProject(int id)
        {
            Project project = AllProjects.FirstOrDefault(project => project.Id == id);

            if (project == null)
            {
                return NotFound("the project not found");
            }

            AllProjects.Remove(project);
            return Ok("the project was deleted");
           
        }
    }

}
