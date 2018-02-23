/********************************************************************************
** 作者： 张青云
** 创始时间：2016-12-3
** 描述：用户相关接口
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
using System.Data;
using Sp.BaseFrame.Services.Interface;
using Sp.BaseFrame.Common.Core;

namespace Business.Services.Service
{
    public interface IUserService : ISPService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码(未加密)</param>
        /// <returns>返回类</returns>
        SpRequestMsg Login(string userName, string password);
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="usercid">所属部门</param>
        /// <param name="department">所属部门</param>
        /// <param name="name">真实姓名</param>
        /// <param name="phone">联系电话</param>
        /// <param name="weixin">微信号</param>
        /// <returns>返回类</returns>
        SpRequestMsg UpdateUser(string department, string name, string phone, string weixin, string usercid);
        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="cid">用户唯一编号</param>
        /// <param name="userName">用户名</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="rePassword">重复密码</param>
        /// <returns></returns>
        SpRequestMsg UpdatePassword(string cid, string userName, string oldPassword, string newPassword, string rePassword);
        /// <summary>
        /// 退出账户:退出时,将退出操作记录到日志表中
        /// </summary>
        /// <param name="cid">用户唯一编号</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        SpRequestMsg Logout(string cid, string userName);
        /// <summary>
        /// </summary>
        /// <param name="data">查询的数据</param>
        /// <returns></returns>
        SpRequestMsg Selectedata(string data, string type);
        /// <summary>
        /// </summary>
        /// <param name="name">注册用户数据</param>
        /// <param name="pwd">注册用户数据</param>
        /// <param name="email">注册用户数据</param>
        /// <returns></returns>
        SpRequestMsg RegUser(string name, string pwd,string email);
    }
}
