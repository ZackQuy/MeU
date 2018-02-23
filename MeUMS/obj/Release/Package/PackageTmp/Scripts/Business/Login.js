/// <reference path="C:\Users\Administrator\Desktop\MeU\MeUMS\MeUMS\Main.aspx" />
/// <reference path="C:\Users\Administrator\Desktop\MeU\MeUMS\MeUMS\Main.aspx" />
/********************************************************************************
 ** 作者： 张青云
 ** 创建时间：2016年12月3
 ** 修改人：
 ** 修改时间：
 ** 描述：登录操作
 *********************************************************************************/
$(function () {
    $("#divBtnLogin").bind("click", LoginFun);
    $("#sigin_submit").bind("click", RegFun);
    //InitLoginHover();
});
function LoginFun() {
    ///<summary>登录</summary>///
    var userName, password, strName, strPassword;
    userName = $("#login-name");
    password = $("#login-pwd");
    strName = userName.val().trim();
    strPassword = password.val().trim();
    if (strName == "") {
        $("#spanMsg").html("&nbsp&nbsp温馨提示：用户名不能为空！");
        userName.focus();
        return;
    }
    if (strPassword == "") {
        $("#spanMsg").html("&nbsp&nbsp温馨提示：密码不能为空！");
        password.focus();
        return;
    }
   // $('#divBtnLogin').css({ "background-color": "#b9bebe" });
    $('#divLoading').css({ "visibility": "visible" });
    $("#divBtnLogin").unbind("click", LoginFun);
    $("#divBtnLogin").unbind("mouseover").unbind("mouseleave");
    $("#divBtnLogin").val("正在登录...");
    $("#spanMsg").html("&nbsp&nbsp正在为您验证账户,请稍等！");
    //#region 提交到后台,根据返回数据进行下一步操作
    var param = { phone: strName, pwd: strPassword };
    var datajson = JSON.stringify(param);
    $.ajax({
        url: 'http://120.24.6.229:2080/MeYouAPP/user/query.do?',
        data: 'DATA=' + datajson + '&type=1',
        type: 'post',
        processData: false,
        contentType: 'application/x-www-form-urlencoded',
        success: 
        function loginRecive(msg) {
        var obj = msg;
        //alert(obj.message.toString());
        if (obj.msg.toString() == "查询成功")
        {
            $("#divBtnLogin").val("立即登录");
            $("#spanMsg").html("&nbsp&nbsp登录成功！");
            parent.$.XYTipsWindow.removeBox();
            document.getElementById("t_login").style.display = "none";
            document.getElementById("user_box").style.display = "block";
            document.getElementById("user_name").innerText = obj.data.userName.toString();
            var c_value = obj.data;
            AddCookie(obj.data.userName,c_value,1);

        }

    }


    });
    //var c = new Sp.ActionRequest("login", Sp.ToJson(param), { fn: loginRecive });
    //c.request({ url: 'ActionHandler.ashx', timeout: 120000 });
}
function loginRecive(action, data, status) {
    var obj = eval('(' + data + ')');
     //alert(obj.message.toString());
    if (obj.success.toString() == "true")
    {
        $("#divBtnLogin").val("立即登录");
        $("#spanMsg").html("&nbsp&nbsp登录成功！");
        var objdata = obj.data.toString().split(";");
        parent.$.XYTipsWindow.removeBox();
        document.getElementById("t_login").style.display = "none";
        document.getElementById("user_box").style.display = "block";
        document.getElementById("user_name").innerText=objdata[1].toString();
    }

}
function LoginFailed() {
    /// <summary>登录失败</summary>
    $("#divBtnLogin").bind("click", LoginFun);
    $('#divBtnLogin').css({ "background-color": "#01A7DE" });
    $('#divLoading').css({ "visibility": "hidden" });
    InitLoginHover();
}
function InitLoginHover() {
    ///<summary>注册鼠标移入移出事件</summary>///
    $("#divBtnLogin").bind("mouseover", function () {
        $("#divBtnLogin").css("background-color", "#DEB701");
    });
    $("#divBtnLogin").bind("mouseleave", function () {
        $("#divBtnLogin").css("background-color", "#01A7DE");
    });
}
function ResetUI() {
    ///<summary>页面变化事件</summary>///
    var mainRight, rightPostion, divTop, divLeft;
    mainRight = $(".main_right");
    rightPostion = mainRight.position();
    divLeft = rightPostion.left;
    divTop = rightPostion.top;
    $("#txtLoginName").css({ "position": "absolute", "left": divLeft + 165, "top": divTop + 90 });
    $("#txtPassword").css({ "position": "absolute", "left": divLeft + 165, "top": divTop + 171 });
    $("#spanMsg").css({ "position": "absolute", "left": divLeft + 79, "top": divTop + 235 });
    $("#divBtnLogin").css({ "position": "absolute", "left": divLeft + 79, "top": divTop + 275 });

};
function ScreenMax() {
    ///<summary>窗体最大化</summary>///
    try {
        if (window.screen) {
            var myW = screen.availWidth;
            var myH = screen.availHeight;
            window.moveTo(0, 0);
            window.resizeTo(myW, myH);
        }
    }
    catch (ex) {
        var a = 1;
    }
}
function EnterKeyDown() {
    ///<summary>回车登录</summary>///
    if (window.event.keyCode == 13) {
        $("#divBtnLogin").trigger("click");
    }
}

function RegFun() {
    ///<summary>注册</summary>///
    var userName, password, email, strName, strPassword, stremail; 
    password = $("#form_userpwd");
    email = $("#form_emails");
    strPassword = password.val().trim();
    stremail = email.val().trim();
    //#region 提交到后台,根据返回数据进行下一步操作
    var param = { pwd: strPassword, phone: stremail, lat: 0, lng: 0, address: "1", city: "1", mt: "web", ms: "1", mac: "1", version: "1" };
    var datajson = JSON.stringify(param);
    $.ajax({
        url: 'http://120.24.6.229:2080/MeYouAPP/user/write.do?',
        data: 'DATA=' + datajson + '&type=1',
        type: 'post',
        processData: false,
        contentType: 'application/x-www-form-urlencoded',
        success:
        function loginRecive(msg) {

            var obj = msg;
            if (obj.code.toString() == "-600") {
                document.getElementById("reg_error").innerText = obj.msg.toString();
            }
            if (obj.code.toString() == "100") {
                
                document.getElementById("reg_error").innerText = obj.msg.toString();
                document.getElementById("t_login").style.display = "none";
                document.getElementById("user_box").style.display = "block";
                document.getElementById("user_name").innerText = obj.data.username.toString();
                window.location.href = "../Main.aspx";
            }

        }


    });
    
}

function RegRecive(action, data, status) {
    var obj = eval('(' + data + ')');
    alert(obj.message.toString());
    if (obj.success.toString() == "true") {
        alert("注册用户成功！");

     //   $("#divBtnLogin").val("立即登录");
     //   $("#spanMsg").html("&nbsp&nbsp登录成功！");
     //   var objdata = obj.data.toString().split(";");
      //  parent.$.XYTipsWindow.removeBox();
      //  document.getElementById("t_login").style.display = "none";
      //  document.getElementById("user_box").style.display = "block";
       // document.getElementById("user_name").innerText = objdata[1].toString();
    }

}


