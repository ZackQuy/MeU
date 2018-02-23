/********************************************************************************
** 作者： 张青云
** 创始时间：2016-12-3
** 描述：分页参数类
————
** 修改人： 
** 修改时间： 
** 描述： 
———— 
*********************************************************************************/

namespace Business.Models
{
    public class SpPagingParam
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string tableName
        {
            set;
            get;
        }
        /// <summary>
        /// 排序字符
        /// </summary>
        public string sort
        {
            set;
            get;
        }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int pageSize
        {
            get;
            set;
        }
        /// <summary>
        /// 页索引号:从1开始
        /// </summary>
        public int page
        {
            get;
            set;
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        public string whereClause
        {
            get;
            set;
        }
        /// <summary>
        /// 字段字符串
        /// </summary>
        public string fields
        {
            get;
            set;
        }
    }
}
