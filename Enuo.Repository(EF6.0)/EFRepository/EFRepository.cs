using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enuo.Repository.EF6
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields
        private readonly DbContext dbContext;
        private IDbSet<TEntity> entities;
        private IUnitOfWork unitOfWork;
        #endregion

        #region Ctors
        public EFRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            dbContext = context;
        }
        #endregion

        #region Property
        internal IDbSet<TEntity> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = dbContext.Set<TEntity>();
                }
                return entities as DbSet<TEntity>;
            }
        }
        internal IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                {
                    unitOfWork = new UnitOfWork(dbContext);
                }
                return unitOfWork;
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 保存时注意并发问题，此处采用的是客户端优先的并发保存
        /// </summary>
        private void Save()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    dbContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    //数据库优先保存，将会用数据库的值替换
                    //ex.Entries.Single().Reload();
                    //客户端优先，将采用输入的值替换
                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }
                catch (DbUpdateException ex)
                {

                }

            }
            while (saveFailed);
        }
        #endregion

        #region Implements IRepository
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {      
                return Entities.AsNoTracking();
            }
            else
            {
                return Entities.Where(predicate).AsNoTracking();
            }

        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return Entities.AsQueryable();
            }
            else
            {
                return Entities.Where(predicate).AsQueryable();
            }

        }

        public IQueryable<TEntity> FromSql(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).First(); ;
        }
        public void Insert(TEntity entity)
        {
            if (entity != null)
            {
                Entities.Add(entity);
                Save();
            }
        }
        public void Insert(IEnumerable<TEntity> entity, int batchSize = 100)
        {
            if (entities != null && entities.Count<TEntity>() > 0)
            {
                UnitOfWork.BeginTransaction();
                foreach (TEntity item in entities)
                {
                    Entities.Add(item);
                }
                UnitOfWork.CommitTransaction();
            }
        }
        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                Entities.Remove(entity);
                Save();
            }
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            if (entities != null && entities.Count<TEntity>() > 0)
            {
                UnitOfWork.BeginTransaction();
                foreach (TEntity item in entities)
                {
                    Delete(item);
                }
                UnitOfWork.CommitTransaction();
            }
        }
        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                var entry = dbContext.Entry<TEntity>(entity);
                if (entry.State == EntityState.Detached || !dbContext.Configuration.AutoDetectChangesEnabled)
                {
                    dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
                    Save();
                }
            }
        }
        public void Update(IEnumerable<TEntity> entities)
        {
            if (entities != null && entities.Count<TEntity>() > 0)
            {
                UnitOfWork.BeginTransaction();
                foreach (TEntity item in entities)
                {
                    var entry = dbContext.Entry<TEntity>(item);
                    if (entry.State == EntityState.Detached || !dbContext.Configuration.AutoDetectChangesEnabled)
                    {
                        entry.State = EntityState.Modified;
                    }
                }
                UnitOfWork.CommitTransaction();
            }
        }
        public bool IsExist(Expression<Func<TEntity, bool>> criteria)
        {
            return Entities.Where(criteria).Count() > 0;
        }
        public int Count()
        {
            return Entities.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).Count();
        }
        #endregion

        #region Task Methods
        public Task<TEntity> FindAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
