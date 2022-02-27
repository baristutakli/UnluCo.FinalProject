using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ColorsViewModel;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IColorService
    {
        bool Add(CreateColorViewModel createColorViewModel);
        bool Delete(DeleteColorViewModel deleteColorViewModel);
        bool Update(UpdateColorViewModel updateColorViewModel);
        Task<List<ColorViewModel>> GetAll(Expression<Func<Color, bool>> filter = null);
        Task<ColorViewModel> Get(Expression<Func<Color, bool>> filter);
        Task<ColorViewModel> GetById(int id);

    }
}
