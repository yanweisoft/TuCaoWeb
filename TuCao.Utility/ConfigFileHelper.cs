using System;
using System.Configuration;

namespace TuCao.Utility
{
    /// <summary>
    ///配置文件相关的读取类
    /// </summary>
    public class ConfigFileHelper
    {
        #region 图片相关(物理路径和网络路径)
        /// <summary>
        /// 发记录图片存放的物理路径
        /// </summary>
        public static string FeedImgPath = ConfigurationManager.AppSettings.Get("FeedImagePath");
        /// <summary>
        /// 图片存放的临时物理路径
        /// </summary>
        public static string TempImagePath = ConfigurationManager.AppSettings["TempImagePath"];
        /// <summary>
        /// 头像存放的物理路径(\img.autohome.com.cn\album\userheaders)
        /// </summary>
        public static string HeadImagePath = ConfigurationManager.AppSettings["HeadImagePath"];
        /// <summary>
        /// 头像图片的url前缀(eg:http://www.autoimg.cn/album/userheaders)
        /// </summary>
        public static string HeadImageImagePreUrl = ConfigurationManager.AppSettings["HeadImageImagePreUrl"];

        /// <summary>
        /// 头像图片的url前缀(eg:http://i{0}.autoimg.cn/album/userheaders)
        /// </summary>
        public static string NewHeadImageImagePreUrl = ConfigurationManager.AppSettings["NewHeadImageImagePreUrl"].SafeConvertToString("http://i{0}.autoimg.cn/album/userheaders");

        /// <summary>
        /// feed图片的url前缀(eg:http://www.autoimg.cn/feed)
        /// </summary>
        public static string FeedImagePreUrl = ConfigurationManager.AppSettings.Get("FeedImagePreUrl").SafeConvertToString("http://www.autimg.cn/album/feed");
        /// <summary>
        /// 新的feed图片前缀http://i{0}.autimg.cn/album/feed
        /// </summary>
        public static string NewFeedImagePreUrl = ConfigurationManager.AppSettings.Get("NewFeedImagePreUrl").SafeConvertToString("http://i{0}.autoimg.cn/album/feed");

        public static bool isOpenPushMessage = ConfigurationManager.AppSettings.Get("isOpenPushMessage").SafeConvertToBoolean();
        /// <summary>
        /// feed图片的url前缀(eg:http://www.autoimg.cn/feed)
        /// </summary>
        public static string TempImagePreUrl = ConfigurationManager.AppSettings.Get("TempImagePreUrl");

        public static string NewTempImagePreUrl = ConfigurationManager.AppSettings.Get("NewTempImagePreUrl").SafeConvertToString("http://i{0}.autoimg.cn/album/temp");
        /// <summary>
        /// 默认头像120*120
        /// </summary>
        public static string DefaultHeadImg120 = string.Concat(ConfigurationManager.AppSettings.Get("DefaultHeadImgUrl"), 120);
        /// <summary>
        /// 默认头像50*50
        /// </summary>
        public static string DefaultHeadImg50 = string.Format(ConfigurationManager.AppSettings.Get("DefaultHeadImgUrl"), 50);
        /// <summary>
        /// 默认头像30*30
        /// </summary>
        public static string DefaultHeadImg30 = string.Format(ConfigurationManager.AppSettings.Get("DefaultHeadImgUrl"), 30);
        /// <summary>
        /// 默认头像不带大小，需自己替换大小
        /// </summary>
        public static string DefaultHeadImg = ConfigurationManager.AppSettings.Get("DefaultHeadImgUrl");
        /// <summary>
        /// 首页广告图网络路径
        /// </summary>
        public static string AdImgPreUrl = ConfigurationManager.AppSettings.Get("AdImgPreUrl");
        /// <summary>
        /// 车系logotu网络路径
        /// </summary>
        public static string SeriesLogoPreUrl = ConfigurationManager.AppSettings.Get("SeriesLogoPreUrl").SafeConvertToString("http://i{0}.autoimg.cn/album/serieslogo");
        public static string DefaultSeriesLogoUrl = ConfigurationManager.AppSettings.Get("DefaultSeriesLogoUrl").SafeConvertToString("http://x.autoimg.cn/space/images/serieslogo.jpg");
        #endregion

        #region 登录框相关的url
        /// <summary>
        /// 登录地址
        /// </summary>
        public static string LoginUrl = ConfigurationManager.AppSettings.Get("loginUrl").SafeConvertToString("http://account.autohome.com.cn/login?backUrl=");
        /// <summary>
        /// 注册地址
        /// </summary>
        public static string RegisterUrl = ConfigurationManager.AppSettings.Get("registerUrl").SafeConvertToString("http://club.service.autohome.com.cn/Reg/mobile/index.html?backtopurl=");


        /// <summary>
        /// 弹出层的登录地址
        /// </summary>
        public static string FloatLoginUrl = ConfigurationManager.AppSettings.Get("FloatLoginUrl").SafeConvertToString("http://x.autoimg.cn/account/Scripts/poplogin_min.js");


        /// <summary>
        /// 退出登录地址
        /// </summary>
        public static string LoginoutUrl = ConfigurationManager.AppSettings.Get("loginoutUrl").SafeConvertToString("http://account.autohome.com.cn/login/logoutjson?backvar=autologinout");

        /// <summary>
        /// 退出二手车登录地址
        /// </summary>
        public static string loginoutCheUrl = ConfigurationManager.AppSettings.Get("loginoutCheUrl").SafeConvertToString("http://account.che168.com/login/logoutjson?backvar=cheloginout");
        #endregion

        #region 发邮件相关的配置
        /// <summary>
        /// 发送邮件的邮箱
        /// </summary>
        public static string SendMail = ConfigurationManager.AppSettings.Get("sendEmail").SafeConvertToString("club@Autohome.com.cn");

        /// <summary>
        /// 密码
        /// </summary>
        public static string PassWord = ConfigurationManager.AppSettings.Get("emailPwd").SafeConvertToString("shuang()");

        /// <summary>
        /// 发送邮件服务
        /// </summary>
        public static string EmailHost = ConfigurationManager.AppSettings.Get("emailHost").SafeConvertToString("club@Autohome.com.cn");

        /// <summary>
        /// 邮箱显示名
        /// </summary>
        public static string EmailName = ConfigurationManager.AppSettings.Get("emailName").SafeConvertToString("汽车之家");

        /// <summary>
        /// 邮件标题
        /// </summary>
        public static string EmailSubject = ConfigurationManager.AppSettings.Get("emailSubject").SafeConvertToString("来自汽车之家的Email验证邮件");
        #endregion

        #region 调用用户中心的api_sourece
        /// <summary>
        /// 验证手机号的apisource
        /// </summary>
        public static int ValidMobile = ConfigurationManager.AppSettings.Get("ValidMobileApiSource").SafeConvertToInt(22345678);
        /// <summary>
        /// 获取用户密码的apisource
        /// </summary>
        public static int ValidPassword = ConfigurationManager.AppSettings.Get("ValidPasswordApiSource").SafeConvertToInt(32345678);
        /// <summary>
        /// 验证邮箱的apisource
        /// </summary>
        public static int ValidEmail = ConfigurationManager.AppSettings.Get("ValidEmailApiSource").SafeConvertToInt(42345678);
        /// <summary>
        /// 解密ssocookie的apisource
        /// </summary>
        public static int DecryptCookie = ConfigurationManager.AppSettings.Get("DecryptCookieApiSource").SafeConvertToInt(12345678);
        #endregion

        /// <summary>
        /// 论坛回复--我的主贴下他人的回复开关
        /// </summary>
        public static bool IsCloseOtherReply = ConfigurationManager.AppSettings["isCloseOtherReply"].SafeConvertToBoolean();


        /// <summary>
        /// 当前域名
        /// </summary>
        public static string CurrentDomain = ConfigurationManager.AppSettings["CurrentDomain"];

        /// <summary>
        /// webapi接口地址
        /// </summary>
        public static string WebApiUrl = ConfigurationManager.AppSettings["WebApiUrl"].SafeConvertToString("webapiUrl.xml");
        /// <summary>
        /// 论坛的详细地址
        /// </summary>
        public static string ClubUrl = ConfigurationManager.AppSettings["ClubUrl"].SafeConvertToString("http://club.autohome.com.cn/bbs/forum-{0}-{1}-1.html");
        /// <summary>
        /// 帖子的详细地址
        /// </summary>
        public static string PostUrl = ConfigurationManager.AppSettings["PostUrl"].SafeConvertToString("http://club.autohome.com.cn/bbs/thread-{0}-{1}-{2}-1.html");


        /// <summary>
        /// 短信下发商ID号
        /// </summary>
        public static int Category = ConfigurationManager.AppSettings.Get("category").SafeConvertToInt(3);

        /// <summary>
        /// 帖子内容截取的长度(字符)
        /// </summary>
        public static int PostContentLength = ConfigurationManager.AppSettings.Get("PostContentLength").SafeConvertToInt(360);


        /// <summary>
        /// 评论内容截取的长度(字符)
        /// </summary>
        public static int CommentContentLength = ConfigurationManager.AppSettings.Get("CommentContentLength").SafeConvertToInt(400);

        /// <summary>
        /// 每个人的首页最多存储的条数
        /// </summary>
        public static int MaxTimelineCount = ConfigurationManager.AppSettings.Get("MaxTimelineCount").SafeConvertToInt(1000);


        /// <summary>
        /// 点击认证车主的url
        /// </summary>
        public static string VerifiedUrl = ConfigurationManager.AppSettings.Get("VerifiedUrl");

        /// <summary>
        /// 绑定经销商url
        /// </summary>
        public static string DealersDataUrl = ConfigurationManager.AppSettings.Get("DealersDataUrl");


        /// <summary>
        /// 发送回复url（评论系统）
        /// </summary>
        public static string ReplyComment = ConfigurationManager.AppSettings.Get("replyComment").SafeConvertToString("http://reply.autohome.com.cn/receiverequest/handler.ashx");



        #region 应用的url(论坛\相册等)
        /// <summary>
        /// 论坛应用-主题帖
        /// </summary>
        public static string ClubMyTopicUrl = ConfigurationManager.AppSettings.Get("ClubMyTopicUrl");

        /// <summary>
        /// 论坛应用-收到的回复
        /// </summary>
        public static string ClubReceiveReplyUrl = ConfigurationManager.AppSettings.Get("ClubReceiveReplyUrl");

        /// <summary>
        /// 论坛应用-发出的回复
        /// </summary>
        public static string ClubSendReplyUrl = ConfigurationManager.AppSettings.Get("ClubSendReplyUrl");

        /// <summary>
        /// 论坛应用-我的相册
        /// </summary>
        public static string ClubMyPhoneUrl = ConfigurationManager.AppSettings.Get("ClubMyPhoneUrl");
        /// <summary>
        /// 论坛应用-Ta的相册
        /// </summary>
        public static string ClubOtherPhoneUrl = ConfigurationManager.AppSettings.Get("ClubOtherPhoneUrl");

        /// <summary>
        /// 论坛应用-私信
        /// </summary>
        public static string ClubPrivateMessageUrl = ConfigurationManager.AppSettings.Get("ClubPrivateMessageUrl");

        /// <summary>
        /// 我的油耗地址
        /// </summary>
        public static string ClubMyOilWearUrl = ConfigurationManager.AppSettings.Get("ClubMyOilWearUrl");

        /// <summary>
        /// 论坛应用-Ta人的主题帖
        /// </summary>
        public static string ClubOtherTopicUrl = ConfigurationManager.AppSettings.Get("ClubOtherTopicUrl");

        /// <summary>
        /// 论坛应用-Ta人发出的回复
        /// </summary>
        public static string ClubOtherReplyUrl = ConfigurationManager.AppSettings.Get("ClubOtherReplyUrl");

        /// <summary>
        /// 通知
        /// </summary>
        public static string ClubNoticeUrl = ConfigurationManager.AppSettings.Get("ClubNoticeUrl");

        /// <summary>
        /// 我的活动
        /// </summary>
        public static string ClubMyRegpartyUrl = ConfigurationManager.AppSettings.Get("ClubMyRegpartyUrl");
        #endregion

        /// <summary>
        /// 发私信--帖子最终页发信息功能
        /// </summary>
        public static string ClubSPMUrl = ConfigurationManager.AppSettings.Get("ClubSPMUrl");

        private static string siteForder = ConfigurationManager.AppSettings.Get("siteFolder");
        /// <summary>
        /// 虚拟目录的名字(只有名字，不带 "/" )
        /// </summary>
        public static string SiteFolder = siteForder ?? string.Empty;

        /// <summary>
        /// 意见反馈
        /// </summary>
        public static string FeedBackUrl = ConfigurationManager.AppSettings.Get("FeedBackUrl");

        /// <summary>
        /// MemcachedServiceListPath
        /// </summary>
        public static string MemcachedServiceListPath = ConfigurationManager.AppSettings["MemcachedService"];

        /// <summary>
        /// 静态资源文件
        /// </summary>
        public static string StaticFilePreUrl = ConfigurationManager.AppSettings["StaticFilePreUrl"];

        /// <summary>
        /// 接口日志开关 0为关   1为开
        /// </summary>
        public static string LogForApiSwitch = ConfigurationManager.AppSettings["LogForApiSwitch"];
        /// <summary>
        /// 接口日志 时间限制 单位毫秒
        /// </summary>
        public static long LogForApiTime = ConfigurationManager.AppSettings["LogForApiTime"].SafeConvertToBigInt();

        /// <summary>
        /// 口碑
        /// </summary>
        public static string KouBeiUrl = ConfigurationManager.AppSettings["KouBeiUrl"].SafeConvertToString("http://k1.autohome.com.cn/myspace/Koubei/Mine");

        /// <summary>
        /// 车内逃脱
        /// </summary>
        public static string Car4AutohomeUrl = ConfigurationManager.AppSettings["Car4AutohomeUrl"].SafeConvertToString("http://car.bamajia.com/autohome/car4autohome/index.php");

        public static string OtherKoubei = ConfigurationManager.AppSettings["OtherKouBeiUrl"].SafeConvertToString("http://k.autohome.com.cn/myspace/koubei/his/{0}");

        /// <summary>
        /// 产品库图片域名
        /// </summary>
        public static string CarProductImageDomian = ConfigurationManager.AppSettings["CarProductImageDomian"].SafeConvertToString("http://car{0}.autoimg.cn");

    }
}
