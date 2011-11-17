<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DegreeYearList.aspx.cs" Inherits="DegreeYearList"
    StylesheetTheme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Script/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList runat="server" ID="ddlYear">
            <asp:ListItem Value="2010">2010</asp:ListItem>
            <asp:ListItem Value="2011">2011</asp:ListItem>
            <asp:ListItem Value="2012">2012</asp:ListItem>
            <asp:ListItem Value="2013">2013</asp:ListItem>
            <asp:ListItem Value="2014">2014</asp:ListItem>
        </asp:DropDownList>
        年
        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
        <input value="导出到excel" type="button" onclick="GetHtmlToOffice('Excel','dvList')" />
        <input type="button" value="关闭" onclick="window.close();" />
        <br />
        <div id="dvList">
            <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false" Width="100%"
                AllowPaging="false" SkinID="gvSkin">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <ItemStyle Width="40" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <%# Eval("name") %>
                        </ItemTemplate>
                        <ItemStyle Width="60" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="1月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon1") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="2月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon2")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="3月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon3")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="4月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon4")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="5月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon5")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="6月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon6")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="7月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon7")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="8月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon8")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="9月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon9")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="10月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon10")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="11月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon11")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="12月(吨)">
                        <ItemTemplate>
                            <%# Eval("mon12")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
