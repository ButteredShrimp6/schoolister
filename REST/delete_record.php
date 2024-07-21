<?php 

include_once('connects.php');
$course = $_GET['courseCode'];
$task =  $_GET['courseTask'];

$result = mysqli_query($con, "DELETE FROM studentdata WHERE courseCode ='$course' and courseTask = '$task'");
if  (mysqli_affected_rows($con) == 0)
{
	echo "No Data";
}
else if ($result == TRUE) 
{
	echo "Deleted";
}
else
{
	echo "Failed";
}

?>