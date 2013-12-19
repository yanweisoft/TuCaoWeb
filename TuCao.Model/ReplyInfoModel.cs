using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuCao.Model
{
    /// <summary>
    /// 回复内容
    /// </summary>
    public class ReplyInfoModel
    {
        private int _id;
        private int _topicid;
        private int _userid;
        private string _nickname;
        private string _postcontent;
        private DateTime _createtime;
        private string _ip;
        private int _status;
        /// <summary>
        /// 主键
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 帖子ID
        /// </summary>
        public int TopicId
        {
            get { return _topicid; }
            set { _topicid = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string PostContent
        {
            get { return _postcontent; }
            set { _postcontent = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// IP
        /// </summary>
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
