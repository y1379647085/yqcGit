$(function()
{
    $("#loginLink").click(function()
    {
        var loginHtml=$("#loginHtml").html();
        showLayer(loginHtml,500,300,closeCallback);
        $("#loginSubmitBtn").click(function()
    {
        var username=$("input[name='username']").val();
        var password=$("input[name='password']").val();
        if(username==='imooc'&&password==='imooc')
        {
            alert("登录成功")
        }else
        {
            $(".error-msg").html("帐号或密码输入错误")
        }
    })
    })

    $('#regeLink').click(function(){
        var regeHtml=$('#regeHtml').html();
        showLayer(regeHtml,500,350,closeCallback);
        $('#regeSubmitBtn').click(function(){
            var username=$("input[name='username']").val();
            var password=$("input[name='password']").val();
            var repassword=$("input[name='repassword']").val();
            if(username==='imooc'&&password==='imooc'&&repassword=='imooc')
            {
                alert("注册成功");
            }else
            {
                $(".error-msg").html("帐号或密码输入错误")
            }
        })
    })

    function showLayer(html,width,height,closeCallback)
    {
        $('#layer-mask').show();
        $('#layer-pop').show();
        $('#layer-pop').css(
            {
                width:width,
                height:height
            }
        )
        $('#layer-content').html(html);
        $('#layer-close').click(function(){
            hidelayer();
            closeCallback();
        })       
    }
    // 隐藏弹出层
    function hidelayer()
    {
        $('#layer-mask').hide();
        $('#layer-pop').hide();
    }
    // 弹出层关闭回调函数
	function closeCallback(){
		$(".error-msg").html("");
	}	
})