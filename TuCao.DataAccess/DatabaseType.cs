/*----------------------------------------------------------------
// Copyright (C) 2011 盛拓传媒 
//
// 文件名：DatabaseType
// 文件功能描述：数据库类型枚举
//
//----------------------------------------------------------------*/
namespace TuCao.DataAccess
{
    /// <summary>
    /// 数据库类型枚举
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// SQLServer
        /// </summary>
        MSSQLServer = 0,
        /// <summary
        /// >Oracle
        /// </summary>
        Oracle = 1,
        /// <summary>
        /// OleDB
        /// </summary>
        OleDB = 2,
        /// <summary>
        /// Odbc
        /// </summary>
        Odbc = 3,
        /// <summary>
        /// MySql
        /// </summary>
        MySql = 4,
    }
}
