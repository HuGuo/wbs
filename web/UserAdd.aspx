<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAdd.aspx.cs" Inherits="UserAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加用户</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    编号
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbCode"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    姓名
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbName"
                        ErrorMessage="必须填写姓名"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    地址
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbAddress"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnAdd" Text="添加" OnClick="btnAdd_Click" /><input
                        type="button" value="取消" onclick="window.close();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
