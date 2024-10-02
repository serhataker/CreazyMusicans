using CreazyMusicans.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace CreazyMusicans.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicansController : ControllerBase
    {
        // we cretaed deafult value for our list
        static List<MusiciansEntity> _s = new List<MusiciansEntity> {

        new MusiciansEntity{Id=1,Name="Ahmet Çalgı",Job="famous musical instrument player",FunnyProperty="always plays the wrong note but it's so much fun"} ,
        new MusiciansEntity{Id=2,Name="Zeynep Melodi",Job="popular melody writer",FunnyProperty="their songs are misunderstood but very popular"},
        new MusiciansEntity{Id=3,Name="Cemil Akor",Job="Crazy chordist",FunnyProperty="Changes chords frequently but is surprisingly talented"}
        };

        [HttpGet] // It is run for the all list value
        public IActionResult GetAll()
        {

            var musican = _s.ToList();
            return Ok(musican);

        }
        // it is get request with id query search the list value
        [HttpGet("search")]
        public IActionResult GetSearch( [FromQuery]int id) 
        { 
        var musican=_s.Where(x => x.Id == id);
            return Ok(musican);
        
        }

       
        // ıt is created for the added new value of list. 
        [HttpPost]
        public IActionResult Create([FromBody] MusiciansEntity entity)
        {
            if (entity == null)
            {
                return BadRequest("Musician entity cannot be null.");
            }

            
            var maxId = _s.Max(x => x.Id);
            entity.Id = maxId + 1;

            _s.Add(entity); 
         

            return CreatedAtAction(nameof(GetAll), new { id = entity.Id }, entity);
        }
        // ıt is updating the musican name nd it is have validation 
        [HttpPut("Update/{id:int:min(1)}/{newMusicanName}")]
        public IActionResult UpdateMusican(int id, string newMusicanName)
        {
            if (string.IsNullOrWhiteSpace(newMusicanName))
            {
                return BadRequest("New musician name cannot be empty.");
            }

            var musican = _s.FirstOrDefault(x => x.Id == id);
            if (musican == null)
            {
                return NotFound();
            }

            musican.Name = newMusicanName;
            return NoContent();
        }


        [HttpPatch("{id:int:min(1)}")]
        public IActionResult Patch(int id, [FromQuery] string name)
        {
            // Find the musician using FirstOrDefault instead of Where
            var musican = _s.FirstOrDefault(x => x.Id == id);

            if (musican == null)
            {
                return NotFound();
            }

            // Check if name is provided
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name cannot be empty.");
            }

            // Update the musician's name
            musican.Name = name;

            return NoContent();
        }


        // It is will be delete value of list.
        [HttpDelete("{id:int:min(1)}")]


        public IActionResult DeleteMusican(int id)
        {

            var musican=_s.FirstOrDefault(x => x.Id == id);
            if(musican == null)

            {
                return NotFound();
            }

            _s.Remove(musican);
            return NoContent();
        }
    }
}
