using SR.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SR.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> AddAllAsync(List<T> entityList);
        Task<T> UpdateAsync(T entity, string updatedBy);
        Task<List<T>> UpdateAllAsync(List<T> entityList,string updatedBy);
        Task DeleteAsync(T entity, string updatedBy, bool isHardDelete = false);
        Task DeleteAllAsync(List<T> entityList, string updatedBy, bool isHarDelete = false);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> GetWithEntityAsync(Expression<Func<T, bool>> predicate, string[] entityNames);
        Task<List<T>> GetListWithEntityAsync(Expression<Func<T, bool>> predicate, string[] entityNames);
        Task<bool> CheckIfExistsAsync(Expression<Func<T, bool>> predicate);
        // Sync Functions
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity, string updatedBy, bool isHardDelete = false);
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetList(Expression<Func<T, bool>> predicate);
        bool CheckIfExists(Expression<Func<T, bool>> predicate);

    }
}
