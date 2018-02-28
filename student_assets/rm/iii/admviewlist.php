<?php
session_start();
if (!isset($_SESSION["ok"])) exit;
?>

<!DOCTYPE html>

<html>
<head>
<title>LISTA</title>

<style type="text/css">
body
{
font-family:verdana;
font-size:10px;
}
</style>
</head>

<body>

<?php

$cn = mysql_connect("localhost","philboar_armando","mTg_.456");
mysql_select_db("philboar_namelist",$cn);
$r = mysql_query("select * from namelist order by id",$cn);
print("<table width='100%'>");
$a=mysql_fetch_assoc($r);
print("<tr>");

print("</tr>");

while($a=mysql_fetch_row($r))
{
	print("<tr>");
	foreach($a as $v)
	{
		print("<td>".$v."</td>");
	}	
	print("</tr>");
}
print("</table>");

mysql_close($cn);
?>

</body>
</html>