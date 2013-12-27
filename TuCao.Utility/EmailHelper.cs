using System;
using System.Text;
using System.Net.Mail;
using System.Threading;

namespace TuCao.Utility
{
    /// <summary>
    /// 发送邮件类
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// 发邮件：基于system.net.mail
        /// </summary>
        /// <param name="strFrom">发送人邮箱</param>
        /// <param name="fromPwd">发送人邮箱密码</param>
        /// <param name="strTo">收件人邮箱</param>
        /// <param name="strSubject">邮件标题</param>
        /// <param name="strBody">邮件内容</param>
        /// <param name="strHost">邮件服务器host</param>
        /// <param name="strDisplay">邮件显示名称</param>
        /// <returns></returns>
        public static bool SendEmailForNet(string strHost, string strFrom, string fromPwd, string strTo, string strSubject, string strBody, string strDisplay)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(strTo);

            msg.From = new MailAddress(strFrom, strDisplay, Encoding.UTF8);

            /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
            msg.Subject = strSubject;//邮件标题 
            msg.SubjectEncoding = Encoding.UTF8;//邮件标题编码 
            msg.Body = strBody;//邮件内容 
            msg.BodyEncoding = Encoding.UTF8;//邮件内容编码 
            msg.IsBodyHtml = true;//是否是HTML邮件 
            msg.Priority = MailPriority.High;//邮件优先级 

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(strFrom, fromPwd);
            //在zj.com注册的邮箱和密码 
            client.Host = strHost;
            object userState = msg;
            try
            {
                //client.Send(msg); 
                client.SendAsync(msg, userState);
                //简单一点儿可以client.Send(msg); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        ///<summary>
        ///</summary>
        ///<param name="strTo">接收邮件email</param>
        ///<param name="strBody">邮件正文</param>
        ///<param name="strSubject">邮件主题</param>
        ///<returns></returns>
        public static bool SendEmailForNet(string strTo, string strBody, string strSubject)
        {
            string strFrom = ConfigFileHelper.SendMail;  //发送邮箱
            string strDisplay = ConfigFileHelper.EmailName; //邮件显示名称

            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            //message.BodyEncoding = Encoding.UTF8;
            // message.SubjectEncoding = Encoding.UTF8;//邮件标题编码 
            message.IsBodyHtml = true;//是否是HTML邮件 
            message.Priority = MailPriority.High;//邮件优先级 

            message.Subject = strSubject;
            message.Body = strBody;
            message.To.Add(strTo);
            message.From = new MailAddress(strFrom, strDisplay, Encoding.UTF8);

            SendMailMessageAsync(message);

            return true;
        }

        /// <summary>
        /// Sends a MailMessage object using the SMTP settings.
        /// </summary>
        public static void SendMailMessage(MailMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            //发送邮件
            string strFrom = ConfigFileHelper.SendMail;  //发送邮箱
            string strPwd = ConfigFileHelper.PassWord; //邮件密码
            string strHost = ConfigFileHelper.EmailHost; //邮件服务器host

            try
            {
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.GetEncoding("gb2312");
                message.SubjectEncoding = Encoding.GetEncoding("gb2312");//邮件标题编码 
                message.IsBodyHtml = true;//是否是HTML邮件 
                message.Priority = MailPriority.High;//邮件优先级 
                SmtpClient smtp = new SmtpClient(strHost);
                smtp.Credentials = new System.Net.NetworkCredential(strFrom, strPwd);

                smtp.Send(message);
                OnEmailSent(message);
            }
            catch
            {
                //Logging.LogHelper.GetILogInstance().Error("发送邮件失败：" + ex.Message);
                //Console.WriteLine( "发送邮件失败：" + ex.Message );
            }
            finally
            {
                // Remove the pointer to the message object so the GC can close the thread.
                message.Dispose();
            }
        }

        /// <summary>
        /// Sends the mail message asynchronously in another thread.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public static void SendMailMessageAsync(MailMessage message)
        {
            ThreadPool.QueueUserWorkItem(delegate { SendMailMessage(message); });
        }

        /// <summary>
        /// Occurs after an e-mail has been sent. The sender is the MailMessage object.
        /// </summary>
        public static event EventHandler<EventArgs> EmailSent;
        private static void OnEmailSent(MailMessage message)
        {
            if (EmailSent != null)
            {
                EmailSent(message, new EventArgs());
            }
        }
    }
}
