<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DegreeAdd.aspx.cs" Inherits="DegreeAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    年份
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlYear" 
                        onselectedindexchanged="ddlYear_SelectedIndexChanged">
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
                    <asp:DropDownList runat="server" ID="ddlMon" AutoPostBack="true"
                        onselectedindexchanged="ddlMon_SelectedIndexChanged">
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
                    价格：（吨/元）
                </td>
                <td>
                    <asp:Label runat="server" ID="lbPrice"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    上月吨位
                </td>
                <td>
                    <asp:Label runat="server" ID="lbPreviousDegrss"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    当月吨位
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbDegree"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rvtbdegree" ControlToValidate="tbDegree" ErrorMessage="*" ></asp:RequiredFieldValidator>
                    <asp:RangeValidator runat="server" ID="rfvdegree" ControlToValidate="tbDegree" 
                        Type="Double" ErrorMessage="*" MinimumValue="0"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnAdd" Text="添加" OnClick="btnAdd_Click" /><input
                        type="button" value="取消" onclick="window.close();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
