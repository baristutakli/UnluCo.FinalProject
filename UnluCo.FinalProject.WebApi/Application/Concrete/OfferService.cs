using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class OfferService : IOfferService
    {
        public void Add(Offer offer)
        {
            throw new NotImplementedException();
        }

        public void Delete(Offer offer)
        {
            throw new NotImplementedException();
        }

        public Task<Offer> Get(Expression<Func<Offer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Offer>> GetAll(Expression<Func<Offer, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Offer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Offer offer)
        {
            throw new NotImplementedException();
        }
    }
}
