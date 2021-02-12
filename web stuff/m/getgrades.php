<?php
if (!isset($_GET["sid"])) return;

$studid = $_GET["sid"];
$cn = mysql_connect("localhost","mtguser","mtg12345") or die(mysql_error());
mysql_select_db("mtgdb",$cn);
$q = "SELECT s.studid,s.fullname,t.topic,g.grade,t.topicid from (tblstudents as s left join tblgrades as g on s.studid=g.studid) inner join tbltopics as t on t.topicid = g.topicid";
$q = $q." where s.studid = ".$studid." order by t.topicid";
$r = mysql_query($q,$cn);

if (mysql_num_rows($r)==0)
{
	print("<p>NO RECORDS FOUND.</p>");
	mysql_close($cn);
	return;
}

print("<table width='100%'>");
$a = mysql_fetch_array($r);
print("<p>Student Name: ".strtoupper(mb_convert_encoding($a["fullname"],"utf-8","html-entities"))."</p>");

$quizavg = 0;
$assavg = 0;
$feavg = 0;
$cavg  = 0;
$quizct = 0;
$assct = 0;
$fect = 0;
$cct = 0;

while ($a)
{
	if ($a["topicid"] >= 0 && $a["topicid"]<100) 
	{
		$quizavg += $a["grade"];
		$quizct++;
		print("<tr>");
		print("<td width='85%' align='right'>".$a['topic']." : </td>");
		print("<td width='15%'>".$a['grade']."</td>");
		print("</tr>");
	}
	if ($a["topicid"] >= 100 && $a["topicid"]<200) 
	{
		$assavg += $a["grade"];
		$assct++;
	}
	if ($a["topicid"] >= 200 && $a["topicid"]<300) 
	{
		$feavg += $a["grade"];
		$fect++;
		print("<tr>");
		print("<td width='85%' align='right'>".$a['topic']." : </td>");
		print("<td width='15%'>".$a['grade']."</td>");
		print("</tr>");
	}
	if ($a["topicid"] >= 300 && $a["topicid"]<400) 
	{
		$cavg += $a["grade"];
		$cct++;
	}
	$a = mysql_fetch_array($r);
}

	print("<tr>");
	print("<tr>");
	print("<td width='85%' align='right'>ASSIGNMENT:</td>");
	if ($assct>0) print("<td width='15%'>".round($assavg/$assct,1)."</td>");
	print("</tr>");
	print("<tr>");
	print("<td width='85%' align='right'>CHARACTER:</td>");
	if ($cavg>0) print("<td width='15%'>".round($cavg/$cct,1)."</td>");
	print("</tr>");
	print("<td width='85%' align='right'>QUIZ AVE.:</td>");
	if ($quizct>0) print("<td width='15%'>".round($quizavg/$quizct,1)."</td>");
	print("</tr>");
	print("<tr>");
	print("<td width='85%' align='right'>FINAL EXAM AVE.:</td>");
	if ($fect>0) print("<td width='15%'>".round($feavg/$fect,1)."</td>");
	print("</tr>");

print("</table>");
mysql_close($cn);
?>