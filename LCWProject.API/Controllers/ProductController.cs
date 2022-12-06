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
        public async Task<IActionResult> Create([FromForm] AddProductDto blogAddModel)
        {
            await _productService.AddProductAsync(_mapper.Map<Product>(blogAddModel));
            return Ok();
        }
    }
}
