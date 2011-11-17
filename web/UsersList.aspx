<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersList.aspx.cs" Inherits="UsersList"
    Theme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <label>
        搜索：</label><asp:DropDownList runat="server" ID="ddlType">
            <asp:ListItem Value="0">姓名</asp:ListItem>
            <asp:ListItem Value="1">编号</asp:ListItem>
        </asp:DropDownList>
    <asp:TextBox runat="server" ID="tbValue"></asp:TextBox>
    <asp:Button runat="server" ID="btnSearch" Text="查询" OnClick="btnSearch_Click" />
    <input type="button" value="添加用户" onclick="window.open('UserAdd.aspx','newwindow','height=150,width=400,top=0,left=0,toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no') " />
    <input type="button" value="价格管理" onclick="window.open('Pricelist.aspx') " />
    <input type="button" value="水汇总" onclick="window.open('DegreeYearList.aspx')" />
    <input type="button" value="电费汇总" onclick="window.open('DegreeYearPayforList.aspx')" />
    <input type="button" value="打印汇总" onclick="window.open('DegreeList.aspx')" />
    <div>
        <asp:GridView ID="gvName" runat="server" DataKeyNames="id" SkinID="gvSkin" AutoGenerateColumns="False"
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lbId" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderStyle Width="40" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="code" HeaderText="编号">
                    <ItemTemplate>
                        <%# Eval("code") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbCode" runat="server" Text='<%# Bind("code") %>' Width="40"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvCode" ControlToValidate="tbCode" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <HeaderStyle Width="60" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <ItemTemplate>
                        <%# Eval("name") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="tbName" Text='<%# Bind("name") %>' Width="60">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvName" ControlToValidate="tbName"
                            ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <HeaderStyle Width="100" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="地址">
                    <ItemTemplate>
                        <%# Eval("address") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="tbAddress" Text='<%# Bind("address") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="缴费记录">
                    <ItemTemplate>
                        <a href="UserDegreeList.aspx?userId=<%# Eval("id") %>" target="_blank">缴费记录</a>
                    </ItemTemplate>
                    <HeaderStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="编辑">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnEdit" Text="编辑" CommandName="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnSave" Text="保存" CommandName="Update"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtnCancel" Text="取消" CommandName="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <HeaderStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnDel" OnClientClick="return confirm('是否删除？')"
                            Text="删除" CommandName="Delete"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="40" />
                </asp:TemplateField>
            </Columns>
            <PagerSettings FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PreviousPageText="上一页"
                Mode="NextPreviousFirstLast" />
        </asp:GridView>
        <asp:GridView ID="gvCode" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2"
            SkinID="gvSkin">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lbId0" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderStyle Width="40" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="code" HeaderText="编号">
                    <ItemTemplate>
                        <%# Eval("code") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbCode" runat="server" Text='<%# Bind("code") %>' Width="40"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvCode" ControlToValidate="tbCode" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <HeaderStyle Width="60" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <ItemTemplate>
                        <%# Eval("name") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="tbName" Text='<%# Bind("name") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvName" ControlToValidate="tbName"
                            ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <HeaderStyle Width="100" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="地址">
                    <ItemTemplate>
                        <%# Eval("address") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="tbAddress" Text='<%# Bind("address") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="缴费记录">
                    <ItemTemplate>
                        <a href="UserDegreeList.aspx?userId=<%# Eval("id") %>" target="_blank">缴费记录</a>
                    </ItemTemplate>
                    <HeaderStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="编辑">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnEdit1" Text="编辑" CommandName="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnSave" Text="保存" CommandName="Update"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtnCancel" Text="取消" CommandName="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <HeaderStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnDel0" OnClientClick="return confirm('是否删除？')"
                            Text="删除" CommandName="Delete"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="40" />
                </asp:TemplateField>
            </Columns>
            <PagerSettings FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PreviousPageText="上一页"
                Mode="NextPreviousFirstLast" />
        </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Wbs.Entity.User"
        DeleteMethod="Del" InsertMethod="Add" SelectMethod="GetByName" TypeName="Wbs.BLL.BLLUser"
        UpdateMethod="Update">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbValue" Name="name" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="Wbs.Entity.User"
        DeleteMethod="Del" InsertMethod="Add" SelectMethod="GetByCode" TypeName="Wbs.BLL.BLLUser"
        UpdateMethod="Update">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbValue" Name="code" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
