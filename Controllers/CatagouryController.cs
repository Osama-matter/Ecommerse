using Ecommerse.DbContect;
using Ecommerse.DTOs;
using Ecommerse.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_CRUD_Libary;                   // Add  refrance  to CRUD Liary  Class , 

namespace Ecommerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagouryController : ControllerBase
    {

        private readonly GenericRepository<Cls_Catagoury> _repo;    // Add  Genarice Repostry  To Class  want to use  it  

        public  CatagouryController (EcommesdbContext context)     // Make  Constractor  to Make  DbContext  
        {
            _repo=  new GenericRepository<Cls_Catagoury>(context);     // make  Context == Generatic  CRUD 
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.ReadAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = _repo.Read(id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateDTO createDTO)
        {

            var Category = new Cls_Catagoury
            { 
                ID = createDTO.ID , 
                Name = createDTO.Name 
          
            };

            _repo.Create(Category);
            return CreatedAtAction(nameof(Get), new { id = createDTO.ID }, createDTO);
        }

        [HttpPut]
        public IActionResult Update(CategoryCreateDTO createDTO)
        {

            var ISExist = _repo.Read(createDTO.ID); 
            if(ISExist == null) return NotFound();


            ISExist.ID = createDTO.ID;
            ISExist.Name = createDTO.Name;
            _repo.Update(ISExist);
            return Ok(createDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}
