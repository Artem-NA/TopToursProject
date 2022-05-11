<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="toptours1.Signup1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TopTours-SignUp</title>
    <%-- My Css --%>
    <link href="StyleSheets/SSRegister.css" rel="stylesheet" />
</head>
<body>
    <div class="loginBox">
        <img src="/imgs/logo.jpeg" class="logo" />
        <form id="form1" runat="server">
           <h1>Sign Up</h1>

           
            <h2>First Name:</h2>
           <input type="text" autocomplete="off" id="FirstName" runat="server" placeholder="Enter First Name" />
            <h2>Last Name:</h2>
           <input type="text" autocomplete="off" id="LastName" runat="server" placeholder="Enter Last Name " />

            <h2>Email:</h2>
           <input type="email" autocomplete="off" id="Email" runat="server" placeholder="Enter Email " />

            <h2>Username:</h2>
           <input type="text" autocomplete="off" id="Username" runat="server" placeholder="Enter Username " />
            <h2>Password:</h2>
            <input type="password" autocomplete="off" id="Password" runat="server" placeholder="Enter Password" />

            <h2>Image(Optional):</h2>

             <label class="upload" for="file1">Upload Image</label>

             <div class="form-input" id="change">
             <div class="preview">
             <img src="defult.jpg" id="file1-preview"/>
             </div>
                 
<%--             <input type="file" id="file1" runat="server" accept="image/*" onchange="showPreview(event);"/>--%>
                  <asp:FileUpload ID="file1" runat="server" onchange="showPreview(event)" accept="image/*"/>

            </div>
              <br /> 
            <asp:Button ID="LoginB" Text="Register" OnClick="LoginB_Click" runat="server" /> <br />
            <a href="Login.aspx">Already Have An Account?</a> <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </form>
            
    </div>


    <%-- JS Script To Preview Image --%>
    <script type="text/javascript">
  function showPreview(event){
  if(event.target.files.length > 0){
    var src = URL.createObjectURL(event.target.files[0]);
      var preview = document.getElementById("file1-preview");
    preview.src = src;
      preview.style.display = "block";
      document.getElementById("change").style.background = "white";
      document.getElementById("change").style.border = "3px solid black";
  }
   }
    </script>
</body>
</html>
