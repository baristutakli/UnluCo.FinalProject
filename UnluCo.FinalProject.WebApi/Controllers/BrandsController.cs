using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.Validators.Brands;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnluCo.FinalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;

        }
        // GET: api/<BrandsController>
        [HttpGet]
        public IActionResult Get()
        {
            var brands = _brandService.GetAll().Result;
            return Ok(JsonConvert.SerializeObject(brands, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
            // return brands == null? StatusCode((int)HttpStatusCode.InternalServerError):Ok(brands);
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var brand = _brandService.GetById(id);
            return brand == null ? NoContent() : Ok(brand);
        }

        // POST api/<BrandsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBrandViewModel createBrandViewModel)
        {
            CreateBrandViewValidator validator = new();
            validator.ValidateAndThrow(createBrandViewModel);
            return _brandService.Add(createBrandViewModel) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);

        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBrandViewModel updateBrandViewModel)
        {
            UpdateBrandViewValidator validator = new UpdateBrandViewValidator();
            validator.ValidateAndThrow(updateBrandViewModel);

            return _brandService.Update(id, updateBrandViewModel) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteBrandViewModel deleteBrand = new DeleteBrandViewModel() { Id = id };
            DeleteBrandViewValidator validator = new DeleteBrandViewValidator();
            validator.ValidateAndThrow(deleteBrand);

            return _brandService.Delete(deleteBrand) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
