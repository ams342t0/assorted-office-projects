<?php
$uid = strtoupper("admin");
$pwd = strtoupper("iddqd1024");


$f = fopen(getcwd()."/auxdb","r");
$h = rtrim(fgets($f),"\r\n");
$un = rtrim(fgets($f),"\r\n");
$pw = rtrim(fgets($f),"\r\n");
fclose($f);


$cn = mysql_connect($h,$un,$pw) or die(mysql_error());
mysql_select_db("philboar_namelist",$cn) or die(mysql_error());

//mysql_query("set old_passwords=1") or die(mysql_error());
$r = mysql_query("select password(upper(nl.password)) as p from namelist as nl where id=65536") or die(mysql_error());

$a = mysql_fetch_array($r);

if (mysql_num_rows($r)==0)
{
	print("Error, not found");
	exit;
}
printf($a["p"]."<br/>");
printf("*".strtoupper(hash("sha1",hash("sha1",$pwd,true))));


mysql_close($cn);
?>