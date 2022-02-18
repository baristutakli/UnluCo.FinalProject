using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class ColorService : IColorService
    {
        public void Add(Color product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Color product)
        {
            throw new NotImplementedException();
        }

        public Task<Color> Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Color> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Color product)
        {
            throw new NotImplementedException();
        }
    }
}
