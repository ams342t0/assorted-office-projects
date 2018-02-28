<?php
session_start();

if (isset($_SESSION["l"]))
{
	exit;
}
if (!isset($_SESSION["lc"]))
{
	$_SESSION["lc"]=1;
}
else
{
	$_SESSION["lc"]++;
	if ($_SESSION["lc"]>10)
	{
		print("Don't push it.");
		exit;
	}	
}

if (!isset($_GET["u"])) exit;
if (!isset($_GET["p"])) exit;

$uid = $_GET["u"];
$pwd = $_GET["p"];

if (strlen($uid)==0) print("Emtpy username ");
if (strlen($pwd)==0) print("Empty password ");
$h="*".strtoupper(hash("sha1",hash("sha1",$pwd,true)));
$cn = mysql_connect("localhost","root","iddqd");
mysql_select_db("mysql",$cn);

$r = mysql_query("select user,password from user where user = '".$uid."' and password = '".$h."'");
if (mysql_num_rows($r)==0) 
{
	print(" Denied ".$h);
	mysql_close($cn);
	exit;
}
print("ok");
mysql_close($cn);
if (!isset($_SESSION["l"]))
	$_SESSION["l"]=1;
?>