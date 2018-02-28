<?php
session_start();

if (!isset($_GET["uid"])) exit;
if (!isset($_GET["pwd"])) exit;

$s=explode("@",$_GET["uid"]);
//$uid = strtoupper($_GET["uid"]);
$uid = strtoupper($s[0]);
$pwd = strtoupper($_GET["pwd"]);


$f = fopen(getcwd()."/auxdb","r");
$h = rtrim(fgets($f),"\r\n");
$un = rtrim(fgets($f),"\r\n");
$pw = rtrim(fgets($f),"\r\n");
fclose($f);


$cn = mysql_connect($h,$un,$pw) or die(mysql_error());
mysql_select_db("philboar_namelist",$cn) or die(mysql_error());
mysql_query("set old_passwords=0");
$r = mysql_query("select nl.id,nl.fullname,nl.level,nl.email1,nl.password from namelist as nl where upper(email2)='" . $uid . "' and password(upper(nl.password))='" . "*".strtoupper(hash("sha1",hash("sha1",$pwd,true)))."'") or die(mysql_error());
//$r = mysql_query("select nl.id,nl.fullname,nl.level,nl.email1,nl.password from namelist as nl where upper(email2)='" . $uid . "' and upper(nl.password)='" .$pwd."'") or die(mysql_error());

if (mysql_num_rows($r)==0)
{
	print("Error, not found");
	$qxs = date("M d, Y h:m:s",time())."ip:".$_SERVER["REMOTE_ADDR"].";".$uid.";".$pwd;
	mysql_query("insert into templist(tempid) values('".$qxs."')",$cn);
	mysql_close($cn);
	exit;
}


$a = mysql_fetch_array($r);
$_SESSION["fn"]=$a["fullname"];
$_SESSION["ok"]="1";
$_SESSION["wc"]=1;
$_SESSION["lid"]=$a["id"];
$_SESSION["un"]=$uid;
print("ok");
$qxs = $a["fullname"].date(" M d, Y h:m:s",time())." ip:".$_SERVER["REMOTE_ADDR"]." ".$_SERVER["HTTP_USER_AGENT"];
mysql_query("insert into templist(tempid) values('".$qxs."')",$cn);

mysql_close($cn);
?>