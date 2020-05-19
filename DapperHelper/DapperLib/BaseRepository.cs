using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Logging;

namespace DapperLib
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        public IUnitOfWork UnitOfWork { get; }

        public BaseRepository( IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        protected IDbConnection DbConnection => UnitOfWork.Connection;

        #region 同步增删改

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns>返回的是自增Id值，非自增Id返回0</returns>
        public int Insert(T t)
        {
            return (int) DbConnection.Insert(t, UnitOfWork.Transaction);
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="list"></param>
        /// <returns>返回响应条数</returns>
        public int Insert(List<T> list)
        {
            return (int) DbConnection.Insert(list, UnitOfWork.Transaction);
        }


        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update(T t)
        {
            return DbConnection.Update(t, UnitOfWork.Transaction);
        }

        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Update(List<T> list)
        {
            return DbConnection.Update(list, UnitOfWork.Transaction);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Delete(T t)
        {
            return DbConnection.Delete(t, UnitOfWork.Transaction);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Delete(List<T> list)
        {
            return DbConnection.Delete(list, UnitOfWork.Transaction);
        }

        /// <summary>
        /// 执行sql语句返回响应条数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Execute(string sql, object param = null)
        {
            return DbConnection.Execute(sql, param, UnitOfWork.Transaction);
        }

        #endregion

        #region 异步增删改

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public async Task<int> InsertAsync(T t, int? commandTimeout = null)
        {

            return await DbConnection.InsertAsync(t, UnitOfWork.Transaction, commandTimeout);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(List<T> list)
        {
            return await DbConnection.InsertAsync(list, UnitOfWork.Transaction);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(T t)
        {
            return await DbConnection.UpdateAsync(t, UnitOfWork.Transaction);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(List<T> list)
        {
            return await DbConnection.UpdateAsync(list, UnitOfWork.Transaction);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(T t)
        {
            return await DbConnection.DeleteAsync(t, UnitOfWork.Transaction);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(List<T> list)
        {
            return await DbConnection.DeleteAsync(list, UnitOfWork.Transaction);
        }

        /// <summary>
        /// 执行sql语句返回响应条数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, object param = null)
        {
            return await DbConnection.ExecuteAsync(sql, param, UnitOfWork.Transaction);
        }

        #endregion

        #region 查询

        public T QueryFirstOrDefault(string sql, object param = null)
        {
            return DbConnection.QueryFirstOrDefault<T>(sql, param, UnitOfWork.Transaction);
        }

        /// <summary>
        /// 根据条件获取条数
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public T2 QueryFirstOrDefault<T2>(string sql, object param = null)
        {
            return DbConnection.QueryFirstOrDefault<T2>(sql, param, UnitOfWork.Transaction);
        }

        public List<T> QueryList(string sql, object param = null)
        {
            return DbConnection.Query<T>(sql, param, UnitOfWork.Transaction).ToList();
        }

        public async Task<T> QueryFirstOrDefaultAsync(string sql, object param = null)
        {
            return await DbConnection.QueryFirstOrDefaultAsync<T>(sql, param, UnitOfWork.Transaction);
        }

        public async Task<T2> QueryFirstOrDefaultAsync<T2>(string sql, object param = null)
        {
            return await DbConnection.QueryFirstOrDefaultAsync<T2>(sql, param, UnitOfWork.Transaction);
        }

        public async Task<List<T>> QueryListAsync(string sql, object param = null)
        {
            var res = await DbConnection.QueryAsync<T>(sql, param, UnitOfWork.Transaction);
            return res.ToList();
        }

        #endregion
    }
}