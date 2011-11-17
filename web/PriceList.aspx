<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PriceList.aspx.cs" Inherits="PriceList"
    Theme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="添加" onclick="window.open('PriceAdd.aspx','newwindow','height=200,width=400,top=0,left=0,toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no') " />
        <input type="button" value="关闭" onclick="window.close();" />
        <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False" SkinID="gvSkin"
            DataKeyNames="id" DataSourceID="ObjectDataSource1" EnableModelValidation="True">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label runat="server" ID="lbId" Text='<%# Bind("id") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderStyle Width="40" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="年份">
                    <ItemTemplate>
                        <%# Eval("yearValue")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="tbYear" Text='<%# Bind("yearValue") %>' Width="60"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvYear" ControlToValidate="tbYear"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rfvTbyear" ControlToValidate="tbYear" Display="Dynamic"
                            ValidationExpression="^20[12][0-9]$" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <HeaderStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="月份">
                    <ItemTemplate>
                        <%# Eval("mon") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="tbMon" Text='<%# Bind("mon") %>' Width="60"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvMon" ControlToValidate="tbMon"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rpvTbmon" ControlToValidate="tbMon" Display="Dynamic"
                            ValidationExpression="^([1-9])|([1][012])$" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <HeaderStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="价格">
                    <ItemTemplate>
                        <%#  Eval("priceValue")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="tbPrice" Text='<%# Bind("priceValue") %>' Width="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvPrice" ControlToValidate="tbPrice"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="revPrice" ControlToValidate="tbPrice"
                            Display="Dynamic" ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="请输入数字"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <HeaderStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                        <%#  Eval("remark")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="tbRemark" Text='<%# Bind("remark") %>' Width="100%"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="编辑">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnEdit" CommandName="Edit" Text="编辑" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnSave" Text="保存" OnClick="lbtnSave_Click"></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtnCancel" Text="取消" CommandName="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <HeaderStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDel" CommandName="delete" OnClientClick="return confirm('是否删除？')"
                            Text="删除" />
                    </ItemTemplate>
                    <HeaderStyle Width="40" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Wbs.Entity.Price"
        DeleteMethod="Del" InsertMethod="Add" SelectMethod="Get" TypeName="Wbs.BLL.BLLPrice"
        UpdateMethod="Update"></asp:ObjectDataSource>
    </form>
</body>
</html>
