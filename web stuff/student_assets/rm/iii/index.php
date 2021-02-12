<?php
session_start();
if (!isset($_SESSION["ok"])){header("location:login.php");}
?>

<html>
<head>

<title>IMC REVIEW MATERIALS</title>
  <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

<style type="text/css">
#dlg1{
	font-size:11px;
}

body
{
font-family:calibri;
}
</style>  
  
<script>
	function fcc()
	{
		pa();
		$(this).dialog("close");
	}
	
	function pas(rtx)
	{
		alert(rtx);
	}
	
	function pae()
	{
		alert("error ajax cp");
	}
	
	function pa()
	{
		$.ajax({url:"/student_assets/rm/cp.php?opwd="+$("#opwd").val()+"&npwd="+$("#npwd").val()+"&rpwd="+$("#rpwd").val()+"&sn="+$("#hn").val(),
		type:"get",
		dataType:"html",
		success:pas,
		error:pae});
	}
	
	$(function()
	{
		$("#bcp").click(function()
		{
			$("#opwd").val("");
			$("#npwd").val("");
			$("#rpwd").val("");
			$("#dlg1").dialog({resizable:"false",width:"400",modal:"true",buttons:{"OK":fcc,CANCEL:function(){$(this).dialog("close");}}});
		});
		$("#st").accordion();
		$("#vl").click(function()
		{
			window.open("admviewlist.php");
		});
		$("#vg").click(function()
		{
			window.open("admviewlog.php");
		});
	});
</script>
</head>

<body>
<div align="center">
<a href="http://www.mtgphil.org"><img src="logo.jpg"/></a>
</div>

<p align="left">
<?php
print("<input type='hidden' id='hn' value='".$_SESSION["un"]."' />");
print(strtoupper($_SESSION["un"])." signed-in");
?>
<br/>
<a id="soid" href="login.php?so=1">Sign out</a>
<br/>
<a id="bcp" href="#">Change password</a>
</p>
<hr/>

<h3 align="center">REVIEW MATERIALS AVAILABE FOR DOWNLOAD</h3>
<div id="st" style='font-size:11px'>
	<?php
		$f = fopen("../admin/auxdb","r");
		$h = rtrim(fgets($f),"\r\n");
		$un = rtrim(fgets($f),"\r\n");
		$pw = rtrim(fgets($f),"\r\n");
		fclose($f);
		
		$cn = mysql_connect($h,$un,$pw) or die(mysql_error());
		mysql_select_db("philboar_namelist",$cn) or die(mysql_error());
		$r = mysql_query("select level from namelist where email2='".$_SESSION["un"]."' order by level") or die(mysql_error());
		$sr = "..";
		
		$samelevel=false;
		$ll1=1024;
		while ($a=mysql_fetch_array($r))
		{
			$ll2=$a["level"];
			
			switch ($ll2)
			{
				case 1:
				case 2:
					if ($ll1==1 || $ll1==2)
						$samelevel=true;
					else
						$samelevel=false;
					$strtitle="YOUNGSTER";
					$rf = "/dl/youngster/";
					break;
				case 3:
				case 4:
					if ($ll1==3 || $ll1==4)
						$samelevel=true;
					else
						$samelevel=false;
					$strtitle="GRADES 3-4";
					$rf="/dl/g34/";
					break;
				case 5:
				case 6:
					if ($ll1==5 || $ll1==6)
						$samelevel=true;
					else
						$samelevel=false;
					$strtitle="GRADES 5-6";
					$rf="/dl/g56/";
					break;
				
					
				default:
					if ($ll1==7 || $ll1==8 || $ll1==9 || $ll1==10)
						$samelevel = true;
					else
						$samelevel = false;
					$rf="/dl/hs/";
					$strtitle="HIGH SCHOOL";
			}
			

			if (!$samelevel)
			{
				
				print("<h3>".$strtitle."</h3>");
				print("<div>");
				print("<table style='font-size:12px'>");
				print("<tr style='font-weight:bold'><td>Filename</td><td></td><td>Date</td></tr>");
				$rq = $sr.$rf;
				$wd = opendir($rq);
				$fla=array();
				while(($f=readdir($wd))!=false)
				{
					if ($f=="." || $f==".." || $f=="ak") continue;
					$ct = filemtime($rq.$f).";".$f;
					$fla[$ct]=$f;
				}
				ksort($fla);
				foreach($fla as $ix=>$kx)
				{
					$qf=explode(";",$ix);
					print("<tr><td><a href='dl.php?sf=".$rf.$kx."'>".$kx."</a></td><td></td><td>".date("F d, Y",$qf[0])."</td></tr>");
				}
				print("</table>");
				print("<br/><p>ANSWER KEYS (Answer keys are posted 3 days after the reviewer)</p>");
				print("<table style='font-size:12px'>");
				print("<tr style='font-weight:bold'><td>Filename</td><td></td><td>Date</td></tr>");
				$rq = $sr.$rf."ak/";
				$wd = opendir($rq);
				$fla=array();
				while(($f=readdir($wd))!=false)
				{
					if ($f=="." || $f==".." || $f=="ak") continue;
					$ct = filemtime($rq.$f).";".$f;
					$fla[$ct]=$f;

				}
				ksort($fla);
				foreach($fla as $ix=>$kx)
				{
					$qf=explode(";",$ix);
					print("<tr><td><a href='dl.php?sf=".$rf."ak/".$kx."'>$kx</a></td><td></td><td>".date("F d, Y",$qf[0])."</td></tr>");
				}
				print("</table>");
				
				print("</div>");
				closedir($wd);
				$ll1 = $ll2;
			}
		}
		
		
		
		mysql_close($cn);
	?>
</div>

<div style="visibility:hidden">
<?php
print("<div id='dlg1' title='Password change for ".$_SESSION["fn"]."'>");
?>
<table>
	<tr><td>Old Password:</td><td><input type="password" id="opwd" size="20" /></td></tr>
	<tr><td>New Password:</td><td><input type="password" id="npwd" size="20" /></td></tr>
	<tr><td>Retype again:</td><td><input type="password" id="rpwd" size="20" /></td></tr>
	<tr><td colspan="2" align="right"><p id="dlgtxt"></p></td></tr>
</table>
</div>
</div>
<hr/>
<a href="#" id="vl">List</a>
<br/>
<a href="#" id="vg">Log</a>


</body>
</html>