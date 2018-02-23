/********************************************************************************
** 作者： 张青云
** 创始时间：2016-10-31
** 描述：插入巡检照片
————
** 修改人：
** 修改时间： 
** 描述： 
————
*********************************************************************************/
using System;
using System.Data;
using System.Web;
using Business.Models;
using Business.Services.Interface;
using Business.Services.Service;
using Sp.BaseFrame.Common.Core;
using Sp.BaseFrame.Framework.Actions;
using Business.Controllers.UserControllers;
using System.Collections.Generic;


namespace Business.Controllers.TerminalControllers
{
    public class InspectionImageController : ActionBase
    {
        protected override string OnExecute()
        { 
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();  
            string pRequestguid = string.Empty;
            string pRequestzpwjmc = string.Empty;
            var dic = RequestData.FromJson<Dictionary<string, string>>();
            pRequestguid = dic.ContainsKey("guid") ? dic["guid"] : "";//序号
            pRequestzpwjmc = dic.ContainsKey("image") ? dic["image"] : "";          
            if (string.IsNullOrEmpty(pRequestguid))
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "返回guid为空!";
                pSpRequestMsg.data = "";
                return pSpRequestMsg.ToNormalJson();
            }
            if (string.IsNullOrEmpty(pRequestzpwjmc))
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "传入图片为空!";
                pSpRequestMsg.data = "";
                return pSpRequestMsg.ToNormalJson();
            }
            SpPagingResponse pSpPagingResponse = new SpPagingResponse();
            IUtilService service = SpServiceFactory.CreateUtilService();
            try
            {
                string NameImg = ValueHelper.ToImage(pRequestzpwjmc);
                DataTable dtDetail = service.QueryInsertImage(pRequestguid, NameImg);            
                pSpRequestMsg.success = true;
                pSpRequestMsg.message = "插入图片成功";
                pSpRequestMsg.data = dtDetail.ToJson();
                pRequestguid = ValueHelper.DataTable2Json(dtDetail);
            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "插入信息获取异常,详情" + ex.Message;
                pSpRequestMsg.data = "";
                Log.Error("插入信息详情获取异常:" + ex.Message.ToString());
            }
            
            return pSpRequestMsg.ToNormalJson();
           // return pRequestguid;
        }


        protected override void OnSetRequestData()
        {
        }
    }
}
