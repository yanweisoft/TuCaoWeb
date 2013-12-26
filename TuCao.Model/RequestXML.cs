using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuCao.Model
{


    #region 微信请求类 2013年12月26日21:40:22
    public class RequestXML
    {

        private string toUserName = "";
        private string fromUserName = "";
        private string createTime = "";
        private string msgType = "";
        private string content = "";
        private string location_X = "";
        private string location_Y = "";
        private string scale = "";
        private string label = "";
        private string picUrl = "";
        private string msgId = "";

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName
        {
            get { return toUserName; }
            set { toUserName = value; }
        }

        /// <summary>
        /// 发送方帐号（一个OpenID） 
        /// </summary>
        public string FromUserName
        {
            get { return fromUserName; }
            set { fromUserName = value; }
        }

        /// <summary>
        /// 消息创建时间 （整型） 
        /// </summary>
        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        /// <summary>
        /// 消息类型  text image location link event  music news 
        /// </summary>
        public string MsgType
        {
            get { return msgType; }
            set { msgType = value; }
        }

        /// <summary>
        /// 文本消息内容 
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        /// <summary>
        /// 地理位置维度 
        /// </summary>
        public string Location_X
        {
            get { return location_X; }
            set { location_X = value; }
        }

        /// <summary>
        /// 地理位置精度 
        /// </summary>
        public string Location_Y
        {
            get { return location_Y; }
            set { location_Y = value; }
        }

        /// <summary>
        /// 地图缩放大小 
        /// </summary>
        public string Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        /// <summary>
        /// 地理位置信息 
        /// </summary>
        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        /// <summary>
        /// 图片链接 
        /// </summary>
        public string PicUrl
        {
            get { return picUrl; }
            set { picUrl = value; }
        }

        /// <summary>
        /// 消息id，64位整型 
        /// </summary>
        public string MsgId
        {
            get { return msgId; }
            set { msgId = value; }
        }

    }

    #endregion
}
