using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperLib
{
    public interface IRepository<T> where T : class
    {
        #region 同步增删改

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Insert(T t);

        /// <summary>
        /// 新增列表(返回响应条数)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        int Insert(List<T> list);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update(T t);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update(List<T> list);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Delete(T t);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool Delete(List<T> list);

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int Execute(string sql, object param = null);

        #endregion

        #region 异步增删改

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        Task<int> InsertAsync(T t, int? commandTimeout = null);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<int> InsertAsync(List<T> list);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T t);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(List<T> list);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(T t);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(List<T> list);

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<int> ExecuteAsync(string sql, object param = null);

        #endregion

        #region 查询

        /// <summary>
        /// 根据条件获取条数
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        T2 QueryFirstOrDefault<T2>(string sql, object param = null);

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        T QueryFirstOrDefault(string sql, object param = null);


        List<T> QueryList(string sql, object param = null);

        /// <summary>
        /// 异步获取实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<T> QueryFirstOrDefaultAsync(string sql, object param = null);

        /// <summary>
        /// 异步获取条数
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<T2> QueryFirstOrDefaultAsync<T2>(string sql, object param = null);

        Task<List<T>> QueryListAsync(string sql, object param = null);

        #endregion
    }
}