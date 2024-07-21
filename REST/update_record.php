<?php 

include_once('connects.php');
$course = $_GET['courseCode'];
$task =  $_GET['courseTask'];
$date = $_GET['courseDeadline'];
$time = $_GET['courseTime'];



$result = mysqli_query($con, "UPDATE studentdata SET courseTask = '$task', courseDeadline =STR_TO_DATE('$date','%Y-%m-%d'), courseTime = STR_TO_DATE('$time','%H:%i') WHERE courseCode = '$course' or courseTask='$task' or courseDeadline=STR_TO_DATE('$date','%Y-%m-%d') or courseTime=STR_TO_DATE('$time','%H:%i')");
if  (mysqli_affected_rows($con) > 0)
{
	echo "Updated";
}
else
{
	echo "No Data";
}

?>