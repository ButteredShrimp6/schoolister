<?php

include_once('connects.php');
$task = $_GET['courseTask'];

$query = "SELECT * FROM studentdata where courseTask = '$task' order by courseDeadline ASC, courseTime ASC";
$check=mysqli_query($con,$query);
$row=mysqli_num_rows($check);
$myArray = array();

if($check == FALSE) { 
    echo "Found";
}

  while($row=mysqli_fetch_array($check))
  	{
  	
	 $myArray[] = $row;
	
  	}
  echo json_encode($myArray);


?>