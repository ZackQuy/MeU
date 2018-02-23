<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Me游导航主页</title>
    <link rel="stylesheet" href="style/base.css"  />
    <link rel="stylesheet" href="style/normalize.css"/>
    <link rel="stylesheet" href="style/default.css"/>
    <link rel="stylesheet" href="style/ideal-image-slider.css"/>
    <script src="Scripts/Base/SpBaseCommonMin.js"></script>
    <script src="JS/jquery-1.4.4.min.js"></script>
    <script src="JS/jquery.XYTipsWindow.min.2.8.js"></script>
    <script src="Scripts/Business/Login.js"></script>
    <script src="Scripts/Business/CookieControl.js"></script>
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
    }) 
     </script>
    



</head>
<body class="body">
    <form id="form1" runat="server">
        <!--页头-->
    <div class="Top">
        <div class ="t_title">
            <div class ="t_t_1">
                <div class ="t_logo">
                    <a href="../Main.aspx">
                        <img src="pic/logo.png" />
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
                    <div style="float:left" ><a href="page/RegPage.aspx" style="color:#FFF;font-weight:300; font-size:19px;cursor:pointer;" onmouseover ="this.style.cssText ='color:#168391;font-weight:300; font-size:19px;cursor:pointer;'" onmouseout="this.style.cssText='color:#FFF;font-weight:300; font-size:19px;cursor:pointer;'">注册</a></div>
                    <div style="float:left"><img style="height:22px;" src ="pic/split.png" /></div>
                    <div style="float:left" ><a id ="login" style="color:#FFF;font-weight:300; font-size:19px;cursor:pointer;" onmouseover ="this.style.cssText ='color:#168391;font-weight:300; font-size:19px;cursor:pointer;'" onmouseout="this.style.cssText='color:#FFF;font-weight:300; font-size:19px;cursor:pointer;'">登录</a></div> 
                </div>
                <div id="user_box" class="user_boxs">
                    <div id="user_img_box" class="user_img_boxs">
                        <img id="user_img" style="width:32px;height:32px" src="pic/m.png" />
                    </div>
                    <div id="user_name_box" class="user_name_boxs">
                        <span style="font-family:宋体;font-size:15px;color:white;margin-top:8px;float:left;margin-left:3px " id="user_name"></span>
                    </div>
                </div>


            </div>
        </div>

          <div id="float" class="t_menmue">
                                    <div style=" width:840px; margin-left:50%;left:-420px; position:absolute">
                                              <div class="t_m_btn">
                                                  <a href="Main.aspx">
                                                       <span style="cursor:pointer;">首页</span>
                                                  </a>
                              </div>
                                              <div class="t_m_btn">
                                                  <a>
                                                       <span style="cursor:pointer;" >热门游记</span>
                                                  </a>
                                              </div>
                                              <div class="t_m_btn">
                                                  <a>
                                                       <span style="cursor:pointer;" >目的地</span>
                                                  </a>
                                              </div>
                                              <div class="t_m_btn">
                                                  <a>
                                                       <span style="cursor:pointer;" >旅游攻略</span>
                                                  </a>
                                              </div>
                                              <div class="t_m_btn">
                                                  <a>
                                                       <span style="cursor:pointer;" >新闻动态</span>
                                                  </a>
                                              </div>
                                              <div class="t_m_btn">
                                                  <a>
                                                       <span style="cursor:pointer;" >关于Me游</span>
                                                  </a>
                                              </div>
                                              <div class="t_m_btn">
                                                  <a>
                                                       <span style="cursor:pointer;" >联系我们</span>
                                                  </a>
                                              </div>
                                    </div>
                                    
                        </div>
    
    </div>
        <!--图片滑动-->
    <div class="PicSlild">
        
            <div id="slider" style="cursor:pointer" >
                                  <a href="Main.aspx">
                                      <img src ="img/appDown.png" />
                                  </a>
                                    <a>
                                       <img data-src="pic/sence1.png"  />
                                    </a>
	                               	<a>
                                       <img data-src="pic/sence2.png"  />
	                               	</a>
	                              	<a>
                                       <img data-src="pic/sence3.png"   />
	                              	</a>
	                             	<a>
                                       <img data-src="pic/sence4.png"   />
	                             	</a>
	                            	
                                   
                                    
	                </div>
        
    </div>
        <!--内容填充-->
    <div class =" C_Trip">
        <div class ="C_T_title">
            <div class ="C_T_name">
                
                    <span style="color:#555555; font-size:28px; font-weight:bold">旅游攻略</span>
                
            </div>
            <div class ="C_T_more">
                <a href ="####">
                    <span style="color:#686868; font-size:26px; font-weight:bold;cursor:pointer;">更多>></span>
                </a>
            </div>
        </div>
        <div class ="C_T_Content">
            <div class ="c_t_conPlan1">
                <div class ="c_t_cP1">
                    <div class ="c_t_cP2">
                        <span>大相岭</span>
                    </div>
                    <div class ="c_t_cPimg">
                        <a href ="####">
                            <img src ="img/Plan1.png" />
                        </a>
                    </div>
                </div>

                <div class ="c_t_cP1">
                    <div class ="c_t_cP2">
                        <span>嘉定坊</span>
                    </div>
                    <div class ="c_t_cPimg">
                        <a href ="####">
                            <img src ="img/Plan2.png" />
                        </a>
                    </div>
                </div>

                <div class ="c_t_cP1">
                    <div class ="c_t_cP2">
                        <span>锦里</span>
                    </div>
                    <div class ="c_t_cPimg">
                        <a href ="####">
                            <img src ="img/Plan3.png" />
                        </a>
                    </div>
                </div>

                <div class ="c_t_cP1">
                    <div class ="c_t_cP2">
                        <span>嘉州长卷</span>
                    </div>
                    <div class ="c_t_cPimg">
                        <a href ="####">
                            <img src ="img/Plan4.png" />
                        </a>
                    </div>
                </div>
            </div>
            <div class ="c_t_conPlan2">
                <div class ="c_t_cP1">
                    <div class ="c_t_cP2">
                        <span>峨眉</span>
                    </div>
                    <div class ="c_t_cPimg">
                        <a href ="####">
                            <img src ="img/Plan5.png" />
                        </a>
                    </div>
                </div>
                <div class ="c_t_cP1">
                    <div class ="c_t_cP2">
                        <span>嘉定南路</span>
                    </div>
                    <div class ="c_t_cPimg">
                        <a href ="####">
                            <img src ="img/Plan6.png" />
                        </a>
                    </div>
                </div>
                <div class ="c_t_cP1">
                    <div class ="c_t_cP2">
                        <span>大佛禅院</span>
                    </div>
                    <div class ="c_t_cPimg">
                        <a href ="####">
                            <img src ="img/Plan7.png" />
                        </a>
                    </div>
                </div>
                <div class ="c_t_cP1">
                    <div class ="c_t_cP2">
                        <span>街子古镇</span>
                    </div>
                    <div class ="c_t_cPimg">
                        <a href ="####">
                            <img src ="img/Plan8.png" />
                        </a>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div class ="C_Trip">
        <div class ="C_T_title">
            <div class ="C_T_name">
                
                    <span style="color:#555555; font-size:28px; font-weight:bold">热门游记</span>
                
            </div>
            <div class ="C_T_more">
                <a href ="####">
                    <span style="color:#686868; font-size:26px; font-weight:bold;cursor:pointer;">更多>></span>
                </a>
            </div>
        </div>
        <div class ="C_user_content">
            <div class ="C_user_c1">
                <div class ="C_user_c_new">
                    <div class ="C_user_c_img">
                        
                            <img src ="img/Trip1.png" />
                        
                    </div>
                    <div class="C_user_c_txt">
                        <div class ="C_user_c_theme">
                            <div class ="C_user_c_word">
                                
                                    <span>银杏下的秋韵</span>
                                
                            </div>
                        </div>
                        <div class =" C_user_c_adic">
                            <div class ="C_user_c_adress">
                                <div class ="C_user_c_swordt">
                                    <span>2014.10.15</span>
                                </div>
                                <div class ="C_user_c_swordp">
                                    <span>四川.乐山</span>
                                </div>
                            </div>
                            <div class ="C_user_c_ico">
                                <div class ="C_user_c_icopic">
                                    <img src="img/ico1.png"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class ="C_user_c_new">
                    <div class ="C_user_c_img">
                        
                            <img src ="img/Trip2.png" />
                        
                    </div>
                    <div class="C_user_c_txt">
                        <div class ="C_user_c_theme">
                            <div class ="C_user_c_word">
                                
                                    <span>停车坐爱枫林晚</span>
                                
                            </div>
                        </div>
                        <div class =" C_user_c_adic">
                            <div class ="C_user_c_adress">
                                <div class ="C_user_c_swordt">
                                    <span>2014.10.22</span>
                                </div>
                                <div class ="C_user_c_swordp">
                                    <span>四川.乐山</span>
                                </div>
                            </div>
                            <div class ="C_user_c_ico">
                                <div class ="C_user_c_icopic">
                                    <img src="img/ico2.png"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class ="C_user_c_new">
                    <div class ="C_user_c_img">
                        
                            <img src ="img/Trip3.png" />
                        
                    </div>
                    <div class="C_user_c_txt">
                        <div class ="C_user_c_theme">
                            <div class ="C_user_c_word">
                                
                                    <span>躲在角落的蔷薇</span>
                                
                            </div>
                        </div>
                        <div class =" C_user_c_adic">
                            <div class ="C_user_c_adress">
                                <div class ="C_user_c_swordt">
                                    <span>2014.7.22</span>
                                </div>
                                <div class ="C_user_c_swordp">
                                    <span>四川.乐山</span>
                                </div>
                            </div>
                            <div class ="C_user_c_ico">
                                <div class ="C_user_c_icopic">
                                    <img src="img/ico3.png"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class ="C_user_c_new">
                    <div class ="C_user_c_img">
                        
                            <img src ="img/Trip4.png" />
                        
                    </div>
                    <div class="C_user_c_txt">
                        <div class ="C_user_c_theme">
                            <div class ="C_user_c_word">
                                
                                    <span>核聚变博物馆</span>
                                
                            </div>
                        </div>
                        <div class =" C_user_c_adic">
                            <div class ="C_user_c_adress">
                                <div class ="C_user_c_swordt">
                                    <span>2014.7.16</span>
                                </div>
                                <div class ="C_user_c_swordp">
                                    <span>四川.乐山</span>
                                </div>
                            </div>
                            <div class ="C_user_c_ico">
                                <div class ="C_user_c_icopic">
                                    <img src="img/ico4.png"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                 <div class ="C_user_c_new">
                    <div class ="C_user_c_img">
                        
                            <img src ="img/Trip1.png" />
                        
                    </div>
                    <div class="C_user_c_txt">
                        <div class ="C_user_c_theme">
                            <div class ="C_user_c_word">
                                
                                    <span>银杏下的秋韵</span>
                                
                            </div>
                        </div>
                        <div class =" C_user_c_adic">
                            <div class ="C_user_c_adress">
                                <div class ="C_user_c_swordt">
                                    <span>2014.10.15</span>
                                </div>
                                <div class ="C_user_c_swordp">
                                    <span>四川.乐山</span>
                                </div>
                            </div>
                            <div class ="C_user_c_ico">
                                <div class ="C_user_c_icopic">
                                    <img src="img/ico1.png"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class ="C_user_c_new">
                    <div class ="C_user_c_img">
                        
                            <img src ="img/Trip2.png" />
                        
                    </div>
                    <div class="C_user_c_txt">
                        <div class ="C_user_c_theme">
                            <div class ="C_user_c_word">
                                
                                    <span>停车坐爱枫林晚</span>
                                
                            </div>
                        </div>
                        <div class =" C_user_c_adic">
                            <div class ="C_user_c_adress">
                                <div class ="C_user_c_swordt">
                                    <span>2014.10.22</span>
                                </div>
                                <div class ="C_user_c_swordp">
                                    <span>四川.乐山</span>
                                </div>
                            </div>
                            <div class ="C_user_c_ico">
                                <div class ="C_user_c_icopic">
                                    <img src="img/ico2.png"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class ="C_user_c_new">
                    <div class ="C_user_c_img">
                        
                            <img src ="img/Trip3.png" />
                        
                    </div>
                    <div class="C_user_c_txt">
                        <div class ="C_user_c_theme">
                            <div class ="C_user_c_word">
                                
                                    <span>躲在角落的蔷薇</span>
                                
                            </div>
                        </div>
                        <div class =" C_user_c_adic">
                            <div class ="C_user_c_adress">
                                <div class ="C_user_c_swordt">
                                    <span>2014.7.22</span>
                                </div>
                                <div class ="C_user_c_swordp">
                                    <span>四川.乐山</span>
                                </div>
                            </div>
                            <div class ="C_user_c_ico">
                                <div class ="C_user_c_icopic">
                                    <img src="img/ico3.png"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class ="C_user_c_new">
                    <div class ="C_user_c_img">
                        
                            <img src ="img/Trip4.png" />
                        
                    </div>
                    <div class="C_user_c_txt">
                        <div class ="C_user_c_theme">
                            <div class ="C_user_c_word">
                                
                                    <span>核聚变博物馆</span>
                                
                            </div>
                        </div>
                        <div class =" C_user_c_adic">
                            <div class ="C_user_c_adress">
                                <div class ="C_user_c_swordt">
                                    <span>2014.7.16</span>
                                </div>
                                <div class ="C_user_c_swordp">
                                    <span>四川.乐山</span>
                                </div>
                            </div>
                            <div class ="C_user_c_ico">
                                <div class ="C_user_c_icopic">
                                    <img src="img/ico4.png"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    </div>

    <div class="Content">
        <div class ="C_pic">
            <img src ="img/Backgrond.png" />
        </div>

    </div>

    <div style ="width:100%;height:560px;background-color:#019877;margin:0 auto;">
        <div class ="C_pic2">
            <a href ="###" class ="C_pic_DownApp">
                <img src ="img/Btn_Down.png" />
            </a>
        </div>
      
    </div>

    <div class="Content">
        <div class ="C_pic">
            <img src ="img/Backg3.png" />
        </div>

    </div>
       

         <!--页脚-->
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
                    <a href="page/RegPage.aspx">
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


    </form>
    <script src="JS/ideal-image-slider.js"></script>
    <script src="JS/iis-captions.js"></script>
    <script src="JS/iis-bullet-nav.js"></script>
    <script>
        var slider = new IdealImageSlider.Slider('#slider');
        slider.addBulletNav();
        slider.start();
	</script>
</body>
</html>
