include "c.txt"

<?php

$f = $_FILES["f"]["name"];
$t = $_FILES["f"]["type"];
$s = $_FILES["f"]["size"];
$tn = $_FILES["f"]["tmp_name"];
move_uploaded_file($tn,getcwd()."/".$f);
print($f."<br/>".$t."<br/>".$s."<br/>".$tn."<br/>".$_POST["x"]);

?>