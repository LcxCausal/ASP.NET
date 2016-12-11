<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Test1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        数据表：<asp:TextBox ID="txtTableName" runat="server"></asp:TextBox>
        <asp:Button ID="btnShowTableData" runat="server" Text="查询" onclick="btnShowTableData_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
            DataKeyNames="stuid" >
            
            <Columns>
                <asp:BoundField DataField="stuid" HeaderText="学号"/>
                <asp:BoundField DataField="stuname" HeaderText="姓名" />
                <asp:BoundField DataField="stusex" HeaderText="性别" />

                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <%#Showsex(Eval("stusex"))%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br /><br />

        <asp:GridView ID="gvwTableData" runat="server" AllowPaging="True" 
            onpageindexchanging="gvwTableData_PageIndexChanging" PageSize="6">
            <PagerSettings FirstPageText="首页" LastPageText="末页" 
                Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
