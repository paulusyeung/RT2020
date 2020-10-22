﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInOut.aspx.cs" Inherits="RT2020.Inventory.Olap.StockInOut" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraPivotGrid.Web" TagPrefix="dxpgw" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divOptions" runat="server" visible="false">
        <div style="background-color: transparent; font: 10pt Tahoma; border-right: 0; border-top: 0;
            border-left: 0; padding: 6px 10px 6px 10px;">
            <asp:Label ID="lblStockCodeFrom" runat="server" Text="From Stock Code:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtStockCode_From" runat="server" Width="120px">00000000</asp:TextBox>
        </div>
        <div style="background-color: transparent; font: 10pt Tahoma; border-right: 0; border-top: 0;
            border-left: 0; padding: 6px 10px 6px 10px;">
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblStockCodeTo" runat="server" Text="To Stock Code:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtStockCode_To" runat="server" Width="120px">ZZZZZZZZ</asp:TextBox>
        </div>
        <div style="background-color: transparent; font: 10pt Tahoma; border-right: 0; border-top: 0;
            border-left: 0; padding: 6px 10px 6px 10px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblShopFrom" runat="server" Text="From Shop:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtFromShop" runat="server" Width="120px" AutoPostBack="True"
                OnTextChanged="txtFromShop_TextChanged"></asp:TextBox>
        </div>
        <div style="background-color: transparent; font: 10pt Tahoma; border-right: 0; border-top: 0;
            border-left: 0; padding: 6px 10px 6px 10px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblShopTo" runat="server" Text="To Shop:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtToShop" runat="server" Width="120px" AutoPostBack="True"
                OnTextChanged="txtToShop_TextChanged"></asp:TextBox>
            &nbsp;
            <asp:Label ID="lblShopError" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div style="background-color: transparent; font: 10pt Tahoma; border-right: 0; border-top: 0;
            border-left: 0; padding: 6px 10px 6px 10px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblFromDate" runat="server" Text="From Date:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtFromDate" runat="server" Width="120px" AutoPostBack="True"
                OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
            <asp:Label ID="lblDateFormatFrom" runat="server" Text="(dd/mm/yyyy)"></asp:Label>
        </div>
        <div style="background-color: transparent; font: 10pt Tahoma; border-right: 0; border-top: 0;
            border-left: 0; padding: 6px 10px 6px 10px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblToDate" runat="server" Text="To Date:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtToDate" runat="server" Width="120px" AutoPostBack="True"
                OnTextChanged="txtToDate_TextChanged">
            </asp:TextBox>
            <asp:Label ID="lblDateFormatTo" runat="server" Text="(dd/mm/yyyy)"></asp:Label>
            &nbsp;
            <asp:Label ID="lblDateError" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnShow0" runat="server" Text="Show" Width="75px" OnClick="btnShow_Click" />
        </div>
    </div>
    <div style="font: 10pt Tahoma; border-right: 0; border-top: 0; border-left: 0; padding: 0px 0px 0px 0px;"
        runat="server" id="divPivotGrid">
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
                    <asp:ImageButton ID="btnOpen" runat="server" ImageUrl="~/Resources/Icons/16x16/16_L_saveOpen.gif"
                        ToolTip="Export and open" Style="vertical-align: middle" OnClick="btOpen_Click"
                        AlternateText="Open" />
                </td>
            </tr>
            <tr>
                <td rowspan="2" valign="top">
                    <strong>Export Options:</strong>
                </td>
                <td>
                    <asp:CheckBox ID="checkPrintHeadersOnEveryPage" runat="server" Text="Print headers on every page" />
                </td>
                <td>
                    <asp:CheckBox ID="checkPrintFilterHeaders" runat="server" Text="Print filter headers"
                        Checked="true" />
                </td>
                <td>
                    <asp:CheckBox ID="checkPrintColumnHeaders" runat="server" Text="Print column headers"
                        Checked="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="checkPrintRowHeaders" runat="server" Text="Print row headers" Checked="true" />
                </td>
                <td>
                    <asp:CheckBox ID="checkPrintDataHeaders" runat="server" Text="Print data headers"
                        Checked="true" />
                </td>
            </tr>
        </table>
        <dxpgw:ASPxPivotGridExporter ID="olapStockInOutExporter" runat="server" ASPxPivotGridID="olapStockInOut" />
        <dxwpg:ASPxPivotGrid ID="olapStockInOut" runat="server" DataSourceID="olapSQLSource">
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
            <Images ImageFolder="~/App_Themes/Glass/{0}/">
            </Images>
            <OptionsPager RowsPerPage="100">
            </OptionsPager>
            <OptionsView ShowGrandTotalsForSingleValues="True" ShowTotalsForSingleValues="True" />
        </dxwpg:ASPxPivotGrid>
        <asp:SqlDataSource ID="olapSQLSource" runat="server" ConnectionString="<%$ ConnectionStrings:SysDb %>"
            SelectCommand="apOlapStockInOut" SelectCommandType="StoredProcedure" OnSelecting="olapSQLSource_OnSelecting">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtStockCode_From" Name="fromSTKCODE" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="txtStockCode_To" Name="toSTKCODE" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="txtFromDate" Name="fromDate" PropertyName="Text"
                    Type="DateTime" />
                <asp:ControlParameter ControlID="txtToDate" Name="toDate" PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="txtFromShop" Name="fromShop" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="txtToShop" Name="toShop" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
