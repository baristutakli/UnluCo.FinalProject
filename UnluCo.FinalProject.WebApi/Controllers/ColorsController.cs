using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ColorsViewModel;

namespace UnluCo.FinalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        private IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        // GET: api/<ColorsController>
        [HttpGet]
        public IActionResult Get()
        {
            var colors = _colorService.GetAll();
            return Ok(colors);
        }

        // GET api/<ColorsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var color = _colorService.GetById(id);
            return Ok(color);
        }

        // POST api/<ColorsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateColorViewModel createColorViewModel)
        {
            _colorService.Add(createColorViewModel);
            return Ok();
        }

        // PUT api/<ColorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateColorViewModel updateColorViewModel)
        {
            updateColorViewModel.Id = id;
            _colorService.Update(updateColorViewModel);
            return Ok();
        }

        // DELETE api/<ColorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteColorViewModel deleteColor = new DeleteColorViewModel() { Id = id };
            _colorService.Delete(deleteColor);
            return Ok();
        }
    }
}
