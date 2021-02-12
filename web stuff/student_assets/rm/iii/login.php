<?php
session_start();
if (isset($_GET["so"]))
{
	unset($_SESSION["ok"]);
	unset($_SESSION["fn"]);
	unset($_SESSION["lv"]);
	unset($_GET["so"]);
	unset($_SESSION["lid"]);
}

if (isset($_SESSION["ok"]))
	header("location:index.php");

?>

<!DOCTYPE html>
<html>
<head>
<title>LOGIN</title>

<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

<style type="text/css">
body
{
	font-family:calibri;
}
</style>
<script>
	function cp()
	{
		$("#txtmsg").html("");	
	}

	function init()
	{
		$("#txtuid").on("keypress",cp);
		$("#txtpwd").on("keypress",cp);
		$("#txtuid").focus();
		$("#bsignin").click(function()
		{
			$.ajax(
				{
					url:"/student_assets/rm/checklog.php?uid="+$("#txtuid").val()+"&pwd="+$("#txtpwd").val(),
					type:"get",
					dataType:"html",
					error:function()
					{
						$("#txtmsg").html("error");
					},
					beforeSend:function()
					{
						//$("#txtmsg").html("before send");
					},
					complete:function()
					{
						//$("#txtmsg").html("complete");
					},
					success:function(strd)
					{
						switch(strd)
						{
							case "ok":
								$("#txtmsg").html("Ok");
								window.location="index.php";
								break;
							
							default:
								$("#txtmsg").html(strd);
						}
					}
				}
			);
		});
	}
	$(init);
</script>

</head>

<body>
<div align="center">
<img src="logo.jpg"/>
</div>
<hr/>
<table align="center">
<tr>
	<td align="right">Username:</td>
	<td><input type="text" id="txtuid" size="20"/></td>
</tr>
<tr>
	<td align="right">Password:</td>
	<td><input type="password" id="txtpwd" size="20"/></td>
</tr>
<tr>
	<td colspan="2" align="right"><input type="button" id="bsignin" value="SIGN IN" size="20"/></td>
</tr>
<tr>
	<td colspan="2" align="right"><p id="txtmsg"></p></td>
</tr>
</table>
<hr/>
<div>
<p align="center">
In case of problems or questions, email us at mtgp02@gmail.com 
</p>
</div>
</body>
</html>