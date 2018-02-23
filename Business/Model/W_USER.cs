using System;
namespace Business.Model
{
    /// <summary>
    /// W_USER:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class W_USER
    {
        public W_USER()
        { }
        #region Model
        private int _cid;
        private string _dlm;
        private string _mm;
        private string _xm;
        private string _xb;
        private int _xtqx;
        private string _yx;
        private string _dh;
        private DateTime _cjsj;
        private DateTime _gxsj;
        private string _zt = "1";
        private string _yhlx;
        /// <summary>
        /// 自增编码
        /// </summary>
        public int cid
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public string dlm
        {
            set { _dlm = value; }
            get { return _dlm; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string mm
        {
            set { _mm = value; }
            get { return _mm; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string xm
        {
            set { _xm = value; }
            get { return _xm; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string xb
        {
            set { _xb = value; }
            get { return _xb; }
        }
        /// <summary>
        /// 系统权限
        /// </summary>
        public int xtqx
        {
            set { _xtqx = value; }
            get { return _xtqx; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string yx
        {
            set { _yx = value; }
            get { return _yx; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string dh
        {
            set { _dh = value; }
            get { return _dh; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime cjsj
        {
            set { _cjsj = value; }
            get { return _cjsj; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime gxsj
        {
            set { _gxsj = value; }
            get { return _gxsj; }
        }
        /// <summary>
        /// 状态：1.启用2.禁用
        /// </summary>
        public string zt
        {
            set { _zt = value; }
            get { return _zt; }
        }
        /// <summary>
        /// 用户类型：1.管理员2.....
        /// </summary>
        public string yhlx
        {
            set { _yhlx = value; }
            get { return _yhlx; }
        }
        #endregion Model

    }
}

