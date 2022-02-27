using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;
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
        public bool Add(CreateOfferViewModel offerViewModel)
        {
            var product= _unitOfwork.Products.GetById(offerViewModel.ProductId).Result;
            if (product is not null)
            {
                if (offerViewModel.Percentage != 0 && offerViewModel.Amount ==0)
                {
                    offerViewModel.Amount = Convert.ToInt32((offerViewModel.Percentage * product.Price) / 100);
                }
                if (offerViewModel.Amount == product.Price)
                {
                    product.IsSold = true;
                    product.IsOfferable = false;
                }

            }
       
            var offer = _mapper.Map<Offer>(offerViewModel);
            offer.Product = product;
            _unitOfwork.Offers.Add(offer);
           var affectedRows =  _unitOfwork.Complete();
            return affectedRows > 0 ? true : false;
        }

        public bool Delete(DeleteOfferViewModel deleteOfferViewModel)
        {
            var offer = _unitOfwork.Offers.GetById(deleteOfferViewModel.Id).Result;
            _unitOfwork.Offers.Delete(offer);
           var affectedRows =  _unitOfwork.Complete();
            return affectedRows > 0 ? true : false;

        }

        public Task<OfferViewModel> Get(Expression<Func<Offer, bool>> filter)
        {
            var offer = _unitOfwork.Offers.GetOffer(filter).Result;
            var vm = _mapper.Map<OfferViewModel>(offer);
            //var offerViewModel = _mapper.Map(offer);
            return Task.FromResult(vm);
        }

        public Task<List<OfferViewModel>> GetAll(Expression<Func<Offer, bool>> filter = null)
        {
            var offers = _unitOfwork.Offers.GetOffers(filter).Result;

            var offerViewList = _mapper.Map<List<Offer>, List<OfferViewModel>>(offers);
            return Task.FromResult(offerViewList);
        }

        public Task<OfferViewModel> GetById(int id)
        {
            var offer = _unitOfwork.Offers.GetById(id).Result;
            var offerViewModel = _mapper.Map<OfferViewModel>(offer);
            return Task.FromResult(offerViewModel);
        }

        public bool Update(UpdateOfferViewModel offerViewModel)
        {
            var product = _unitOfwork.Products.GetById(offerViewModel.ProductId).Result;
            if (product is not null)
            {
                if (offerViewModel.Percentage != 0 && offerViewModel.Amount == 0)
                {
                    offerViewModel.Amount = Convert.ToInt32((offerViewModel.Percentage * product.Price) / 100);
                }
                if (offerViewModel.Amount == product.Price)
                {
                    product.IsSold = true;
                    product.IsOfferable = false;
                }

            }

            var offer = _mapper.Map<Offer>(offerViewModel);
            offer.Product = product;
            _unitOfwork.Offers.Add(offer);
           var affectedRows =  _unitOfwork.Complete();
            return affectedRows > 0 ? true : false;
        }

        // Changes offer status
        public bool Update(UpdateOfferActivityViewModel offerViewModel)
        {
            var offer = _unitOfwork.Offers.GetById(offerViewModel.Id).Result;
            var product = _unitOfwork.Products.GetById(offerViewModel.Id).Result;
            if (product is not null && offerViewModel.IsActive==false)
            {
                    product.IsSold = true;
                    product.IsOfferable = false;
            }

            offer.Product = product;

            _unitOfwork.Offers.Update(offer);

           var affectedRows =  _unitOfwork.Complete();

            var offersToDelete = _unitOfwork.Offers.GetOffers(o => o.Product.Id == offerViewModel.ProductId).Result;
            foreach (var selectedOffer in offersToDelete)
            {
                if (selectedOffer.Id!=offer.Id)
                {
                    _unitOfwork.Offers.Delete(selectedOffer);
                }
            
            }
           var result=  _unitOfwork.Complete();
            return result> 0 ? true : false;
        }
    }
}
