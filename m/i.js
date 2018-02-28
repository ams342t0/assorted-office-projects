	var cb_centers,
		cb_levels,
		cb_sex,
		cb_sched,
		chkregistered,
		cb_rooms,
		cb_classes,
		cb_topics;
		
	var centerid=1048576,
		levelid=1048576,
		sexid=1048576,
		schedid=1048576,
		noted=0,
		registered=-1,
		classid=1048576,
		roomid =1048576,
		topicid=1048576;
	var ucell;
	var selstudname;
	var isgradenull;
	var xmlo;
	var tp;
	var dowhat=0;
	var bi,gbox;
	var sox,soy;
	var strget;
	var bdetails;
	
	function initxml()
	{
		try
		{
			xmlo = new XMLHttpRequest();
		}
		catch(e)
		{
			try
			{
				alert(e);
				xmlo = new ActiveXObject("msxml2.xmlhttp");
			}
			catch(e)
			{
				alert(e);
				xmlo = new ActiveXObject("microsoft.xmlhttp");
			}
		}
		xmlo.onreadystatechange = function()
		{
			if (xmlo.readyState == 3) 
			{
				if (dowhat==0) tp.innerHTML = "<td align='center'><font face='arial black' size='30px'>LOADING...</font></td>";
				if (dowhat==9) document.getElementById("pdetails").innerHTML = "Loading...";
			}
			if (xmlo.readyState == 4 && xmlo.status == 200)
			{
				switch(dowhat)
				{
					case 0:
						tp.innerHTML = xmlo.responseText;
						break;
					
					case 1:
						cb_centers.innerHTML = xmlo.responseText;
						break;

					case 2:
						cb_sex.innerHTML = xmlo.responseText;
						break;

					case 3:
						cb_levels.innerHTML = xmlo.responseText;
						break;

					case 4:
						cb_sched.innerHTML = xmlo.responseText;
						break;
					
					case 5:
						document.getElementById("boxpid").innerHTML = xmlo.responseText;
						break;
					
					case 6:
						cb_classes.innerHTML = xmlo.responseText;
						break;
						
					case 7:
						cb_rooms.innerHTML = xmlo.responseText;
						break;

					case 8:
						cb_topics.innerHTML = xmlo.responseText;
						cb_topics.options.selectedIndex = 0;
						topicid = cb_topics.options[0].id;
						break;
					
					case 9:
						document.getElementById("pdetails").innerHTML = xmlo.responseText;					
						break;
					
					case 10:
						isgradenull = false;
						if (xmlo.responseText == "NULL") 
						{
							document.getElementById("txtgrade").value = "";
							isgradenull = true;
						}
						else document.getElementById("txtgrade").value = xmlo.responseText;
						break;
					
					case 11:
						document.getElementById("gdescription").innerHTML = selstudname + "<br/>" + cb_topics.value + " : " + xmlo.responseText;
						if (xmlo.responseText=="t_ok_1" || xmlo.responseText=="t_ok_2") 
						{
							isgradenull = false;
							ucell.textContent = document.getElementById("txtgrade").value;
						}
						if (xmlo.responseText=="t_ok_3") 
						{
							isgradenull = true;
							ucell.textContent = "";
						}
						break;
				}
			}
		}
	}
	
	function initdoc()
	{
		bdetails = document.getElementById("details");
		tp = document.getElementById("maintable");
		cbi = document.getElementById("mainbar");
		bi = document.getElementById("boxdiv");
		gbox = document.getElementById("gradebox");
		cb_centers = document.getElementById("cbcenters");
		cb_levels  = document.getElementById("cblevels");
		cb_sex     = document.getElementById("cbsex");
		cb_sched   = document.getElementById("cbschedule");
		cb_classes = document.getElementById("cbclasses");
		cb_rooms   = document.getElementById("cbrooms");
		chkregistered = document.getElementById("chkregistered");
		cb_topics = document.getElementById("cbtopics");
		cb_centers.disabled = true;
		cb_levels.disabled = true;
		cb_sex.disabled = true;
		cb_sched.disabled = true;
		cb_classes.disabled = true;
		cb_rooms.disabled = true;
		document.getElementById("closedetails").addEventListener("click",closedetails,true);
		document.getElementById("closeboxbtn").addEventListener("click",hidebox,true);
		document.getElementById("maintable").addEventListener("click",mouse_click,true);
		document.getElementById("maintable").addEventListener("mouseover",mouse_over,true);
		document.getElementById("maintable").addEventListener("mouseout",mouse_out,true);
		document.getElementById("mainbar").addEventListener("click",rclick,true);
		addEventListener("resize",resizetable,true);
		document.getElementById("btnrefresh").addEventListener("click",btnrefresh,true);
		document.getElementById("quickview").addEventListener("click",quickview,true);
		document.getElementById("gboxclose").addEventListener("click",gboxclose,true);
		document.getElementById("entergrade").addEventListener("click",entergrade,true);
		document.getElementById("savegrade").addEventListener("click",savegrade,true);
		document.getElementById("savezero").addEventListener("click",savezero,true);
		document.getElementById("savenull").addEventListener("click",savenull,true);
		document.getElementById("btnsearch").addEventListener("click",btn_search,true);
		cb_topics.addEventListener("change",changetopic,true);
		cb_classes.addEventListener("change",changeclass,true);
		initxml();
		initqdb();
	}
	
	function btn_search()
	{
		strget = "qc="+centerid+"&ql="+levelid+"&qs="+sexid+"&qt="+schedid+"&qr="+registered+"&qn="+noted+"&qrm="+roomid+"&qclass="+classid+"&qtopic="+topicid+"&qsearch="+document.getElementById("txtsearch").value;
		window.scrollTo(0,0);
		dowhat = 0;
		xmlo.open("GET","filltable.php?"+strget,true);
		xmlo.send();
	}
	
	function resizetable()
	{
		document.getElementById("btnrefresh").style["width"]=window.innerWidth-50+"px";
	}
	
	function savegrade()
	{
		var grade;
		
		grade = document.getElementById("txtgrade").value;
		dowhat = 11;
		if (isgradenull)
			xmlo.open("GET","savegrade.php?sid="+studid+"&tid="+topicid+"&g="+grade+"&n=0",false);
		else
			xmlo.open("GET","savegrade.php?sid="+studid+"&tid="+topicid+"&g="+grade+"&n=1",false);
		xmlo.send();
	}
	
	function savezero()
	{
		dowhat = 11;
		if (isgradenull)
			xmlo.open("GET","savegrade.php?sid="+studid+"&tid="+topicid+"&g=0&n=0",true);
		else
			xmlo.open("GET","savegrade.php?sid="+studid+"&tid="+topicid+"&g=0&n=1",true);
		document.getElementById("txtgrade").value = 0;
		xmlo.send();
	}
	
	function savenull()
	{
		dowhat = 11;
		xmlo.open("GET","savegrade.php?sid="+studid+"&tid="+topicid+"&g=0&n=2",true);
		xmlo.send();
		document.getElementById("txtgrade").value = "";
	}
	
	function btnrefresh()
	{
		tp.innerHTML = "<td align='center'><font face='arial black' size='30px'>LOADING...</font></td>";
		showbox(bi,0);
		showbox(gbox,0);
		showbox(bdetails,0);
		
		strget = "qc="+centerid+"&ql="+levelid+"&qs="+sexid+"&qt="+schedid+"&qr="+registered+"&qn="+noted+"&qrm="+roomid+"&qclass="+classid+"&qtopic="+topicid+"&qsearch=";
		window.scrollTo(0,0);
		dowhat = 0;
		xmlo.open("GET","filltable.php?"+strget,true);
		xmlo.send();
	}
	
	function rclick(e)
	{
		if (e.target.tagName=="INPUT")
		{
			switch (e.target.id)
			{
				case "centerall":
					centerid = 1048576;
					cb_centers.disabled = true;
					break;
					
				case "centerone":
					cb_centers.disabled = false;
					centerid = cb_centers.options[cb_centers.options.selectedIndex].id;
					break;
				
				case "sexall":
					cb_sex.disabled = true;
					sexid = 1048576;
					break;
					
				case "sexone":
					cb_sex.disabled = false;
					sexid = cb_sex.options[cb_sex.options.selectedIndex].id;
					break;
					
				case "scheduleall":
					cb_sched.disabled = true;
					schedid = 1048576;
					upds();
					break;
					
				case "scheduleone":
					cb_sched.disabled = false;
					schedid= cb_sched.options[cb_sched.options.selectedIndex].id;				
					upds();
					break;
				
				case "levelall":
					cb_levels.disabled = true;
					levelid = 1048576;
					break;
					
				case "levelone":
					cb_levels.disabled = false;
					levelid = cb_levels.options[cb_levels.options.selectedIndex].id;				
					break;
					
				case "classall":
					cb_classes.disabled = true;
					classid = 1048576;
					break;
				
				case "classone":
					cb_classes.disabled = false;
					classid = cb_classes.options[cb_classes.options.selectedIndex].id;
					break;
					
				case "roomall":
					cb_rooms.disabled = true;
					roomid = 1048576;
					break;
				
				case "roomone":
					cb_rooms.disabled = false;
					roomid = cb_rooms.options[cb_rooms.options.selectedIndex].index;
					break;
				
				case "chkregistered":
					if (chkregistered.checked) registered = -1;
					else registered = 0;
					break;
			}
		}
		if (e.target.tagName == "SELECT")
		{
			switch (e.target.id)
			{
				case "cbcenters":
					centerid = cb_centers.options[cb_centers.options.selectedIndex].id;
					break;
					
				case "cblevels":
					levelid = cb_levels.options[cb_levels.options.selectedIndex].id;				
					break;
					
				case "cbsex":
					sexid = cb_sex.options[cb_sex.options.selectedIndex].id;
					break;
				
				case "cbschedule":
					schedid= cb_sched.options[cb_sched.options.selectedIndex].id;				
					upds();
					break;
				
				case "cbclasses":
					classid = cb_classes.options[cb_classes.options.selectedIndex].id;
					break;
				
				case "cbrooms":
					roomid = cb_rooms.options[cb_rooms.options.selectedIndex].id;
					break;
				
				case "cbtopics":
					topicid = cb_topics.options[cb_topics.options.selectedIndex].id;
					showbox(gbox,0);
					break;
			}
		}
	}
	
	function changeclass()
	{
		classid = cb_classes.options[cb_classes.options.selectedIndex].id;
	}
	
	function changetopic()
	{
		topicid = cb_topics.options[cb_topics.options.selectedIndex].id;
		showbox(gbox,0);
		if (classid!=1048576) btnrefresh();
	}
	
	function upds()
	{
		dowhat=6;
		xmlo.open("GET","fetchrows.php?opt=6&tid="+schedid,false);
		xmlo.send();
		dowhat=7;
		xmlo.open("GET","fetchrows.php?opt=7&tid="+schedid,false);
		xmlo.send();
		showbox(gbox,0);
		
	}

	function initqdb()
	{
		dowhat=1;
		xmlo.open("GET","fetchrows.php?opt=1",false);
		xmlo.send();
		dowhat=2;
		xmlo.open("GET","fetchrows.php?opt=2",false);
		xmlo.send();
		dowhat=3;
		xmlo.open("GET","fetchrows.php?opt=3",false);
		xmlo.send();
		dowhat=4;
		xmlo.open("GET","fetchrows.php?opt=4",false);
		xmlo.send();
		dowhat=6;
		xmlo.open("GET","fetchrows.php?opt=6&tid="+schedid,false);
		xmlo.send();
		dowhat=7;
		xmlo.open("GET","fetchrows.php?opt=7&tid="+schedid,false);
		xmlo.send();
		dowhat=8;
		xmlo.open("GET","fetchrows.php?opt=8&tid="+schedid,true);
		xmlo.send();
	}
	
	function hidebox()
	{
		showbox(bi,0);
	}
	

	function mouse_click(e)
	{
		var pr;
		if (e.target.tagName=='TD')
		{
				sox = pageXOffset+e.clientX;
				soy = pageYOffset+e.clientY-100;
				pr = e.target.parentNode;
				studid = pr.id;
				selstudname = pr.cells[1].textContent;
				ucell = pr.cells[4];
				switch (e.target.cellIndex)
				{
					case 4:
						showbox(bdetails,0);
						showbox(bi,0);
						entergrade(e);
						break;
					
					case 3:
						showbox(bdetails,0);
						showbox(gbox,0);
						quickview(e);
						break;
						
					default:
						dowhat=9;
						xmlo.open("GET","getdetails.php?sid="+studid,true);
						xmlo.send();
						showbox(bi,0);
						showbox(gbox,0);
						showbox(bdetails,1);
						bdetails.style["left"]=sox+"px";
						bdetails.style["top"] =soy+"px";
						document.getElementById("closedetails").focus();
				}
		}
	}
	
	function entergrade(e)
	{
		dowhat=10;
		xmlo.open("GET","fetchgrade.php?sid="+studid+"&tid="+topicid,false);
		xmlo.send();
		document.getElementById("gdescription").innerHTML = selstudname + "<br/>" + cb_topics.value;
		gbox.style["left"]=sox-275+"px";
		gbox.style["top"]=soy+"px";
		showbox(gbox,1);
		document.getElementById("txtgrade").focus();
	}
	
	function quickview(e)
	{
		dowhat=5;
		xmlo.open("GET","getgrades.php?sid="+studid,true);
		xmlo.send();
		bi.style["left"]=sox+"px";
		bi.style["top"]=soy+"px";
		showbox(bi,1);
		document.getElementById("closeboxbtn").focus();
	}
	
	function gboxclose()
	{
		showbox(gbox,0);
	}

	
	function mouse_over(e)
	{
		if (e.target.tagName=="TD")
		{
//			e.target.parentNode.style["background-color"]="#000000";
			e.target.parentNode.style["color"]="#ff000f";
			document.body.style.cursor="pointer";
		}
	}
	
	function mouse_out(e)
	{
		if (e.target.tagName=="TD")
		{
//			e.target.parentNode.style["background-color"]="#DDE9ED";
			e.target.parentNode.style["color"]="#000000";
			document.body.style.cursor="default";
		}
	}
	
	function showbox(o,s)
	{
		switch (s)
		{
			case 0:
				o.style["visibility"]="hidden";
				break;
			
			case 1:
				o.style["visibility"]="visible";
				break;
		}
	}
	
	function closedetails()
	{
		showbox(bdetails,0);
		showbox(bi,0);
		showbox(gbox,0);
	}
	
	addEventListener("load",initdoc,true);
	
	
