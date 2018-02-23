/********************************************************************************
** 作者： 张青云
** 创始时间：201611-22
** 描述：通用登录日志表服务
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
using System.Web;
using System.IO;
using System.Reflection;
using System.Configuration;
using Sp.BaseFrame.Common.Core.IO;
using Sp.BaseFrame.Common.Core;
using System.Data;
using Business.Services.Service;

namespace Business.Controllers.BaseControllers
{
    public class InsertLogMes
    {

        /// <summary>
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="subordinateSystem">日志所属系统</param>
        /// <param name="logType">日志类型</param>
        /// <param name="userCid">用户cid</param>
        /// <returns></returns>
        public string InsertLogMessage(string message, int subordinateSystem, int logType, string userCid)
        {
            SpRequestMsg pRequestMsg = new SpRequestMsg();
            try
            {
                string tableName = "p_log";
                IUserService service = SpServiceFactory.CreateUserService();
                string sqlExists = string.Format("SELECT * FROM  p_user  WHERE cid ={0}", userCid);
                DataTable dt = service.m_AdoDataLoader.QueryData(sqlExists).Tables[0];
                string logerName = Convert.ToString(dt.Rows[0]["dlm"]);
                string userName = Convert.ToString(dt.Rows[0]["xm"]);
                string clientIP = GetIP();
                string loginCreateTime = Sp.BaseFrame.Common.Util.Utilitys.GetCurrentTime();  //获取当前时间
                DateTime recordTime = Convert.ToDateTime(loginCreateTime);
                List<string> listSQL = new List<string>();//事务语句
                string sql = string.Format("insert into {0}  (yhcid,dlm,xm,ssxt,rzlx,ipdz,cznr,jlsj) values ('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                tableName, userCid, logerName, userName, subordinateSystem, logType, clientIP, message, recordTime);
                listSQL.Add(sql);
                bool bResult = service.m_AdoDataLoader.ExcuteData(listSQL);
                if (bResult)
                {
                    pRequestMsg.success = true;
                    pRequestMsg.message = "用户日志新增成功！";
                }
                else
                {
                    pRequestMsg.success = false;
                    pRequestMsg.message = "用户日志新增失败！";
                }
            }
            catch (Exception ex)
            {
                Log.Error("添加日志异常，详情：", ex);
                pRequestMsg.success = false;
                pRequestMsg.message = "添加日志失败！";
            }
            return pRequestMsg.ToNormalJson();
        
        }
        /// <summary>
        /// 获取当前用户IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.UserHostAddress;

            if (result == "::1")
                return "127.0.0.1";

            if (string.IsNullOrEmpty(result) || !IsIP(result))
                return "unknown";

            return result;
        }
        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        /// <summary>
        /// 日志类型
        /// </summary>
        public enum LogType
        {
            /// <summary>
            /// 登录
            /// </summary>
            Login = 0,
            /// <summary>
            /// 注销
            /// </summary>
            Logout = 1,
            /// <summary>
            /// 发送邮件
            /// </summary>
            SendMail = 2,
            /// <summary>
            /// 发送短信
            /// </summary>
            SendSMS = 3,
            /// <summary>
            /// 生成文件
            /// </summary>
            CreateFile = 4,
            /// <summary>
            /// 删除文件
            /// </summary>
            DeleteFile = 5
        }
    }
}
