using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ColorsViewModel;
using UnluCo.FinalProject.WebApi.DataAccess.Abstract;
using UnluCo.FinalProject.WebApi.DataAccess.UnitOfWorks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfwork;

        public ColorService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public void Add(ColorViewModel colorViewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(DeleteColorViewModel deleteColorViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ColorViewModel> Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<ColorViewModel>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<ColorViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateColorViewModel updateColorViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
