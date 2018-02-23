<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="page_LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href ="../style/base.css"  />
        <style type="text/css">
        a:link {
            text-decoration: none; 
        }
        a:visited {
        text-decoration: none; 
        }
        a:hover {
            text-decoration: none; 
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Close").click(function () {
                $.XYTipsWindow.removeBox();
            });
        })
    </script>
</head>
<body>
    
    <div class ="Login">
        <div class ="L_top">
            <div style ="float:left">
            <span>
                登录
            </span>
            </div>
            <div class ="L_t_close">
                <div id ="Close">

                </div>
            </div>
        </div>
        <div class ="L_line">

        </div>
        <div class ="L_content">
            <div class ="L_content_l">
                <div style ="color:#5c5c5c;font-size:19px;font-family: STSong;font-stretch:initial;margin-top:50px;margin-left:37px">
                    <span >
                        从社交网络登录
                    </span>
                </div>
                <div class ="L_con_l_pic">
                    <div class ="L_con_l_pic_div">
                        <div class ="L_con_l_p_pic">
                            <div id="" class ="L_con_l_p_wxPic">

                            </div>
                        </div>
                        <div class ="L_con_l_p_picWord">
                            <span>微信</span>
                        </div>

                    </div>
                    <div class ="L_con_l_pic_div">
                        <div class ="L_con_l_p_pic">
                            <div id="" class ="L_con_l_p_QQPic">

                            </div>
                        </div>
                        <div class ="L_con_l_p_picWord">
                            <span>QQ</span>
                        </div>
                    </div>
                    <div class ="L_con_l_pic_div">
                        <div class ="L_con_l_p_pic">
                            <div id="" class ="L_con_l_p_xinlangPic">

                            </div>
                        </div>
                        <div class ="L_con_l_p_picWord">
                            <span>微博</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class ="L_content_l2">

            </div>
          
            <div class =" L_content_r">
                <div class ="L_content_r_top">
                    <a href="######">
                        <span>注册</span>
                    </a>
                </div>
                <div class ="L_content_r_con_text">
                    <div class ="L_content_r_con">
                    <input id="login-name" placeholder="邮箱/用户名" name="username" style="outline:none;border:none;text-indent:15px;font-size:15px;" type="text" />
                    </div>
                </div>
                <div class ="L_content_r_con_text">
                    <div class ="L_content_r_con">
                    <input id="login-pwd" placeholder="密码" name="pwd" style="outline:none;border:none;text-indent:15px;font-size:15px;" type="text" />
                    </div>
                </div>
                <div class ="L_content_r_con_text">
                    <div class ="L_content_r_captcha">
                    <input id="login-captcha" placeholder="请输入验证码" name="captcha" style="outline:none;border:none;text-indent:15px;font-size:15px;" type="text" />
                    </div>
                    <img id="login-captcha-img" src ="../pic/captcha.jpg"  />
                </div>
                <div class ="L_content_r_con_notice">
                    <label>
                        <input name ="remember-me" type ="checkbox" />
                        记住我的登录状态
                    </label>
                </div>
                <div class ="L_content_r_con_btn">
                    <input type ="submit" value ="立即登录"/>
                </div>
            </div>
           
        </div>
    
    </div>
    
</body>
</html>
