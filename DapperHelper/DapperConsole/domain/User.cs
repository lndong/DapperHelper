using System;
using Dapper.Contrib.Extensions;

namespace DapperConsole.domain
{
    /// <summary>
    /// 没有加此特性时，在使用Contrib扩展时表名会默认加s
    /// </summary>
    [Table("UserInfo")]
    public class User
    {
        [ExplicitKey]
        public Guid UserId { get; set; }

        public string UserName { get; set; }
    }
}