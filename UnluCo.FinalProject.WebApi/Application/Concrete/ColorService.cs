using AutoMapper;
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
        private readonly IMapper _mapper;
        public ColorService(IUnitOfWork unitOfwork, IMapper mapper)
        {
            _unitOfwork = unitOfwork;
            _mapper = mapper;
        }
        public void Add(CreateColorViewModel colorViewModel)
        {
            var color = _mapper.Map<Color>(colorViewModel);
            _unitOfwork.Colors.Add(color);
            _unitOfwork.Complete();
        }

        public void Delete(DeleteColorViewModel deleteColorViewModel)
        {
            var color = _unitOfwork.Colors.GetById(deleteColorViewModel.Id).Result;
            _unitOfwork.Colors.Delete(color);
            _unitOfwork.Complete();

        }

        public Task<ColorViewModel> Get(Expression<Func<Color, bool>> filter)
        {
            var color = _unitOfwork.Colors.Get(filter).Result;
            var colorViewModel = _mapper.Map<ColorViewModel>(color);
            return Task.FromResult(colorViewModel);
        }

        public Task<List<ColorViewModel>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            var colors = _unitOfwork.Colors.GetAll(filter).Result;

            var colorViewList = _mapper.Map<List<Color>, List<ColorViewModel>>(colors);
            return Task.FromResult(colorViewList);
        }

        public Task<ColorViewModel> GetById(int id)
        {
            var color = _unitOfwork.Colors.GetById(id).Result;
            var colorViewModel = _mapper.Map<ColorViewModel>(color);
            return Task.FromResult(colorViewModel);
        }

        public void Update(UpdateColorViewModel updateColorViewModel)
        {
            var color = _mapper.Map<Color>(updateColorViewModel);
            
            _unitOfwork.Colors.Update(color);
            _unitOfwork.Complete();
        }
    }
}
