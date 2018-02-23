/********************************************************************************
** 作者： 张青云
** 创始时间：2016-12-3
** 描述：分页列表
————
** 修改人： 
** 修改时间： 
** 描述： 
————
*********************************************************************************/
using System;
using System.Data;
using System.Web;
using Business.Services.Interface;
using Business.Services.Service;
using Sp.BaseFrame.Common.Core;
using Sp.BaseFrame.Framework.Actions;
using Business.Models;
namespace Business.Controllers.TerminalControllers
{
    public class PagingTerminalController : GetActionBase
    {
        protected override string OnExecute()
        {
            HttpContext context = this.SpContext as HttpContext;
            try
            {
                string tableName = "p_terminal";//设备表
                string fields = "cid,sbbm,sbmc,jxh,jd,wd";//返回字段
                string whereClause = context.Request["keyWord"] ?? "";//where部分
                string strPage = context.Request["start"] ?? "1";//
                string strPageSize = context.Request["pageSize"] ?? "15";
                string sort = context.Request["sort"] ?? "";
                string userName = context.Request["userName"] ?? "";
                int page = Convert.ToInt32(strPage);
                if (page <= 0)
                {
                    page = 1;
                }
                if (!string.IsNullOrEmpty(whereClause))
                {
                    whereClause = string.Format("where CONCAT(IFNULL(sbmc,''),' ',IFNULL(sbbm,''),' ',IFNULL(jxh,'')) LIKE '%{0}%'", whereClause);
                }
                int pageSize = Convert.ToInt32(strPageSize);
                SpPagingParam pSpPagingParam = new SpPagingParam()
                {
                    tableName = tableName,
                    pageSize = pageSize,
                    page = page,
                    sort = sort,
                    whereClause = whereClause,
                    fields = fields
                };
                IUtilService utilService = SpServiceFactory.CreateUtilService();
                int total = 0;
                DataTable dtResult = utilService.QueryPageTable(pSpPagingParam, ref total);
                return this.ToJsonP(dtResult.ToStandardJson(true, total, "分页列表数据"));
            }
            catch (Exception ex)
            {
                Log.Error("分页查询异常:" + ex.Message.ToString());
                throw ex;
            }
        }
    }
}
