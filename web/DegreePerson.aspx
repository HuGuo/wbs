<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DegreePerson.aspx.cs" Inherits="DegreePerson"
    Theme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Script/Common.js"></script>
    <style type="text/css">
        alignLeft
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divNoShow">
        <input type="button" value="打印预览" onclick="printpr('dvList')" />
        <input type="button" onclick="print('dvList')" value="打印" />
        <input type="button" onclick="window.close()" value="关闭" />
        <br />
    </div>
    <div id="dvList" style="text-align: center;">
        <table border="1px" width="" cellspacing="0" style="border-collapse: collapse; border-color: Black;">
            <tr>
                <td width="50px">
                    编号：
                </td>
                <td width="40px"><asp:Label runat="server" ID="tbCode"></asp:Label>
                    
                </td>
                <td width="50px">
                    姓名:
                </td>
                <td><asp:Label runat="server" ID="tbName"></asp:Label>
                </td>
                <td width="50px">
                    年份：
                </td>
                <td><asp:Label runat="server" ID="tbYear"></asp:Label>
                </td>
                <td width="50px">
                    月份：
                </td>
                <td><asp:Label runat="server" ID="tbMon"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    地址:
                </td>
                <td colspan="7"><asp:Label runat="server" ID="tbAddress"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    上月：
                </td>
                <td width="60px"><asp:Label runat="server" ID="tbLastdegreevalue"></asp:Label>
                </td>
                <td>
                    当月：
                </td>
                <td width="60px"><asp:Label runat="server" ID="tbDegreevalue"></asp:Label>
                </td>
                <td>
                    价格：
                </td>
                <td width="60px"><asp:Label runat="server" ID="tbPricevalue"></asp:Label>
                </td>
                <td>
                    金额：
                </td>
                <td width="60px"><asp:Label runat="server" ID="tbPayfor"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="8" style="text-align: left; vertical-align: top; height: 50px;">
                    备注：<asp:Label runat="server" ID="tbRemark"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
