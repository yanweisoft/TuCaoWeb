/*----------------------------------------------------------------
// Copyright (C) 2011 盛拓传媒 
//
// 文件名：DBSettings
// 文件功能描述：Web.Config数据库链接参数设置
//
//----------------------------------------------------------------*/
using System.Configuration;

namespace TuCao.DataAccess
{
    /// <summary>
    /// Web.Config数据库链接参数设置
    /// </summary>
    public sealed class DBSettings
    {
        /// <summary>
        /// UserCenter 主数据库
        /// 
        /// 配置节点：UserCenterMainDB.ConnectionString
        /// </summary>
        public static DatabaseProperty TuCaoMainDb;

        /// <summary>
        /// UserCenter 读数据库
        /// 
        /// 配置节点：UserCenterReadDB.ConnectionString
        /// </summary>
        public static DatabaseProperty UserCenterReadDb;





        /// <summary>
        /// 构造设置
        /// </summary>
        static DBSettings()
        {
            // UserCenter 主数据库
            TuCaoMainDb = GetDatabaseProperty("TuCaoMainDB.ConnectionString");
        }

        #region 得到数据库链接设置
        /// <summary>
        /// 得到数据库链接设置
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <returns></returns>
        public static DatabaseProperty GetDatabaseProperty(string name)
        {
            DatabaseProperty dp = new DatabaseProperty { DatabaseType = DatabaseType.MSSQLServer };

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings == null)
            {
                dp.ConnectionString = string.Empty;
            }
            else
            {
                dp.ConnectionString = settings.ConnectionString;
                if (settings.ProviderName == "System.Data.SqlClient")
                {
                    dp.DatabaseType = DatabaseType.MSSQLServer;
                }
            }

            return dp;
        }
        #endregion
    }
}