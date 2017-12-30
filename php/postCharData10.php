<?php

	include "connection.php";

	$conn = new mysqli($servername, $server_username, $server_password, $server_db);

	if (!$conn) {
		echo "-1";
	} else {

		$namePost = mysqli_real_escape_string($conn, $_POST['usernamePost']);
		$descPost = mysqli_real_escape_string($conn, $_POST['descPost']);
		$urlPost = mysqli_real_escape_string($conn, $_POST['urlPost']);

		$query = "INSERT INTO data (charName, charDesc, picURL) VALUES ('".$namePost."','".$descPost."','".$urlPost."')";
		$result = mysqli_query($conn, $query);
		echo "Injected";

	}
?>