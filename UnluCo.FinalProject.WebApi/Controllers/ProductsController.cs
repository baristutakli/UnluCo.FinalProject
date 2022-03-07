using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.Validators.Brands;
using UnluCo.FinalProject.WebApi.Application.Validators.Products;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductsController>
        //  [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAll().Result;
            return Ok(JsonConvert.SerializeObject(products, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetById(id).Result;
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductViewModel createProductViewModel)
        {
            CreateProductViewModelValidator validator = new CreateProductViewModelValidator();
            validator.ValidateAndThrow(createProductViewModel);
            _productService.Add(createProductViewModel);
            return Ok(new Response { Status = "Success", Message = "Added  successfully!" });
        }


        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProductViewModel updateProductViewModel)
        {
            updateProductViewModel.Id = id;
            UpdateProductViewModelValidator validator = new UpdateProductViewModelValidator();
            validator.ValidateAndThrow(updateProductViewModel);

            return _productService.Update(updateProductViewModel) ? Ok(new Response { Status = "Success", Message = "Updated  successfully!" }) : StatusCode(StatusCodes.Status500InternalServerError);

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteProductViewModel deleteProduct = new DeleteProductViewModel() { Id = id };
            DeleteProductViewValidator validator = new DeleteProductViewValidator();
            validator.ValidateAndThrow(deleteProduct);
            _productService.Delete(deleteProduct);
            return _productService.Delete(deleteProduct) ? Ok(new Response { Status = "Success", Message = "Deleted successfully!" }) : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
