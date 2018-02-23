/********************************************************************************
** 作者： 张青云
** 创始时间：2016-10-26
** 描述：密码重置
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
using Business.Controllers.UserControllers;

namespace Business.Controllers.UserControllers
{
    public class PwdResetController : ActionBase
    {

        protected override string OnExecute()
        {
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            pSpRequestMsg.data = "";
            try
            {
                //获取传入参数
                var dic = RequestData.FromJson<Dictionary<string, string>>();
               // string dlm = dic.ContainsKey("UserName") ? dic["UserName"] : "0";//序号

                string mm = dic.ContainsKey("oldPassword") ? dic["oldPassword"] : "";
                string newmm = dic.ContainsKey("newPassword") ? dic["newPassword"] : "";
                string remm = dic.ContainsKey("rePassword") ? dic["rePassword"] : "";
                string usercid = dic.ContainsKey("usercid") ? dic["usercid"] : ""; 
                if (string.IsNullOrEmpty(mm))
                {
                    pSpRequestMsg.success = false;
                    pSpRequestMsg.message = "原密码不能为空!";
                    return pSpRequestMsg.ToNormalJson();
                }
                if (string.IsNullOrEmpty(newmm))
                {
                    pSpRequestMsg.success = false;
                    pSpRequestMsg.message = "新密码不能为空!";
                    return pSpRequestMsg.ToNormalJson();
                }
                if (string.IsNullOrEmpty(remm))
                {
                    pSpRequestMsg.success = false;
                    pSpRequestMsg.message = "重复密码不能为空!";
                    return pSpRequestMsg.ToNormalJson();
                }

                IUserService userService = SpServiceFactory.CreateUserService();
                pSpRequestMsg = userService.UpdatePassword(usercid, "", mm, newmm, remm);

            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "密码输入异常,详情" + ex.Message;
                Log.Error("异常:" + ex.Message.ToString());
            }
            return pSpRequestMsg.ToNormalJson();
        }

        protected override void OnSetRequestData()
        {
        }

    }
}