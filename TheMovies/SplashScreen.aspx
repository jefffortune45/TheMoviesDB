<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SplashScreen.aspx.cs" Inherits="TheMovies.SplashScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <script type="text/javascript">
        window.onload = function () {

            setTimeout(function () {
                window.location.replace("FormFilm.aspx");
            }, 5000)

        }
    </script>
<head runat="server">
    <title> TheMovies</title>
     <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
          <div>
		  <p>T</p>
		  <p>h</p>
		  <p>e</p>
	      <p>M</p>
		  <p>o</p>
		  <p>v</p>
		  <p>i</p>
		  <p>e</p>
		</div>
       
       
    </form>
</body>
</html>
