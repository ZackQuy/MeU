/********************************************************************************
** 作者： 张青云
** 创始时间：2016-10-28
** 描述：插入经纬度坐标
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
using Business.Services.Interface;
using System.Data;


namespace Business.Controllers.TerminalControllers
{
    public class InsertJWDController : ActionBase
    {

        protected override string OnExecute()
        {
            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            pSpRequestMsg.data = "";
            DataTable dtDetail = null;
            try
            {
                //获取传入参数
                var dic = RequestData.FromJson<Dictionary<string, string>>();
                string xjjd = dic.ContainsKey("xjjd") ? dic["xjjd"] : "";//序号
                string xjwd = dic.ContainsKey("xjwd") ? dic["xjwd"] : "";
                string xjguid = dic.ContainsKey("guid") ? dic["guid"] : "";
                string xjyh = dic.ContainsKey("xjyh") ? dic["xjyh"] : "";//巡检用户cid
                string dateJWD = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (string.IsNullOrEmpty(xjguid))
                {
                    pSpRequestMsg.success = false;
                    pSpRequestMsg.message = "巡检返回ID为空";
                    return pSpRequestMsg.ToNormalJson();
                }
                if (string.IsNullOrEmpty(xjjd))
                {
                    pSpRequestMsg.success = false;
                    pSpRequestMsg.message = "巡检上报经度坐标为空!";
                    return pSpRequestMsg.ToNormalJson();
                }
                if (string.IsNullOrEmpty(xjwd))
                {
                    pSpRequestMsg.success = false;
                    pSpRequestMsg.message = "巡检上报纬度坐标为空!";
                    return pSpRequestMsg.ToNormalJson();
                }
                IUtilService utilService = SpServiceFactory.CreateUtilService();

                dtDetail = utilService.QueryInsertJWDData(xjjd, xjwd, xjguid, dateJWD, xjyh);
              //  pSpRequestMsg.data = dtDetail.ToJson();
              

            }
            catch (Exception ex)
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "上报坐标请求异常,详情" + ex.Message;
                Log.Error("上报坐标请求异常:" + ex.Message.ToString());
                return pSpRequestMsg.ToNormalJson();
            }
            return dtDetail.ToJsonStore(true, dtDetail.Rows.Count);
           // return pSpRequestMsg.ToNormalJson();
        }

        protected override void OnSetRequestData()
        {
        }

    }
}