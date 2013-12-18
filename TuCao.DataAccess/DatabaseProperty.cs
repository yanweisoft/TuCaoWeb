/*----------------------------------------------------------------
// Copyright (C) 2011 ʢ�ش�ý 
//
// �ļ�����DatabaseProperty
// �ļ��������������ݿ�������
//
//----------------------------------------------------------------*/

namespace TuCao.DataAccess
{
    /// <summary>
    /// ���ݿ�������
    /// </summary>
    public struct DatabaseProperty
    {
        private string _mConnectionString;

        /// <summary>
        /// ���ݿ�����
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
        /// ���ݿ�����
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
        /// ��������ݿ�������ʵ��
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
