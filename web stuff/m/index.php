<?php
include "bd.php";
?>

<!DOCTYPE html>
<html>
<head>
<title>LOGIN</TITLE>
<style type="text/css">
#t
{
	border-collapse:collapse;
}
</style>

<script type="text/javascript">
var xt;
function initdoc()
{
	try{
	try
	{
	xt = new XMLHttpRequest();
	}
	catch(e1)
	{
		xt = new ActiveXObject("microsoft.XMLHTTP");
	}
	xt.onreadystatechange=function()
	{
		if (xt.readyState==4 && xt.status == 200)
		{
			document.getElementById("txtp").innerHTML = xt.responseText;
			if (xt.responseText!="ok")
			{
				document.getElementById("txtp").style["color"]="#ff0000";
			}
			else
			{
				window.location="index.php";
			}
		}
	
	}
		document.getElementById("btn").addEventListener("click",enterclick,false);
	}catch(e){alert(e);}
}

function enterclick()
{
		xt.open("get","v.php?u="+document.getElementById("txtuid").value+"&p="+document.getElementById("txtpwd").value,false);
		xt.send();
}

addEventListener("load",initdoc,false);

</script>

</head>

<body>

<table id="t" align="center">
<tr>
<td align="right">uid:</td>
<td><input type="text" id="txtuid" name="txtuid" autofocus="true"></td>
</tr>
<tr>
<td align="right">pwd:</td>
<td><input type="password" id="txtpwd" name="txtpwd"></td>
</tr>
<tr>
<td></td>
<td align="right"><input type="button" id="btn" value="ENTER"></td>
</tr>
<tr>
<td colspan="2">
<p id="txtp" align="right"></p>
</td>
</tr>
</table>
</body>
</html>