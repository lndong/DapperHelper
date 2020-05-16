using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperLib
{
    public interface IRepository
    {
        #region 同步增删改

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int Insert(string sql, object param = null);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int Update(string sql, object param = null);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int Delete(string sql, object param = null);

        #endregion

        #region 异步增删改

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<int> InsertAsync(string sql, object param = null);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(string sql, object param = null);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(string sql, object param = null);


        #endregion

        #region 查询

        T QueryFirstOrDefault<T>(string sql, object param = null);


        List<T> QueryList<T>(string sql, object param = null);


        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null);

        Task<List<T>> QueryListAsync<T>(string sql, object param = null);

        #endregion
    }
}