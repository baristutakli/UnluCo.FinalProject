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
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(FinalDbContext context):base(context)
        {

        }

    }
}
