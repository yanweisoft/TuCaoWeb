using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace TuCao.Model
{
    public class Class1
    {
        public void LoadData()
        {
            string strName = "张三";
        }

        public SqlConnection GetSqlConnection()
        {
            string strConnction = "server=.;database=;uid=;pwd=;";
            SqlConnection scn = new SqlConnection(strConnction);
            return scn;
        }

        public int GetData(int x, int y)
        {
            int result = x + y;
            return result;
        }
    }
}
