using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LCWProject.Bussiness.DTO.Product;
using LCWProject.Bussiness.Interfaces;
using LCWProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace LCWProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogList = _mapper.Map<List<ProductDto>>(await _productService.GetAllProductAsync());
            return Ok(blogList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<ProductDto>(await _productService.FindByIdAsync(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddProductDto productDto)
        {
            var existProduct = await _productService.GetByNameAsync(_mapper.Map<Product>(productDto));
            if (existProduct == null)
            {
                await _productService.AddProductAsync(_mapper.Map<Product>(productDto));
                return Created("",productDto);
            }
            else
            {
                return BadRequest("product is exist");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] ProductDto productDto)
        {
            var product = await _productService.FindByIdAsync(id);
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            return Ok(_productService.UpdateProduct(product));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.RemoveAsync(await _productService.FindByIdAsync(id));
            return NoContent();
        }
    }
}
