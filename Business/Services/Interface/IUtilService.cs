/********************************************************************************
** 作者： 张青云
** 创始时间：2016-12-3
** 描述：相关查询接口
————
** 修改人： 
** 修改时间： 
** 描述： 
————
*********************************************************************************/
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using Business.Models;

namespace Business.Services.Interface
{
    public interface IUtilService
    {
        /// <summary>
        /// 参数化方式执行事务
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <returns>查询结果</returns>
        bool ExecuteListSQL(List<string> listSQL, List<DbParameter[]> cmdParms);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteSQL(string sql);
        /// <summary>
        /// 查询表格数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fields"></param>
        /// <param name="where"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        DataTable QueryData(string fields, string tableName, string where,string cid);
        /// <summary>
        /// 查询用户信息数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fields"></param>
        /// <param name="where"></param>
        /// <param name="usercid"></param>
        /// <returns></returns>
        DataTable QueryUserData(string fields, string tableName, string where,string usercid);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pSpPagingParam">查询参数</param>
        /// <param name="total">表总条数</param>
        /// <returns>表格</returns>
        DataTable QueryPageTable(SpPagingParam pSpPagingParam, ref int total);

        /// <summary>
        /// 查询巡检数据
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="datestart"></param>  
        /// <param name="xjjd"></param>  
        /// <param name="xjwd"></param>  
        /// <param name="xjdz"></param>  
        /// <param name="xjyh"></param>
        /// <returns></returns>
        DataTable QueryInspectionData(string guid,string xjjd,string xjwd ,string datestart,string xjdz,string xjyh);

        /// <summary>
        /// 插入经纬度坐标
        /// </summary>
        /// <param name="jd"></param>
        /// <param name="wd"></param>   
        /// <param name="xjguid"></param>
        /// <param name="dateJWD"></param>
        /// <param name="xjyh"></param>
        /// <returns></returns>
        DataTable QueryInsertJWDData(string jd, string wd,string xjguid,string dateJWD,string xjyh);

        /// <summary>
        /// 插入结束时间
        /// </summary>   
        /// <param name="xjguid"></param>
        /// <param name="Exitdate"></param>
        /// <param name="xjjd"></param>  
        /// <param name="xjwd"></param>  
        /// <param name="xjjsdz"></param> 
        /// <param name="xjyh"></param>
        /// <returns></returns>
        DataTable QueryInsertExitDate(string xjguid, string Exitdate,string xjjd,string xjwd,string xjjsdz,string xjyh);

        /// <summary>
        /// 插入巡检内容
        /// </summary>   
        /// <param name="xjguid"></param>
        /// <param name="xjnrjl"></param>
        /// <returns></returns>
        DataTable QueryInsertDataImg(string xjguid, string xjnrjl);
        /// <summary>
        /// 插入巡检图片
        /// </summary>   
        /// <param name="xjguid"></param>
        /// <param name="zpwjmc"></param>
        /// <returns></returns>
        DataTable QueryInsertImage(string xjguid, string zpwjmc);

        /// <summary>
        /// 插入巡检结论及图片列表
        /// </summary>   
        /// <param name="xjguid"></param>
        /// <param name="zpwjmc"></param>
        /// <param name="xjnrjl"></param>
        /// <param name="sbsj"></param>
        /// <param name="yhcid"></param>
        /// <returns></returns>
        DataTable QueryInsertImageList(string xjguid, string zpwjmc, string xjnrjl,string sbsj,string yhcid);
    }
}
