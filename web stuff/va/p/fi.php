<?php
//Fetch deposit slip image, if available

//unique student id
$id = $_POST["sid"];

//for testing
print($id);

//deposit slip image
$filepath="sample.jpg";

print("<a href='$filepath'><img src='$filepath' width='450' height='480'></a>");

?>