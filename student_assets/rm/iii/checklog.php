<?php
session_start();

if (!isset($_GET["uid"])) exit;
if (!isset($_GET["pwd"])) exit;

$uid = strtoupper($_GET["uid"]);
$pwd = strtoupper($_GET["pwd"]);


$f = fopen(getcwd()."../admin/auxdb","r");
$h = rtrim(fgets($f),"\r\n");
$un = rtrim(fgets($f),"\r\n");
$pw = rtrim(fgets($f),"\r\n");
fclose($f);


$cn = mysql_connect($h,$un,$pw) or die(mysql_error());
mysql_select_db("philboar_namelist",$cn) or die(mysql_error());
//$r = mysql_query("select id,fullname,level,email1,password from namelist where upper(email2)='" . $uid . "' and password(upper(password))='" . "*".strtoupper(hash("sha1",hash("sha1",$pwd,true)))."'") or die(mysql_error());
$r = mysql_query("select id,fullname,level,email1,password from namelist where upper(email2)='" . $uid . "' and upper(password)='" .strtoupper($pwd)."'") or die(mysql_error());

if (mysql_num_rows($r)==0)
{
	print("Error, not found");
	exit;
}

$a = mysql_fetch_array($r);
$_SESSION["fn"]=$a["fullname"];
$_SESSION["ok"]="1";
$_SESSION["wc"]=1;
$_SESSION["lid"]=$a["id"];
$_SESSION["un"]=$uid;
print("ok");

mysql_close($cn);
?>