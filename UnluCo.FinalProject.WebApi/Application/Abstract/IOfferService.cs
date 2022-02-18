using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IOfferService
    {
        void Add(Offer offer);
        void Delete(Offer offer);
        void Update(Offer offer);
        Task<List<Offer>> GetAll(Expression<Func<Offer, bool>> filter = null);
        Task<Offer> Get(Expression<Func<Offer, bool>> filter);
        Task<Offer> GetById(int id);

    }
}
