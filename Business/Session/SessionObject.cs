/********************************************************************************
** 作者： 张青云
** 创始时间：2016-12-3
** 描述：用于session信息存储。
*********************************************************************************/
using System;
using System.Web;

namespace Business.Session
{
    public class SessionObject
    {
        private const String SessionKey = "SessionObject";
        public SessionObject()
        {

        }
        /// <summary>
        /// 外部使用方法（session）
        /// </summary>
        public static SessionObject Instance
        {
            get
            {
                if (null == HttpContext.Current.Session[SessionKey])
                {
                    HttpContext.Current.Session[SessionKey] = new SessionObject();
                }
                return HttpContext.Current.Session[SessionKey] as SessionObject;
            }
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        //public SpUser CurrentUser { get; set; }
    }
}
