<?php
session_start();

if (!isset($_SESSION["ok"])) exit;
if (!isset($_SESSION["lid"])) exit;
if (!isset($_GET["opwd"])) exit;
if (!isset($_GET["npwd"])) exit;
if (!isset($_GET["rpwd"])) exit;


$uid = strtoupper($_SESSION["lid"]);
$opwd = strtoupper($_GET["opwd"]);
$npwd = strtoupper($_GET["npwd"]);
$rpwd = strtoupper($_GET["rpwd"]);
$npi =  strtoupper($_GET["sn"]);

$u="philboar_armando";
$p="mTg_.456";
$h="localhost";
$cn = mysql_connect($h,$u,$p);
mysql_select_db("philboar_namelist",$cn);
$r = mysql_query("select id,password from namelist where id=".$uid." and upper(password)='".$opwd."'",$cn);
if (mysql_num_rows($r)==0)
	print("invalid old pasword");
else
	if ($npwd != $rpwd)
		print("new password do not match");
	else if (strlen($npwd) < 6)
		print("Password is too short (must be at least 6 characters long)");
	else
		if ($npwd != $opwd)
		{
			mysql_query("update namelist set password = '".$npwd."' where upper(email2)='".$npi."'",$cn) or die (mysql_error());
			print("ok");
		}
mysql_close($cn);

?>

