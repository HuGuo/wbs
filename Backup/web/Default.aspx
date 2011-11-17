<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <label>
            搜索：</label><asp:DropDownList runat="server" ID="ddlType">
                <asp:ListItem Value="0">请选择</asp:ListItem>
                <asp:ListItem Value="1">姓名</asp:ListItem>
                <asp:ListItem Value="2">编号</asp:ListItem>
            </asp:DropDownList>
        <asp:TextBox runat="server" ID="tbValue"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" Text="查询" OnClick="btnSearch_Click" />
        <div>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                DataSourceID="ObjectDataSource1" AllowPaging="True" AllowSorting="True" BackColor="White"
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black"
                GridLines="Vertical">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%# Eval("id") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lbId" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="code" HeaderText="编号">
                        <ItemTemplate>
                            <%# Eval("code") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lbCode" runat="server" Text='<%# Bind("code") %>'></asp:Label>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox runat="server" ID="tbName" Text='<%# Bind("name") %>'></asp:TextBox>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <%# Eval("name") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="tbName" Text='<%# Bind("name") %>'>
                            </asp:TextBox>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox runat="server" ID="tbName" Text='<%# Bind("name") %>'></asp:TextBox>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="缴费记录">
                        <ItemTemplate>
                            <a href="">缴费记录</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="编辑">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbtnUpdate" CommandName="Insert" Text="保存"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbtnEdit" Text="编辑" CommandName="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton runat="server" ID="lbtnEdit" Text="保存" CommandName="Update"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="LinkButton1" Text="取消" CommandName="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbtnDel" OnClientClick="confirm('是否删除？')" Text="删除"
                                CommandName="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="#CCCCCC" />
            </asp:GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Wbs.Entity.User"
            DeleteMethod="Del" InsertMethod="Add" SelectMethod="Get" TypeName="Wbs.BLL.BLLUser"
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
        &nbsp;&nbsp;
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
        </asp:DetailsView>
    </form>
</body>
</html>
