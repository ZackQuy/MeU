/********************************************************************************
** 作者： 张青云
** 创始时间：2016-11-23
** 描述：相关查询接口实现
————
** 修改人： 
** 修改时间： 
** 描述： 
————
*********************************************************************************/
using System;
using System.Data;
using Business.Services.Interface;
using MySql.Data.MySqlClient;
using Sp.BaseFrame.Common.Core;
using Sp.BaseFrame.Common.Database;
using Sp.BaseFrame.Common.Util;
using System.Collections.Generic;
using System.Data.Common;
using Business.Models;
using Business.Controllers.UserControllers;

namespace Business.Services.Service
{
    public class UtilService : IUtilService
    {

        /// <summary>
        /// 执行多条语句的事务
        /// </summary>
        /// <param name="listSQL"></param>
        /// <returns></returns>
        bool IUtilService.ExecuteListSQL(List<string> listSQL, List<DbParameter[]> cmdParms)
        {
            return ApplicationManager.DefaultConnection.ExcuteData(listSQL, cmdParms);
        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int IUtilService.ExecuteSQL(string sql)
        {
            return ApplicationManager.DefaultConnection.ExcuteData(sql);
        }
        /// <summary>
        /// 查询表格数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fields"></param>
        /// <param name="where"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        DataTable IUtilService.QueryData(string fields, string tableName, string where,string cid)
        {
            try { 

            DataTable dtResult = new DataTable();
            DataTable dtimg = new DataTable();
            string sqlimg = "SELECT tpmc from p_image where sbcid = " + cid + "";
            string strSql = string.Empty;
            if (string.IsNullOrEmpty(where))
            {
                strSql = string.Format("SELECT {0} FROM {1}", fields, tableName);
            }
            else
            {
                strSql = string.Format("SELECT {0} FROM {1} WHERE {2}", fields, tableName, where);
            }
            dtimg = ApplicationManager.DefaultConnection.QueryData(sqlimg).Tables[0];

            dtResult = ApplicationManager.DefaultConnection.QueryData(strSql).Tables[0];
            dtResult.Columns.Add("sbtp");
            int tpwz = dtResult.Columns.IndexOf("sbtp");
            
            string ListPic = "";
            for (int i = 0; i < dtimg.Rows.Count;i++ )
            {
                if (i == dtimg.Rows.Count - 1)
                {
                    ListPic += "http://123.56.236.26/imgFolderPath/" + dtimg.Rows[i][0];
                }
                else {
                    ListPic += "http://123.56.236.26/imgFolderPath/" + dtimg.Rows[i][0] + ";";
                }
              // dtResult.Rows[0][tpwz] = "http://123.56.236.26/imgFolderPath/"+dtimg.Rows[i][0]+"";
              // tpwz++;
             //  if(i < dtimg.Rows.Count-1)
              // {
              //     dtResult.Columns.Add("sbtp" + i + "");
             //  }
            }
            string[] imglist = ListPic.Split(';');

           // for (int j = 0; j < imglist.Length - 1;j++ )
           // {
               // dtResult.Rows[0][tpwz] += imglist[j].ToString() + ",";
           // }
            dtResult.Rows[0][tpwz] = imglist.ToJson();
            return dtResult;
        }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// 查询用户信息数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fields"></param>
        /// <param name="where"></param>
        /// <param name="usercid"></param>
        /// <returns></returns>
        DataTable IUtilService.QueryUserData(string fields, string tableName, string where,string usercid)
        {
            try{

            SpRequestMsg pSpRequestMsg = new SpRequestMsg();
            pSpRequestMsg.data = "";
            DataTable dtResult = new DataTable();
            DataTable dtResultcid = new DataTable();
            DataTable dtbmcid = new DataTable();

            string strSql = string.Empty;
            string sqlwhere = "SELECT bmcid FROM p_relation WHERE yhcid = " + usercid + "";
            if (string.IsNullOrEmpty(where))
            {
                strSql = string.Format("SELECT {0} FROM {1}", fields, tableName);
            }
            else
            {
                strSql = string.Format("SELECT {0} FROM {1} WHERE {2}", fields, tableName, where);
            }

            dtResultcid = ApplicationManager.DefaultConnection.QueryData(sqlwhere).Tables[0];//得到的部门cid编号
            string bmcid = dtResultcid.Rows[0][0].ToString();
            if (bmcid == "")
            {
                pSpRequestMsg.success = false;
                pSpRequestMsg.message = "请求异常,该用户未分配部门！";
                return null;
            }
            else{
            string sqlbmcid = "SELECT mc FROM p_dept WHERE cid = " + bmcid + "";
            dtbmcid = ApplicationManager.DefaultConnection.QueryData(sqlbmcid).Tables[0];//得到的部门名称
            dtResult = ApplicationManager.DefaultConnection.QueryData(strSql).Tables[0];//得到的用户基本信息 
            dtResult.Columns.Add("bmmc");
            dtResult.Rows[0]["bmmc"] = dtbmcid.Rows[0][0].ToString();
            
            }
            return dtResult;
        }
            catch (Exception ex) { throw ex; }
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pSpPagingParam">查询参数</param>
        /// <param name="total">表总条数</param>
        /// <returns>表格</returns>
        public DataTable QueryPageTable(SpPagingParam pSpPagingParam, ref int total)
        {
            try
            {
                MySqlParameter[] parameters = {
                    new MySqlParameter("?p_tablename", MySqlDbType.VarChar, 100),
                    new MySqlParameter("?p_sort", MySqlDbType.VarChar, 100),
                    new MySqlParameter("?p_pagesize", MySqlDbType.Int32),
                    new MySqlParameter("?p_startindex", MySqlDbType.Int32),
                    new MySqlParameter("?p_filter", MySqlDbType.VarChar,100),
                    new MySqlParameter("?p_fields", MySqlDbType.VarChar,100),
                    new MySqlParameter("?p_outrows", MySqlDbType.Int32),
                    };
                parameters[0].Value = pSpPagingParam.tableName;
                parameters[1].Value = pSpPagingParam.sort;
                parameters[2].Value = pSpPagingParam.pageSize;
                parameters[3].Value = pSpPagingParam.page;
                parameters[4].Value = pSpPagingParam.whereClause;
                parameters[5].Value = pSpPagingParam.fields;
                parameters[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                DataTable dtResult = ApplicationManager.DefaultConnection.QueryData("GetDataByPageTABLE", parameters, 1).Tables[0];
                total = Convert.ToInt32(parameters[6].Value);
                return dtResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询巡检信息数据
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="dateStart"></param>
        /// <param name="xjjd"></param>  
        /// <param name="xjwd"></param> 
        /// <param name="xjdz"></param>
        /// <param name="xjyh"></param>
        /// <returns></returns>
        DataTable IUtilService.QueryInspectionData(string guid, string dateStart,string xjjd,string xjwd,string xjdz,string xjyh)
        {
            try{
            DataTable dtResult = new DataTable(); 
            string SQL = string.Format("insert into p_gas_inspection (guid,xjkssj,xjksjd,xjkswd,xjksdz,yhcid) values ('{0}','{1}','{2}','{3}','{4}','{5}')", guid,dateStart,xjjd,xjwd,xjdz,xjyh);
            int p = ApplicationManager.DefaultConnection.ExcuteData(SQL);

            string SQLjwd = string.Format("update p_user set xjjd = '{0}',xjwd = '{1}',xjsj = '{2}' where cid = '{3}' ", xjjd, xjwd, dateStart, xjyh);
            int pjwd = ApplicationManager.DefaultConnection.ExcuteData(SQLjwd);//插入用户表巡检坐标信息

            dtResult = ApplicationManager.DefaultConnection.QueryData("select guid from p_gas_inspection where guid = " + guid + "").Tables[0];
            return dtResult;}
        catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 插入经纬度坐标
        /// </summary>
        /// <param name="jd"></param>
        /// <param name="wd"></param>  
        /// <param name="xjguid"></param>
        /// <param name="xjyh"></param>
        /// <returns></returns>
        /// 
        DataTable IUtilService.QueryInsertJWDData(string jd, string wd, string xjguid ,string dateJWD,string xjyh)
        {
            try{
            DataTable dtResult = new DataTable();
            string sqlguidSelect = "select xjguid from p_gas_inspection_track where xjguid = " + xjguid + "";
            string sqlInsert = string.Format("insert into p_gas_inspection_track (xjguid,jd,wd,jlsj) values ('{0}','{1}','{2}','{3}')", xjguid, jd, wd, dateJWD);
            dtResult = ApplicationManager.DefaultConnection.QueryData(sqlguidSelect).Tables[0];
            int p = ApplicationManager.DefaultConnection.ExcuteData(sqlInsert);
            string SQLjwd = string.Format("update p_user set xjjd = '{0}',xjwd = '{1}',xjsj = '{2}' where cid = '{3}' ", jd, wd, dateJWD, xjyh);
            int pjwd = ApplicationManager.DefaultConnection.ExcuteData(SQLjwd);//插入用户表巡检坐标信息
            dtResult = ApplicationManager.DefaultConnection.QueryData("select xjguid from p_gas_inspection_track where xjguid = " + xjguid + "").Tables[0];
            return dtResult;}
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
        /// 
        DataTable IUtilService.QueryInsertExitDate(string xjguid, string Exitdate,string xjjd,string xjwd,string xjjsdz,string xjyh)
        {
            try
            {
                DataTable dtResult = new DataTable();
                string SQLdate = string.Format("update p_gas_inspection set xjjssj = '{0}',xjjsjd = '{2}',xjjswd = '{3}',xjjsdz = '{4}' where guid = '{1}' ", Exitdate, xjguid,xjjd,xjwd,xjjsdz);
                int p = ApplicationManager.DefaultConnection.ExcuteData(SQLdate);
                string SQLjwd = string.Format("update p_user set xjjd = '{0}',xjwd = '{1}',xjsj = '{2}' where cid = '{3}' ", xjjd, xjwd, Exitdate, xjyh);
                int pjwd = ApplicationManager.DefaultConnection.ExcuteData(SQLjwd);//插入用户表巡检坐标信息
                dtResult = ApplicationManager.DefaultConnection.QueryData("select guid from p_gas_inspection where guid = " + xjguid + "").Tables[0];
                return dtResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 插入巡检内容
        /// </summary>   
        /// <param name="xjguid"></param>
        /// <param name="xjnrjl"></param>
        /// <returns></returns>
        DataTable IUtilService.QueryInsertDataImg(string xjguid, string xjnrjl)
        {
            try
            {
                DataTable dtResult = new DataTable();
                string SQLdate = string.Format("update p_gas_inspection set xjnrjjl = '{0}' where guid = '{1}' ", xjnrjl, xjguid);
                int p = ApplicationManager.DefaultConnection.ExcuteData(SQLdate);
                dtResult = ApplicationManager.DefaultConnection.QueryData("select guid from p_gas_inspection where guid = " + xjguid + "").Tables[0];
                return dtResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 插入巡检图片
        /// </summary>   
        /// <param name="xjguid"></param>
        /// <param name="zpwjmc"></param>
        /// <returns></returns>
        DataTable IUtilService.QueryInsertImage(string xjguid, string zpwjmc)
        {
            try
            {
                DataTable dtResult = new DataTable();
                string SQL = string.Format("insert into p_gas_inspection_photo (xjguid,zpwjmc) values ('{0}','{1}') ", xjguid, zpwjmc);//插入巡检guid和图片名称
                int p = ApplicationManager.DefaultConnection.ExcuteData(SQL);
                dtResult = ApplicationManager.DefaultConnection.QueryData("select xjguid from p_gas_inspection_photo where xjguid = " + xjguid + "").Tables[0];//返回此次插入的巡检guid
                return dtResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 插入巡检图片列表及结论上报内容
        /// </summary>   
        /// <param name="xjguid"></param>
        /// <param name="zpwjmc"></param>
        /// <param name="xjnrjl"></param>
        /// <param name="sbsj"></param>
        /// <param name="yhcid"></param>
        /// <returns></returns>
        DataTable IUtilService.QueryInsertImageList(string xjguid, string zpwjmc, string xjnrjl,string sbsj,string yhcid)
        {
            try
            {
                DataTable dtResult = new DataTable();
                string[] ListImgName = zpwjmc.Split(';');//数组存储照片名称
                for (int i = 0; i < ListImgName.Length - 1; i++)
                {
                    string SQL = string.Format("insert into p_gas_inspection_photo (yhguid,zpwjmc,jlsj) values ('{0}','{1}','{2}') ", yhcid, ListImgName[i], sbsj);//插入隐患内容表cid和图片名称时间
                    int p = ApplicationManager.DefaultConnection.ExcuteData(SQL);
                }
                string SQLdate = string.Format("insert into p_gas_inspection_hidden (xjnrjjl,xjguid,sbsj) values ('{0}','{1}','{2}') ", xjnrjl, xjguid, sbsj);//插入巡检内容
                int content_gas = ApplicationManager.DefaultConnection.ExcuteData(SQLdate);
                dtResult = ApplicationManager.DefaultConnection.QueryData("select xjguid from p_gas_inspection_hidden where xjguid = " + xjguid + "").Tables[0];//返回此次插入的巡检guid
                return dtResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
