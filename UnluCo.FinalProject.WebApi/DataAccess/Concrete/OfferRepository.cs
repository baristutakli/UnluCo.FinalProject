using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Common.Repositories;
using UnluCo.FinalProject.WebApi.DataAccess.Abstract;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.DataAccess.Concrete
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        public OfferRepository(UserDbContext context):base(context)
        {

        }

        public async Task<Offer> GetOffer(Expression<Func<Offer, bool>> filter)
        {
            return await _dbcontext.Set<Offer>().Include("Products").FirstOrDefaultAsync(filter);
        }

        public async Task<List<Offer>> GetOffers(Expression<Func<Offer, bool>> filter=null)
        {
            return filter ==null ?await _dbcontext.Set<Offer>().Include("Products").ToListAsync(): await _dbcontext.Set<Offer>().Include("Products").Where(filter).ToListAsync();
        }

    }
}
