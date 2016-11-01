		String.prototype.Trim = function()
		{	//去掉首尾的空格
			return this.replace(/(^\s*)|(\s*$)/g, "");
		}
		
		

		function RegCheck(FormName)
		{
		
			var regEmail =   /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
			var regChi = /^[^\x00-\xff]{1,80}$/
			if (!FormName.v_Agree.checked)
			{
				alert("请先阅读服务条款,并点击接受服务条款.");
				FormName.v_Agree.focus();
				return false;
			}
			if (FormName.TextBox1.value.Trim()=="")
			{
				alert("会员名不得为空呀！……");
				FormName.TextBox1.focus();
				return false;
			}
			if (FormName.TextBox1.value.Trim().length< 2)
			{
				alert("会员名不得小于2字符.");
				FormName.TextBox1.focus();
				return false;
			}
			if (FormName.v_Password.value.Trim()=="")
			{
				alert("密码不得为空呀！……");
				FormName.v_Password.focus();
				return false;
			}
			if (FormName.v_Password2.value.Trim()=="")
			{
				alert("密码确认不得为空呀！……");
				FormName.v_Password2.focus();
				return false;
			}
			if (FormName.v_Password.value.Trim()!=FormName.v_Password2.value.Trim())
			{
				alert("密码确认与密码不符合.");
				FormName.v_Password2.select();
				FormName.v_Password2.focus();
				return false;
			}
			if (FormName.v_Answer.value.Trim()=="")
			{
				alert("问题答案不得为空呀！……");
				FormName.v_Answer.focus();
				return false;
			}
			
			if (FormName.v_PaperNum.value.Trim()=="")
			{
				alert("证件号不得为空呀！……");
				FormName.v_PaperNum.focus();
				return false;
			}
			if (FormName.v_TrueName.value.Trim()=="")
			{
				alert("真实姓名不得为空呀！……");
				FormName.v_TrueName.focus();
				return false;
			}
			if(!regChi.test(FormName.v_TrueName.value.Trim()))
			{
				alert("请输入您的中文名字!")
				objForm.u_ctt_cn.focus();
				return false
			}
			if (FormName.v_Mail.value.Trim()=="")
			{
				alert("您的e-mail不得为空呀！……");
				FormName.v_Mail.focus();
				return false;
			}

			if (!regEmail.test(FormName.v_Mail.value.Trim()))
			{
				alert("请正确填写email地址.");
				FormName.v_Mail.focus();
				return false;
			}
			if (FormName.v_Mobile.value.Trim() == "")
			{
				alert("您的手机号不得为空呀！……");
				FormName.v_Mobile.focus();
				return false;
			}
			if (FormName.TextBox9.value.Trim() == "")
			{
				alert("您的生日不得为空呀！……");
				FormName.v_Mobile.focus();
				return false;
			}
			var u_eml = FormName.v_Mail.value.Trim()
			
			if(!regEmail.test(u_eml))
			{
			alert("请输入有效的电子邮件地址！")
			objForm.u_eml.focus();
			 return false
			}							
		}
document.writeln('<div id=meizzDateLayer style="position: absolute; width: 142; height: 166; z-index: 9998; display: none">');
		document.writeln('<span id=tmpSelectYearLayer  style="z-index: 9999;position: absolute;top: 2; left: 18;display: none"></span>');
		document.writeln('<span id=tmpSelectMonthLayer style="z-index: 9999;position: absolute;top: 2; left: 75;display: none"></span>');
		document.writeln('<table border=0 cellspacing=1 cellpadding=0 width=142 height=160 bgcolor=#000000 onselectstart="return false">');
		document.writeln('  <tr><td width=142 height=23 bgcolor=#FFFFFF><table border=0 cellspacing=1 cellpadding=0 width=140 height=23>');
		document.writeln('      <tr align=center><td width=20 align=center bgcolor=#808080 style="font-size:12px;cursor: hand;color: #FFD700" ');
		document.writeln('        onclick="meizzPrevM()" title="前一月" Author=meizz><b Author=meizz>&lt;</b>');
		document.writeln('        </td><td width=100 align=center style="font-size:12px;cursor:default" Author=meizz>');

		document.writeln('        <span Author=meizz id=meizzYearHead onmouseover="style.backgroundColor=\'yellow\'" onmouseout="style.backgroundColor=\'white\'" title="点击这里选择年份" onclick="tmpSelectYearInnerHTML(this.innerText)" style="cursor: hand;"></span>&nbsp;年&nbsp;<span');
		document.writeln('         id=meizzMonthHead Author=meizz onmouseover="style.backgroundColor=\'yellow\'" onmouseout="style.backgroundColor=\'white\'" title="点击这里选择月份" onclick="tmpSelectMonthInnerHTML(this.innerText)" style="cursor: hand;"></span>&nbsp;月</td>');

		document.writeln('        <td width=20 bgcolor=#808080 align=center style="font-size:12px;cursor: hand;color: #FFD700" ');
		document.writeln('         onclick="meizzNextM()" title="后一月" Author=meizz><b Author=meizz>&gt;</b></td></tr>');
		document.writeln('    </table></td></tr>');
		document.writeln('  <tr><td width=142 height=18 bgcolor=#808080>');
		document.writeln('<table border=0 cellspacing=0 cellpadding=0 width=140 height=1 style="cursor:default">');
		document.writeln('<tr align=center><td style="font-size:12px;color:#FFFFFF" Author=meizz>日</td>');
		document.writeln('<td style="font-size:12px;color:#FFFFFF" Author=meizz class="td1">一</td><td style="font-size:12px;color:#FFFFFF" Author=meizz>二</td>');
		document.writeln('<td style="font-size:12px;color:#FFFFFF" Author=meizz>三</td><td style="font-size:12px;color:#FFFFFF" Author=meizz>四</td>');
		document.writeln('<td style="font-size:12px;color:#FFFFFF" Author=meizz>五</td><td style="font-size:12px;color:#FFFFFF" Author=meizz>六</td></tr>');
		document.writeln('</table></td></tr>');
		document.writeln('  <tr><td width=142 height=120>');
		document.writeln('    <table border=0 cellspacing=1 cellpadding=0 width=140 height=120 bgcolor=#FFFFFF>');
		var n=0; for (j=0;j<5;j++){ document.writeln (' <tr align=center>'); for (i=0;i<7;i++){
		document.writeln('<td width=20 height=20 id=meizzDay'+n+' style="font-size:12px" Author=meizz onclick=meizzDayClick(this.innerText)></td>');n++;}
		document.writeln('</tr>');}
		document.writeln('      <tr align=center><td width=20 height=20 style="font-size:12px" id=meizzDay35 Author=meizz ');
		document.writeln('         onclick=meizzDayClick(this.innerText)></td>');
		document.writeln('        <td width=20 height=20 style="font-size:12px" id=meizzDay36 Author=meizz onclick=meizzDayClick(this.innerText)></td>');
		document.writeln('        <td colspan=5 align=right Author=meizz><span onclick=closeLayer() style="font-size:12px;cursor: hand"');
		document.writeln('         Author=meizz title="返回（不选择日期）"><u>关闭</u></span>&nbsp;</td></tr>');
		document.writeln('    </table></td></tr><tr><td>');
		document.writeln('        <table border=0 cellspacing=1 cellpadding=0 width=100% bgcolor=#FFFFFF>');
		document.writeln('          <tr><td Author=meizz align=left><input Author=meizz type=button value="<<" title="前一年" onclick="meizzPrevY()" ');
		document.writeln('             onfocus="this.blur()" style="	cursor: hand;BACKGROUND-COLOR: #808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px outset; BORDER-TOP: #808080 1px outset; FONT-SIZE: 12px; height: 20px;color: #FFD700; font-weight: bold"><input Author=meizz title="前一月" type=button ');
		document.writeln('             value="<" onclick="meizzPrevM()" onfocus="this.blur()" style="cursor: hand;BACKGROUND-COLOR: #808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px outset; BORDER-TOP: #808080 1px outset;font-size: 12px; height: 20px;color: #FFD700; font-weight: bold"></td><td ');
		document.writeln('             Author=meizz align=center><input Author=meizz type=button value="重置" onclick="meizzToday()" ');
		document.writeln('             onfocus="this.blur()" title="显示当前时间" style="cursor: hand;BACKGROUND-COLOR: #808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px outset; BORDER-TOP: #808080 1px outset;font-size: 12px; height: 20px;color: #FFFFFF; font-weight: bold"></td><td ');
		document.writeln('             Author=meizz align=right><input Author=meizz type=button value=">" onclick="meizzNextM()" ');
		document.writeln('             onfocus="this.blur()" title="后一月" style="cursor: hand;BACKGROUND-COLOR: #808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px outset; BORDER-TOP: #808080 1px outset;font-size: 12px; height: 20px;color: #FFD700; font-weight: bold"><input ');
		document.writeln('             Author=meizz type=button value=" >>" title="后一年" onclick="meizzNextY()"');
		document.writeln('             onfocus="this.blur()" style="cursor: hand;BACKGROUND-COLOR: #808080;BORDER-BOTTOM: #808080 1px outset; BORDER-LEFT: #808080 1px outset; BORDER-RIGHT: #808080 1px outset; BORDER-TOP: #808080 1px outset;font-size: 12px; height: 20px;color: #FFD700; font-weight: bold"></td>');
		document.writeln('</tr></table></td></tr></table></div>');
		var outObject;
		function setday(tt,obj) 
		{
		if (arguments.length >  2){alert("对不起！传入本控件的参数太多！");return;}
		if (arguments.length == 0){alert("对不起！您没有传回本控件任何参数！");return;}
		var dads  = document.all.meizzDateLayer.style;var th = tt;
		var ttop  = tt.offsetTop;     
		var thei  = tt.clientHeight;
		var tleft = tt.offsetLeft;   
		var ttyp  = tt.type;          
		while (tt = tt.offsetParent){ttop+=tt.offsetTop; tleft+=tt.offsetLeft;}
		dads.top  = (ttyp=="image")? ttop+thei : ttop+thei+6;
		dads.left = tleft;
		outObject = (arguments.length == 1) ? th : obj;
		dads.display = '';
		event.returnValue=false;
		}

		var MonHead = new Array(12);    		  
			MonHead[0] = 31; MonHead[1] = 28; MonHead[2] = 31; MonHead[3] = 30; MonHead[4]  = 31; MonHead[5]  = 30;
			MonHead[6] = 31; MonHead[7] = 31; MonHead[8] = 30; MonHead[9] = 31; MonHead[10] = 30; MonHead[11] = 31;

		var meizzTheYear=new Date().getFullYear(); 
		var meizzTheMonth=new Date().getMonth()+1; 
		var meizzWDay=new Array(37);               

		function document.onclick()
		{ 
		with(window.event.srcElement)
		{ if (tagName != "INPUT" && getAttribute("Author")==null)
			document.all.meizzDateLayer.style.display="none";
		}
		}

		function meizzWriteHead(yy,mm)  
		{ document.all.meizzYearHead.innerText  = yy;
			document.all.meizzMonthHead.innerText = mm;
		}

		function tmpSelectYearInnerHTML(strYear) 
		{
		if (strYear.match(/\D/)!=null){alert("年份输入参数不是数字！");return;}
		var m = (strYear) ? strYear : new Date().getFullYear();
		if (m < 1000 || m > 9999) {alert("年份值不在 1000 到 9999 之间！");return;}
		var n = m - 10;
		if (n < 1000) n = 1000;
		if (n + 26 > 9999) n = 9974;
		var s = "<select Author=meizz name=tmpSelectYear style='font-size: 12px' "
			s += "onblur='document.all.tmpSelectYearLayer.style.display=\"none\"' "
			s += "onchange='document.all.tmpSelectYearLayer.style.display=\"none\";"
			s += "meizzTheYear = this.value; meizzSetDay(meizzTheYear,meizzTheMonth)'>\r\n";
		var selectInnerHTML = s;
		for (var i = n; i < n + 26; i++)
		{
			if (i == m)
			{selectInnerHTML += "<option value='" + i + "' selected>" + i + "年" + "</option>\r\n";}
			else {selectInnerHTML += "<option value='" + i + "'>" + i + "年" + "</option>\r\n";}
		}
		selectInnerHTML += "</select>";
		document.all.tmpSelectYearLayer.style.display="";
		document.all.tmpSelectYearLayer.innerHTML = selectInnerHTML;
		document.all.tmpSelectYear.focus();
		}

		function tmpSelectMonthInnerHTML(strMonth) 
		{
		if (strMonth.match(/\D/)!=null){alert("月份输入参数不是数字！");return;}
		var m = (strMonth) ? strMonth : new Date().getMonth() + 1;
		var s = "<select Author=meizz name=tmpSelectMonth style='font-size: 12px' "
			s += "onblur='document.all.tmpSelectMonthLayer.style.display=\"none\"' "
			s += "onchange='document.all.tmpSelectMonthLayer.style.display=\"none\";"
			s += "meizzTheMonth = this.value; meizzSetDay(meizzTheYear,meizzTheMonth)'>\r\n";
		var selectInnerHTML = s;
		for (var i = 1; i < 13; i++)
		{
			if (i == m)
			{selectInnerHTML += "<option value='"+i+"' selected>"+i+"月"+"</option>\r\n";}
			else {selectInnerHTML += "<option value='"+i+"'>"+i+"月"+"</option>\r\n";}
		}
		selectInnerHTML += "</select>";
		document.all.tmpSelectMonthLayer.style.display="";
		document.all.tmpSelectMonthLayer.innerHTML = selectInnerHTML;
		document.all.tmpSelectMonth.focus();
		}

		function closeLayer()              
		{
			document.all.meizzDateLayer.style.display="none";
		}

		function document.onkeydown()
		{
			if (window.event.keyCode==27)document.all.meizzDateLayer.style.display="none";
		}

		function IsPinYear(year)            
		{
			if (0==year%4&&((year%100!=0)||(year%400==0))) return true;else return false;
		}

		function GetMonthCount(year,month)  
		{
			var c=MonHead[month-1];if((month==2)&&IsPinYear(year)) c++;return c;
		}

		function GetDOW(day,month,year)     
		{
			var dt=new Date(year,month-1,day).getDay()/7; return dt;
		}

		function meizzPrevY()  
		{
			if(meizzTheYear > 999 && meizzTheYear <10000){meizzTheYear--;}
			else{alert("年份超出范围（1000-9999）！");}
			meizzSetDay(meizzTheYear,meizzTheMonth);
		}
		function meizzNextY()  
		{
			if(meizzTheYear > 999 && meizzTheYear <10000){meizzTheYear++;}
			else{alert("年份超出范围（1000-9999）！");}
			meizzSetDay(meizzTheYear,meizzTheMonth);
		}
		function meizzToday()  
		{
			meizzTheYear = new Date().getFullYear();
			meizzTheMonth = new Date().getMonth()+1;
			meizzSetDay(meizzTheYear,meizzTheMonth);
		}
		function meizzPrevM()  
		{
			if(meizzTheMonth>1){meizzTheMonth--}else{meizzTheYear--;meizzTheMonth=12;}
			meizzSetDay(meizzTheYear,meizzTheMonth);
		}
		function meizzNextM()  
		{
			if(meizzTheMonth==12){meizzTheYear++;meizzTheMonth=1}else{meizzTheMonth++}
			meizzSetDay(meizzTheYear,meizzTheMonth);
		}

		function meizzSetDay(yy,mm)   
		{
		meizzWriteHead(yy,mm);
		for (var i = 0; i < 37; i++){meizzWDay[i]=""}; 
		var day1 = 1,firstday = new Date(yy,mm-1,1).getDay();  
		for (var i = firstday; day1 < GetMonthCount(yy,mm)+1; i++){meizzWDay[i]=day1;day1++;}
		for (var i = 0; i < 37; i++)
		{ var da = eval("document.all.meizzDay"+i)     
			if (meizzWDay[i]!="")
			{ da.innerHTML = "<b>" + meizzWDay[i] + "</b>";
				da.style.backgroundColor = (yy == new Date().getFullYear() &&
				mm == new Date().getMonth()+1 && meizzWDay[i] == new Date().getDate()) ? "#FFD700" : "#73a6de";
				da.style.cursor="hand"
			}
			else{da.innerHTML="";da.style.backgroundColor="";da.style.cursor="default"}
		}
		}
		function meizzDayClick(n)  
		{
		var yy = meizzTheYear;
		var mm = meizzTheMonth;
		if (mm < 10){mm = "0" + mm;}
		if (outObject)
		{
			if (!n) {outObject.value=""; return;}
			if ( n < 10){n = "0" + n;}
			outObject.value= yy + "-" + mm + "-" + n ; 
			closeLayer(); 
		}
		else {closeLayer(); alert("您所要输出的控件对象并不存在！");}
		}
		meizzSetDay(meizzTheYear,meizzTheMonth);