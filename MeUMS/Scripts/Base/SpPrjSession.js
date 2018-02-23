/// <reference path="SpBaseCommon.js" />
/********************************************************************************
** 作者： 张青云
** 创始时间：2016-12-3
** 修改人：
** 修改时间：
** 描述：用于存储全局信息的单例类。
*********************************************************************************/
Sp.PrjSession = (function () {
    var _uniqueInstance; // Private attribute that holds the single instance.
    var _userInfo;
    var _spMap;
    var _userAuth;
    var _workRegion;
    var _regions;
    function constructor() {
        // All of the normal singleton code goes here.
        return {
            setUserInfo: function (userInfo) {
                /// <summary>保存用户信息</summary>
                /// <param name="userInfo">用户信息类</param>
                _userInfo = userInfo;
            },
            getUserInfo: function () {
                /// <summary>获取用户信息</summary>
                /// <returns type="object">获取用户信息</returns>
                return _userInfo;
            },
            setUserAuth: function (userAuth) {
                /// <summary>
                /// 设置用户权限信息
                /// </summary>
                /// <param name="userAuth"></param>
                _userAuth = userAuth;
            },
            getUserAuth: function () {
                /// <summary>
                /// 获取用户权限信息
                /// </summary>
                /// <returns type=""></returns>
                return _userAuth;
            },
            setWorkRegion: function (workRegion) {
                /// <summary>保存工作区域</summary>
                /// <param name="workRegion"></param>
                _workRegion = workRegion;
            },
            getWorkRegion: function () {
                /// <summary>返回工作区域</summary>
                /// <returns type="Polygon">返回工作区域</returns>
                return _workRegion;
            },
            getIsHaveAuth: function (qx) {
                /// <summary>
                /// 根据权限名称遍历用户是否包含权限
                /// </summary>
                /// <param name="id"></param>
                var have = false;
                for (var i = 0; i < _userAuth.length; i++) {
                    if (_userAuth[i].QX == qx) {
                        have = true;
                        break;
                    }
                }
                return have;
            },
            getCategoryAuth: function () {
                /// <summary>
                /// 获取用户数据权限
                /// </summary>
                var auth = [];
                var auths = "";
                for (var i = 0; i < _userAuth.length; i++) {
                    if (_userAuth[i].QXLX == "3") {
                        auth.push("'" + _userAuth[i].QX + "'");
                    }
                }
                if (auth.length == 1094) {
                    auths = "all";
                } else {
                    auths = auth.join(",");
                }
                return auths;
            },
            setSpMap: function (spMap) {
                /// <summary>保存用户信息</summary>
                /// <param name="userInfo">用户信息类</param>
                _spMap = spMap;
            },
            getSpMap: function () {
                /// <summary>获取用户信息</summary>
                /// <returns type="object">获取用户信息</returns>
                return _spMap;
            },
            getAllRegions: function () {
                /// <summary>
                /// 获取所有行政区划数据
                /// </summary>
                return _regions;
            },
            setAllRegions: function (regions) {
                /// <summary>
                /// 设置现在区划数据
                /// </summary>
                _regions = regions;
            }
        };
    }

    return {
        getInstance: function () {
            /// <summary>获取全局信息实例</summary>
            /// <returns type=""></returns>
            if (!_uniqueInstance) {
                // Instantiate only if the instance doesn't exist.
                _uniqueInstance = constructor();
            }
            return _uniqueInstance;
        }
    }
})();