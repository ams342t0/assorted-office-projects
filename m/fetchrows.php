<?php
if (!isset($_GET['opt']))
{
	exit;
}

$cn = mysql_connect("localhost","mtguser","mtg12345");
mysql_select_db("mtgdb",$cn);
$o = $_GET['opt'];

switch ($o)
{
	case '1':
		$r = mysql_query("select centerid,centername from tblcenters order by centername",$cn);
		while ($a = mysql_fetch_array($r))
		{
			print("<option id='".$a['centerid']."'>".mb_convert_encoding($a['centername'],"utf-8","html-entities")."</option>");
		}
		break;
	
	case '2':
		$r = mysql_query("select sexid,sex from tblsex order by sex",$cn);
		while ($a = mysql_fetch_array($r))
		{
			print("<option id='".$a['sexid']."'>".$a['sex']."</option>");
		}
		break;
		
	case '3':
		$r = mysql_query("select levelid,leveltext from tbllevels order by levelid",$cn);
		while ($a = mysql_fetch_array($r))
		{
			print("<option id='".$a['levelid']."'>".$a['leveltext']."</option>");
		}
		break;
	
	case '4':
		$r = mysql_query("select trainingid,quickdescription from tbltraining order by quickdescription");
		while ($a = mysql_fetch_array($r))
		{
			print("<option id='".$a['trainingid']."'>".$a['quickdescription']."</option>");
		}
		break;

	case '6':
		$tid = $_GET["tid"];
		if ($tid == "1048576") $r = mysql_query("select classid,classname from tblclass order by classname");
		else $r = mysql_query("select classid,classname from tblclass where schedule = " .$tid." order by classname");
		while ($a = mysql_fetch_array($r))
		{
			print("<option id='".$a['classid']."'>".$a['classname']."</option>");
		}
		break;

	case '7':
		$tid = $_GET["tid"];
		if ($tid == "1048576") $r = mysql_query("select roomid,roomname from tblrooms order by roomname");
		else $r = mysql_query("select roomid,roomname from tblrooms where schedule = " .$tid." order by roomname");
		while ($a = mysql_fetch_array($r))
		{
			print("<option id='".$a['roomid']."'>".$a['roomname']."</option>");
		}
		break;

	case '8':
		$tid = $_GET["tid"];
		$r = mysql_query("select topicid,topic from tbltopics order by topic");
		while ($a = mysql_fetch_array($r))
		{
			print("<option id='".$a['topicid']."'>".$a['topic']."</option>");
		}
		break;
}

mysql_close($cn);


?>