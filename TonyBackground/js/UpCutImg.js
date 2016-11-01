function ajaxFileUpload(field)
{
    if ($("#" + field + "_file").val() == "")
    {
        return false;
    }
    var fileName = $("#" + field + "_file").val();
    var ext = fileName.split('.')[fileName.split('.').length - 1];    
    var allowext = $("#" + field + "_allowExt").val();
    var allows = allowext.split(',');
    var allow = false;
    for (var i = 0; i < allows.length; i++)
    {
        if (allows[i] == ext)
        {
            allow = true;
            break;
        }
    }
    if (!allow)
    {
        alert("您上传的文件为" + ext + ",请上传 " + allowext + " 格式的文件");
        return false;
    }

    $("#" + field + "_process").show();
    $("#" + field + "_file").hide();
    $.ajaxFileUpload
	    (
		    {
		        url: 'doUpload.aspx',
		        secureuri: false,
		        fileElementId: field + '_file',
		        dataType: 'json',
		        success: function(data, status)
		        {
		            if (typeof (data.error) != 'undefined')
		            {
		                if (data.error != '')
		                {
		                    alert(data.error);
		                } else
		                {
		                    //alert(data.msg);
		                    //未图片设置
		                    $("#" + field + "_img").attr("src", "../uploads/" + data.msg);
		                    $("#" + field + "_value").val(data.msg);
		                    $("#" + field + "_path").val(data.msg);
		                    $("#" + field + "_imgW").val(data.width);
		                    $("#" + field + "_imgH").val(data.height);
		                    $("#" + field + "_process").hide();
		                    $("#" + field + "_file").show();
		                    $("#" + field + "_img").show();
		                    //$("#" + field + "_up").hide();

		                    var nH = parseInt($("#" + field + "_needH"));
		                    var nW = parseInt($("#" + field + "_needW"));

		                    if ((parseInt($("#" + field + "_needH").val()) < parseInt(data.height) || parseInt($("#" + field + "_needW").val()) < parseInt(data.width)) && (nH>0 && nW>0))
		                    {
		                        $("#" + field + "_cut").show();
		                    }
		                    //未文件设置
		                    $("#" + field + "_doc").html("点击查看");
		                    $("#" + field + "_doc").attr("href", "../uploads/" + data.msg);
		                    $("#" + field + "_del").show();
		                }
		            }
		        },
		        error: function(data, status, e)
		        {
		            alert(e);
		        }
		    }
	    )
    return false;
}
function initUpload(filed)
{
    $("#" + filed + "_img").width($("#" + filed + "_needW").val());
    $("#" + filed + "_img").height($("#" + filed + "_needH").val());
    $("#" + filed + "_img").lightBox({ fixedNavigation: true });

    var needH = parseInt($("#" + filed + "_needH").val());
    var needW = parseInt($("#" + filed + "_needW").val());
    if (needH <= 0 || needW < 0)
    {
        $("#" + filed + "_cut").hide();
    }
    var showW = parseInt($("#" + filed + "_img").width()) + 100;
    if (showW > 800) { showW = 800; }
    if (showW < 420) {showW = 420;}
    var showH = parseInt($("#" + filed + "_img").height()) + 200;
    if (showH > 650) { showH = 650; }
    if (showH < 460) {showH = 460;}

    if (parseInt($("#" + filed + "_img").width()) > 100 || parseInt($("#" + filed + "_img").height()) > 100)
    {
        $("#" + filed + "_img").width(parseInt(parseInt($("#" + filed + "_img").width()) / 2));
        $("#" + filed + "_img").height(parseInt(parseInt($("#" + filed + "_img").height()) / 2));
    }
    if (parseInt($("#" + filed + "_img").width()) < 30 || parseInt($("#" + filed + "_img").height()) < 30)
    {
        $("#" + filed + "_img").width(50);
        $("#" + filed + "_img").height(50);
    }

    if ($("#" + filed + "_value").val() == "")
    {
        $("#" + filed + "_del").hide();
    }
    else
    {
        $("#" + filed + "_del").show();
    }
    $("#" + filed + "_del").click(function()
    {
        $("#" + filed + "_value").val("");
        $("#" + filed + "_img").hide();
        $("#" + filed + "_doc").hide();
        $("#" + filed + "_del").hide();
        return false;
    });

    $("#" + filed + "_file").change(function()
    {
        if ($(this).val() == "")
        {
            $("#" + filed + "_up").hide();
        }
        else
        {
            $("#" + filed + "_up").show();
        }
    });

    $("#" + filed + "_cut").click(function()
    {
        $.blockUI({
            message: $("#uploaddiv"),
            css:
                    {
                        top: ($(window).height() - showH) / 2 + 'px',
                        left: ($(window).width() - showW) / 2 + 'px',
                        width: showW+'px',
                        height: showH+'px',
                        textAlign: 'left'
                    }
        });
        $("#frame").attr("src", "cut.aspx?w=" + $("#" + filed + "_needW").val() + "&h=" + $("#" + filed + "_needH").val() + "&path=" + $("#" + filed + "_path").val() + "&name=" + filed + "#" + Math.random());
    });
}