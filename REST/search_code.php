<?php

include_once('connects.php');
$course = $_GET['courseCode'];

$query = "SELECT * FROM studentdata where courseCode = '$course'";
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