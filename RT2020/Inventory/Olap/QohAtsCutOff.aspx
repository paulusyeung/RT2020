<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QohAtsCutOff.aspx.cs" Inherits="RT2020.Inventory.Olap.QohAtsCutOff" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraPivotGrid.Web" tagprefix="dxpgw" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin: 0">
    <form id="form1" runat="server">
    <div runat="server" id="divOptions" visible="false">
        <div style="background-color: transparent; font: 10pt Tahoma; border-right: 0; border-top: 0;
            border-left: 0; padding: 6px 10px 6px 10px;">
            <asp:Label ID="lblStkcodeTitle" runat="server" Text="STKCODE">
            </asp:Label><br />
            <asp:Label ID="lblSTKCODE_From" runat="server" Text="From:">
            </asp:Label>
            <asp:TextBox runat="server" Width="80px" ID="txtSTKCODE_From">
            </asp:TextBox>
            <asp:Label ID="lblSTKCODE_To" runat="server" Text="To:">
            </asp:Label>
            <asp:TextBox runat="server" Width="80px" ID="txtSTKCODE_To">
            </asp:TextBox>
        </div>
        <div style="background-color: transparent; font: 10pt Tahoma; border-right: 0; border-top: 0;
            border-left: 0; padding: 6px 10px 6px 10px;">
            <asp:Label ID="lblDateTitle" runat="server" Text="Date">
            </asp:Label><br />
            <asp:Label ID="lblDate_From" runat="server" Text="From:">
            </asp:Label>
            <asp:TextBox runat="server" ID="txtDateFrom" Enabled="false" Width="80px" />
            <asp:Label ID="lblDate_To" runat="server" Text="To:">
            </asp:Label>
            <asp:TextBox runat="server" ID="txtDateTo" Width="80px"/>
        </div>
        <div style="background-color: transparent; font: 10pt Tahoma; border-right: 0; border-top: 0;
            border-left: 0; padding: 6px 10px 6px 10px;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:CheckBox ID="chkShowPO" runat="server" AutoPostBack="true" Text="Show PO Quantity and Cost"
                        OnCheckedChanged="chkShowPO_CheckChanged" />
                    <br />
                    <asp:CheckBox ID="chkShowAts" runat="server" Text="Show Available-To-Sales Quantity" />
                    <br />
                    <asp:CheckBox ID="chkShowOLN" runat="server" Text="Show Outstangding OnLoan Quantity" />
                    <br />
                    <asp:CheckBox ID="chkShowRtlAmt" runat="server" Text="Show Retail Amount" />
                    <br />
                    <asp:CheckBox ID="chkSkipZeroQty" runat="server" Text="Skip ZERO Qty (C/D Qty, B/F Qty, ATS Qty & PO Qty)" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="background-color: transparent; font: 10pt Tahoma; border-right: 0; border-top: 0;
            border-left: 0; padding: 6px 10px 6px 10px;">
            <asp:Button ID="btnShow" runat="server" Text="Show" Width="75px" OnClick="btnShow_Click" />
        </div>
    </div>
    <div style="font: 10pt Tahoma; border-right: 0; border-top: 0; border-left: 0; padding: 0px 0px 0px 0px;" runat="server" id="divPivotGrid">
        <table border="0" cellpadding="3" cellspacing="0">
            <tr>
                <td colspan="4">
                    <strong>Export to:</strong>
                    <asp:DropDownList ID="listExportFormat" runat="server" Style="vertical-align: middle">
                        <asp:ListItem Selected="True">Pdf</asp:ListItem>
                        <asp:ListItem>Excel</asp:ListItem>
                        <asp:ListItem>Rtf</asp:ListItem>
                        <asp:ListItem>Text</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ImageButton ID="btnSaveAs" runat="server" ImageUrl="~/Resources/Icons/16x16/16_L_save.gif"
                        ToolTip="Export and save" Style="vertical-align: middle" OnClick="btnSaveAs_Click"
                        AlternateText="Save" />
                    <asp:ImageButton ID="btnOpen" runat="server" ImageUrl="~/Resources/Icons/16x16/16_L_saveOpen.gif" ToolTip="Export and open"
                        Style="vertical-align: middle" OnClick="btOpen_Click" AlternateText="Open" />
                </td>
            </tr>
            <tr>
                <td rowspan="2" valign="top">
                    <strong>Export Options: </strong>
                </td>
                <td>
                    <asp:CheckBox ID="checkPrintHeadersOnEveryPage" runat="server" Text="Print headers on every page" />
                </td>
                <td>
                    <asp:CheckBox ID="checkPrintFilterHeaders" runat="server" Text="Print filter headers"
                        Checked="True" />
                </td>
                <td>
                    <asp:CheckBox ID="checkPrintColumnHeaders" runat="server" Text="Print column headers"
                        Checked="True" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="checkPrintRowHeaders" runat="server" Text="Print row headers" Checked="True" />
                </td>
                <td>
                    <asp:CheckBox ID="checkPrintDataHeaders" runat="server" Text="Print data headers"
                        Checked="True" />
                </td>
            </tr>
        </table>
        <dxpgw:ASPxPivotGridExporter ID="olapQohAtsNormalExporter" runat="server" 
            ASPxPivotGridID="olapQohAtsNormal" />
        <dxwpg:ASPxPivotGrid ID="olapQohAtsNormal" runat="server" 
            DataSourceID="olapSQLSource">
            <Styles CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                <HeaderStyle>
                    <HoverStyle>
                        <BackgroundImage ImageUrl="~/App_Themes/Glass/PivotGrid/pgHeaderBackHot.gif" Repeat="RepeatX" />
                    </HoverStyle>
                    <BackgroundImage ImageUrl="~/App_Themes/Glass/PivotGrid/pgHeaderBack.gif" Repeat="RepeatX" />
                </HeaderStyle>
                <FilterAreaStyle>
                    <BackgroundImage ImageUrl="~/App_Themes/Glass/PivotGrid/pgFilterAreaBack.gif" Repeat="RepeatX" />
                </FilterAreaStyle>
                <FilterButtonPanelStyle>
                    <BackgroundImage ImageUrl="~/App_Themes/Glass/PivotGrid/pgFilterPanelBack.gif" Repeat="RepeatX" />
                </FilterButtonPanelStyle>
                <MenuStyle GutterWidth="0px" />
            </Styles>
            <OptionsLoadingPanel Text="Loading&amp;hellip;">
            </OptionsLoadingPanel>
            <OptionsPager RowsPerPage="100">
            </OptionsPager>
            <OptionsView ShowColumnTotals="true" ShowRowTotals="true" ShowColumnGrandTotals="true"
                ShowRowGrandTotals="true" ShowGrandTotalsForSingleValues="true" ShowTotalsForSingleValues="true" />
            <Images ImageFolder="~/App_Themes/Glass/{0}/">
            </Images>
        </dxwpg:ASPxPivotGrid>
        <asp:SqlDataSource ID="olapSQLSource" runat="server" ConnectionString="<%$ ConnectionStrings:SysDb %>"
            SelectCommand="apOlapQohAtsNormal" SelectCommandType="StoredProcedure" OnSelecting="olapSQLSource_OnSelecting">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtSTKCODE_From" Name="fromSTKCODE" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtSTKCODE_To" Name="toSTKCODE" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="fromDate" 
                    PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="txtDateTo" Name="toDate" PropertyName="Text" 
                    Type="DateTime" DefaultValue="" />
                <asp:ControlParameter ControlID="chkShowPO" Name="ShowPOQty" 
                    PropertyName="Checked" Type="Boolean" />
                <asp:ControlParameter ControlID="chkShowAts" Name="ShowATSQty" 
                    PropertyName="Checked" Type="Boolean" />
                <asp:ControlParameter ControlID="chkShowOLN" Name="ShowOSTOnLoanQty" 
                    PropertyName="Checked" Type="Boolean" />
                <asp:ControlParameter ControlID="chkShowRtlAmt" Name="ShowRetailAmount" 
                    PropertyName="Checked" Type="Boolean" />
                <asp:Parameter DefaultValue="false" Name="ShowRemarks1To6" Type="Boolean" />
                <asp:ControlParameter ControlID="chkSkipZeroQty" Name="SkipZeroQty" 
                    PropertyName="Checked" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
