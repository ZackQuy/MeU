Ext.apply(Ext.form.VTypes, {
    pinteger: function (v) {
        /// <summary>
        /// 非负整数(正整数或0)
        /// </summary>
        /// <param name="v"></param>
        /// <returns type=""></returns>
        if ("0" == v.trim().toString()) {
            return true;
        }
        else {
            var r = /^[1-9]*[1-9][0-9]*$/;
            return r.test(v);
        }
    },
    //固定电话、传真
    phone: function (v) {
        var r = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/;
        return r.test(v);
    },
    //移动电话
    mobile: function (v) {
        //var r = /^((\(\d{2,3}\))|(\d{3}\-))?13\d{9}$/;
        var r = /^0{0,1}(1[34578][0-9]|15[7-9]|153|156|18[7-9])[0-9]{8}$/;
        return r.test(v);
    },
    //固定电话和移动电话
    phonemobile: function (v) {
        //        var r = /^(^(d{3,4}-)?d{7,8})$|(13[0-9]{9})$/;
        //var r = /^(\(\d{3,4}\)|\d{3,4}-|\s)?\d{7,14}$/;
        //var r = /^(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}$/;
        var r = /^(^(\d{3,4}-)?\d{7,8})$|(1[3,4,5,7,8][0-9]{9})$/;
        return r.test(v);
    },
    //电话区号
    areacode: function (v) {
        var r = /^0[1-9]\d{1,2}$/;
        return r.test(v);
    },
    //电话号码，7位或者8位
    phonecode: function (v) {
        var r = /^[1-9]\d{6,7}$/;
        return r.test(v);
    },
    //邮政编码
    zip: function (v) {
        var r = /^[1-9]\d{5}$/;
        return r.test(v);
    },
    mail: function (v) {
        /// <summary>
        /// 邮箱
        /// </summary>
        /// <param name="v"></param>        
        var r = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
        return r.test(v);
    },
    //简体中文
    chinese: function (v) {
        var r = /^[\u0391-\uFFE5]+$/;
        return r.test(v);
    },
    //非中文
    noChinese: function (v) {
        var r = /^[\u0391-\uFFE5]+$/;
        return !r.test(v);
    },
    numberLetter: function (v) {
        return true;
        //        var r = /^[0-9A-Za-z]{,20}$/;
        //        return r.test(v);
    },
    //货币
    currency: function (v) {
        var r = /^\d+(\.\d+)?$/;
        return r.test(v);
    },
    //QQ
    qq: function (v) {
        var r = /^[1-9]\d{4,9}$/;
        return r.test(v);
    },
    //实数
    double: function (v) {
        var r = /^[-\+]?\d+(\.\d+)?$/;
        return r.test(v);
    },
    //安全密码
    safe: function (v) {
        var r = /^(([A-Z]*|[a-z]*|\d*|[-_\~!@#\$%\^&\*\.\(\)\[\]\{\}<>\?\\\/\'\"]*)|.{0,5})$|\s/;
        return !r.test(v);
    },
    //验证码
    check: function (v) {
        if (getCookie("ValidateCode").toUpperCase() != v.toUpperCase()) {
            return false;
        }
        else {
            return true;
        }
    },
    //身份证号
    idcheck: function (sId) {
        var isIdCard15 = /^((1[1-5])|(2[1-3])|(3[1-7])|(4[1-6])|(5[0-4])|(6[1-5])|71|(8[12])|91)\d{4}((19)|(20))((\d{2}(0[13-9]|1[012])(0[1-9]|[12]\d|30))|(\d{2}(0[13578]|1[02])31)|(\d{2}02(0[1-9]|1\d|2[0-8]))|(([13579][26]|[2468][048]|0[48])0229))\d{3}(\d|X|x)$/;
        var isIdCard18 = /^((1[1-5])|(2[1-3])|(3[1-7])|(4[1-6])|(5[0-4])|(6[1-5])|71|(8[12])|91)\d{4}((\d{2}(0[13-9]|1[012])(0[1-9]|[12]\d|30))|(\d{2}(0[13578]|1[02])31)|(\d{2}02(0[1-9]|1\d|2[0-8]))|(([13579][26]|[2468][048]|0[48])0229))\d{3}$/;
        if (isIdCard15.test(sId) || isIdCard18.test(sId)) {
            return true;
        }
        else {
            return false;
        }
    },
    //组织机构代码
    ubocode: function (v) {
        var r = /^[A-Z0-9]{9}$/;
        return r.test(v);
    },
    ubocodeText:'请输入九位数字或大写字母组成的组织机构代码',
    pintegerText: '请输入正整数',
    phoneText: '请输入正确的电话或传真号码,格式如：0000-XXXXXXXX',
    phonecodeText: '请输入正确的电话或传真号码,格式如：XXXXXXXX',
    mobileText: '请输入正确的移动电话号码,格式如：1XXXXXXXXXX',
    areacodeText: '请输入正确的电话区号,格式如：0XXX或者0XX',
    zipText: '请输入正确的6位邮政编码!',
    mailText: '请输入有效的邮箱地址!',
    searchText: '请不要输入非法的搜索字符!',
    chineseText: '您只能在这里输入中文字符!',
    noChineseText: '您不能在这里输入中文字符!',
    currencyText: '请输入货币值!<br />格式如：1.00',
    qqText: '请输入合法的QQ号码!',
    doubleText: '请输入实数值,可带+/-号!',
    safeText: '请输入足够安全的字符,包含英文和数字货其他字符!',
    checkText: '验证码错误!',
    idcheckText: '请输入15位或者18的身份证号码',
    phonemobileText: '请输入正确的手机号1XXXXXXXXXX或者座机号0000-XXXXXXXX',
    numberLetterText: '只能输入数字和字母！'
});