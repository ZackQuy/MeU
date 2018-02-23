/********************************************************************************
** 作者： 张青云
** 创始时间：2016-11-20
** 描述：插入巡检结论及照片
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
using Business.Controllers.BaseControllers;
using Sp.BaseFrame.Common.Database;


namespace Business.Controllers.TerminalControllers
{
    public class InspectionImageListController : ActionBase
    {
        protected override string OnExecute()
        {
            //获取传入参数       
            HttpContext context = this.SpContext as HttpContext;
            context.Response.ContentType = "text/html";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic = RequestData.FromJson<Dictionary<string, string>>();

            DataTable dtDetail = null;
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            string pRequestguid = string.Empty;
            string yhcid = string.Empty;
            pRequestguid = dic["guid"] ?? "";//
            string pRequestxjnrjjl = dic["xjnrjjl"] ?? "";//获取结论上报内容
            string datesbsj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//上报时间
            string sqlSelectguid = "select max(cid) from p_gas_inspection_hidden";//查询出隐患表的最大cid值
            DataTable dtGetguid = new DataTable();
            dtGetguid = ApplicationManager.DefaultConnection.QueryData(sqlSelectguid).Tables[0];
            if (dtGetguid.Rows[0][0].ToString() == "")
            {
                yhcid = "1";
            }
            if (dtGetguid.Rows[0][0].ToString() != "")
            {
                int maxguid = Convert.ToInt32(dtGetguid.Rows[0][0]) + 1;
                yhcid = Convert.ToString(maxguid);
            }
            if (string.IsNullOrEmpty(pRequestguid))
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
                SavePicAction savepic = new SavePicAction();
                List<string> listImgeName = new List<string>();
                listImgeName = savepic.SaveUploadFileList(context, "GasPhoto");
                string NameImgs = "";
                Log.Info("listImgeName:" + listImgeName.Count);
                for (int i = 0; i < listImgeName.Count; i++)
                {
                    if (listImgeName[i].ToString() == "")
                    {

                    }
                    else
                    {
                        NameImgs += listImgeName[i].ToString() + ";";
                    }

                }
                dtDetail = service.QueryInsertImageList(pRequestguid, NameImgs, pRequestxjnrjjl, datesbsj,yhcid);
                pSpRequestMsg.success = true;
                pSpRequestMsg.message = "上报信息成功";
                pSpRequestMsg.data = dtDetail.ToJson();
                pRequestguid = ValueHelper.DataTable2Json(dtDetail);
                //Log.Info("结果:上报信息成功");
            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "插入信息获取异常,详情" + ex.Message;
                pSpRequestMsg.data = "";
                Log.Error("插入信息详情获取异常:" + ex.Message.ToString());
                return pSpRequestMsg.ToNormalJson();
            }
            return dtDetail.ToJsonStore(true, dtDetail.Rows.Count); 
        }


        protected override void OnSetRequestData()
        {
        }
    }
}
