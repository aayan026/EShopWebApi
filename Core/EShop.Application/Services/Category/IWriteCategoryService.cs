using EShop.Application.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Application.Services.Common;
namespace EShop.Application.Services.Category
{
    public interface ICategoryWriteService : IWriteGenericService<Domain.Entities.Concretes.Category>
    {
    }
}
