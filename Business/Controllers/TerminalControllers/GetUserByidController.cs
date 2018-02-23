/********************************************************************************
** 作者： 张青云
** 创始时间：2016-10-27
** 描述：查询用户信息详情
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
    public class GetUserByidController : GetActionBase
    {
        protected override string OnExecute()
        {

           
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            SpRequestMsgData pSpRequestMsgdata = new SpRequestMsgData();
            DataTable dtDetail = null ;
            string JsonData = string.Empty;
            string tableName = "p_user";//用户信息
            string fields = "xm,dh,wx";//返回字段    
            HttpContext context = this.SpContext as HttpContext;
            string cid = context.Request["usercid"] ?? "";
           // string cid = ValueHelper.pwdcid;
            if (string.IsNullOrEmpty(cid))
            {
                pSpRequestMsgdata.success = false;
                pSpRequestMsgdata.message = "唯一标识不能为空!";
                pSpRequestMsgdata.Jsondata = "";
                return JsonData;
            }
            string strWhere = string.Format("cid={0}", cid);
            SpPagingResponse pSpPagingResponse = new SpPagingResponse();
            IUtilService service = SpServiceFactory.CreateUtilService();
            try
            {
                dtDetail = service.QueryUserData(fields, tableName, strWhere,cid);
                pSpRequestMsgdata.success = true;
                pSpRequestMsgdata.message = "用户详情获取成功";
                JsonData = ValueHelper.DataTable2Json(dtDetail);
                pSpRequestMsgdata.Jsondata = JsonData;
               
               
            }
            catch (Exception ex)
            {
                pSpRequestMsgdata.success = false;
                pSpRequestMsgdata.message = "用户详情获取异常,详情" + ex.Message;
                pSpRequestMsgdata.Jsondata = "";
                Log.Error("用户详情获取异常:" + ex.Message.ToString());
                return pSpRequestMsg.ToNormalJson();
            }

             // return JsonData;
            return dtDetail.ToJsonStore(true, dtDetail.Rows.Count);
        }

    }
}
