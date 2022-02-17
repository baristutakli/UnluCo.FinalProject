using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Common.Repositories;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.DataAccess.Abstract
{
    public interface IOfferRepository: IRepository<Offer>
    {
        public Task<Offer> GetOffer(Expression<Func<Offer, bool>> filter);
        public Task<List<Offer>> GetOffers(Expression<Func<Offer, bool>> filter = null);
    }
}
