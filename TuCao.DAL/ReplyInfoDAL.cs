using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TuCao.DataAccess;
using TuCao.DataAccess.SqlClient;
using TuCao.Model;
namespace TuCao.DAL
{
    public class ReplyInfoDAL
    {
        private const string sql_insert = @" INSERT INTO [ReplyInfo]( [TopicId],[UserId],[NickName] ,[PostContent],[CreateTime] ,[IP] ,[Status]) VALUES( 
                                               @TopicId, @UserId,@NickName,@PostContent,@CreateTime,@Ip,@Status)";
        private const string sql_update = @" UPDATE [ReplyInfo] SET  ,[TopicId] = @TopicId,[UserId] = @UserId ,[NickName] = @NickName ,[PostContent] = @PostContent,[CreateTime] = @CreateTime  ,[IP] = @IP ,[Status] = @Status WHERE [Id] = @Id ";

        private const string sql_delete = @" DELETE FROM [ReplyInfo]   WHERE Id=@Id ";

        private const string sql_select = @"SELECT [Id],[TopicId] ,[UserId] ,[NickName] ,[PostContent],[CreateTime],[IP],[Status] FROM [ReplyInfo] WHERE Id=@Id ";

        private const string sql_select_pager = @"Declare @sql nvarchar(2000)
Declare @startRecord int
Declare @endRecord int
Set @startRecord = (@page-1)*@pageSize + 1
Set @endRecord = @startRecord + @pageSize - 1
Set @sql = 'SELECT   [Id],[TopicId],[UserId],[NickName],[PostContent],[CreateTime],[IP],[Status]  rowId FROM (SELECT  [Id],[TopicId],[UserId],[NickName],[PostContent],[CreateTime],[IP],[Status] ,ROW_NUMBER() OVER(ORDER BY Id DESC) AS rowId FROM ReplyInfo WITH (NOLOCK) WHERE  1=1 and {0} ) AS Tab_TotalTable WHERE rowId BETWEEN ' + Convert(varchar(50),@startRecord) + ' AND ' +  Convert(varchar(50),@endRecord)
Exec(@Sql)";


        #region   SELECT

        private DataTable GetPagerData(int pageSize, int pageIndex, string strWhere)
        {
            SqlQuery baseQuery = new SqlQuery();
            string sql = sql_select_pager;
            baseQuery.CommandText = string.Format(sql, strWhere);
            baseQuery.Parameters.Add("@pageSize", pageSize, SqlDbType.Int);
            baseQuery.Parameters.Add("@page", pageIndex, SqlDbType.Int);
            return SqlDataAccess.ExecuteDataset(baseQuery, DBSettings.TuCaoMainDb).Tables[0];
        }
        #endregion

        #region  INSERT

        public bool Insert(ReplyInfoModel model)
        {
            bool isOk = false;
            if (model == null)
            {
                return isOk;
            }

            try
            {
                SqlQuery insertQuery = new SqlQuery();
                insertQuery.CommandText = sql_insert;
                insertQuery.Parameters.Add("@TopicId", model.TopicId, SqlDbType.TinyInt);
                insertQuery.Parameters.Add("@UserId", model.UserId, SqlDbType.Int);
                insertQuery.Parameters.Add("@NickName", model.NickName, SqlDbType.NVarChar, 50);
                insertQuery.Parameters.Add("@PostContent", model.PostContent, SqlDbType.NVarChar, 500);
                insertQuery.Parameters.Add("@CreateTime", model.CreateTime, SqlDbType.DateTime);
                insertQuery.Parameters.Add("@IP", model.IP, SqlDbType.NVarChar, 50);
                insertQuery.Parameters.Add("@Status", model.Status, SqlDbType.Int);
                isOk = SqlDataAccess.ExecuteNonQuery(insertQuery, DBSettings.TuCaoMainDb) > 0 ? true : false;
            }
            catch (Exception ex)
            { }

            return isOk;
        }
        #endregion

        #region  UPDATE
        public bool Update(ReplyInfoModel model)
        {
            bool isOk = false;
            if (model == null)
            {
                return isOk;
            }

            try
            {
                SqlQuery insertQuery = new SqlQuery();
                insertQuery.CommandText = sql_insert;
                insertQuery.Parameters.Add("@TopicId", model.TopicId, SqlDbType.TinyInt);
                insertQuery.Parameters.Add("@UserId", model.UserId, SqlDbType.Int);
                insertQuery.Parameters.Add("@NickName", model.NickName, SqlDbType.NVarChar, 50);
                insertQuery.Parameters.Add("@PostContent", model.PostContent, SqlDbType.NVarChar, 500);
                insertQuery.Parameters.Add("@CreateTime", model.CreateTime, SqlDbType.DateTime);
                insertQuery.Parameters.Add("@Ip", model.IP, SqlDbType.NVarChar, 50);
                insertQuery.Parameters.Add("@Status", model.Status, SqlDbType.Int);
                insertQuery.Parameters.Add("@Id", model.Id, SqlDbType.Int);
                isOk = SqlDataAccess.ExecuteNonQuery(insertQuery, DBSettings.TuCaoMainDb) > 0 ? true : false;
            }
            catch (Exception ex)
            {


            }



            return isOk;

        }
        #endregion


        #region  DELETE

        public int Del(int Id)
        {
            SqlQuery baseQuery = new SqlQuery();

            baseQuery.CommandText = sql_delete;
            baseQuery.Parameters.Add("@objid", Id, SqlDbType.Int);
            return SqlDataAccess.ExecuteNonQuery(baseQuery, DBSettings.TuCaoMainDb);
        }
        #endregion








    }
}
