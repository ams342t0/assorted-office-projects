<?php

// Fill event combo box, 

$i = 0;

while ($i < 10)
{
	// UNIQUE ID VALUE
	$id = $i;
	
	// SOME TEXT TO DISPLAY IN COMBOBOX
	$text = "Event value " . $i;
	
	print("<option id='fe' value='$id'>$text</option>");
	$i++;
}

?>