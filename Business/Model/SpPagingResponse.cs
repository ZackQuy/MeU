/********************************************************************************
** 作者： 张青云
** 创始时间：2016-12-3
** 描述：查询结果类
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
using System.Data;

namespace Business.Models
{
    public class SpPagingResponse
    {
        /// <summary>
        /// 查询结果表
        /// </summary>
        public DataTable dataTable
        {
            set;
            get;
        }
        /// <summary>
        /// 操作是否成功,成功返回true,失败返回false
        /// </summary>
        public bool success
        {
            get;
            set;
        }
        /// <summary>
        /// 查询结果总记录数
        /// </summary>
        public int total
        {
            get;
            set;
        }
    }
}
