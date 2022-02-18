using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IOfferService
    {
        void Add(CreateOfferViewModel offerViewModel);
        void Delete(DeleteOfferViewModel deleteOfferViewModel);
        void Update(UpdateOfferViewModel updateOfferViewModel);
        Task<List<OfferViewModel>> GetAll(Expression<Func<Offer, bool>> filter = null);
        Task<OfferViewModel> Get(Expression<Func<Offer, bool>> filter);
        Task<OfferViewModel> GetById(int id);

    }
}
