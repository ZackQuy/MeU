/********************************************************************************
** 作者： 张青云
** 创始时间：2016-10-28
** 描述：停止巡检
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

namespace Business.Controllers.TerminalControllers
{
    public class InspectionStopController : GetActionBase
    {
        protected override string OnExecute()
        {
            DataTable dtDetail = null;
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();  
            string pRequestguid = string.Empty;                 
            HttpContext context = this.SpContext as HttpContext;
            string Inspectguid = context.Request["xjguid"] ?? "";
            string xjjd = context.Request["xjjd"] ?? "";
            string xjwd = context.Request["xjwd"] ?? "";
            string xjdz = context.Request["xjdz"] ?? "";
            string xjyh = context.Request["xjyh"] ?? "";//巡检用户cid
            string dateStop = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (string.IsNullOrEmpty(Inspectguid))
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "返回guid为空!";
                pSpRequestMsg.data = "";
                return pSpRequestMsg.ToNormalJson();
            }
            SpPagingResponse pSpPagingResponse = new SpPagingResponse();
            IUtilService service = SpServiceFactory.CreateUtilService();
            try
            {
                dtDetail = service.QueryInsertExitDate(Inspectguid, dateStop, xjjd, xjwd, xjdz, xjyh);
                pSpRequestMsg.success = true;
                pSpRequestMsg.message = "巡检结束成功";
                pSpRequestMsg.data = dtDetail.ToJson();
                pRequestguid = ValueHelper.DataTable2Json(dtDetail);
            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "巡检获取异常,详情" + ex.Message;
                pSpRequestMsg.data = "";
                Log.Error("巡检详情获取异常:" + ex.Message.ToString());
                return pSpRequestMsg.ToNormalJson();
            }
            return dtDetail.ToJsonStore(true, dtDetail.Rows.Count);
        }

    }
}
