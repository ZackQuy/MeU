/********************************************************************************
** 作者： 张青云
** 创始时间：2016-12-3
** 描述：通用文件上传存储服务
————
** 修改人： 
** 修改时间： 
** 描述： 
————
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Reflection;
using System.Configuration;
using Sp.BaseFrame.Common.Core.IO;
using Sp.BaseFrame.Common.Core;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace Business.Controllers.BaseControllers
{
    public class SavePicAction
    {
        string fileFullPath = string.Empty;//文件上传全路径
        string fileName = string.Empty;//上传文件名称,含后缀;
        string suffix = string.Empty;//文件后缀
        string relativePath = string.Empty;
        string filePath = string.Empty;
        string strFileName = string.Empty;//存储文件名称和后缀
        float fileMaxSize = int.Parse(System.Configuration.ConfigurationManager.AppSettings["FileMaxSize"]);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="context"></param>
        /// <param name="subFolder">子文件夹，如：people、poi等</param>
        /// <param name="resetName">是否重命名</param>
        /// <param name="NameLast">是否保留原有文件名并在原名后加入随机数</param>
        /// <returns></returns>
        public string SaveUploadFile(HttpContext context, string subFolder, bool resetName = true,bool NameLast = false)
        {
            string strFileFullPath = string.Empty;//文件完整路径
            //string strRootPath = context.Request.PhysicalApplicationPath + "UploadFiles\\" + subFolder + "\\";
            string strRootPath = ConfigurationManager.AppSettings["imgFolderPath"].ToString() + subFolder + "\\";
            string fileName = null;//文件的名称
            try
            {
                //验证父级文件夹，如果不存在 则创建 
                if (!Directory.Exists(strRootPath))
                {
                    Directory.CreateDirectory(strRootPath);
                }
                ///遍历File表单元素      
                HttpFileCollection files = context.Request.Files;

                for (int iFile = 0; iFile < files.Count; iFile++)
                {
                    ///检查文件扩展名字          
                    HttpPostedFile postedFile = files[iFile];
                    fileName = System.IO.Path.GetFileName(postedFile.FileName);//如：Chrysanthemum.jpg
                    if (!string.IsNullOrEmpty(fileName))//如果不为空：则重命名再保存
                    {
                        string fileNewName = fileName;
                        if (resetName)
                        {
                            fileNewName = ResetFileName(fileName);
                            strFileFullPath = strRootPath + fileNewName;
                            postedFile.SaveAs(strFileFullPath);//保存文件
                            return fileNewName;
                        }
                        if (NameLast)
                        {
                            fileNewName = ResetFileNames(fileName);
                            strFileFullPath = strRootPath + fileNewName;
                            postedFile.SaveAs(strFileFullPath);//保存文件
                            return fileNewName;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //记录本地日志
                Log.Error("异常：" + ex.ToString());
                return null;
            }
            return null;
        }
        /// <summary>
        ///多文件上传，返回多文件
        /// </summary>
        /// <param name="context"></param>
        /// <param name="subFolder">人口照片、poi等文件夹名称</param>
        /// <param name="resetName">是否只返回文件名称</param>
        /// <returns></returns>
        public List<string> SaveUploadFileList(HttpContext context, string subFolder, bool resetName = true)
        {
            string strFileFullPath = string.Empty;//文件完整路径
            string strRootPath = ConfigurationManager.AppSettings["imgFolderPath"].ToString() + subFolder + "\\";
            List<string> listImge = new List<string>();
            try
            {
                //验证父级文件夹，如果不存在 则创建 
                if (!Directory.Exists(strRootPath))
                {
                    Directory.CreateDirectory(strRootPath);
                }
                ///遍历File表单元素      
                HttpFileCollection files = context.Request.Files;
                for (int iFile = 0; iFile < files.Count; iFile++)
                {
                    strFileName = "";
                    suffix = "";
                    ///检查文件扩展名字          
                    HttpPostedFile postedFile = files[iFile];
                    filePath = postedFile.FileName;
                    float fileSize = (postedFile.ContentLength / 1024.0f) / 1024.0f;
                    if (fileSize > fileMaxSize)
                    {

                    }
                    else
                    {
                        fileName = System.IO.Path.GetFileName(postedFile.FileName);
                        if ("" != fileName)
                        {
                            string fileNewName = ResetFileName(fileName);
                            strFileFullPath = strRootPath + fileNewName;
                            //判断目录中是否已经存在此文件
                            if (FileFolderHelper.IsFileExist(strFileFullPath))
                            {
                                //暂不处理
                            }
                            else
                            {
                                postedFile.SaveAs(strFileFullPath);//保存图片
                                if (resetName)
                                {
                                    listImge.Add(fileNewName);//将新定义的图片名称返回
                                }
                                else {
                                    listImge.Add(subFolder + "\\" + fileNewName);//将新定义的图片名称返回
                                }
                                
                              
                            }
                        }
                        else
                        {

                            listImge.Add("");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("文件上传出错,详情：" + ex.ToString());
            }
            return listImge;
        }
        /// <summary>
        /// 重命名上传文件
        /// </summary>
        /// <param name="fileName">文件原名称（含后缀,如：Chrysanthemum.jpg）</param>
        /// <returns>新文件名称（如：20150121112319327_52617.jpg）</returns>
        private string ResetFileNames(string fileName)
        {
            //计算随机种子
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            int seed = BitConverter.ToInt32(bytes, 0);
            //生成随机数
            Random random = new Random(seed);
            string strRandom = random.Next(10000, 99999).ToString();//5位随机数
            string[] arraryFilename;
            arraryFilename = fileName.Split('.');
            string filename = arraryFilename[0];
            return filename + strRandom + fileName.Substring(fileName.LastIndexOf('.'));
            // return DateTime.Now.ToString("yyyyMMddHHmmssfff") + strRandom + fileName.Substring(fileName.LastIndexOf('.'));
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
            string strRootPath = ConfigurationManager.AppSettings["imgFolderPath"].ToString() + "specialist\\";
            try
            {
                //验证父级文件夹，如果不存在 则创建 
                if (!Directory.Exists(strRootPath))
                {
                    Directory.CreateDirectory(strRootPath);
                }
                string PathImg = strRootPath + ImaName + " ";
                bmp.Save(PathImg);
                return ImaName;
            }

            catch (Exception ex)
            {
                //记录本地日志
                Log.Error("异常：" + ex.ToString());
                return null;
            }
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
        /// 删除文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="subFolder">文件夹名称</param>
        /// <param name="DeleteAll">是否删除所有文件，包括非空文件夹</param>
        public static void DeleteFieldFile(string fileName, string subFolder,bool DeleteAll = false)
        {
            if (DeleteAll)
            {
                string Path = ConfigurationManager.AppSettings["imgFolderPath"].ToString() + subFolder + "\\";
                 DirectoryInfo di = new DirectoryInfo(Path);
                 di.Delete(true);
            }
            else
            {
                string file = ConfigurationManager.AppSettings["imgFolderPath"].ToString() + subFolder + "\\" + fileName + " ";
                if (System.IO.File.Exists(file))
                {
                    System.IO.File.Delete(file);
                }
            }

           
        }
        /// <summary>
        /// 更改文件夹名称
        /// </summary>
        /// <param name="oldName">旧的文件夹名字</param>
        /// <param name="newName">新的文件夹名字</param>
        /// <param name="subFolder">存储这两个文件夹的文件夹名称</param>
        public static void ResetFileName(string oldName, string newName, string subFolder)
        {
            string Path = ConfigurationManager.AppSettings["imgFolderPath"].ToString() + subFolder + "\\";
            Directory.Move(Path + oldName, Path + newName);
        }


    }
}
