/********************************************************************************
** 作者： 
** 创始时间：
** 描述：
————
** 修改人： 张青云
** 修改时间： 2016-10-27
** 描述： 查询设备详情
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
    public class GetTerminalByCidController : GetActionBase
    {
        protected override string OnExecute()
        {
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            string JsonData = string.Empty;
            string tableName = "p_terminal";//设备表
            string fields = "cid,jxh,sbbm,jkfl,sbmc,jd,wd,jdmc,lxdh,ssdw,dwdz,dwlxr";//返回字段           
            HttpContext context = this.SpContext as HttpContext;
            string cid = context.Request["cid"] ?? "";
            if (string.IsNullOrEmpty(cid))
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "设备唯一标识不能为空!";
                pSpRequestMsg.data = "";
                return pSpRequestMsg.ToNormalJson();
            }
            string strWhere = string.Format("cid={0}", cid);
            ValueHelper.TerminalCid = cid;
            SpPagingResponse pSpPagingResponse = new SpPagingResponse();
            IUtilService service = SpServiceFactory.CreateUtilService();
            DataTable dtDetail = null;
            try
            {
                dtDetail = service.QueryData(fields, tableName, strWhere, cid);
                pSpRequestMsg.success = true;
                pSpRequestMsg.message = "设备详情获取成功";
                pSpRequestMsg.data = JsonData;
                JsonData = ValueHelper.DataTable2Json(dtDetail);
            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "设备详情获取异常,详情" + ex.Message;
                // pSpRequestMsg.data = "";
                Log.Error("设备详情获取异常:" + ex.Message.ToString());
                return pSpRequestMsg.ToNormalJson();

            }
            // return JsonData;//返回json字符串数据
            //return pSpRequestMsg.ToNormalJson();
            return dtDetail.ToJsonStore(true, dtDetail.Rows.Count);
        }

    }
}
