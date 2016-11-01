<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mid.aspx.cs" Inherits="TonyBackground_mid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="js/jquery.js" type="text/javascript"></script>
    
    <script language="javascript">
        function expand()
        {            
            var cols = $(window.parent.document).find("#m").attr("cols");
            if (cols == "0,20,*")
            {
                $(window.parent.document).find("#m").attr("cols", "200,20,*");
            }
            else
            {
                $(window.parent.document).find("#m").attr("cols", "0,20,*");
            }
            
        }
    </script>
</head>
<body>
    <div style="background-color:#D7EAFE; height:600px; vertical-align:middle;padding:300px 0" >
    <img src="images/a1.jpg" style=" vertical-align:middle; cursor:pointer; " onclick="expand();"  />
    </div>
</body>
</html>
