<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserDegreeList.aspx.cs" Inherits="UserDegreeList"
    Theme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Script/Common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="关闭" onclick="window.close();" />
        <input type="button" value="添加" onclick="window.open('DegreeAdd.aspx?userid=<%= Request.QueryString["userid"] %>','newwindow','height=200,width=400,top=0,left=0,toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no')" />
        <input type="button" value="打印预览" onclick="printpr('dvList')" />
        <input type="button" onclick="print('dvList')" value="打印" />
    </div>
    <div id="dvList">
        <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false" SkinID="gvSkin">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ItemStyle Width="40" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="年">
                    <ItemTemplate>
                        <%# Eval("price.yearvalue") %>
                    </ItemTemplate>
                    <ItemStyle Width="40" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="月">
                    <ItemTemplate>
                        <%# Eval("price.mon") %>
                    </ItemTemplate>
                    <ItemStyle Width="40" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="价格（吨/元）">
                    <ItemTemplate>
                        <%# Eval("price.pricevalue") %>
                    </ItemTemplate>
                    <ItemStyle Width="120" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="上月吨位">
                    <ItemTemplate>
                        <%# GetPreviousDegree(Eval("userId").ToString(),Eval("price.yearvalue").ToString(),Eval("price.mon").ToString())%>
                    </ItemTemplate>
                    <ItemStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="当月吨位">
                    <ItemTemplate>
                        <%# Eval("degreevalue") %>
                    </ItemTemplate>
                    <ItemStyle Width="80" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                        <%# Eval("degreevalue") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="打印">
                    <ItemTemplate>
                        <a onclick="window.open('DegreePerson.aspx?userid=<%# Eval("userId") %>&year=<%# Eval("price.yearvalue")%>&mon=<%# Eval("price.mon")%>','newwindow','height=200,width=500,top=0,left=0,toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no') "
                            href="#">打印</a>
                    </ItemTemplate>
                    <ItemStyle Width="80" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
