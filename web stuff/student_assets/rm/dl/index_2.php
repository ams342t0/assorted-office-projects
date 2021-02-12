<?php
include "mf.php";
session_start();
if (!isset($_SESSION["ok"])){header("location:login.php");}
?>

<html>
<head>

<title>WELCOME</title>
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
		if (rtx=="ok")
			window.location="login.php?so=1";
	}
	
	function pae()
	{
		alert("error ajax cp");
	}
	
	function pa()
	{
		$.ajax({url:"/student_assets/rm/cp.php?opwd="+$("#opwd").val()+"&npwd="+$("#npwd").val()+"&rpwd="+$("#rpwd").val(),
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
	});
</script>
</head>

<body>
<div align="center">
<a href="http://www.mtgphil.org"><img src="logo.jpg"/></a>
</div>

<p align="left">
<?php
print(strtoupper($_SESSION["fn"])." signed-in");
?>
<br/>
<a id="soid" href="login.php?so=1">Sign out</a>
<br/>
<a id="bcp" href="#">Change password</a>
</p>
<hr/>

<h3 align="center">REVIEW MATERIALS AVAILABE FOR DOWNLOAD</h3>
<div id="st">
	<h3>YOUNGSTER</h3>
	<div>
		<table style="font-size:12px">
			<tr style="font-weight:bold"><td>Filename</td><td></td><td>Date modified</td></tr>
			<?php
				$sr = getcwd();
				$r = $sr."/dl/youngster/";
				$wd = opendir($r);
				while(($f=readdir($wd))!=false)
				{
					if ($f=="." || $f=="..") continue;
					print("<tr><td><a href='dl.php?sf=".scram($r.$f)."'>$f</a></td><td></td><td>".date("F d, Y",filemtime($r.$f))."</td></tr>");
				}
			?>
		</table>
	</div>
	<h3>GRADE 3-4</h3>
	<div>
		<table style="font-size:12px">
			<tr style="font-weight:bold"><td>Filename</td><td></td><td>Date modified</td></tr>
			<?php
				$sr = getcwd();
				$r = $sr."/dl/g34/";
				$wd = opendir($r);
				while(($f=readdir($wd))!=false)
				{
					if ($f=="." || $f=="..") continue;
					print("<tr><td><a href='dl.php?sf=".scram($r.$f)."'>$f</a></td><td></td><td>".date("F d, Y",filemtime($r.$f))."</td></tr>");
				}
			?>
		</table>
	</div>
	<h3>GRADE 5-6</h3>
	<div>
		<table style="font-size:12px">
			<tr style="font-weight:bold"><td>Filename</td><td></td><td>Date modified</td></tr>
			<?php
				$sr = getcwd();
				$r = $sr."/dl/g56/";
				$wd = opendir($r);
				while(($f=readdir($wd))!=false)
				{
					if ($f=="." || $f=="..") continue;
					print("<tr><td><a href='dl.php?sf=".scram($r.$f)."'>$f</a></td><td></td><td>".date("F d, Y",filemtime($r.$f))."</td></tr>");
				}
			?>
		</table>
	</div>
	<h3>HIGH SCHOOL</h3>
	<div>
		<table style="font-size:12px">
			<tr style="font-weight:bold"><td>Filename</td><td></td><td>Date modified</td></tr>
			<?php
				$sr = getcwd();
				$r = $sr."/dl/hs/";
				$wd = opendir($r);
				while(($f=readdir($wd))!=false)
				{
					if ($f=="." || $f=="..") continue;
					print("<tr><td><a href='dl.php?sf=".scram($r.$f)."'>$f</a></td><td></td><td>".date("F d, Y",filemtime($r.$f))."</td></tr>");
				}
			?>
		</table>
	</div>
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

</body>
</html>