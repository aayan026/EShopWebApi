using EShop.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Services.Common
{
    public interface IGenericService<T> where T : IBaseEntity, new()
    {

    }
}
