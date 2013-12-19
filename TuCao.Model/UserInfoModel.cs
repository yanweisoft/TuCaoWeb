using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuCao.Model
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class UserInfoModel
    {
        private int _id;
        private string _useremail;
        private string _nickname;
        private DateTime _createtime;
        private DateTime _lastlogintime;
        private string _ip;
        private int _logincount;
        /// <summary>
        /// 主键
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 邮件地址
        /// </summary>
        public string UserEmail
        {
            get { return _useremail; }
            set { _useremail = value; }
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
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// 上次登陆时间
        /// </summary>
        public DateTime LastLoginTime
        {
            get { return _lastlogintime; }
            set { _lastlogintime = value; }
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
        /// 登陆次数
        /// </summary>
        public int LoginCount
        {
            get { return _logincount; }
            set { _logincount = value; }
        }
    }
}
