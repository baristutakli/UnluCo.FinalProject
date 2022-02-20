using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;
using UnluCo.FinalProject.WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnluCo.FinalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _brandService;
      
        public CategoriesController(ICategoryService brandService)
        {
            _brandService = brandService;
          
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
            var brands = _brandService.GetAll();
            return Ok(brands);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           var brand= _brandService.GetById(id);
            return Ok(brand);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryViewModel createCategoryViewModel)
        {
            _brandService.Add(createCategoryViewModel);
            return Ok();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateCategoryViewModel updateCategoryViewModel)
        {
            _brandService.Update(id,updateCategoryViewModel);
            return Ok();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteCategoryViewModel deleteCategory = new DeleteCategoryViewModel() { Id=id};  
            _brandService.Delete(deleteCategory);
            return Ok();
        }
    }
}
