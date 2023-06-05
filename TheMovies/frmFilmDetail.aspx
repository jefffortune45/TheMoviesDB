<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmFilmDetail.aspx.cs" Inherits="TheMovies.frmFilmDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 100%;
            width: 100%;
        }
        .auto-style2 {
            margin-top: 12px;
      
             margin-left: 54px;
             
        }
        .auto-style3 {
           
             margin-left: 78px;
              margin-top: 12px;
        }
        .auto-style5 {
            margin-left: 71px;
             margin-top: 12px;
        }
        .auto-style6 {
            margin-left: 32px;
        }
         .auto-style7 {
            text-a
        }
           .auto-style8 {
            float:left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: chocolate" class="auto-style1">
        <div>  
        <div style="display: table; " class="auto-style8">
            <table>
                <tr>
                     <td>  <asp:Label ID="lblTitle" runat="server" Text="Label" CssClass="auto-style7"></asp:Label> </td>
                  
                </tr>
                  <tr>
                     <td>  <asp:Literal ID="Video" runat="server" ></asp:Literal> </td>
                </tr>

                    <tr>
                     
                    <td>  <asp:TextBox ID="overview" runat="server" TextMode="MultiLine" Height="178px" Width="534px"></asp:TextBox>
                        <br />
                    </td>
                </tr>

            </table>
        </div>
        
               
        
         <div style="display: table; " class="auto-style8">
             <table>
                  <div>
                 <tr>
                      
                    <td>  Original_language <asp:TextBox ID="language" runat="server" CssClass="auto-style6" Width="159px"></asp:TextBox> </td>
                </tr>
        </div>
         <div>
                 <tr>
                    
                    <td>  Release_date" <asp:TextBox ID="date" runat="server" CssClass="auto-style2" Width="156px"></asp:TextBox> </td>
                </tr>
        </div>
         <div>
                 <tr>
                     
                    <td> Popularity
                        <asp:TextBox ID="popularity" runat="server" CssClass="auto-style3" Width="158px"></asp:TextBox> </td>
                </tr>
        </div>
         <div>
                 <tr>
                     
                    <td>Vote_average  
                        <asp:TextBox ID="Vote_average" runat="server" CssClass="auto-style2" Width="156px"></asp:TextBox> </td>
                </tr>
        </div>
         <div>
                 <tr> <td>
                     Vote_count 
                        <asp:TextBox ID="vote_count" runat="server" CssClass="auto-style5" Height="17px" Width="155px"></asp:TextBox> </td>
                </tr>
        </div>


                 </table>
        </div>
            </div>
        
       
      
       
       
      
    </form>
</body>
</html>
