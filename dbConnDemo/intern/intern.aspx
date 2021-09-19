<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="intern.aspx.cs" Inherits="dbConnDemo.intern.intern" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <link href="../style/form.css" rel="stylesheet" />
<table class="nav-justified" style="height: 352px">
 
    <tr>
        <td colspan="2" style="height: 63px">
            <asp:Label ID="lblOutput" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style1" style="width: 596px">Intern Id</td></tr>
        <tr>
        <td class="auto-style2" style="height: 58px">
            <asp:TextBox class="auto-style" ID="txtInternId" runat="server"  Font-Size="18pt" Height="23px"></asp:TextBox>
        </td>
            </tr>
    
    <tr>
        <td class="auto-style1" style="width: 596px">First Name English</td>
        </tr>
    <tr>
          <td class="auto-style2" style="height: 60px">  <asp:TextBox ID="txtFnameEn" runat="server"  Font-Size="18pt" Height="23px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1" style="width: 596px">First Name Arabic </td></tr>
       <tr><td class="auto-style2" style="height: 55px">
            <asp:TextBox ID="txtFnameAr" runat="server" Font-Size="18pt" Height="23px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1" style="width: 596px">
             Date of Birth
        </td></tr>
        <tr>
            <td  class="auto-style2">

                <asp:TextBox ID="txtDateOfBirth" runat="server" Height="23px" Width="216px" ></asp:TextBox>
                <asp:ImageButton ID="ImageBDateOfBirth" runat="server" Height="23px" ImageUrl="~/image/Calendar1.jpg" OnClick="ImageBDateOfBirth_Click" Width="26px" />
                <asp:Calendar ID="CalendarDateOfBirth" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" OnSelectionChanged="CalendarDateOfBirth_SelectionChanged">
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>

        </td>
    </tr>
    <tr>
        <td class="auto-style1" style="width: 596px">Country</td></tr>
      <tr>  <td class="auto-style2" style="height: 55px">
            <asp:DropDownList ID="ddlCountry" runat="server"  Font-Size="18pt" Height="23px" Width="226px" >
            </asp:DropDownList></td></tr>
    
    
    <tr>
        <td class="auto-style1" style="width: 596px">Salary</td></tr>
        <tr><td class="auto-style2" style="height: 60px">
            <asp:TextBox ID="txtSalary" runat="server" Font-Size="18pt" Height="23px"></asp:TextBox>
            
           
        </td></tr>
      <tr>
        <td class="auto-style1" style="width: 596px">upload training request letter</td></tr>
        <tr><td class="auto-style2" style="height: 60px">
            <asp:FileUpload ID="FileUpdate" runat="server" />
            <asp:Button ID="btnUploadFile" runat="server" Height="27px" OnClick="btnUploadFile_Click" style="margin-bottom: 0" Text="upload file" Width="101px" />
            
           
        </td></tr>
    
    <tr>
        <td class="auto-style1" style="width: 596px">Active</td></tr>
       <tr> <td class="auto-style2" style="height: 98px">
                <asp:RadioButtonList ID="rblActive" runat="server"  Font-Size="18pt" Width="81px">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
        </td></tr>
    
    <tr>
        <td class="auto-style1" style="width: 596px">Hobbies</td></tr>
        <tr><td class="auto-style2" style="height: 63px">
            <asp:CheckBoxList ID="cblHobbies" runat="server" Font-Size="18pt" RepeatDirection="Horizontal" >
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        
        <td colspan="2" style="height: 87px">
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" Height="45px" BackColor="Cyan" BorderColor="White" BorderStyle="None" Font-Bold="True" Font-Size="18pt" ForeColor="White" Width="100px" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" BackColor="Fuchsia" BorderColor="White" Font-Bold="True" Font-Size="18pt" ForeColor="White" Height="45px" Width="100px" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" BackColor="Red" BorderColor="White" Font-Bold="True" Font-Italic="False" Font-Size="18pt" ForeColor="White" Height="45px"  Width="100px"/>
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" BackColor="#9966FF" Font-Bold="True" Font-Size="18pt" ForeColor="White" Height="45px" style="margin-bottom: 8"  Width="100px" />
            </td></tr>

          <tr>
              <td colspan="2"> <asp:Button ID="btnShowData" runat="server" Text="Show Data" OnClick="btnShowData_Click" BackColor="#CCFF66" Font-Bold="True" Font-Size="18pt" ForeColor="White"  Width="153px" Height="45px" />
            <asp:Button ID="btnShowIntern" runat="server" OnClick="btnShowIntern_Click" Text="Show Intern" BackColor="#996600" Font-Bold="True" Font-Size="18pt" ForeColor="White"  Width="171px" Height="45px" style="margin-right: 77" />
            
          

        </td>
    </tr>
</table>
    <table>
    <tr><td>
             <asp:GridView ID="gvIntern" runat="server" Font-Bold="True" Font-Size="18pt" style="margin-top: 63px" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                 
                 <FooterStyle BackColor="White" ForeColor="#000066" />
                 <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                 <RowStyle ForeColor="#000066" />
                 <SelectedRowStyle BackColor="#669999" BorderStyle="Double" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                 <SortedAscendingHeaderStyle BackColor="#007DBB" />
                 <SortedDescendingCellStyle BackColor="#CAC9C9" />
                 <SortedDescendingHeaderStyle BackColor="#00547E" />
                 <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="intern Info">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkupdate" runat="server"  
                                        CommandArgument='<%# Bind("internId") %>' OnClick="populateForm_Click"
                                        Text='<%# Eval("InternId")  %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left"></ItemStyle>
                            </asp:TemplateField>
                     </Columns>
            </asp:GridView></td></tr>
           <tr><td style="width: 707px"> <asp:GridView ID="gvInternHobby" runat="server" CellPadding="4" CssClass="auto-style6" ForeColor="#333333" GridLines="None" Width="407px">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle Font-Bold="True" Font-Size="24pt" BackColor="#FFCC66" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView></td>
        </tr>
   </table>

    
</asp:Content>
