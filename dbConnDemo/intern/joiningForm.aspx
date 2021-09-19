<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="joiningForm.aspx.cs" Inherits="dbConnDemo.intern.joiningForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent"  runat="server">
    <link href="../style/form.css" rel="stylesheet" />
           <table class="nav-justified" style="height: 352px">
 
    <tr>
        <td colspan="2" style="height: 63px">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style1" style="width: 67%">Intern Id</td>
        <td class="auto-style2" style="height: 58px">
            <asp:TextBox  ID="txtInternId" runat="server" Font-Bold="True" Font-Size="18pt" Height="22px" Width="155px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1" style="width: 67%">First Name </td>
        <td class="auto-style2" style="height: 60px">
            <asp:TextBox ID="txtFirstName" runat="server" Font-Bold="True" Font-Size="18pt" Height="22px" Width="155px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1" style="width: 67%">&nbsp;middle Name </td>
        <td class="auto-style2" style="height: 55px">
            <asp:TextBox ID="txtMiddleName" runat="server" Font-Bold="True" Font-Size="18pt" Height="22px" Width="155px"></asp:TextBox>
        </td>
    </tr>
               <tr>
        <td class="auto-style1" style="width: 67%"> last Name </td>
        <td class="auto-style2" style="height: 55px">
            <asp:TextBox ID="txtLastName" runat="server" Font-Bold="True" Font-Size="18pt" Height="22px" Width="155px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1" style="width: 67%">choose your major</td>
        <td class="auto-style2" style="height: 55px">
            <asp:DropDownList ID="ddlInternMajor" runat="server" Font-Size="18pt" Height="22px" Width="155px">
            </asp:DropDownList>
        </td>
    </tr>
                <tr>
        <td class="auto-style1" style="width: 67%">choose your training departmnet</td>
        <td class="auto-style2" style="height: 55px">
            <asp:DropDownList ID="ddlDepartmnetName" runat="server" Font-Size="18pt" Height="22px" Width="155px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style1" style="width: 67%">choose training start date</td>
        <td class="auto-style2" style="height: 60px">
            <asp:TextBox ID="txtStartDate" runat="server" Font-Bold="True" Font-Size="18pt" Height="22px" Width="155px"></asp:TextBox> <asp:ImageButton ID="ImageBtnStartDate" runat="server" Height="26px" ImageUrl="~/image/Calendar1.jpg" OnClick=" ImageBtnStartDate_Click" />
            <asp:Calendar ID="CalendarStartDate" runat="server" OnSelectionChanged="CalendarStartDate_SelectionChanged"></asp:Calendar>
           
           
           
        </td>
    </tr>
                   
    <tr>
        <td class="auto-style1" style="width: 67%">choose training end date</td>
        <td class="auto-style2" style="height: 60px">
            <asp:TextBox ID="txtEndDate" runat="server" Font-Bold="True" Font-Size="18pt" Height="22px" Width="155px"></asp:TextBox><asp:ImageButton ID="ImageBtnEndDate" runat="server" Height="24px" ImageUrl="~/image/Calendar1.jpg" OnClick="ImageBtnEndDate_Click" />
            <asp:Calendar ID="CalendarEndDate" runat="server" OnSelectionChanged="CalendarEndDate_SelectionChanged"></asp:Calendar>
           
           
&nbsp;
           
        </td>
       
    
   
    <tr>
        
        <td colspan="2" style="height: 87px">
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert"  BackColor="Cyan" BorderColor="White" BorderStyle="None"  Font-Size="16pt" ForeColor="White" Width="115px"/>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" BackColor="Fuchsia" BorderColor="White" BorderStyle="None"  Font-Size="16pt" ForeColor="White" Width="115px"/>
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" BackColor="Red" BorderColor="White"   Font-Size="16pt" ForeColor="White" Width="115px"/></td></tr>

          <tr>
              <td colspan="2"> <asp:Button ID="btnShowData" runat="server" Text="Show Data" OnClick="btnShowData_Click" BackColor="#CCFF66"   ForeColor="White"   Font-Size="16pt"  Width="115px" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" BackColor="#9966FF"   ForeColor="White"   Font-Size="16pt" Width="115px" />
           
            
          

                  <asp:Button ID="btnShowIntern2Data" runat="server" Text="show intern" BackColor="green" ForeColor="White"   Font-Size="16pt"  Width="115px" OnClick="btnShowIntern2Data_Click" />
           
            
          

        </td>
    </tr>
</table>
    <table>
    <tr><td>
             <asp:GridView ID="gvIntern2" runat="server" Font-Bold="True" Font-Size="18pt"  ForeColor="Black" GridLines="Horizontal"  BorderWidth="1px" CellPadding="4" Height="207px" style="margin-right: 100; margin-top: 0" Width="518px">
                 <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                 <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                 <SelectedRowStyle BackColor="#CC3333" BorderStyle="Double" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F7F7F7" />
                 <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                 <SortedDescendingCellStyle BackColor="#E5E5E5" />
                 <SortedDescendingHeaderStyle BackColor="#242121" />
                    <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="intern Infomation">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkupdate2" runat="server"  
                                        CommandArgument='<%# Bind("intern2Id") %>' OnClick="populateForm2_Click"
                                        Text='<%# Eval("Intern2Id")  %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left"></ItemStyle>
                            </asp:TemplateField>
                     </Columns>
            </asp:GridView></td></tr>
        <tr>
          <td>

              <br />
              <br />
              <br />
              <asp:GridView ID="gvViewIntern2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="207px" style="margin-right: 100; margin-top: 0" Width="518px">
                  <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                  <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                  <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                  <RowStyle BackColor="White" ForeColor="#003399" />
                  <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                  <SortedAscendingCellStyle BackColor="#EDF6F6" />
                  <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                  <SortedDescendingCellStyle BackColor="#D6DFDF" />
                  <SortedDescendingHeaderStyle BackColor="#002876" />
                
              </asp:GridView>
              <br />

          </td>  
    </tr>
          
        
   </table>

</asp:Content>
