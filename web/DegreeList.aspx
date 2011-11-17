<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DegreeList.aspx.cs" Inherits="DegreeList"
    Theme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Script/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divNoShow">
        <asp:DropDownList runat="server" ID="ddlYear">
            <asp:ListItem Value="2010">2010</asp:ListItem>
            <asp:ListItem Value="2011">2011</asp:ListItem>
            <asp:ListItem Value="2012">2012</asp:ListItem>
            <asp:ListItem Value="2013">2013</asp:ListItem>
            <asp:ListItem Value="2014">2014</asp:ListItem>
        </asp:DropDownList>
        年
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
        月
        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
        <input type="button" value="打印预览" onclick="printpr('dvList')" />
        <input type="button" onclick="print('dvList')" value="打印" />
        <input type="button" onclick="window.close();" value="关闭" />
        <br />
    </div>
    <div id="dvList" style="text-align: center;">
        <asp:DataList ID="dlList" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
            <ItemTemplate>
                <%# ((Container.ItemIndex + 1) % 10 == 1 || (Container.ItemIndex + 1) % 10 == 2)&&Container.ItemIndex!=0&&Container.ItemIndex!=1 ? "<div style='page-break-after: always;'></div>" : ""%>
                <table border="1px" width="" cellspacing="0" style="border-collapse: collapse; border-color: Black; margin-bottom:10px; margin-right:6px;">
                    <tr>
                        <td width="50px">
                            编号：
                        </td>
                        <td width="40px">
                            <%# Eval("code") %>
                        </td>
                        <td width="50px">
                            姓名:
                        </td>
                        <td>
                            <%# Eval("name") %>
                        </td>
                        <td width="50px">
                            年份：
                        </td>
                        <td>
                            <%# ddlYear.SelectedValue %>
                        </td>
                        <td width="50px">
                            月份：
                        </td>
                        <td>
                            <%# ddlMon.SelectedValue %>
                        </td>
                    </tr>
                    <tr>
                        <td>地址：
                        </td>
                        <td colspan="7">
                            <%# Eval("address") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            上月：
                        </td>
                        <td width="60px">
                            <%# Eval("lastdegreevalue") %>
                        </td>
                        <td>
                            当月：
                        </td>
                        <td width="60px">
                            <%# Eval("degreevalue")%>
                        </td>
                        <td>
                            价格：
                        </td>
                        <td width="60px">
                            <%# Eval("pricevalue") %>
                        </td>
                        <td>
                            金额：
                        </td>
                        <td width="60px">
                            <%# GetDegreeValue(Eval("degreevalue").ToString(), Eval("lastdegreevalue").ToString(), Eval("pricevalue").ToString())%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" style="text-align: left; vertical-align: top; height: 50px;">
                            备注：<%# Eval("remark") %>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList></div>
    </form>
</body>
</html>
