<?php
function scram($s)
{
	$outstr="";
	for($i=0;$i<strlen($s);$i++)
	{
		$ac=ord($s[$i]);
		$off = $ac-35;
		$outstr=$outstr.chr(126-$off);
	}
	return $outstr;
}

function unscram($s)
{
	$outstr="";
	for($i=0;$i<strlen($s);$i++)
	{
		$ac=ord($s[$i]);
		$off = 126-$ac;
		$outstr=$outstr.chr($off+35);
	}
	return $outstr;
}


?>