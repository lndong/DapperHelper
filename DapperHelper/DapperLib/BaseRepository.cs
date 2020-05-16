using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;

namespace DapperLib
{
    public class BaseRepository : IRepository
    {
        protected ILogger<BaseRepository> Logger { get; }

        public IUnitOfWork UnitOfWork { get; }

        public BaseRepository(/*ILogger<BaseRepository> logger,*/ IUnitOfWork unitOfWork)
        {
            //Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected IDbConnection DbConnection => UnitOfWork.Connection;

        #region 同步增删改

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Insert(string sql, object param = null) => Execute(sql, param);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Update(string sql, object param = null) => Execute(sql, param);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Delete(string sql, object param = null) => Execute(sql, param);

        /// <summary>
        /// 执行sql语句返回响应条数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private int Execute(string sql, object param = null)
        {
            return DbConnection.Execute(sql, param, UnitOfWork.Transaction);
        }

        #endregion

        #region 异步增删改

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(string sql, object param = null) => await ExecuteAsync(sql, param);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(string sql, object param = null) => await ExecuteAsync(sql, param);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(string sql, object param = null) => await ExecuteAsync(sql, param);

        /// <summary>
        /// 执行sql语句返回响应条数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private async Task<int> ExecuteAsync(string sql, object param = null)
        {
            return await DbConnection.ExecuteAsync(sql, param, UnitOfWork.Transaction);
        }

        #endregion

        #region 查询

        public T QueryFirstOrDefault<T>(string sql, object param = null)
        {
            return DbConnection.QueryFirstOrDefault<T>(sql, param, UnitOfWork.Transaction);
        }

        public List<T> QueryList<T>(string sql, object param = null)
        {
            return DbConnection.Query<T>(sql, param, UnitOfWork.Transaction).ToList();
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null)
        {
            return await DbConnection.QueryFirstOrDefaultAsync<T>(sql, param, UnitOfWork.Transaction);
        }

        public async Task<List<T>> QueryListAsync<T>(string sql, object param = null)
        {
            var res = await DbConnection.QueryAsync<T>(sql, param, UnitOfWork.Transaction);
            return res.ToList();
        }

        #endregion
    }
}