<?php
		//FILL MAIN TABLE (LIST ITEMS)
		

		// just for testing purposes
		print("<table border = '1' id='maintable'>");


		// conditions for filter statement
		if (isset($_POST["eventid"]))
			$event = $_POST["eventid"];
		else
			$event = "EVENT";
		
		if (isset($_POST["statusid"]))
			$status = $_POST["statusid"];
		else
			$status = "STATUS";


		$i=0;
		
		while ($i < 100)
		{
			//substitute fields
			$id = $i;
			$name = "Name";
			$school = "School";
			$center = "Center";
			$isapproved = false;
			$hasdepositslip=true;
				
			print("<tr class='listitem' id='$id'>");
			
			af("td",$event,"","","10%");
			af("td",$name,"","","20%");
			af("td",$school,"","","15%");
			af("td",$center,"","","15%");
			af("td",$status,"","","10%");
			
			// if no deposit slip uploaded leave columns blank, else, fill in
			if ($hasdepositslip)
			{
				$depositslip = "<a id=".$id." class='depslip' href='#'> Deposit Slip </a>";
				af("td",$depositslip,"","","10%");

				if ($isapproved)
					$approved="<input type='checkbox' class = 'chkapproved' checked='true' />Approved";
				else
					$approved="<input type='checkbox' class = 'chkapproved' />Approved";

				$update="<input type='button' class='btnupdate' value='UPDATE'>";

				af("td",$approved,"","","10%");
				af("td",$update,"","","10%");
			}
			else
			{
				af("td","","","","10%");
				af("td","","","","10%");
				af("td","","","","10%");				
			}

			print("</tr>");
			$i++;
		}
		
		print("</table>");		
		
		function af($t,$s,$i,$c,$w)
		{
			print("<$t width='$w' id='$i' class='$c'>$s</$t>");
		}
?>