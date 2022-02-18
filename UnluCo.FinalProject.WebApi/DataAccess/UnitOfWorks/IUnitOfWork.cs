using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.DataAccess.Abstract;

namespace UnluCo.FinalProject.WebApi.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products{ get; }
        IColorRepository Colors { get; }
        IBrandRepository Brands { get; }
        IOfferRepository Offers { get; }
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }
        int Complete();
    }
}
