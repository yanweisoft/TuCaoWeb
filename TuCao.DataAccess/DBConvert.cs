/*----------------------------------------------------------------
// Copyright (C) 2011 盛拓传媒 
//
// 文件名：DBConvert.cs
// 文件功能描述：数据库字段转换方法
//
//----------------------------------------------------------------*/
using System;

namespace TuCao.DataAccess
{
    /// <summary>
    /// 数据库字段转换方法
    /// </summary>
    public class DbConvert
    {
        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsEmpty(Object o)
        {
            if( o == null )
            {
                return true;
            }

            if( o == DBNull.Value )
            {
                return true;
            }

            return false;
        }

        ///<summary>
        /// 转换为字符串
        ///</summary>
        ///<param name="o"></param>
        ///<returns></returns>
        public static string ToString(Object o)
        {
            return IsEmpty( o ) ? string.Empty : Convert.ToString( o );
        }

        ///<summary>
        /// 转换为int
        ///</summary>
        ///<param name="o"></param>
        ///<returns></returns>
        public static int ToInt(Object o)
        {
            return ToInt( o, 0 );
        }

        ///<summary>
        /// 转换为int
        ///</summary>
        ///<param name="o"></param>
        ///<param name="defaultValue"></param>
        ///<returns></returns>
        public static int ToInt(Object o, int defaultValue )
        {
            if( IsEmpty(o) )
            {
                return defaultValue;
            }

            int result = defaultValue;
            try
            {
                result = Convert.ToInt32(o);
            }
            catch{}

            return result;
        }

    }
}
