using System.Data;

namespace TuCao.Utility
{
    public static class DataHelper
    {
        /// <summary>
        /// 判断DataTable是否为空
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsNullData(this DataTable dt)
        {
            bool value = !(dt != null && dt.Rows != null && dt.Rows.Count != 0);
            return value;

        }
        /// <summary>
        /// 判断DataSet是否为空   
        /// </summary>
        /// <param name="ds">要判断的DataSet</param>
        /// <returns></returns>
        public static bool IsNullData(this DataSet ds)
        {
            bool value = !(ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0);
            return value;
        }
        /// <summary>
        /// 判断DataRow是否为空
        /// </summary>
        /// <param name="dr">要判断的DataRow</param>
        /// <returns></returns>
        public static bool IsNullData(this DataRow dr)
        {
            bool value = dr == null;
            return value;
        }
    }
}
