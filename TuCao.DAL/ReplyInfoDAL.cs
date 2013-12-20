using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuCao.DAL
{
    public class ReplyInfoDAL
    {
        private const string sql_insert = @" INSERT INTO [ReplyInfo]( [TopicId],[UserId],[NickName] ,[PostContent],[CreateTime] ,[Ip] ,[Status]) VALUES( 
                                               @TopicId, @UserId,@NickName,@PostContent,@CreateTime,@Ip,@Status)";
        private const string sql_update = @" UPDATE [ReplyInfo] SET  ,[TopicId] = @TopicId,[UserId] = @UserId ,[NickName] = @NickName ,[PostContent] = @PostContent,[CreateTime] = @CreateTime  ,[Ip] = @Ip ,[Status] = @Status WHERE [Id] = @Id ";

        private const string sql_delete = @" DELETE FROM [ReplyInfo]   WHERE Id=@Id ";

        private const string sql_select = @"SELECT [Id],[TopicId] ,[UserId] ,[NickName] ,[PostContent],[CreateTime],[Ip],[Status] FROM [ReplyInfo] WHERE Id=@Id ";

    }
}
