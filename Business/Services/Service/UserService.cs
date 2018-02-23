/********************************************************************************
** 作者： 张青云
** 创始时间：2016-12-3
** 描述：用户相关接口实现类
————
** 修改人： 
** 修改时间： 
** 描述： 
————
*********************************************************************************/
using System;
using System.Data;
using Sp.BaseFrame.Common.Database;
using Sp.BaseFrame.Services.Service;
using Sp.BaseFrame.Common.Core;
using MySql.Data.MySqlClient;
using Sp.BaseFrame.Services.Interface;
using System.Collections.Generic;
using Business.Controllers.UserControllers;
using Business.Controllers.BaseControllers;
using System.Configuration;

namespace Business.Services.Service
{
    public class UserService : SPServiceBase, IUserService
    {
        static readonly int systemType = Convert.ToInt32(ConfigurationManager.AppSettings["systemType"]);
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码(未加密)</param>
        /// <returns></returns>
        public SpRequestMsg Login(string userName, string password)
        {
           
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            pSpRequestMsg.data = "";      
            try
            {
                MySqlParameter[] parameters = { new MySqlParameter("?dlm", userName) };
                //判断用户是否存在
                DataTable dtExist = ApplicationManager.DefaultConnection.QueryData("select cid from p_user where dlm=?dlm", parameters, 0).Tables[0];
                if (dtExist.Rows.Count > 0)
                {
                       MySqlParameter[] parameters1 = { 
                          new MySqlParameter("?dlm", userName),
                          new MySqlParameter("?mm", Sp.BaseFrame.Common.Util.AESEncryptionUtils.Encrypt(password))//密码加密
                          
                    };
                    //判断用户信息是否合法
                    DataTable dtUser = ApplicationManager.DefaultConnection.QueryData("select cid,zt,dlm from p_user where dlm=?dlm and mm=?mm", parameters1, 0).Tables[0];
                    if (dtUser.Rows.Count > 0)
                    {
                        var dt = ApplicationManager.DefaultConnection.QueryData("select xtqx from p_user where dlm=?dlm", parameters, 0).Tables[0];//判断用户权限
                        if (dt.Rows.Count > 0 && string.Format(",{0},", dt.Rows[0].Field<string>("xtqx")).IndexOf(string.Format(",{0},", systemType)) > -1)
                        {
                            string strZT = dtUser.Rows[0]["zt"].ToString();
                            string cid = dtUser.Rows[0]["cid"].ToString();
                            string username = dtUser.Rows[0]["dlm"].ToString();
                            string sqlQuery = "SELECT xtqx FROM p_user WHERE cid = " + cid + "";
                            string ssxt = ApplicationManager.DefaultConnection.ExecuteScalar(sqlQuery);
                            string logtype = "SELECT rzlx FROM p_user WHERE cid = " + cid + "";
                            string userxm = "SELECT xm FROM p_user WHERE cid = " + cid + "";
                            string xm = ApplicationManager.DefaultConnection.ExecuteScalar(userxm);
                            if (strZT == "2")//禁用
                            {
                                pSpRequestMsg.success = false;
                                pSpRequestMsg.message = "该用户已被禁用,请联系管理员!";
                            }
                            else
                            {
                                pSpRequestMsg.success = true;
                                pSpRequestMsg.message = "用户登录成功！";
                                pSpRequestMsg.data = cid + ";" + xm;//返回用户唯一编号cid
                                InsertLogMes insertlogmes = new InsertLogMes();
                                insertlogmes.InsertLogMessage(pSpRequestMsg.message, 6, 0, cid);

                                ValueHelper.pwdcid = cid;//定义全局变量cid
                                ValueHelper.pwdusername = username;//定义全局变量用户名

                            }
                        }
                        else {
                            pSpRequestMsg.success = false;
                            pSpRequestMsg.message = "该用户已没有系统权限！";
                        }

                        
                    }
                    else
                    {
                        pSpRequestMsg.success = false;
                        pSpRequestMsg.message = "登录密码错误!";
                    }
                }
                else
                {
                    pSpRequestMsg.success = false;
                    pSpRequestMsg.message = "登录名不存在!";
                }
            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "登录请求异常,详情" + ex.Message;
            }
            return pSpRequestMsg;
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="usercid">所属部门</param>
        /// <param name="department">所属部门</param>
        /// <param name="name">真实姓名</param>
        /// <param name="phone">联系电话</param>
        /// <param name="weixin">微信号</param>
        /// <returns>返回类</returns>
        public SpRequestMsg UpdateUser(string department, string name, string phone, string weixin, string usercid)
        {
            //TODO 
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            pSpRequestMsg.data = "";
            ISPService service = SpServiceFactory.CreateServiceBase();
            try
            {
                string Uname = "UPDATE p_user SET xm = '" + name + "' WHERE cid = " + usercid + "";
                string Uphone = "UPDATE p_user SET dh = " + phone + " WHERE cid = " + usercid + "";
                string Uweixin = "UPDATE p_user SET wx = " + weixin + " WHERE cid = " + usercid + "";
                ApplicationManager.DefaultConnection.ExcuteData(Uname);
                ApplicationManager.DefaultConnection.ExcuteData(Uphone);
                ApplicationManager.DefaultConnection.ExcuteData(Uweixin);
                pSpRequestMsg.success = true;
                pSpRequestMsg.message = "信息修改成功！"; 

            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "信息修改请求异常,详情" + ex.Message;
            }






            return pSpRequestMsg;
        }

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="cid">用户唯一编号</param>
        /// <param name="userName">用户名</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="rePassword">重复密码</param>
        /// <returns></returns>
        public SpRequestMsg UpdatePassword(string cid, string userName, string oldPassword, string newPassword, string rePassword)
        {
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            pSpRequestMsg.data = "";
            ISPService service = SpServiceFactory.CreateServiceBase();
            
            try {
                string oldPwd = Sp.BaseFrame.Common.Util.AESEncryptionUtils.Encrypt(oldPassword);
                MySqlParameter[] parameters = { new MySqlParameter("?mm", oldPwd) };
                //判断是否存在
                DataTable dtExist = ApplicationManager.DefaultConnection.QueryData("select mm from p_user where mm=?mm", parameters, 0).Tables[0];
                if (dtExist.Rows.Count > 0)
                {
                    pSpRequestMsg.success = true;
                    pSpRequestMsg.message = "密码匹配正确!";


                    if (newPassword != rePassword)
                    {
                        pSpRequestMsg.success = false;
                        pSpRequestMsg.message = "前后密码输入不一致!";

                    }
                    else {
                        string NewPwd = Sp.BaseFrame.Common.Util.AESEncryptionUtils.Encrypt(newPassword);//加密新添加密码
                        string updata = "UPDATE p_user SET mm = '" + NewPwd + "' WHERE cid = " + cid + " ";
                        ApplicationManager.DefaultConnection.ExcuteData(updata);
                        pSpRequestMsg.message = "密码修改成功！"; 
                         }
                   
                }
                 
            }
            catch (Exception ex) 
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "密码修改请求异常,详情" + ex.Message;
            }

            return pSpRequestMsg;

        }
        /// <summary>
        /// 退出账户:退出时,将退出操作记录到日志表中
        /// </summary>
        /// <param name="cid">用户唯一编号</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>

        public SpRequestMsg Logout(string cid, string userName)
        {
            //TODO 
            throw new NotImplementedException();
        }
        /// <summary>
        /// </summary>
        /// <param name="data">查询的数据</param>
        /// <param name="type">查询的数据</param>
        /// <returns></returns>

        public SpRequestMsg Selectedata(string data,string type)
        {
            //TODO 
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            pSpRequestMsg.data = "";
            try {
                MySqlParameter[] parameters = { new MySqlParameter("?data", data) };
                //判断用户是否存在
                DataTable dtExist = ApplicationManager.DefaultConnection.QueryData("select cid from p_user where " + type + "=?data", parameters, 0).Tables[0];

                if (dtExist.Rows[0][0].ToString() != "")
                {
                    pSpRequestMsg.success = false;
                    if(type =="yx")
                    {
                        pSpRequestMsg.message = "该邮箱已注册，请重新输入！";
                    }
                    if (type == "dlm")
                    {
                        pSpRequestMsg.message = "该名称已注册，请重新输入！";
                    }
                
                }
                else {
                    pSpRequestMsg.success = true;
                    if (type == "yx")
                    {
                        pSpRequestMsg.message = "邮箱可用！";
                    }
                    if (type == "dlm")
                    {
                        pSpRequestMsg.message = "用户名可用！";
                    }
                }
            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = true;
                if (type == "yx")
                {
                    pSpRequestMsg.message = "邮箱可用！";
                }
                if (type == "dlm")
                {
                    pSpRequestMsg.message = "用户名可用！";
                }
            }


            return pSpRequestMsg;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">注册用户数据</param>
        /// <param name="pwd">注册用户数据</param>
        /// <param name="email">注册用户数据</param>
        /// <returns></returns>
        public SpRequestMsg RegUser(string name, string pwd, string email)
    {
        SpRequestMsg pSpRequestMsg = new SpRequestMsg();
        pSpRequestMsg.data = "";
        try {
            string NewPwd = Sp.BaseFrame.Common.Util.AESEncryptionUtils.Encrypt(pwd);//加密新添加密码
            string sqlInsert = string.Format("insert into p_user (dlm,mm,yx) values ('{0}','{1}','{2}')", name, NewPwd, email);
            ApplicationManager.DefaultConnection.ExcuteData(sqlInsert);
            pSpRequestMsg.success = true;
            pSpRequestMsg.message = "注册用户成功！";
        }
        catch (Exception ex)
        {
            pSpRequestMsg.success = false;
            pSpRequestMsg.message = "注册用户请求异常,详情" + ex.Message;
        }


        return pSpRequestMsg;
        }
    }
}
