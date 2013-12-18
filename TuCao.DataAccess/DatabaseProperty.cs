/*----------------------------------------------------------------
// Copyright (C) 2011 盛拓传媒 
//
// 文件名：DatabaseProperty
// 文件功能描述：数据库属性类
//
//----------------------------------------------------------------*/

namespace TuCao.DataAccess
{
    /// <summary>
    /// 数据库属性类
    /// </summary>
    public struct DatabaseProperty
    {
        private string _mConnectionString;

        /// <summary>
        /// 数据库链接
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return _mConnectionString;
            }
            set
            {
                _mConnectionString = value;
            }
        }

        private DatabaseType _mDatabaseType;

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DatabaseType
        {
            get
            {
                return _mDatabaseType;
            }
            set
            {
                _mDatabaseType = value;
            }
        }

        /// <summary>
        /// 构造空数据库属性类实例
        /// </summary>
        public static DatabaseProperty Empty
        {
            get
            {
                return new DatabaseProperty();
            }
        }
    }
}
