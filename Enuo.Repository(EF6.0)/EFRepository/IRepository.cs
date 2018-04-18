using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enuo.Repository.EF6
{
    /// <summary>
    /// The sort order.
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// The ascending.
        /// </summary>
        Ascending,

        /// <summary>
        /// The descending.
        /// </summary>
        Descending
    }
    public interface IRepository<TEntity> where TEntity : class
    {
        //DbSet<TEntity> Entities { get; }

        #region Methods
        /// <summary>
        /// Filters a sequence of values based on a predicate. This method is no-tracking query.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements that satisfy the condition specified by predicate.</returns>
        /// <remarks>This method is no-tracking query.</remarks>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Filters a sequence of values based on a predicate. This method will change tracking by context.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that contains elements that satisfy the condition specified by predicate.</returns>
        /// <remarks>This method will change tracking by context.</remarks>
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Uses raw SQL queries to fetch the specified <typeparamref name="TEntity" /> data.
        /// </summary>
        /// <param name="sql">The raw SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>An <see cref="IQueryable{TEntity}" /> that contains elements that satisfy the condition specified by raw SQL.</returns>
        IQueryable<TEntity> FromSql(string sql, params object[] parameters);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Insert a new Entity
        /// </summary>
        /// <param name="entity">The entity to Insert</param>
        void Insert(TEntity entity);
        /// <summary>
        /// Insert the specified entities
        /// </summary>
        /// <param name="entity">The entity to Insert</param>
        void Insert(IEnumerable<TEntity> entity, int batchSize = 100);
        /// <summary>
        /// Delete a Entity
        /// </summary>
        /// <param name="entity">The entity to  Delete</param>
        void Delete(TEntity entity);
        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void Delete(IEnumerable<TEntity> entities);
        /// <summary>
        /// Update a Entity
        /// </summary>
        /// <param name="entities">The entity to Update</param>
        void Update(TEntity entity);
        /// <summary>
        /// Updates the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void Update(IEnumerable<TEntity> entities);
        /// <summary>
        /// 验证实体时否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool IsExist(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 获取所有实体数量
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// 获取指定lambda表达式实体数量
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Task Methods
        /// <summary>
        /// Finds an entity with the given primary key values. If found, is attached to the context and returned. If no entity is found, then null is returned.
        /// </summary>
        /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
        /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous find operation. The task result contains the found entity or null.</returns>
        Task<TEntity> FindAsync(params object[] keyValues);

        /// <summary>
        /// Inserts a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous insert operation.</returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Inserts a range of entities asynchronously.
        /// </summary>
        /// <param name="entities">The entities to insert.</param>
        /// <returns>Task.</returns>
        Task InsertAsync(params TEntity[] entities);

        /// <summary>
        /// Inserts a range of entities asynchronously.
        /// </summary>
        /// <param name="entities">The entities to insert.</param>
        /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous insert operation.</returns>
        Task InsertAsync(IEnumerable<TEntity> entities);
        #endregion

        #region 批量处理操作
        ///// <summary>
        ///// 获取分页实体集
        ///// </summary>
        ///// <typeparam name="TOrderBy"></typeparam>
        ///// <param name="orderBy">排序组属性</param>
        ///// <param name="pageIndex">当前页</param>
        ///// <param name="pageSize">每页大小</param>
        ///// <param name="sortOrder">排序方式</param>
        ///// <returns></returns>
        //IEnumerable<TEntity> Get<TOrderBy>(Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending);
        ///// <summary>
        ///// 获取分页实体集
        ///// </summary>
        ///// <typeparam name="TOrderBy"></typeparam>
        ///// <param name="criteria">lambda表达式</param>
        ///// <param name="orderBy">排序组属性</param>
        ///// <param name="pageIndex">当前页</param>
        ///// <param name="pageSize">每页大小</param>
        ///// <param name="sortOrder">排序方式</param>
        ///// <returns></returns>
        //IEnumerable<TEntity> Get<TOrderBy>(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, TOrderBy>> orderBy, int pageIndex, int pageSize, SortOrder sortOrder = SortOrder.Ascending);
        #endregion


    }
}
