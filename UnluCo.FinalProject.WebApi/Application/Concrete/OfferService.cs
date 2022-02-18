using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;
using UnluCo.FinalProject.WebApi.DataAccess.Abstract;
using UnluCo.FinalProject.WebApi.DataAccess.UnitOfWorks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        public OfferService(IUnitOfWork unitOfwork, IMapper mapper)
        {
            _unitOfwork = unitOfwork;
            _mapper = mapper;
        }
        public void Add(CreateOfferViewModel offerViewModel)
        {
            var offer = _mapper.Map<Offer>(offerViewModel);
            _unitOfwork.Offers.Add(offer);
        }

        public void Delete(DeleteOfferViewModel deleteOfferViewModel)
        {
            var offer = _unitOfwork.Offers.GetById(deleteOfferViewModel.Id).Result;
            _unitOfwork.Offers.Delete(offer);

        }

        public Task<OfferViewModel> Get(Expression<Func<Offer, bool>> filter)
        {
            var offer = _unitOfwork.Offers.Get(filter).Result;
            var offerViewModel = _mapper.Map<OfferViewModel>(offer);
            return Task.FromResult(offerViewModel);
        }

        public Task<List<OfferViewModel>> GetAll(Expression<Func<Offer, bool>> filter = null)
        {
            var offers = _unitOfwork.Offers.GetAll(filter).Result;

            var offerViewList = _mapper.Map<List<Offer>, List<OfferViewModel>>(offers);
            return Task.FromResult(offerViewList);
        }

        public Task<OfferViewModel> GetById(int id)
        {
            var offer = _unitOfwork.Offers.GetById(id).Result;
            var offerViewModel = _mapper.Map<OfferViewModel>(offer);
            return Task.FromResult(offerViewModel);
        }

        public void Update(UpdateOfferViewModel updateOfferViewModel)
        {
            var offer = _mapper.Map<Offer>(updateOfferViewModel);
            _unitOfwork.Offers.Update(offer);
        }
    }
}
