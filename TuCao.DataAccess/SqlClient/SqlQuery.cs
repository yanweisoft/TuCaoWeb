/*----------------------------------------------------------------
// Copyright (C) 2011 ʢ�ش�ý 
//
// �ļ�����SqlQuery
// �ļ�����������MSSql������
//
//----------------------------------------------------------------*/
using System.Data;

namespace TuCao.DataAccess.SqlClient
{
    /// <summary>
    /// MSSql������
    /// </summary>
    public class SqlQuery
    {
        #region Private properties

        /// <summary>
        /// Default command timeout.
        /// </summary>
        protected const int COMMAND_TIMEOUT_DEFAULT = 30;
        /// <summary>
        /// Comamnd text.
        /// </summary>
        protected string m_CommandText;
        /// <summary>
        /// Command timeout.
        /// </summary>
        protected int m_CommandTimeout = COMMAND_TIMEOUT_DEFAULT;
        /// <summary>
        /// Command type.
        /// </summary>
        protected CommandType m_CommandType = CommandType.Text;
        /// <summary>
        /// parameters
        /// </summary>
        protected SqlQueryParameterCollection m_Parameters = new SqlQueryParameterCollection();

        #endregion

        #region Public properties

        /// <summary>
        /// MSSql����
        /// </summary>
        public virtual string CommandText
        {
            set
            {
                this.m_CommandText = value;
            }
            get
            {
                return this.m_CommandText;
            }
        }

        /// <summary>
        /// MSSql���ʱʱ��
        /// </summary>
        public int CommandTimeout
        {
            set
            {
                if (value < 10)
                    this.m_CommandTimeout = COMMAND_TIMEOUT_DEFAULT;
                else
                    this.m_CommandTimeout = value;
            }
            get
            {
                return this.m_CommandTimeout;
            }
        }

        /// <summary>
        /// MSSql��������
        /// </summary>
        public CommandType CommandType
        {
            set
            {
                this.m_CommandType = value;
            }
            get
            {
                return this.m_CommandType;
            }
        }

        /// <summary>
        /// MSSql�������
        /// </summary>
        public SqlQueryParameterCollection Parameters
        {
            set
            {
                this.m_Parameters = value;
            }
            get
            {
                return this.m_Parameters;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// ����
        /// </summary>
        public SqlQuery()
        {

        }

        #endregion
    }
}