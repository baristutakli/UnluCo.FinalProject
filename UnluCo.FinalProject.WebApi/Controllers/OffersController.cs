using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.Validators.Brands;
using UnluCo.FinalProject.WebApi.Application.Validators.Offers;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;

namespace UnluCo.FinalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private IOfferService _offerService;
        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }
        // GET: api/<OffersController>
        [HttpGet]
        public IActionResult Get()
        {
            var offers = _offerService.GetAll();
            return Ok(offers);
        }

        // GET api/<OffersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var offer = _offerService.Get(p=>p.Id==id);
            return Ok(offer);
        }

        // POST api/<OffersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateOfferViewModel createOfferViewModel)
        {

            CreateOfferViewModelValidator validator = new CreateOfferViewModelValidator();
            validator.ValidateAndThrow(createOfferViewModel);
            _offerService.Add(createOfferViewModel);
            return Ok();

        }

        // PUT api/<OffersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateOfferViewModel updateOfferViewModel)
        {
            UpdateOfferViewModelValidator validator = new UpdateOfferViewModelValidator();
            updateOfferViewModel.Id = id;
            validator.ValidateAndThrow(updateOfferViewModel);
            _offerService.Update(updateOfferViewModel);
            return Ok();
        }

        // DELETE api/<OffersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteOfferViewModelValidator validator = new DeleteOfferViewModelValidator();
            DeleteOfferViewModel deleteOffer = new DeleteOfferViewModel() { Id = id };
            validator.ValidateAndThrow(deleteOffer);
            _offerService.Delete(deleteOffer);
            return Ok();
        }
    }
}
