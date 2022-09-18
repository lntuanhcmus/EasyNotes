using EasyNotes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotes.Infrastructure.Models
{
    public interface IRepository<T> : IRepositoryWithTypeId<T,long> where T: IEntityWithTypedId<long>
    {

    }
}
