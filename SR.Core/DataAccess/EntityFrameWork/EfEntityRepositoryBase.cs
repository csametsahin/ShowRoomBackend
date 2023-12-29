using Microsoft.EntityFrameworkCore;
using SR.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SR.Core.DataAccess.EntityFrameWork
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        #region async methods
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public virtual async Task<List<TEntity>> AddAllAsync(List<TEntity> entityList)
        {
            using (var context = new TContext())
            {
                await context.Set<TEntity>().AddRangeAsync(entityList);
                await context.SaveChangesAsync();
                return entityList;
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, string updatedBy)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                updatedEntity.CurrentValues["UpdatedDate"] = DateTime.Now;
                updatedEntity.CurrentValues["UpdatedBy"] = updatedBy;
                context.ChangeTracker.DetectChanges();
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public virtual async Task<List<TEntity>> UpdateAllAsync(List<TEntity> entityList, string updatedBy)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entityList)
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    updatedEntity.CurrentValues["UpdatedDate"] = DateTime.Now;
                    updatedEntity.CurrentValues["UpdatedBy"] = updatedBy;
                }
                context.ChangeTracker.DetectChanges();
                await context.SaveChangesAsync();
                return entityList;
            }
        }

        public virtual async Task DeleteAsync(TEntity entity, string updatedBy, bool isHardDelete)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                if (!isHardDelete)
                {
                    deletedEntity.State = EntityState.Modified;
                    deletedEntity.CurrentValues["UpdatedDate"] = DateTime.Now;
                    deletedEntity.CurrentValues["UpdatedBy"] = updatedBy;
                    deletedEntity.CurrentValues["IsDeleted"] = true;
                }
                else
                {
                    deletedEntity.State = EntityState.Deleted;
                }
                context.ChangeTracker.DetectChanges();
                await context.SaveChangesAsync();

            }
        }
        public virtual async Task DeleteAllAsync(List<TEntity> entityList, string updatedBy, bool isHardDelete = false)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entityList)
                {
                    var deletedEntity = context.Entry(entity);
                    if (!isHardDelete)
                    {
                        deletedEntity.State = EntityState.Modified;
                        deletedEntity.CurrentValues["IsDeleted"] = true;
                        deletedEntity.CurrentValues["UpdatedDate"] = DateTime.Now;
                        deletedEntity.CurrentValues["UpdatedBy"] = updatedBy;
                    }
                    else
                    {
                        deletedEntity.State = EntityState.Deleted;
                    }
                    context.ChangeTracker.DetectChanges();
                }
                await context.SaveChangesAsync();
            }
        }
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return await context
                    .Set<TEntity>()
                    .FirstOrDefaultAsync(predicate);
            }
        }
        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            using (var context = new TContext())
            {
                return predicate == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(predicate).ToListAsync();
            }
        }
        public virtual async Task<TEntity> GetWithEntityAsync(Expression<Func<TEntity, bool>> predicate, params string[] entityNames)
        {
            using (var context = new TContext())
            {
                var entity = context.Set<TEntity>().AsQueryable();
                foreach (var entityName in entityNames)
                    entity = entity.Include(entityName);

                return await entity
                    .FirstOrDefaultAsync(predicate);
            }
        }
        public virtual async Task<List<TEntity>> GetListWithEntityAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] entityNames)
        {
            using (var context = new TContext())
            {
                var entity = context.Set<TEntity>().AsQueryable();
                foreach (var entityName in entityNames)
                    entity = entity.Include(entityName);

                var result = predicate == null ? entity : entity.Where(predicate);
                return await result.ToListAsync();
            }
        }
        public virtual async Task<bool> CheckIfExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return await context
                    .Set<TEntity>()
                    .AnyAsync(predicate);
            }
        }
        #endregion

        #region sync methods
        public virtual TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }
        public virtual TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
        public virtual void Delete(TEntity entity, string updatedBy, bool isHardDelete = false)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                if (!isHardDelete)
                {
                    deletedEntity.State = EntityState.Modified;
                    deletedEntity.CurrentValues["UpdatedBy"] = updatedBy;
                    deletedEntity.CurrentValues["UpdatedDate"] = DateTime.Now;
                    deletedEntity.CurrentValues["IsDeleted"] = true;
                }
                else
                {
                    deletedEntity.State = EntityState.Deleted;
                }
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
            }
        }
        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }
        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null)
        {
            using (var context = new TContext())
            {
                return predicate == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(predicate).ToList();
            }
        }
        public bool CheckIfExists(Expression<Func<TEntity, bool>> predicate)
        {

            using (var context = new TContext())
            {
                return context.Set<TEntity>().Any(predicate);
            }

        }
        #endregion
    }
}
