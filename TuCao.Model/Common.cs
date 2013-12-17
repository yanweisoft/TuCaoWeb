using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace TuCao.Model
{
    public class Common
    {
        public DataTable GetData()
        {
            SqlConnection scn = Class1.GetSqlConnection();
            scn.Open();
            string strSql = "SELECT * FROM USERINFO WIHT(NOLOCK)";
            SqlDataAdapter ada = new SqlDataAdapter(strSql, scn);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            scn.Close();
            return dt;

        }
    }
}
