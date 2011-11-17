<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PriceAdd.aspx.cs" Inherits="PriceAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加电价</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="width: 80px;">
                    年份
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlYear">
                        <asp:ListItem Value="2010">2010</asp:ListItem>
                        <asp:ListItem Value="2011">2011</asp:ListItem>
                        <asp:ListItem Value="2012">2012</asp:ListItem>
                        <asp:ListItem Value="2013">2013</asp:ListItem>
                        <asp:ListItem Value="2014">2014</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    月份
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlMon">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    价格
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbPrice"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="tbPrice"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="revPrice" ControlToValidate="tbPrice" Display="Dynamic"
                         ValidationExpression="^\d+(\.\d+)?$" ErrorMessage="请输入数字"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    备注
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbRemark" Text="请居民用户于每页22号以前交情电费"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnAdd" Text="添加" OnClick="btnAdd_Click"  /><input
                        type="button" value="取消" onclick="window.close();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
