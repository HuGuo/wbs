var hkey_root, hkey_path, hkey_key
hkey_root = "HKEY_CURRENT_USER"
hkey_path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\"
//设置网页打印的页眉页脚为空
function pagesetup_null() {
    try {
        var RegWsh = new ActiveXObject("WScript.Shell")
        hkey_key = "header"
        RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "")
        hkey_key = "footer"
        RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "")
    } catch (e) { }
}
//设置网页打印的页眉页脚为默认值
function pagesetup_default() {
    try {
        var RegWsh = new ActiveXObject("WScript.Shell")
        hkey_key = "header"
        RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&w&b页码，&p/&P")
        hkey_key = "footer"
        RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "&u&b&d")
    } catch (e) { }
}
function setdivhidden(id) {//把指定id以外的层统统隐藏
    var divs = document.getElementById(id).previousSibling.previousSibling;
    divs.style.display = "none";
}
function setdivvisible(id) {//把指定id以外的层统统显示
    var divs = document.getElementById(id).previousSibling.previousSibling;
    divs.style.display = "block";
}
function printpr(dvList) //预览函数
{
    pagesetup_null(); //预览之前去掉页眉，页脚
    setdivhidden(dvList); //打印之前先隐藏不想打印输出的元素

    var WebBrowser = '<OBJECT ID="WebBrowser1" WIDTH=0 HEIGHT=0 CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></OBJECT>';
    document.body.insertAdjacentHTML('beforeEnd', WebBrowser); //在body标签内加入html（WebBrowser activeX控件）
    WebBrowser1.ExecWB(7, 1); //打印预览
    WebBrowser1.outerHTML = ""; //从代码中清除插入的html代码
    pagesetup_default(); //预览结束后页眉页脚恢复默认值
    setdivvisible(dvList); //预览结束后显示按钮
}
function print(dvList) //打印函数
{
    pagesetup_null(); //打印之前去掉页眉，页脚
    setdivhidden(dvList); //打印之前先隐藏不想打印输出的元素

    var WebBrowser = '<OBJECT ID="WebBrowser1" WIDTH=0 HEIGHT=0 CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></OBJECT>';
    document.body.insertAdjacentHTML('beforeEnd', WebBrowser); //在body标签内加入html（WebBrowser activeX控件）
    WebBrowser1.ExecWB(6, 1); //打印
    WebBrowser1.outerHTML = ""; //从代码中清除插入的html代码
    pagesetup_default(); //打印结束后页眉页脚恢复默认值
    setdivvisible(dvList); //打印结束后显示按钮
}

function GetHtmlToOffice(excelOrWord, copyElementId) {
    switch (excelOrWord) {
        case "Excel":
            GetHtmlToExecl(copyElementId);
            break;
        case "Word":
            GetHtmlToWord(copyElementId);
            break;
    }
}

function GetHtmlToExecl(tableid) {
    var curTbl = document.getElementById(tableid);
    var oXL = new ActiveXObject("Excel.Application");
    var oWB = oXL.Workbooks.Add();
    var oSheet = oWB.ActiveSheet;
    var sel = document.body.createTextRange();
    sel.moveToElementText(curTbl);
    sel.execCommand("Copy");
    oSheet.Paste();
    oXL.Visible = true;
}

function GetHtmlToWord(tableid) {
    var curTbl = document.getElementById(tableid);
    var oWD = new ActiveXObject("Word.Application");
    var oDC = oWD.Documents.Add("", 0, 1);
    var oRange = oDC.Range(0, 1);
    var sel = document.body.createTextRange();
    sel.moveToElementText(curTbl);
    sel.execCommand("Copy");
    oRange.Paste();
    oWD.Application.Visible = true;
}

function CallPrint(callElementId) {
    var prtContent = document.getElementById(callElementId);
    var WinPrint = window.open('', '', 'letf=0,top=0,toolbar=0,resizable=yes,scrollbars=0,status=0,menubar=0');
    WinPrint.document.write(prtContent.innerHTML);
    WinPrint.document.close();
    WinPrint.focus();
    WinPrint.print();
    WinPrint.close();
}

