<?php

if (!isset($_GET["sid"])) return;

$studid = $_GET["sid"];
$cn = mysql_connect("localhost","mtguser","mtg12345") or die(mysql_error());
mysql_select_db("mtgdb",$cn);
$s = "SELECT sl.Fullname as Name, s.Sex, l.levelprefix as Level, sl.school as School, c.centername as Center, " .
             " c.city AS City, r.regionshort as Region, rm.roomname as Room,cl.classname as Class,noted,registered,score" .
             " FROM ((((((tblStudents AS sl INNER JOIN tblCenters AS c ON sl.center = c.centerid) " .
             " INNER JOIN tblSex AS s ON sl.sex = s.sexid) INNER JOIN tblLevels AS l ON sl.level = l.levelid) " .
             " INNER JOIN tblRegions AS r ON c.region = r.regionid) INNER JOIN tblArea AS a ON r.area = a.areaid) " .
             " LEFT OUTER  JOIN tblRooms as rm on rm.roomid=sl.room) " .
			 " LEFT OUTER  JOIN tblclass as cl on cl.classid=sl.class " .
             " WHERE studid=".$studid." ORDER BY regionid,centername,fullname";
$r = mysql_query($s,$cn);
$a = mysql_fetch_assoc($r);
print("<table>");
foreach($a as $v=>$i)
{
	if (isset($i))	
	{
		print("<tr>");
		if ($v=='noted' || $v=='registered')
		{
			if ($i==0) print("<td>".$v." : </td><td>NO</td>");
			else  print("<td>".$v." : </td><td>YES</td>");
		}
		else print("<td>".$v." : </td><td>".strtoupper(mb_convert_encoding($i,"utf-8","html-entities"))."</td>");
		print("</tr>");
	}
}
print("</table>");
mysql_close($cn);
?>