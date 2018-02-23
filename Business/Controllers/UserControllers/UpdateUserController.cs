/********************************************************************************
** 作者： 张青云
** 创始时间：2016-10-26
** 描述：用户信息更新
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
using System.Web;
using Business.Models;
using Business.Services.Interface;
using System.Data;

namespace Business.Controllers.UserControllers
{
    public class UpdateUserController : ActionBase
    {

        protected override string OnExecute()
        {
            /////////todo
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();                      
            pSpRequestMsg.data = "";
           
            try
            {                
                //获取传入参数
                var dic = RequestData.FromJson<Dictionary<string, string>>();
                string XM = dic.ContainsKey("name") ? dic["name"] : "";
                string DH = dic.ContainsKey("phone") ? dic["phone"] : "";
                string WX = dic.ContainsKey("weixin") ? dic["weixin"] : "";
                string Usercid = dic.ContainsKey("usercid") ? dic["usercid"] : "";     
                if (string.IsNullOrEmpty(XM))
                {
                    pSpRequestMsg.success = false;
                    pSpRequestMsg.message = "真实名字不能为空!";
                    return pSpRequestMsg.ToNormalJson();
                }
                if (string.IsNullOrEmpty(DH))
                {
                    pSpRequestMsg.success = false;
                    pSpRequestMsg.message = "电话号码不能为空!";
                    return pSpRequestMsg.ToNormalJson();
                }
                if (string.IsNullOrEmpty(WX))
                {
                    pSpRequestMsg.success = false;
                    pSpRequestMsg.message = "微信号不能为空!";
                    return pSpRequestMsg.ToNormalJson();
                }

                IUserService userService = SpServiceFactory.CreateUserService();
                pSpRequestMsg = userService.UpdateUser("", XM, DH, WX, Usercid);

            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "用户更新请求异常,详情" + ex.Message;
                Log.Error("用户更新请求异常:" + ex.Message.ToString());
            }
            return pSpRequestMsg.ToNormalJson();
        }

        protected override void OnSetRequestData()
        {
        }

    }
}