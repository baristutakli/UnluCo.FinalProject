using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IColorService
    {
        void Add(Color product);
        void Delete(Color product);
        void Update(Color product);
        Task<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null);
        Task<Color> Get(Expression<Func<Color, bool>> filter);
        Task<Color> GetById(int id);

    }
}
