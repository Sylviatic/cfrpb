<?php
	include "connection.php";

	$conn = new mysqli($servername, $server_username, $server_password, $server_db);

	if (!$conn) 
	{
		echo "Failed to connect to database.";
	} else 
	{
		$charNamePost = mysqli_real_escape_string($conn, $_POST['charNamePost']);

		$query = "SELECT * from data WHERE charName='".$charNamePost."'";
		if ($result = mysqli_query($conn, $query)) 
		{
			while ($row = mysqli_fetch_assoc($result)) 
			{
				$charName = $row['charName'];
				$charDesc = $row['charDesc'];
				$charImg = $row['picURL'];


				$finalString = "".$charName."|".$charDesc."|".$charImg."";

				echo $finalString;
			}
		}
	}
?>