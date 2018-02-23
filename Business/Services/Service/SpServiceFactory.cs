
/********************************************************************************
** 作者： 张青云
** 创始时间：2016-11-23
** 描述：公用服务类工厂
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
using Sp.BaseFrame.Services.Interface;
using Sp.BaseFrame.Services.Service;
using Business.Services.Interface;

namespace Business.Services.Service
{
    public class SpServiceFactory
    {
        /// <summary>
        /// 创建一个共享服务类
        /// </summary>
        /// <returns>返回具体实例类</returns>
        public static ISPService CreateServiceBase(string connectionKey = "sqlConnection")
        {
            return new SPServiceBase(connectionKey);
        }

        /// <summary>
        /// 创建自定义服务类
        /// </summary>
        /// <returns>返回具体实例类</returns>
        public static IUserService CreateUserService()
        {
            return new UserService();
        }
        /// <summary>
        /// 创建通用操作服务类
        /// </summary>
        /// <returns>返回具体实例类</returns>
        public static IUtilService CreateUtilService()
        {
            return new UtilService();
        }
    }
}
