addEventListener("load",init_all,true);

var xmlr,maintable,dlg,cb,cbevent,cbstatus,studid,eventid,statusid;

function init_all()
{
	try
	{
		sd_init("dlg1","dlg_cb1");
		initxmlr();
		fetch_xml(function(){document.getElementById("maintable").innerHTML = xmlr.responseText;},"p/ft.php","",false,function(){document.getElementById("maintable").innerHTML="Loading...";});
		maintable = get_E("maintable");
		cbevent  = get_E("ffe");
		fetch_xml(function(){cbevent.innerHTML = xmlr.responseText;},"p/fe.php","",false,function(){});
		cbstatus = get_E("st");
		fetch_xml(function(){cbstatus.innerHTML = xmlr.responseText;},"p/fs.php","",true,function(){});		
		addEvent("maintable","click",item_click);
		cbevent.addEventListener("change",clkhandler,true);
		cbstatus.addEventListener("change",clkhandler,true);
	}
	catch(u)
	{
		alert(u);
	}
}

function sd_init(i,i2)
{
	dlg = get_E(i);
	cb  = get_E(i2);
	addEvent(i2,"click",sd_hide);
}

function sd_show()
{
	dlg.style["visibility"]="visible";
	dlg.style["left"]=(window.screen.width  -  dlg.clientWidth)/2  + "px";
	dlg.style["top"] =(window.screen.height -  dlg.clientHeight)/2 + "px";
}
	
function sd_hide()
{
	dlg.style["visibility"]="hidden";
}

function clkhandler(e)
{
	if (e.target.id =="ffe")
		eventid=e.target.value;
	
	if  (e.target.id =="st")
		statusid = e.target.value;

	fetch_xml(function(){document.getElementById("maintable").innerHTML = xmlr.responseText;},"p/ft.php","eventid="+eventid+"&statusid="+statusid,false,function(){document.getElementById("maintable").innerHTML="Loading...";});
}

function item_click(e)
{
	if (e.target.className=="depslip")
	{
		studid = e.target.id;
		fetch_xml(function(){get_E("content").innerHTML = xmlr.responseText;},"p/fi.php","sid="+studid,true,function(){document.getElementById("content").innerHTML="Loading...";});
		sd_show();
	}

	if (e.target.className=="btnupdate")
	{
		var checked = e.target.parentNode.previousSibling.firstChild.checked;
		studid = e.target.parentNode.parentNode.id;
		alert(checked);
	}
	
	if (e.target.parentNode.className=="listitem")
	{
		studid = e.target.parentNode.id;
		alert(studid);
	}
}

function initxmlr()
{
	try
	{
		xmlr = new XMLHttpRequest();
	}
	catch(x)
	{
		try
		{
			xmlr = new ActiveXObject("microsoft.xmlhttp");
		}
		catch(x2)
		{
			try
			{
				xmlr = new ActiveXObject("ms.xmlhttp2");
			}
			catch(x3)
			{
				alert("Can't start ajax.");
			}
		}
	}
}

function fetch_xml(ae,s,d,b,i)
{
	xmlr.onreadystatechange = function()
	{
		if (xmlr.readyState == 3)
		{
			i();
		}
		if (xmlr.readyState==4 && xmlr.status == 200)
		{
			ae();
		}
	}
	xmlr.open("POST",s,b);
	xmlr.setRequestHeader("Content-type","application/x-www-form-urlencoded");
	xmlr.send(d);
}

function get_E(id)
{
	return document.getElementById(id);
}

function addEvent(id,e,a)
{
	get_E(id).addEventListener(e,a,true);
}

