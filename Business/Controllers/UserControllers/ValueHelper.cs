/********************************************************************************
** 作者： 张青云
** 创始时间：2016-10-26
** 描述：通用帮助类方法
————
** 修改人： 
** 修改时间： 
** 描述： 
————
*********************************************************************************/
using Sp.BaseFrame.Common.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Business.Controllers.UserControllers
{
    class ValueHelper
    {
        public static string pwdcid = string.Empty;//定义登录用户cid
        public static string pwdusername = string.Empty;//定义登录用户名
        public static string TerminalCid = string.Empty;//
       

        public static string DataTable2Json(DataTable dt)//将datatable转换成json数据格式
        {
            if (dt.Rows.Count == 0)
            {
                return "";
            }

            StringBuilder jsonBuilder = new StringBuilder();
            // jsonBuilder.Append("{");   
            //jsonBuilder.Append(dt.TableName.ToString());    
            jsonBuilder.Append("[");//转换成多个model的形式  
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            //  jsonBuilder.Append("}");  
            return jsonBuilder.ToString();
        }


        /// <summary>
        /// 重命名上传文件
        /// </summary>
        /// <param name="fileName">文件原名称（含后缀,如：Chrysanthemum.jpg）</param>
        /// <returns>新文件名称（如：20150121112319327_52617.jpg）</returns>
        public static string ResetFileName(string fileName)
        {
            //计算随机种子
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            int seed = BitConverter.ToInt32(bytes, 0);
            //生成随机数
            Random random = new Random(seed);
            string strRandom = random.Next(10000, 99999).ToString();//5位随机数
            return DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + strRandom + fileName.Substring(fileName.LastIndexOf('.'));
        }


        /// <summary>
        /// 解码图片
        /// </summary>
        /// <param name="base64">文件原名称（含后缀,如：Chrysanthemum.jpg）</param>
        /// <returns></returns>
        public static string ToImage(string base64)
        {


            string dummyData = base64.Replace("data:image/jpeg;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/png;base64,", "").Replace("data:image/gif;base64,", "").Replace("data:image/bmp;base64,", "").Replace("%2B", "+");
            byte[] bytes = Convert.FromBase64String(dummyData);
            MemoryStream memStream = new MemoryStream(bytes);
            BinaryFormatter binFormatter = new BinaryFormatter();
            Bitmap bmp = new Bitmap(memStream);
            string ImaName = ResetFileName("Chrysanthemum.jpg");
            string PathImg = ConfigurationManager.AppSettings["imgFolderPath"].ToString() + "GasPhoto//";
            //bmp.Save(PathImg);
            try
            {
                //验证父级文件夹，如果不存在 则创建 
                if (!Directory.Exists(PathImg))
                {
                    Directory.CreateDirectory(PathImg);
                }
                string PathImgField = PathImg + ImaName + " ";
                bmp.Save(PathImgField);
                return ImaName;
            }

            catch (Exception ex)
            {
                //记录本地日志
                Log.Error("异常：" + ex.ToString());
                return null;
            }
          //  return ImaName;
        }


    }
}
