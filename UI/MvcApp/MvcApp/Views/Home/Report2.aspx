<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="DevExpress.Web.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v12.1.Web, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Report2</title>
</head>
<body runat="server">
    <form id="form1" runat="server">
    <div>
        <dx:ReportToolbar ID="ReportToolbar1" runat='server' ShowDefaultButtons='False' 
            ReportViewerID="ReportViewer1">
            <Items>
                <dx:ReportToolbarButton ItemKind='SaveToDisk' />
                <dx:ReportToolbarButton ItemKind='SaveToWindow'  />
                <dx:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                    <Elements>
                        <dx:ListElement Value='pdf' />
                        <dx:ListElement Value='xls' />
                        <dx:ListElement Value='xlsx' />
                        <dx:ListElement Value='rtf' />
                        <dx:ListElement Value='mht' />
                        <dx:ListElement Value='html' />
                        <dx:ListElement Value='txt' />
                        <dx:ListElement Value='csv' />
                        <dx:ListElement Value='png' />
                    </Elements>
                </dx:ReportToolbarComboBox>
            </Items>
            <Styles>
                <LabelStyle>
                    <Margins MarginLeft='3px' MarginRight='3px' />
                </LabelStyle>
            </Styles>
        </dx:ReportToolbar>
        <br />
        <dx:ReportViewer ID="ReportViewer1" runat="server" 
            Report="<%# new MvcApp.Report.XtraReport1() %>" 
            ReportName="MvcApp.Report.XtraReport1">
        </dx:ReportViewer>
        <%
             
             %>
    </div>
    <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server" Width="280px" 
        Theme="Aqua" >
    </dx:ASPxUploadControl>

    <input type=button value=选择路径 onclick='javascript: alert(new ActiveXObject("Shell.Application").BrowseForFolder(0, "请选择路径", 0, "").Items().Item().Path)'>
    </form>
</body>
</html>
