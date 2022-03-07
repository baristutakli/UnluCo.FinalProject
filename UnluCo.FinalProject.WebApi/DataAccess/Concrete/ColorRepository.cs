using UnluCo.FinalProject.WebApi.Common.Repositories;
using UnluCo.FinalProject.WebApi.DataAccess.Abstract;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.DataAccess.Concrete
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(UserDbContext context) : base(context)
        {

        }

    }
}
