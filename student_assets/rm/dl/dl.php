<?php
include "mf.php";
session_start();
if (!isset($_SESSION["ok"])) 
{
    header("location:index.php");
    exit;
}
if (!isset($_GET["sf"])) 
{
    header("location:index.php");
    exit;
}

$file=getcwd().$_GET["sf"];
header("Content-Description:File Transer");
header("Content-type:application/octet-stream");
header("Content-Disposition:attachment;filename=".basename($file));
header("Content-transfer-encoding:binary");
header("Expires:0");
header("Cache-Control:must-revalidate");
header("Pragma:public");
header("Content-length:".filesize($file));
ob_clean();
flush();
readfile($file);
?>