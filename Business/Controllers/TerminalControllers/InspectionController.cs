/********************************************************************************
** 作者： 张青云
** 创始时间：2016-10-27
** 描述：巡检详情
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
using Sp.BaseFrame.Common.Database;
using System.Collections.Generic;

namespace Business.Controllers.TerminalControllers
{
    public class InspectionController : GetActionBase
    {
        protected override string OnExecute()
        { 
 
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            DataTable dtDetail = null;
            string pRequestguid = string.Empty;         
            HttpContext context = this.SpContext as HttpContext;          
            string dateStart = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string InspectionGuid = string.Empty;
            string sqlSelectguid = "select max(cid) from p_gas_inspection";
            DataTable dtGetguid = new DataTable();
            dtGetguid = ApplicationManager.DefaultConnection.QueryData(sqlSelectguid).Tables[0];
            if (dtGetguid.Rows[0][0].ToString() == "")
            {
                InspectionGuid = "1";
            }
            if (dtGetguid.Rows[0][0].ToString() != "")
            {
                int maxguid = Convert.ToInt32(dtGetguid.Rows[0][0]) + 1;
                InspectionGuid = Convert.ToString(maxguid);
            }
            string xjjd = context.Request["xjjd"] ?? "";//经度
            string xjwd = context.Request["xjwd"] ?? "";//纬度
            string xjdz = context.Request["xjdz"] ?? "";//巡检地址
            string xjyh = context.Request["xjyh"] ?? "";//巡检用户cid
            SpPagingResponse pSpPagingResponse = new SpPagingResponse();
            IUtilService service = SpServiceFactory.CreateUtilService();
            try
            {
                dtDetail = service.QueryInspectionData(InspectionGuid,dateStart,xjjd,xjwd,xjdz,xjyh);

                pSpRequestMsg.success = true;
                pSpRequestMsg.message = "巡检开始成功";
                pSpRequestMsg.data = pRequestguid;
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
