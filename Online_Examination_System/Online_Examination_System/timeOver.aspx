<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="timeOver.aspx.cs" Inherits="Online_Examination_System.timeOver" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="assets/css/TimeOver.css" rel="stylesheet" />
    <link href="assets/css/bootstrap.min.css" rel="stylesheet"/> 
    <script src="../assets/js/jquery.min.js"></script>
     <script src="../assets/js/bootstrap.bundle.min.js"></script>
    <title>Time is over</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a class="btn btn-primary" style=" position: absolute;
    bottom: 1%;
    left: 50%;
    transform: translateX(-50%);" href="http://localhost:50618/index.aspx" role="button">Try again!</a>
        </div>
    </form>
   
</body>
</html>
