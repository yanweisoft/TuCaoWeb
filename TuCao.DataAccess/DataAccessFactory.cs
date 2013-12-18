/*----------------------------------------------------------------
// Copyright (C) 2011 盛拓传媒 
//
// 文件名：DataAccessFactory
// 文件功能描述：数据访问工厂
//
//----------------------------------------------------------------*/
using TuCao.DataAccess.SqlClient;

namespace TuCao.DataAccess
{
    /// <summary>
    /// 数据访问工厂
    /// </summary>
    public sealed class DataAccessFactory
    {
        /// <summary>
        /// 创建数据访问实例 Create an SQLServer dataaccess
        /// </summary>
        /// <param name="connString">数据库链接（配置）</param>
        /// <returns></returns>
        public static SqlDataAccess CreateSqlDataAccess(string connString)
        {
            return new SqlDataAccess(connString);
        }

        /// <summary>
        /// 创建数据访问实例 Create an SQLServer dataaccess
        /// </summary>
        /// <param name="dp">数据库链接（配置）</param>
        /// <returns></returns>
        public static SqlDataAccess CreateSqlDataAccess(DatabaseProperty dp)
        {
            return new SqlDataAccess(dp.ConnectionString);
        }

    }
}