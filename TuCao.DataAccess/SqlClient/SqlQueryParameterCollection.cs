/*----------------------------------------------------------------
// Copyright (C) 2011 ʢ�ش�ý 
//
// �ļ�����SqlQueryParameterCollection
// �ļ�����������MSSql�������������
//
//----------------------------------------------------------------*/
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace TuCao.DataAccess.SqlClient
{
    /// <summary>
    /// MSSql�������������
    /// </summary>
    public sealed class SqlQueryParameterCollection : MarshalByRefObject
    {
        private int m_IntitialCapacity = 10;
        private ArrayList m_Items;

        /// <summary>
        /// ����
        /// </summary>
        public SqlQueryParameterCollection()
        {
        }

        /// <summary>
        /// ����
        /// </summary>
        public SqlQueryParameterCollection(int initCapacity)
        {
            m_IntitialCapacity = initCapacity;
        }

        /// <summary>
        /// ������
        /// </summary>
        private ArrayList Items
        {
            get
            {
                if (this.m_Items == null)
                {
                    this.m_Items = new ArrayList(m_IntitialCapacity);
                }
                return this.m_Items;
            }
        }

        /// <summary>
        /// ����ͳ��
        /// </summary>
        public int Count
        {
            get
            {
                if (this.m_Items == null)
                {
                    return 0;
                }
                return this.m_Items.Count;

            }
        }


        /// <summary>
        /// ׷��һ���������
        /// </summary>
        /// <param name="param">SqlParameter</param>
        /// <returns>SqlParameter</returns>
        public SqlParameter Add(SqlParameter param)
        {
            this.Items.Add(param);
            return param;
        }

        /// <summary>
        /// ׷��һ���������
        /// </summary>
        /// <param name="parameterName">������</param>
        /// <param name="value">����ֵ</param>
        /// <returns>SqlParameter</returns>
        public SqlParameter Add(string parameterName, object value)
        {
            return this.Add(new SqlParameter(parameterName, value));
        }

        /// <summary>
        /// ׷��һ���������
        /// </summary>
        /// <param name="parameterName">������</param>
        /// <param name="value">����ֵ</param>
        /// <param name="dbType">��������</param>
        /// <returns>SqlParameter</returns>
        public SqlParameter Add(string parameterName, object value, SqlDbType dbType)
        {
            SqlParameter para = new SqlParameter(parameterName, value);
            para.SqlDbType = dbType;

            return this.Add(para);
        }

        /// <summary>
        /// ׷��һ���������
        /// </summary>
        /// <param name="parameterName">������</param>
        /// <param name="value">����ֵ</param>
        /// <param name="dbType">��������</param>
        /// <param name="size">������С</param>
        /// <returns></returns>
        public SqlParameter Add(string parameterName, object value, SqlDbType dbType, int size)
        {
            SqlParameter para = new SqlParameter(parameterName, value);
            para.SqlDbType = dbType;
            para.Size = size;

            return this.Add(para);
        }

        /// <summary>
        /// ׷��һ���������
        /// </summary>
        /// <param name="parameterName">������</param>
        /// <param name="value">����ֵ</param>
        /// <param name="dbType">��������</param>
        /// <param name="size">������С</param>
        /// <param name="direction">�������롢�����ʽ</param>
        /// <returns></returns>
        public SqlParameter Add(string parameterName, object value, SqlDbType dbType, int size, ParameterDirection direction)
        {
            SqlParameter para = new SqlParameter(parameterName, value);
            para.SqlDbType = dbType;
            para.Size = size;
            para.Direction = direction;

            return this.Add(para);
        }


        /// <summary>
        /// ������
        /// </summary>
        public SqlParameter this[int index]
        {
            get
            {
                this.RangeCheck(index);
                return ((SqlParameter)this.m_Items[index]);
            }

            set
            {
                this.RangeCheck(index);
                this.m_Items[index] = value;
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        public SqlParameter this[string parameterName]
        {
            get
            {
                int num1 = this.RangeCheck(parameterName);
                return ((SqlParameter)this.m_Items[num1]);
            }

            set
            {
                int num1 = this.RangeCheck(parameterName);
                this.m_Items[num1] = value;
            }
        }

        /// <summary>
        /// ��֤����
        /// </summary>
        /// <param name="Value"></param>
        private void ValidateType(object Value)
        {
        }

        /// <summary>
        /// ��֤
        /// </summary>
        /// <param name="index">������</param>
        /// <param name="Value"></param>
        private void Validate(int index, SqlParameter Value)
        { }

        /// <summary>
        /// �����ŷ�Χ���
        /// </summary>
        /// <param name="index">������</param>
        private void RangeCheck(int index)
        {
            if ((index < 0) || (this.Count <= index))
            {
                throw new IndexOutOfRangeException("Number " + index.ToString() + " is out of Range");

            }
        }

        /// <summary>
        /// ���������Χ���
        /// </summary>
        /// <param name="parameterName">�������</param>
        /// <returns></returns>
        private int RangeCheck(string parameterName)
        {
            int num1;
            num1 = this.IndexOf(parameterName);
            if (num1 < 0)
            {
                throw new IndexOutOfRangeException("ParameterName " + parameterName + " dose not exist");
            }
            return num1;
        }

        /// <summary>
        /// ����Ƿ��������
        /// </summary>
        /// <param name="parameterName">�������</param>
        /// <returns>������</returns>
        public int IndexOf(string parameterName)
        {
            int index = -1;
            if (this.m_Items != null)
            {
                for (int i = 0; i < this.m_Items.Count; i++)
                {
                    if (((SqlParameter)m_Items[i]).ParameterName.Equals(parameterName))
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }

        /// <summary>
        /// ���SQL����
        /// </summary>
        public void Clear()
        {
            this.Items.Clear();
        }
    }
}
