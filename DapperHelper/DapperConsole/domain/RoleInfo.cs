using System;
using Dapper.Contrib.Extensions;

namespace DapperConsole.domain
{
    [Table("RoleInfo")]
    public class RoleInfo
    {
        [Key]
        public int Id { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }

    }
}