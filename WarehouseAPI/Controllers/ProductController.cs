using Microsoft.AspNetCore.Mvc;
using WarehouseBAL.Interfaces;
using WarehouseDAL.DTO;
using WarehouseDAL.Models;



namespace WarehouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }
        [HttpPost("CreateProduct")]
        public IActionResult Create(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Product product = new Product
            {
                DepartmentId = productDTO.DepartmentId,
                Name = productDTO.Name,
                Manufacturer = productDTO.Manufacturer,
                WarrantyStartDate = productDTO.WarrantyStartDate,
                WarrantyEndDate = productDTO.WarrantyEndDate
            };
            _productService.Create(product);
            return Ok();
        }
        [HttpPut("UpdateProduct/{id}")]
        public IActionResult Update(int id, ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Product product = new Product
            {
                DepartmentId = productDTO.DepartmentId,
                Name = productDTO.Name,
                Manufacturer = productDTO.Manufacturer,
                WarrantyStartDate = productDTO.WarrantyStartDate,
                WarrantyEndDate = productDTO.WarrantyEndDate
            };
            Product updatedProduct = _productService.Update(id, product);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult Delete(int id)
        {
            Product deletedProduct = _productService.Delete(id);
            if (deletedProduct == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
