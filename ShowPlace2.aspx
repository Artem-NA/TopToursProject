<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowPlace2.aspx.cs" Inherits="toptours1.ShowPlace2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>View My Place</title>
    <link href="StyleSheets/SSHome.css" rel="stylesheet" />
    <link href="StyleSheets/SSPlace.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.15.4/css/fontawesome.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>

    <!--font-family-->
		<link href="https://fonts.googleapis.com/css?family=Rufina:400,700" rel="stylesheet" />

		<link href="https://fonts.googleapis.com/css?family=Poppins:100,200,300,400,500,600,700,800,900" rel="stylesheet" />

	
		<!--font-awesome.min.css-->
		<link rel="stylesheet" href="assets/css/font-awesome.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <section class="sub-header">
        <nav>
            <a herf="Home2.aspx"><img id="logo" src="imgs/logoWhPNG.png" alt="logo"/></a>
            <div class="nav-links" id="navLinks">
                <ul>
                    <%-- li- list item --%>
                    <asp:BulletedList ID="BulletedList1"  runat="server"></asp:BulletedList>
                       <asp:Button ID="IsLogged" runat="server" class="btnlog" Text="" OnClick="IsLogged_Click" />
                </ul>
            </div>
        </nav>
  
    </section>

        

        <section class="secTwo">
        
         <div class="row">
             <div class="secTwo-col" style="flex-basis:90%;">
                 <asp:Image ID="Image1" runat="server" style="width:500px; height:350px;" /> <br />
                 <asp:Label ID="Label1" style="text-align:left; font-size:25px; font-weight:600" runat="server" Text="Label"></asp:Label> <br />
                 <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
                 <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
                 <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                 </div>
             <asp:Button ID="EditBtn" runat="server" Text="Update Place" class="visit-btn" OnClick="EditBtn_Click" style="width:50%;" />
             <asp:Button ID="DeleteBtn" runat="server" Text="Delete Place" class="visit-btn" OnClick="DeleteBtn_Click" style="width:50%;" />
             


         </div>


     </section>









    


      <section class="footer"> 
          <h3>All credits to Top-Tours.</h3>
      </section>

    </form>
</body>
</html>