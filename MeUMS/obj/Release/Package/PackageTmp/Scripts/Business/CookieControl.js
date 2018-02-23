/********************************************************************************
 ** 作者： 张青云
 ** 创建时间：2017年1月19
 ** 修改人：
 ** 修改时间：
 ** 描述：cookie操作
 *********************************************************************************/
//$(window).load(function () {

//});
//Sp.Cookie = function () {
    
//};
//Sp.Cookie.prototype = {
function AddCookie(c_name, value, expiresHours) {
    var cookieString = c_name + "=" + escape(value);
    //判断是否设置过期时间,0代表关闭浏览器时失效
    if(expiresHours>0){ 
        var date=new Date(); 
        date.setTime(date.getTime+expiresHours*3600*1000); 
        cookieString=cookieString+"; expires="+date.toGMTString(); 
    } 
    document.cookie=cookieString; 
};
function EditCookie(c_name, value, expiresHours) {
    var cookieString = c_name + "=" + escape(value);
    //判断是否设置过期时间,0代表关闭浏览器时失效
    if (expiresHours > 0) {
        var date = new Date();
        date.setTime(date.getTime + expiresHours * 3600 * 1000); //单位是多少小时后失效
        cookieString = cookieString + "; expires=" + date.toGMTString();
    }
    document.cookie = cookieString;
};
function GetCookie (c_name) {
    var strCookie = document.cookie;
    var arrCookie = strCookie.split("; ");
    for (var i = 0; i < arrCookie.length; i++) {
        var arr = arrCookie[i].split("=");
        if (arr[0] == c_name) {
            return unescape(arr[1]);
        } else {
            return "";
        }
    }
};
function DeleteCookie(c_name) {
    var date = new Date();
    date.setTime(date.getTime() - 10000); //设定一个过去的时间即可
    document.cookie = c_name + "=v; expires=" + date.toGMTString();
};
//}
