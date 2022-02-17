using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.DataAccess.Abstract;
using UnluCo.FinalProject.WebApi.DataAccess.Concrete;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository Developers{get;private set;}

        public IColorRepository Colors{get;private set;}

        public IBrandRepository Brands{get;private set;}

        public IOfferRepository Offers{get;private set;}

        public IUserRepository Users{get;private set;}

        public ICategoryRepository Categories{get;private set;}

        private readonly UserDbContext _dbcontext;

        public IProductRepository IProductRepository { get; }

        public UnitOfWork(UserDbContext context)
        {
            _dbcontext = context;
            IProductRepository = new ProductRepository(_dbcontext);

        }
        public int Complete()
        {
           return  _dbcontext.SaveChanges();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
