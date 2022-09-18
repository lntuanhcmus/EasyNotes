using EasyNotes.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotes.Infrastructure.Data
{
    public interface IRepositoryWithTypeId<T, TId> where T: IEntityWithTypedId<TId>
    {
        IQueryable<T> Query();

        T FindById(TId id);

        Task<T> FindByIdAsync(TId id);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void RemoveRAnge(IEnumerable<T> entities);

        void Update(T entity);

        void SaveChanges();

        Task SaveChangeAsyncs();

        void Remove(T entity);

    }
}
