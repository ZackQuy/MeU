/********************************************************************************
** 作者：  张青云
** 创始时间：2016年12月3日
** 修改人：
** 修改时间：
** 描述：常用操作方法汇总类
*********************************************************************************/
Sp.SpUtil = (function () {
    var _uniqueInstance;
    var _dataMask = null;
    function constructor() {
        return {
            LoadMask: function (controlId, tip, isclose) {
                /// <summary>
                /// 显示进度框
                /// </summary>
                /// <param name="controlId">承载进度条的容器,可以document.body、元素、DOM节点、id</param>
                /// <param name="tip">显示的信息</param>
                /// <param name="isclose">是否关闭其他进度条</param>
                if (true == isclose && null != _dataMask) {
                    _dataMask.destroy();
                    _dataMask = null;
                }
                _dataMask = new Ext.LoadMask(controlId, { msg: tip });
                _dataMask.show();
            },
            CloseMask: function () {
                /// <summary>
                ///关闭并销毁提示框(todo如果渲染多个进度条时，暂时只能销毁最后初始化的进度条)
                /// </summary>
                if (null != _dataMask) {
                    _dataMask.destroy();
                    _dataMask = null;
                }
            }
        };
    }
    return {
        GetInstance: function () {
            /// <summary>获取全局信息实例</summary>
            /// <returns type=""></returns>
            if (!_uniqueInstance) {
                _uniqueInstance = constructor();
            }
            return _uniqueInstance;
        }
    }
})();