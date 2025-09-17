using Ecommerse.DTOs;
using Ecommerse.Interface;
using Ecommerse.Model;
using Ecommerse.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepo;

        public ProductController(IProduct productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productRepo.ShowAll()
                .Select(p => new ProductReadDto
                {
                    Id = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    Category = p.Category == null ? null : new CategoryReadDto
                    {
                        Id = p.Category.ID,
                        Name = p.Category.Name
                    }
                }).ToList();

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [Authorize] // لازم توكن
        public IActionResult GetById(int id)
        {
            // ✅ هنا هيدخل بس لو معاك توكن صح

            var product = _productRepo.GetUingID(id);
            if (product == null)
            {
                return NotFound();
            }

            var dto = new ProductReadDto
            {
                Id = product.ID,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Category = product.Category == null ? null : new CategoryReadDto
                {
                    Id = product.Category.ID,
                    Name = product.Category.Name
                }
            };

            return Ok(dto);
        }


        [HttpPost]
        [Authorize]

        public IActionResult Create(ProductCreatrDTOs dto)
        {
            var product = new Cls_Product
            {
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.catagouryID
            };

            _productRepo.Add(product);
            _productRepo.Save();

            return CreatedAtAction(nameof(GetById), new { id = product.ID }, dto);
        }

        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, [FromForm]ProductCreatrDTOs dto)
        {
            var existing = _productRepo.GetUingID(id);
            if (existing == null) return NotFound();

            existing.Name = dto.Name;
            existing.Price = dto.Price;
            existing.CategoryId = dto.catagouryID;

            _productRepo.Edit(existing);
            _productRepo.Save();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (_productRepo.Delete(id))
            {
                _productRepo.Save();
                return Ok(); 
            }
            return NotFound();
        }
    }
}






