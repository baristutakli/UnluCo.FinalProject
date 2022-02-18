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

        public OfferService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public void Add(CreateOfferViewModel offerViewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(DeleteOfferViewModel deleteOfferViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<CreateOfferViewModel> Get(Expression<Func<Offer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<CreateOfferViewModel>> GetAll(Expression<Func<Offer, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<CreateOfferViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateOfferViewModel updateOfferViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
