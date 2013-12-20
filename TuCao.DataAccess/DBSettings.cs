/*----------------------------------------------------------------
// Copyright (C) 2011 ʢ�ش�ý 
//
// �ļ�����DBSettings
// �ļ�����������Web.Config���ݿ����Ӳ�������
//
//----------------------------------------------------------------*/
using System.Configuration;

namespace TuCao.DataAccess
{
    /// <summary>
    /// Web.Config���ݿ����Ӳ�������
    /// </summary>
    public sealed class DBSettings
    {
        /// <summary>
        /// UserCenter �����ݿ�
        /// 
        /// ���ýڵ㣺UserCenterMainDB.ConnectionString
        /// </summary>
        public static DatabaseProperty TuCaoMainDb;

        /// <summary>
        /// UserCenter �����ݿ�
        /// 
        /// ���ýڵ㣺UserCenterReadDB.ConnectionString
        /// </summary>
      //public static DatabaseProperty UserCenterReadDb;

        /// <summary>
        /// ��������
        /// </summary>
        static DBSettings()
        {
            // UserCenter �����ݿ�
            TuCaoMainDb = GetDatabaseProperty("TuCaoMainDB.ConnectionString");
        }

        #region �õ����ݿ���������
        /// <summary>
        /// �õ����ݿ���������
        /// </summary>
        /// <param name="name">�ڵ�����</param>
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