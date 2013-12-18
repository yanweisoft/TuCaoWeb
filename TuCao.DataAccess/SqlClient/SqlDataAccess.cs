/*----------------------------------------------------------------
// Copyright (C) 2011 ʢ�ش�ý 
//
// �ļ�����SqlDataAccess
// �ļ�����������MSSql���ݿ������
//
//----------------------------------------------------------------*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace TuCao.DataAccess.SqlClient
{
    /// <summary>
    /// MSSql���ݿ������
    /// </summary>
    public sealed class SqlDataAccess
    {

        #region Private properties

        /// <summary>
        /// Ĭ�����ʱʱ��
        /// Default command timeout
        /// </summary>
        private const int DEF_CMD_TIMEOUT = 10;
        /// <summary>
        /// Ĭ�����ʱʱ��
        /// </summary>
        private int m_CommandTimeOut = DEF_CMD_TIMEOUT;
        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        private SqlConnection m_Connection;
        /// <summary>
        /// ���ݿ�����
        /// </summary>
        private SqlTransaction m_Trans;

        #endregion

        #region Constructor

        /// <summary>
        /// ����.
        /// </summary>
        private SqlDataAccess()
        {

        }

        /// <summary>
        /// ����.
        /// </summary>
        internal SqlDataAccess(SqlConnection conn)
            : this()
        {
            m_Connection = conn;
        }

        /// <summary>
        /// ����.
        /// </summary>
        internal SqlDataAccess(string connectionString)
            : this()
        {
            m_Connection = new SqlConnection(connectionString);
        }

        #endregion


        #region ��������
        /// <summary>
        /// ���ݿ������ַ���.
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return m_Connection;
            }
        }

        /// <summary>
        /// �������ݿ�����
        /// </summary>
        public IDbTransaction BeginTransaction()
        {
            m_Trans = m_Connection.BeginTransaction();
            return m_Trans;
        }

        /// <summary>
        /// ������
        /// Open a connection
        /// </summary>
        public void Open()
        {
            if (IsClosed)
                Connection.Open();
        }
        /// <summary>
        /// �ر�����
        /// Close the opened connection
        /// </summary>
        public void Close()
        {
            Connection.Close();
        }

        /// <summary>
        /// �����Ƿ��Ѿ��ر�
        /// Whether the connection is closed.
        /// </summary>
        public bool IsClosed
        {
            get
            {
                return Connection.State.Equals(ConnectionState.Closed);
            }
        }

        /// <summary>
        /// ���������ʱ
        /// Command execute timeout.
        /// </summary>
        public int CommandTimeOut
        {
            get
            {
                return m_CommandTimeOut;
            }

            set
            {
                m_CommandTimeOut = value;
            }
        }

        /// <summary>
        /// ִ���������DataSet
        /// Execute query and return DataSet.
        /// </summary>
        public DataSet ExecuteDataset(SqlQuery q)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, q);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            SyncParameter(cmd, q);

            cmd.Parameters.Clear();

            return ds;
        }

        /// <summary>
        /// ִ���������DataReader
        /// </summary>
        public IDataReader ExecuteReader(SqlQuery q)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, q);

            IDataReader reader = cmd.ExecuteReader();

            SyncParameter(cmd, q);

            cmd.Parameters.Clear();

            return reader;
        }

        /// <summary>
        /// ִ���������������������(Object)
        /// </summary>
        public Object ExecuteScalar(SqlQuery q)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, q);

            Object oValue = cmd.ExecuteScalar();

            SyncParameter(cmd, q);

            cmd.Parameters.Clear();

            return oValue;
        }

        /// <summary>
        /// ִ���������Ӱ������
        /// </summary>
        public int ExecuteNonQuery(SqlQuery q)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, q);

            int affectRows = cmd.ExecuteNonQuery();

            SyncParameter(cmd, q);

            cmd.Parameters.Clear();

            return affectRows;
        }

        /// <summary>
        ///ִ���������Xml�ĵ�
        /// </summary>
        public XmlDocument ExecuteXmlDoc(SqlQuery q)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ִ���������XmlReader
        /// </summary>
        public XmlReader ExecuteXmlReader(SqlQuery q)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, q);

            XmlReader xmlReader = cmd.ExecuteXmlReader();

            SyncParameter(cmd, q);

            cmd.Parameters.Clear();

            return xmlReader;
        }

        /// <summary>
        /// ����Sql����
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="q"></param>
        private void PrepareCommand(SqlCommand cmd, SqlQuery q)
        {
            cmd.CommandType = q.CommandType;
            cmd.CommandText = q.CommandText;
            cmd.Connection = m_Connection;
            cmd.CommandTimeout = q.CommandTimeout;
            cmd.Transaction = m_Trans;

            if (q.Parameters.Count > 0)
            {
                int parameterNum = q.Parameters.Count;
                for (int i = 0; i < parameterNum; i++)
                {
                    cmd.Parameters.Add(q.Parameters[i]);
                }
            }
        }

        /// <summary>
        /// SyncParameter
        /// </summary>
        private void SyncParameter(SqlCommand cmd, SqlQuery q)
        {
            //int parameterCount = q.Parameters.Count;
            //if (parameterCount > 0)
            //{
            //    for (int i = 0; i < parameterCount; i++)
            //    {
            //        q.Parameters[i].SyncParameter();
            //    }

            //}
        }
        #endregion


        #region Static methods
        /// <summary>
        /// ִ���������Dataset
        /// </summary>
        /// <param name="q">SqlQuery����</param>
        /// <param name="dp">Sql��������</param>
        /// <returns>Dataset</returns>
        public static DataSet ExecuteDataset(SqlQuery q, DatabaseProperty dp)
        {
            SqlDataAccess da = new SqlDataAccess(dp.ConnectionString);
            da.Open();
            DataSet ds = da.ExecuteDataset(q);
            da.Close();

            return ds;
        }

        /// <summary>
        /// ִ���������Ӱ������
        /// </summary>
        /// <param name="q">SqlQuery����</param>
        /// <param name="dp">Sql��������</param>
        /// <returns>Ӱ������</returns>
        public static int ExecuteNonQuery(SqlQuery q, DatabaseProperty dp)
        {
            SqlDataAccess da = new SqlDataAccess(dp.ConnectionString);
            da.Open();
            int affectRows = da.ExecuteNonQuery(q);
            da.Close();

            return affectRows;
        }

        /// <summary>
        /// ִ���������DataReader
        /// </summary>
        /// <param name="q">SqlQuery����</param>
        /// <param name="dp">Sql��������</param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(SqlQuery q, DatabaseProperty dp)
        {
            SqlDataAccess da = new SqlDataAccess(dp.ConnectionString);
            da.Open();
            return da.ExecuteReader(q);

        }

        /// <summary>
        /// ִ����������������е�Object
        /// </summary>
        /// <param name="q">SqlQuery����</param>
        /// <param name="dp">Sql��������</param>
        /// <returns>�������е�Object</returns>
        public static Object ExecuteScalar(SqlQuery q, DatabaseProperty dp)
        {
            SqlDataAccess da = new SqlDataAccess(dp.ConnectionString);
            da.Open();
            object scalar = da.ExecuteScalar(q); 
            da.Close();

            return scalar;
        }

        /// <summary>
        /// ִ���������XmlReader
        /// </summary>
        /// <param name="q">SqlQuery����</param>
        /// <param name="dp">Sql��������</param>
        /// <returns>XmlReader</returns>
        public static XmlReader ExecuteXmlReader(SqlQuery q, DatabaseProperty dp)
        {
            SqlDataAccess da = new SqlDataAccess(dp.ConnectionString);
            da.Open();
            return da.ExecuteXmlReader(q);
        }

        /// <summary>
        /// ִ���������Xml�ĵ�
        /// </summary>
        /// <param name="q">SqlQuery����</param>
        /// <param name="dp">Sql��������</param>
        /// <returns>Xml�ĵ�</returns>
        public static XmlDocument ExecuteXmlDoc(SqlQuery q, DatabaseProperty dp)
        {
            SqlDataAccess da = new SqlDataAccess(dp.ConnectionString);
            da.Open();
            XmlDocument doc = da.ExecuteXmlDoc(q);
            da.Close();

            return doc;
        }
        #endregion

        #region ��չ����
        /// <summary>
        /// ִ����������������е�����ֵ
        /// </summary>
        /// <param name="q">SqlQuery����</param>
        /// <param name="dp">Sql��������</param>
        /// <returns>�������е�Object</returns>
        public static int ExecuteScalarToInt(SqlQuery q, DatabaseProperty dp)
        {
            return DbConvert.ToInt( ExecuteScalar( q, dp ) );
        }

        /// <summary>
        /// ִ����������������е�����ֵ
        /// </summary>
        public int ExecuteScalarToInt(SqlQuery q)
        {
            return DbConvert.ToInt( ExecuteScalar( q ) );
        }

        /// <summary>
        /// ִ����������������е��ַ���
        /// </summary>
        /// <param name="q">SqlQuery����</param>
        /// <param name="dp">Sql��������</param>
        /// <returns>�������е�Object</returns>
        public static string ExecuteScalarToString(SqlQuery q, DatabaseProperty dp)
        {
            return DbConvert.ToString( ExecuteScalar( q, dp ) );
        }

        /// <summary>
        /// ִ����������������е��ַ���
        /// </summary>
        public string ExecuteScalarToString(SqlQuery q)
        {
            return DbConvert.ToString( ExecuteScalar( q ) );
        }
        #endregion
    }
}
