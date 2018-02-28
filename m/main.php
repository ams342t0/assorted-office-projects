<?php
session_start();
if (!isset($_SESSION["l"])) 
{
	header("Location:http://localhost/ws/m");
	exit;
}

?>

<!DOCTYPE html>

<html>
<head>
<title> IGH </title>

<script type="text/javascript" src="i.js"></script>
<link rel="stylesheet" type="text/css" href="s.css"/>

</head>

<body>

<div id="divmt">

<br/>
<br/>
<hr>

<table id='maintable' border="1" width="100%">
</div>
</table>


<div id="details">
<table width="100%" align="center">
<tr>
<td align="center">
<input type="button" value="GRADE" id="entergrade">
<input type="button" value="VIEW" id="quickview">
<input type="button" value="CLOSE" id="closedetails">
</td>
</tr>
</table>
<p id="pdetails"></p>
</div>

<div id="boxdiv">
<table width="100%">
<tr>
<td align="center">
<input type="button" value="CLOSE" id="closeboxbtn" />
</td>
</tr>
</table>
<p id="boxpid"></p>
</div>


<div id="gradebox">
<table>
<tr>
<td colspan="2"><p id="gdescription"></p></td>
</tr>
<tr>
<td>Score:<input type="text" align="center" id="txtgrade" size="5"></td>
<td>
	<input type="button" id="savegrade" value = "SAVE">
	<input type="button" value="CLOSE" id="gboxclose">
</td>
</tr>
<tr>
<td><input type="button" id="savezero" value="SAVE ZERO"></td>
<td><input type="button" id="savenull" value="SAVE NULL"></td>
</tr>
</table>
</div>

<div id="divmainbar">
<table width="100%" id = "mainbar">
<tr>
<td>
	Center:
	<input type="radio" id="centerall" name="r_center" checked="true">All
	<input type="radio" id="centerone" name="r_center"><select width="20" id="cbcenters"></select>
</td>
<td>
	Level:
	<input type="radio" id="levelall" name="r_level" checked="true">All
	<input type="radio" id="levelone" name="r_level"><select id="cblevels"></select>
</td>
<td>
	Sched:
	<input type="radio" id="scheduleall" name="r_schedule" checked="true">All
	<input type="radio" id="scheduleone" name="r_schedule"><select id="cbschedule"></select>
</td>
<td>
	Sex:
	<input type="radio" id="sexall" name="r_sex" checked="true">All
	<input type="radio" id="sexone" name="r_sex"><select id="cbsex"></select>
</td>
</tr>
<tr>
<td>
	Class:
	<input type="radio" id="classall" name="r_class" checked="true">All
	<input type="radio" id="classone" name="r_class"><select id="cbclasses"></select>
</td>
<td>
	Topic:<select id="cbtopics"></select>
</td>
<td>
	Room:
	<input type="radio" id="roomall" name="r_room" checked="true">All
	<input type="radio" id="roomone" name="r_room"><select id="cbrooms"></select>
</td>
<td>
	<input type="checkbox" id="chkregistered" name="chkregistered" checked="true">Reg.
</td>
</tr>
<tr>
<td>
	<input type="text" id="txtsearch" name="txtsearch" />
	<button id="btnsearch">SEARCH</button>
</td>
</tr>
<tr>
<td colspan="4" align="center"><button id="btnrefresh" style="width:600px;height:40px">LOAD</button></td>
</tr>
</table>
</div>




<hr>
</body>

</html>