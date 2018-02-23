using System;
namespace Business.Model
{
    /// <summary>
    /// W_USER:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ��������
        /// </summary>
        public int cid
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// ��¼��
        /// </summary>
        public string dlm
        {
            set { _dlm = value; }
            get { return _dlm; }
        }
        /// <summary>
        /// ��¼����
        /// </summary>
        public string mm
        {
            set { _mm = value; }
            get { return _mm; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string xm
        {
            set { _xm = value; }
            get { return _xm; }
        }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string xb
        {
            set { _xb = value; }
            get { return _xb; }
        }
        /// <summary>
        /// ϵͳȨ��
        /// </summary>
        public int xtqx
        {
            set { _xtqx = value; }
            get { return _xtqx; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string yx
        {
            set { _yx = value; }
            get { return _yx; }
        }
        /// <summary>
        /// �绰
        /// </summary>
        public string dh
        {
            set { _dh = value; }
            get { return _dh; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime cjsj
        {
            set { _cjsj = value; }
            get { return _cjsj; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime gxsj
        {
            set { _gxsj = value; }
            get { return _gxsj; }
        }
        /// <summary>
        /// ״̬��1.����2.����
        /// </summary>
        public string zt
        {
            set { _zt = value; }
            get { return _zt; }
        }
        /// <summary>
        /// �û����ͣ�1.����Ա2.....
        /// </summary>
        public string yhlx
        {
            set { _yhlx = value; }
            get { return _yhlx; }
        }
        #endregion Model

    }
}

