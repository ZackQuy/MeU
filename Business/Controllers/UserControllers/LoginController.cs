/********************************************************************************
** 作者： 张青云
** 创始时间：2016-12-3
** 描述：登录服务
————
** 修改人： 
** 修改时间： 
** 描述： 
————
*********************************************************************************/
using System;
using System.Collections.Generic;
using Sp.BaseFrame.Common.Core;
using Business.Services.Service;
using Sp.BaseFrame.Framework.Actions;

namespace Business.Controllers.UserControllers
{
    public class LoginController : ActionBase
    {

        protected override string OnExecute()
        {
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            SpRequestMsg pSpRequestMsgemail = new SpRequestMsg();
            pSpRequestMsg.data = "";
            try
            {
                //获取传入参数
                var dic = RequestData.FromJson<Dictionary<string, string>>();
                string dlm = dic.ContainsKey("userName") ? dic["userName"] : "";//序号
                string mm = dic.ContainsKey("password") ? dic["password"] : "";
                string email = dic.ContainsKey("email") ? dic["email"] : "";
                string type = dic.ContainsKey("type") ? dic["type"] : "";
                string username = dic.ContainsKey("username") ? dic["username"] : "";
                string strname = dic.ContainsKey("strName") ? dic["strName"] : "";
                string strPassword = dic.ContainsKey("strPassword") ? dic["strPassword"] : "";
                string useremail = dic.ContainsKey("useremail") ? dic["useremail"] : "";
                IUserService userService = SpServiceFactory.CreateUserService();
                if(mm!="")
                {
                pSpRequestMsg = userService.Login(dlm, mm);
                }
                if (type == "yx")
                {
                    pSpRequestMsg = userService.Selectedata(email, type);
                   
                }
                if (type == "dlm")
                {
                    pSpRequestMsg = userService.Selectedata(username, type);

                }
                if (type == "reg")
                {
                    pSpRequestMsg = userService.RegUser(strname, strPassword, useremail);

                }
                
            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "登录请求异常,详情" + ex.Message;
                Log.Error("登录请求异常:" + ex.Message.ToString());
                return pSpRequestMsg.ToNormalJson();
            }
            return pSpRequestMsg.ToJson();
        }

        protected override void OnSetRequestData()
        {
        }

    }
}