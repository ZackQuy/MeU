/********************************************************************
** 作者： 张青云
** 创始时间：2016-04-15
** 描述：发送邮件工具类
————
** 修改人： 
** 修改时间： 
** 描述： 
————
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace Business.Utils
{
    /// <summary>
    /// 发送邮件工具类
    /// </summary>
    public class MailHelper : IDisposable
    {

        private static string mailUserName = ConfigurationManager.AppSettings["mailUserName"];//邮件发送人邮箱账户
        private static string mailPassword = ConfigurationManager.AppSettings["mailPassword"];//邮件发送人邮箱密码
        private static string mailDisplayName = ConfigurationManager.AppSettings["mailDisplayName"];//邮件发送人显示名称
        private static string smtpServerHost = ConfigurationManager.AppSettings["smtpServerHost"];//SMTP服务器地址
        private static int smtpServerPort = int.Parse(ConfigurationManager.AppSettings["smtpServerPort"]);//SMTP服务器端口
        private MailMessage mailMsg = null;

        /// <summary>
        /// 初始化MailHelper实例
        /// </summary>
        /// <param name="subject">邮件主题</param>
        /// <param name="body">邮件正文</param>
        /// <param name="isBodyHtml">邮件正文是否为 Html 格式</param>>
        public MailHelper(string subject, string body, bool isBodyHtml = true)
        {
            mailMsg = new MailMessage();
            mailMsg.Subject = subject;
            mailMsg.SubjectEncoding = Encoding.UTF8;
            mailMsg.Body = body;
            mailMsg.BodyEncoding = Encoding.UTF8;
            mailMsg.IsBodyHtml = isBodyHtml;
            mailMsg.From = new MailAddress(mailUserName, mailDisplayName);
        }

        /// <summary>
        /// 添加邮件接收人
        /// </summary>
        /// <param name="addresses">邮件地址</param>
        public void AddUser(string addresses)
        {
            mailMsg.To.Add(addresses);
        }

        /// <summary>
        /// 添加邮件附件
        /// </summary>
        /// <param name="fileName">文件全路径</param>
        public void AddFile(string fileName)
        {
            mailMsg.Attachments.Add(new Attachment(fileName));
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        public void Send()
        {
            using (var sc = new SmtpClient(smtpServerHost, smtpServerPort))
            {
                sc.Credentials = new NetworkCredential(mailUserName, mailPassword);
                sc.Send(mailMsg);
            }
        }

        public void Dispose()
        {
            if (mailMsg != null)
                mailMsg.Dispose();
        }
    }
}
