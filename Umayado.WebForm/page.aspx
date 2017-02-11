<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="page.aspx.vb" Inherits="Umayado.WebForm.page" %>

<%@ Register Assembly="Umayado.WebForm" Namespace="Umayado.WebForm" TagPrefix="cc1" %>

<%@ Register src="ViewSwitcher.ascx" tagname="ViewSwitcher" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ViewSwitcher ID="ViewSwitcher1" runat="server" />
        <div class="body">
            <cc1:RenderPane ID="RenderPane1" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
