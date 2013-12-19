using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuCao.Model
{

    /// <summary>
    /// 帖子内容
    /// </summary>
    public class TopicInfoModel
    {
        private int _id;
        private int _userid;
        private string _nickname;
        private int _sex;
        private int _typeid;
        private string _postcontent;
        private string _posttags;
        private string _isemail;
        private string _ip;
        private DateTime _createtime;
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
        /// 用户ID
        /// </summary>
        public int Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        /// <summary>
        /// 类别ID
        /// </summary>
        public int Typeid
        {
            get { return _typeid; }
            set { _typeid = value; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Postcontent
        {
            get { return _postcontent; }
            set { _postcontent = value; }
        }
        /// <summary>
        /// 标签
        /// </summary>
        public string Posttags
        {
            get { return _posttags; }
            set { _posttags = value; }
        }
        /// <summary>
        /// 是否邮件通知
        /// </summary>
        public string Isemail
        {
            get { return _isemail; }
            set { _isemail = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Createtime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// IP
        /// </summary>
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
