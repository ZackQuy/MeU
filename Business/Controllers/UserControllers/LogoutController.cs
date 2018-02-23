/********************************************************************************
** 作者： 张青云
** 创始时间：2016-12-3
** 描述：登出服务
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
    public class LogoutController : ActionBase
    {

        protected override string OnExecute()
        {
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            pSpRequestMsg.data = "";
            try
            {
                ////获取传入参数
                //var dic = RequestData.FromJson<Dictionary<string, string>>();
                //string dlm = dic.ContainsKey("UserName") ? dic["UserName"] : "0";//序号
                //string mm = dic.ContainsKey("Password") ? dic["Password"] : "";
                //if (string.IsNullOrEmpty(dlm))
                //{
                //    pSpRequestMsg.success = false;
                //    pSpRequestMsg.message = "登录名不能为空!";
                //    return pSpRequestMsg.ToNormalJson();
                //}
                //if (string.IsNullOrEmpty(mm))
                //{
                //    pSpRequestMsg.success = false;
                //    pSpRequestMsg.message = "登录密码不能为空!";
                //    return pSpRequestMsg.ToNormalJson();
                //}
                //IUserService userService = SpServiceFactory.CreateUserService();
                //pSpRequestMsg = userService.Login(dlm, mm);

                //TODO
            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "登录请求异常,详情" + ex.Message;
                Log.Error("登录请求异常:" + ex.Message.ToString());
            }
            return pSpRequestMsg.ToNormalJson();
        }

        protected override void OnSetRequestData()
        {
        }

    }
}