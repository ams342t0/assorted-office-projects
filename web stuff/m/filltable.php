
<!DOCTYPE html>

<html>
<head>

</head>

<body>

<?php
	if (!isset($_GET["qc"])) return;
	if (!isset($_GET["ql"])) return;
	if (!isset($_GET["qs"])) return;
	if (!isset($_GET["qt"])) return;
	if (!isset($_GET["qr"])) return;
	if (!isset($_GET["qn"])) return;
	if (!isset($_GET["qrm"])) return;
	if (!isset($_GET["qclass"])) return;
	if (!isset($_GET["qtopic"])) return;	
	if (!isset($_GET["qsearch"])) return;
	
	$qman=0;
	$qc = $_GET["qc"];
	$ql = $_GET["ql"];
	$qs = $_GET["qs"];
	$qt = $_GET["qt"];
	$qr = $_GET["qr"];
	$qn = $_GET["qn"];
	$qrm = $_GET["qrm"];
	$qclass = $_GET["qclass"];
	$qtopic = $_GET["qtopic"];
	$qsearch = $_GET["qsearch"];
	
	$cn = mysql_connect("localhost","mtguser","mtg12345");
	mysql_select_db("mtgdb",$cn);
	
	$qstring = "";
	
	$qstring = "";
	
	if ($qc != '1048576')
			$qstring = " WHERE center = " . $qc;
	
	if ($ql != '1048576')
		if (strlen($qstring) > 0) $qstring = $qstring." and level = " . $ql;
		else $qstring = " WHERE level = " . $ql;

	if ($qt != '1048576')
		if (strlen($qstring) > 0) $qstring = $qstring." and schedule = " . $qt;
		else $qstring = " WHERE schedule = " . $qt;

	if ($qs != '1048576')
		if (strlen($qstring) > 0) $qstring = $qstring." and sex = " . $qs;
		else $qstring = " WHERE sex = " . $qs;

	if ($qr != '0')
		if (strlen($qstring) > 0) $qstring = $qstring." and registered = " . $qr;
		else $qstring = " WHERE registered = " . $qr;
		
	if ($qn != '0')
		if (strlen($qstring) > 0) $qstring = $qstring." and noted = " . $qn;
		else $qstring = " WHERE noted = " . $qn;
		
	if ($qrm != '1048576')
		if (strlen($qstring) > 0) $qstring = $qstring." and room = " . $qrm;
		else $qstring = " WHERE room = " . $qrm;
		
	if ($qclass != '1048576')
	{
		$qstring = $qstring." and class = " . $qclass;
		$qman = 1;
	}

	if (strlen($qsearch)>0)
		$qstring = $qstring . " and fullname like '%". $qsearch . "%'";

	$qstring = $qstring." order by fullname";
	
	$r = mysql_query("select s.studid,fullname,school,leveltext from tblstudents as s inner join tbllevels as l on s.level = l.levelid ".  $qstring) or die (mysql_error());

		
	if (mysql_num_rows($r)>0)
	{
			$i = 1;
			while ($a = mysql_fetch_array($r))
			{
					print("<tr id='".$a["studid"]."'>");
					print("<td height = '26px' width='2%' align='right'>".$i.".</td>");
					print("<td width='20%'>".mb_convert_encoding($a["fullname"],'UTF-8','HTML-ENTITIES')."</td>");
					print("<td width='5%'>".$a["leveltext"]."</td>");
					print("<td width='25%'>".mb_convert_encoding($a["school"],'utf-8','html-entities')."</td>");
					if ($qman==1) print("<td width='5%' align='center' style='font-weight:bold;font-size:16px'>".getgrade($a["studid"],$qtopic)."</td>");
					print("</tr>");
					$i++;
			}
	}
	else
	{
					print("<tr>");
					print("<td height='40px' align='center'>(EMPTY LIST)</td>");
					print("</tr>");
	}
	
	mysql_close($cn);

	function getgrade($sid,$tid)
	{
		$r = mysql_query("select grade from tblgrades where studid = " . $sid . " and topicid = " . $tid);
		if (mysql_num_rows($r) == 0) return "";
		$a=mysql_fetch_array($r);
		return $a["grade"];
	}
	
?>

</body>

</html>