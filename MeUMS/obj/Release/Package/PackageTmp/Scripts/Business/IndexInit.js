$(document).ready(function () {
    function emailCheck(obj, labelName) {
        var objName = eval("document.all." + obj);
        var pattern = /^0?1[3|4|5|7|8][0-9]\d{8}$/;
        if (!pattern.test(objName.value)) {
            alert("请输入正确的手机号");
            objName.focus();
            return false;
        }
        return true;
    };
    function check_email(email, hint) {
        if (!email) {
            hint.text('请输入手机号');
            return false;
        }

        var re = /^0?1[3|4|5|7|8][0-9]\d{8}$/;
        if (!re.test(email)) {
            hint.text('请输入正确的手机号');
            return false;
        }

        return true;
    };
    $('#form_emails').blur(function () {
        var email = $(this).val();
        var hint = $(this).next();
        if (!check_email(email, hint))
            return;
        //#region 提交到后台,根据返回数据进行下一步操作
        var param = { mobilephone: email};
        var datajson = JSON.stringify(param);
        /*
        $.ajax({
            url: 'http://120.24.6.229:2080/MeYouAPP/user/query.do?',
            data: 'DATA=' + datajson + '&type=2',
            type: 'post',
            processData: false,
            contentType: 'application/x-www-form-urlencoded',
            success:
            function loginRecive(msg) {

                var obj = msg;
                //alert(obj.message.toString());
                if (obj.msg.toString() == "查询成功") {
                    $('#email_error').html("号码已经注册！");
                }
                else {
                    $('#email_error').html("号码可用！");
                }

            }


        })
        */
      //  var param = { email: $(this).val(),type:"yx" };
      //  var c = new Sp.ActionRequest("login", Sp.ToJson(param), {
     //       fn: RegRecive
    //    });
    //    c.request({ url: 'ActionHandler.ashx', timeout: 120000 });


    });
    $('#form_username').blur(function () {
        var username = $(this).val();
        var hint = $(this).next();
        if (!check_username(username, hint))
            return;
        var param = { username: username };
        var datajson = JSON.stringify(param);
        $.ajax({
            url: 'http://120.24.6.229:2080/MeYouAPP/user/query.do?',
            data: 'DATA=' + datajson + '&type=2',
            type: 'post',
            processData: false,
            contentType: 'application/x-www-form-urlencoded',
            success:
            function loginRecive(msg) {

                var obj = msg;
                //alert(obj.message.toString());
                if (obj.msg.toString() == "查询成功") {
                  //  hint.text("用户名已经注册！");
                }
                else {
                   // hint.text("用户名可用！");
                }

            }


        })
    });
    function check_username(username, hint) {
        if (!username) {
            hint.text('请输入用户名');
            return false;
        }
        if (username.length < 2 || username.length > 30) {
            hint.text('用户名长度应为2~30个字符');
            return false;
        }

        var re = /^[a-z_A-Z0-9一-龥]+$/;
        if (!re.test(username)) {
            hint.text('用户名只能包含中文字符、英文字母、数字和下划线(_)');
            return false;
        }

        return true;
    }
    $('#form_userpwd').blur(function () {
        check_password($(this));
    });
    function check_password(input) {
        var password = $(input).val();
        var hint = $(input).next();
        if (password.length < 6 || password.length > 40) {
            hint.text('请输入6-40位密码');
            return false;
        } else {
            hint.text('');
            return true;
        }
    }

    $('#form_reuserpwd').blur(function () {
        check_repassword($(this));
    });

    function check_repassword(input) {
        var password = $(input).val();
        var hint = $(input).next();
        if (password != $('#form_userpwd').val()) {
            hint.text('请输入相同密码！');
            return false;
        } else {
            hint.text('');
            return true;
        }
    }


    function RegRecive(action, data, status)
    {
        var obj = eval('(' + data + ')');
        //alert(obj.message.toString());
        if (obj.success.toString() == "false") {
            
            $('#email_error').html(obj.message.toString());
        }
        else {
            $('#email_error').html(obj.message.toString());
        }
    }

})