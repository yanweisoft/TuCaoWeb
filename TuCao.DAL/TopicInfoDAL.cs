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
    public class TopicInfoDAL
    {
        #region  SQL
        private const string sql_insert = @" INSERT INTO [TopicInfo]([UserId],[NickName],[Sex],[TypeId],[PostContent],[PostTags],[IsEmail],[CreateTime] ,[IP],[Status]) VALUES( 
                                              @[UserId],@[NickName],@[Sex],@[TypeId],@[PostContent],@[PostTags],@[IsEmail],@[CreateTime] ,@[IP],@[Status])";
        private const string sql_update = @" UPDATE [TopicInfo] SET  ,[UserId] = @UserId,[NickName] = @NickName ,[Sex] = @Sex ,[TypeId] = @TypeId,[PostContent] = @PostContent  ,[PostTags] = @PostTags ,[IsEmail] = @IsEmail,[CreateTime]=@CreateTime, [IP]=@IP,[Status]=@Status WHERE [Id] = @Id ";

        private const string sql_delete = @" DELETE FROM [TopicInfo]   WHERE Id=@Id ";

        private const string sql_select = @"SELECT   [Id],[UserId],[NickName],[Sex],[TypeId],[PostContent],[PostTags],[IsEmail],[CreateTime] ,[IP],[Status] FROM [TopicInfo] WHERE Id=@Id ";

        private const string sql_select_pager = @"Declare @sql nvarchar(2000)
Declare @startRecord int
Declare @endRecord int
Set @startRecord = (@page-1)*@pageSize + 1
Set @endRecord = @startRecord + @pageSize - 1
Set @sql = 'SELECT  [Id],[UserId],[NickName],[Sex],[TypeId],[PostContent],[PostTags],[IsEmail],[CreateTime] ,[IP],[Status]  rowId FROM (SELECT   [Id],[UserId],[NickName],[Sex],[TypeId],[PostContent],[PostTags],[IsEmail],[CreateTime] ,[IP],[Status] ,ROW_NUMBER() OVER(ORDER BY Id DESC) AS rowId FROM TopicInfo WITH (NOLOCK) WHERE  1=1 and {0} ) AS Tab_TotalTable WHERE rowId BETWEEN ' + Convert(varchar(50),@startRecord) + ' AND ' +  Convert(varchar(50),@endRecord)
Exec(@Sql)";
        #endregion
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

        public bool Insert(TopicInfoModel model)
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
                insertQuery.Parameters.Add("@UserId", model.UserId, SqlDbType.TinyInt);
                insertQuery.Parameters.Add("@NickName", model.NickName, SqlDbType.Int);
                insertQuery.Parameters.Add("@Sex", model.Sex, SqlDbType.NVarChar, 50);
                insertQuery.Parameters.Add("@TypeId", model.TypeId, SqlDbType.NVarChar, 500);
                insertQuery.Parameters.Add("@PostContent", model.PostContent, SqlDbType.DateTime);
                insertQuery.Parameters.Add("@PostTags", model.PostTags, SqlDbType.NVarChar, 50);
                insertQuery.Parameters.Add("@IsEmail", model.IsEmail, SqlDbType.Int);
                insertQuery.Parameters.Add("@CreateTime", model.CreateTime, SqlDbType.Int);
                insertQuery.Parameters.Add("@IP", model.IP, SqlDbType.Int);
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
