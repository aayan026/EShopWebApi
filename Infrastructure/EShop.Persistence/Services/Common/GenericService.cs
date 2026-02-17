using EShop.Application.Repositories.Common;
using EShop.Application.Services.Common;
using EShop.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Services.Common
{
    public class GenericService<T> : IGenericService<T> where T : IBaseEntity, new()
    {



    }
}
