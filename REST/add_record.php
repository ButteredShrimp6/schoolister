<?php 

include_once('connects.php');
$course = $_GET['courseCode'];
$task =  $_GET['courseTask'];
$date = $_GET['courseDeadline'];
$time=$_GET['courseTime'];


$result = mysqli_query($con,"INSERT INTO studentdata (courseCode, courseTask, courseDeadline, courseTime) VALUES('$course','$task',STR_TO_DATE('$date','%Y-%m-%d'),STR_TO_DATE('$time','%H:%i'))");
echo "Data Inserted";

?>