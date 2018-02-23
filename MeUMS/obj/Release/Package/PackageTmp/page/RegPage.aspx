<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegPage.aspx.cs" Inherits="page_RegPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户注册</title>
    <link rel="stylesheet" href="../style/base.css"  />
    <link rel="stylesheet" href="../style/normalize.css"/>
    <link rel="stylesheet" href="../style/default.css"/>
    <link rel="stylesheet" href="../style/ideal-image-slider.css"/>
    <script src="../Scripts/Base/SpBaseCommonMin.js"></script>
    <script src="../JS/jquery-1.4.4.min.js"></script>
    <script src="../JS/jquery.XYTipsWindow.min.2.8.js"></script>
    <script src="../Scripts/Business/Login.js"></script>
    <script src="../Scripts/Business/IndexInit.js"></script>
    <script src="../Scripts/Business/CookieControl.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            var oDiv = document.getElementById("float");
            var H = 0;
            var Y = oDiv;
            while (Y) { H += Y.offsetTop; Y = Y.offsetParent };
            window.onscroll = function () {
                var s = document.body.scrollTop || document.documentElement.scrollTop;
                if (s > H) { oDiv.className = "t_menmue t_menmue2"; }
                else { oDiv.className = "t_menmue"; }
            };

        }
    </script>
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
        $("a[id='login']").click(function () {
            $.XYTipsWindow({
                ___showTitle: false,
                ___showBoxbg: false,
                ___content: "id:Login",
                ___width: "530",
                ___height: "355",
                ___drag: "___boxTitle",
                ___showbg: true,           
            });
        });
        $("#Close").click(function () {
            parent.$.XYTipsWindow.removeBox();
        });
        $("a[id='form_login']").click(function () {
            $.XYTipsWindow({
                ___showTitle: false,
                ___showBoxbg: false,
                ___content: "id:Login",
                ___width: "530",
                ___height: "355",
                ___drag: "___boxTitle",
                ___showbg: true,
            });
        });
    }) 
     </script>
</head>
<body>
        <!--页头-->
    <div style="width:100%; height:120px;background-color:#6fc9d3;">
        <div class ="t_title">
            <div class ="t_t_1">
                <div class ="t_logo">
                    <a href="../Main.aspx">
                        <img src="../pic/logo.png" />
                    </a>
                    
                </div>
                <div class ="t_show">
                    <div style=" margin-top:10px; margin-left:40px;">
                                                       <span style="color:#386d73; font:Arial, Helvetica, sans-serif; font-weight:bolder">唯心而行</span></div>
                                                       <div style=" margin-top:10px; margin-left:0px;">
                                                       <span style="color:#386d73; font:Arial, Helvetica, sans-serif; font-weight:bolder">无微不至</span>
                                                       </div>
                                                       <div style=" margin-top:10px; margin-left:20px">
                                                       <span style="color:#386d73; font:Arial, Helvetica, sans-serif; font-weight:bolder">享受身旁的每一缕阳光</span></div>
                </div>

            </div>
            <div class =" t_t_2">
                <div class ="t_search">
                    <span style="margin-top:5px;color:#FFF;font-weight:300; font-size:18px;">
                        搜索:
                    </span>
                    <input id="t_Search"  placeholder ="搜索地点/用户"  style=" line-height: 16px;width:110px;" type="text" />
                    
                </div>
                <div class ="t_login" id="t_login">
                    <div style="float:left" ><a href="RegPage.aspx" style="color:#FFF;font-weight:300; font-size:19px;cursor:pointer;" onmouseover ="this.style.cssText ='color:#168391;font-weight:300; font-size:19px;cursor:pointer;'" onmouseout="this.style.cssText='color:#FFF;font-weight:300; font-size:19px;cursor:pointer;'">注册</a></div>
                    <div style="float:left"><img style="height:22px;" src ="../pic/split.png" /></div>
                    <div style="float:left" ><a id ="login" style="color:#FFF;font-weight:300; font-size:19px;cursor:pointer;" onmouseover ="this.style.cssText ='color:#168391;font-weight:300; font-size:19px;cursor:pointer;'" onmouseout="this.style.cssText='color:#FFF;font-weight:300; font-size:19px;cursor:pointer;'">登录</a></div> 
                </div>
                <div id="user_box" class="user_boxs">
                    <div id="user_img_box" class="user_img_boxs">
                        <img id="user_img" style="width:32px;height:32px" src="../pic/m.png" />
                    </div>
                    <div id="user_name_box" class="user_name_boxs">
                        <span style="font-family:宋体;font-size:15px;color:white;margin-top:8px;float:left;margin-left:3px " id="user_name"></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <!--注册表单-->
        <div class="reg_center_align">
            <div class="reg_c_left">
                <div class="reg_c_l_signup">
                    <h1 class="reg_signup_title">创建你的新账户</h1>
                    <div class="reg_signup_form" id="reg_sign_forms">
                        <div class="reg_s_f_header">
                            <h2 class="reg_s_f_title">创建账户</h2>
                            <div class="reg_s_f_login">
                                或者
                                <a id="form_login">登录</a>
                            </div>
                        </div>
                        <div id="reg_form" class="reg_s_f_form">
                            <p class="reg_form_lable">
                                <label>电话号码：</label>
                            </p>
                            <div class="reg_form_text">
                                <input type="text" name="form_email" id="form_emails" />
                                <span id="email_error"></span>
                            </div>
                            <%--    
                            <p class="reg_form_lable">
                                <label>用户名：</label>
                            </p>
                            <div class="reg_form_text">
                                <input type="text" name="form_userna" id="form_username" />
                                <span id="username_error"></span>
                            </div>--%>
                            <p class="reg_form_lable">
                                <label>密码：</label>
                            </p>
                            <div class="reg_form_text">
                                <input type="password" name="form_uspwd" id="form_userpwd" />
                                <span id="userpwd_error"></span>
                            </div>
                            <p class="reg_form_lable">
                                <label>重复密码：</label>
                            </p>
                            <div class="reg_form_text">
                                <input type="password" name="form_uspwd" id="form_reuserpwd" />
                                <span id="reuserpwd_error"></span>
                            </div>
                            <p class="reg_form_lable">
                                <label>验证码：</label>
                            </p>
                            <div style="width:300px;">
                              <div class ="reg_form_pictext">
                                <input type="text" name="form_email" id="form_pic" />
                             </div>
                                <img style="height: 35px; width: 94px;vertical-align: bottom; border: 1px solid #e7e7e7; border-left: none; float:left;margin-top:0px;" id="lo-mg" src ="../pic/captcha.jpg"  />
                           </div>
                            <p class="terms">
                                单击注册表示同意我们的服务条款
                                <a style="color:#4abdcc" href="">服务条款</a>
                            </p>
                            <p style="margin-top:25px;float:left">
                                <input style="background: #4abdcc;border: 0px solid #f7f7f7;color: #ffffff; cursor: pointer;font-size: 14px; height: 32px;text-shadow: 1px 1px 1px #5c5c5c; width: 96px;" id="sigin_submit" type="button" value="注册" />
                                <span id="reg_error" style="color: red;font-size: 12px;"></span>
                            </p>
                            
                        </div>
                    </div>
                    <div class="reg_c_l_right">
                    <img src="../img/f_left.png" />
                    </div>
                </div>
            </div>
            <div class="reg_c_right">
                <img src="../img/f_right.png" />
            </div>

        </div>
        <div class="reg_clear_both">

        </div>

    <div class="Foot">
        <div class ="F_bgpic">
            <div class ="F_ptop">
                <div class ="F_pt_L">
                    <div>
                        <dl>
                            <dt>产品服务</dt>
                            <dd><a href ="####">Me游APP下载</a></dd>
                            <dd><a href ="####">Me游APP功能</a></dd>
                            <dd><a href ="####">Me游地图定制</a></dd>
                            <dd><a href ="####">Me游加盟</a></dd>
                            <dd><a href ="####">Me游注册</a></dd>
                        </dl>
                    </div>
                    <div>
                        <dl>
                            <dt>关于Me游</dt>
                            <dd><a href ="####">公司介绍</a></dd>
                            <dd><a href ="####">公司动态</a></dd>
                            <dd><a href ="####">Me游团队</a></dd>
                            <dd><a href ="####">问题帮助</a></dd>
                            <dd><a href ="####">联系我们</a></dd>

                        </dl>

                    </div>
                    <div>
                        <dl>
                            <dt>帮助反馈</dt>
                            <dd><a href ="####">APP使用帮助</a></dd>
                            <dd><a href ="####">APP问题反馈</a></dd>
                            <dd><a href ="####">官网问题反馈</a></dd>
                            <dd><a href ="####">客服反馈</a></dd>
                            

                        </dl>

                    </div>
                    <div>
                        <dl>
                            <dt>友情链接</dt>
                            <dd><a href ="####">中国旅游网</a></dd>
                            <dd><a href ="####">去哪儿网</a></dd>
                            <dd><a href ="####">面包旅游</a></dd>
                            

                        </dl>

                    </div>
                
                </div>
                <div class ="F_pt_C">

                </div>
                <div class ="F_pt_R">

                </div>
            </div>
            <div class ="F_pbottom">

            </div>
        </div>

    </div>
        <!--用户信息-->
    <div id="Login" class ="Login">
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
                    <a href="RegPage.aspx">
                        <span>注册</span>
                    </a>
                </div>
                <div class ="L_content_r_con_text">
                    <div class ="L_content_r_con">
                    <input id="login-name" placeholder="电话" name="username" style="outline:none;border:none;text-indent:15px;font-size:15px;" type="text" />
                    </div>
                </div>
                <div class ="L_content_r_con_text">
                    <div class ="L_content_r_con">
                    <input id="login-pwd" placeholder="密码" name="pwd" style="outline:none;border:none;text-indent:15px;font-size:15px;" type="password" />
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
                    <input id="divBtnLogin" type ="submit" value ="立即登录"/>
                    <span style="margin-top:5px; float:left;color:red" id="spanMsg"> &nbsp&nbsp温馨提示：请准确填写账户信息</span>
                </div>
                
            </div>
           
        </div>
    
    </div>
    
</body>
</html>
