using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///UploadImgField 的摘要说明
/// </summary>
public class UploadImgField : WebControl
{
    private Panel panel = new Panel();
    public Panel Panel
    {
        get { return this.panel; }
    }
    public UploadImgField(Column c, string v)
	{
        this.ID = c.ColumnName;

        this.panel = Builder.GetPanel(c);
        TableCell cell2 = ((System.Web.UI.WebControls.Table)panel.Controls[0]).Rows[0].Cells[1];
        string html = string.Empty;

        if (!string.IsNullOrEmpty(v))
        {
            html += "<img class='uploadImg' id=\"" + c.ColumnName + "_img\" style=\"cursor:pointer;\" height=\"30\" src=\"../uploads/" + v + "\" />";
        }
        else
        {
            html += "<img class='uploadImg' id=\"" + c.ColumnName + "_img\" style=\"display: none;cursor:pointer;\" height=\"30\" />";
        }
        html += "<img id='" + c.ColumnName + "_process' src='images/process.gif' style='display:none;' />";
        html += "<input class='uploadImgFile' id=\"" + c.ColumnName + "_file\" type=\"file\" name=\"" + c.ColumnName + "_file\">";
        html += "<input class='uploadImgButton' id=\"" + c.ColumnName + "_up\" type=\"button\" value=\"上传\" onclick=\"return ajaxFileUpload('" + c.ColumnName + "');\" />";
        html += "<input class='uploadImgButton' id=\"" + c.ColumnName + "_cut\" type=\"button\" value=\"剪切\" />";
        html += "<input id=\"" + c.ColumnName + "_path\" type=\"hidden\" value=\"../uploads/" + v + "\" />";
        html += "<input id=\"" + c.ColumnName + "_allowExt\" type=\"hidden\" value=\"" + c.AllowExt + "\" />";
        html += "<input id=\"" + c.ColumnName + "_needH\" type=\"hidden\" value=\"" + c.ImgHeight + "\" />";
        html += "<input id=\"" + c.ColumnName + "_needW\" type=\"hidden\" value=\"" + c.ImgWidth + "\" />";        
        html += "<input id=\"" + c.ColumnName + "_imgH\" type=\"hidden\" />";
        html += "<input id=\"" + c.ColumnName + "_imgW\" type=\"hidden\" />";
        if (!string.IsNullOrEmpty(v))
        {
            html += "<input id=\"" + c.ColumnName + "_value\" name=\"" + c.ColumnName + "_value\" type=\"hidden\" value=\"" + v + "\" />";
        }
        else
        {
            html += "<input id=\"" + c.ColumnName + "_value\" name=\"" + c.ColumnName + "_value\" type=\"hidden\" />";
        }
        html += "<a id='" + c.ColumnName + "_del' href='#'>删除</a>";
        Literal lit = Builder.GetHTML(c, html, 0);
        Literal script = Builder.GetScirpt(c, "$(document).ready(function() {initUpload(\""+c.ColumnName+"\"); });");
        cell2.Controls.Add(lit);
        cell2.Controls.Add(script);
	}
}
