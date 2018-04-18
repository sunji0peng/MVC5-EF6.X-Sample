using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enuo.Repository.EF6
{
    /// <summary>
    /// 批量事务处理接口，实现事务处理相关操作
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 是否进行事务
        /// </summary>
        bool IsInTransaction { get; }
        /// <summary>
        /// 开始事务
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// 开始事务
        /// </summary>
        void BeginTransaction(IsolationLevel isolationLevel);
        /// <summary>
        /// 回滚操作
        /// </summary>
        void RollBackTransaction();
        /// <summary>
        /// 提交
        /// </summary>
        void CommitTransaction();
    }
}
