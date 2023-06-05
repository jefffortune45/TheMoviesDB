<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormFilm.aspx.cs" Inherits="TheMovies.FormFilm" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>The Movie</title>
    <style type="text/css">
        .auto-style9 {
            height: 600px;
            width: 700px;
        }
        .auto-style10 {
            margin-top: 3px;
        }
        .auto-style11 {
            width: 264px;
        }
        .auto-style12 {
            margin-left: 146px;
        }
        .auto-style13 {
            float: left;
            height: 491px;
        }
        .auto-style14 {
            width: 264px;
            height: 23px;
        }
        .auto-style15 {
            margin-top: 14px;
             margin-left: 14px;
              margin-right: 14px;
               margin-top: 14px;
        }
         .auto-style16 {
            position:center
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server" style="background-color: chocolate" class="auto-style9">
        <div class="auto-style16">
   <div style="display: table; float: left; ">
<table>
<tr>
    <td> <asp:ImageButton ID="ImageButton1" runat="server" Width="342px" Height="455px" OnClick="ImageButton1_Click" /> </td>
</tr>

     <tr>
                     <td> <asp:Button ID="Precedent" runat="server" Text="Precedent" OnClick="Precedent_Click" Width="92px"/>
                         <asp:Button ID="Suivant" runat="server" Text="Suivant" OnClick="Suivant_Click" CssClass="auto-style12" Width="99px"/>
                      </td>
                 

               </tr>

</table>

   </div >

        <div style="display: table; " class="auto-style13">
            <table>
                <tr> <td class="auto-style14">
                    <asp:Label ID="Title" runat="server"></asp:Label>
                     </td></tr>

                 <tr> <td class="auto-style11">
                    <asp:TextBox ID="overview" runat="server" Height="414px" Width="254px" Font-Size="Small" CssClass="auto-style15" TextMode="MultiLine"></asp:TextBox>
                     </td></tr>

                 <tr> <td class="auto-style11">
                     Releasedate
                    <asp:TextBox ID="Releasedate" runat="server" Height="25px" Width="176px" CssClass="auto-style10"></asp:TextBox>
                     </td></tr>
                <asp:Panel ID="Panel1" runat="server" Width="48">
                </asp:Panel>
            </table>
        </div>

        </div> 
                
        
         
        
   

         
                
        
         
    </form>
</body>
</html>
