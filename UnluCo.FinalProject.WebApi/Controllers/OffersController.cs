using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.Validators.Brands;
using UnluCo.FinalProject.WebApi.Application.Validators.Offers;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;
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
            var offer = _offerService.Get(p => p.Id == id);
            return Ok(offer);
        }

        // POST api/<OffersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateOfferViewModel createOfferViewModel)
        {

            CreateOfferViewModelValidator validator = new CreateOfferViewModelValidator();
            validator.ValidateAndThrow(createOfferViewModel);

            return _offerService.Add(createOfferViewModel) ? Ok(new Response { Status = "Success", Message = "Created successfully!" }) : StatusCode(StatusCodes.Status500InternalServerError);

        }

        [HttpPut("{id}/Active")]
        public IActionResult UpdateOfferActivity(int id, [FromBody] UpdateOfferActivityViewModel updateOfferActivityViewModel)
        {
            UpdateOfferActivityViewModelValidator validator = new UpdateOfferActivityViewModelValidator();
            updateOfferActivityViewModel.Id = id;
            validator.ValidateAndThrow(updateOfferActivityViewModel);

            return _offerService.Update(updateOfferActivityViewModel) ? Ok(new Response { Status = "Success", Message = "Updated successfully!" }) : StatusCode(StatusCodes.Status500InternalServerError);
        }


        // PUT api/<OffersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateOfferViewModel updateOfferViewModel)
        {
            UpdateOfferViewModelValidator validator = new UpdateOfferViewModelValidator();
            updateOfferViewModel.Id = id;
            validator.ValidateAndThrow(updateOfferViewModel);

            return _offerService.Update(updateOfferViewModel) ? Ok(new Response { Status = "Success", Message = "Updated successfully!" }) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // DELETE api/<OffersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(DeleteOfferViewModel deleteOfferViewModel)
        {
            DeleteOfferViewModelValidator validator = new DeleteOfferViewModelValidator();
            DeleteOfferViewModel deleteOffer = new DeleteOfferViewModel() { Id = deleteOfferViewModel.Id };
            validator.ValidateAndThrow(deleteOffer);

            return _offerService.Delete(deleteOffer) ? Ok(new Response { Status = "Success", Message = "Deleted  successfully!" }) : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
