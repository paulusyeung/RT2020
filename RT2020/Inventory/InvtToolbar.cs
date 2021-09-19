using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using RT2020.Common.Helper;

namespace RT2020.Inventory
{
    public class InvtToolbar
    {
        private Control atsPaneCtrl;
        private FormType fType;

        nxStudio.BaseClass.WordDict oDict = new nxStudio.BaseClass.WordDict(ConfigHelper.CurrentWordDict, ConfigHelper.CurrentLanguageId);

        public enum FormType
        {
            GoodsReceive,
            GoodsReturn,
            Transfer,
            Adjustment,
            Replenishment,
            StockTake,
            All
        }

        public InvtToolbar(Control toolBar, ref ToolBar tbInvt, FormType formType)
        {
            atsPaneCtrl = toolBar;
            fType = formType;
            //ClearToolBar();
            AddItemToToolBar(tbInvt);
        }

        private void ClearToolBar()
        {
            if (atsPaneCtrl != null)
            {
                atsPaneCtrl.Controls.Clear();
            }
        }

        private ContextMenu BuildGoodsReceiveContextMenu()
        {
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem(oDict.GetWord("Goods Receive"), string.Empty, "Goods_Receive"));

            MenuItem rec = new MenuItem(oDict.GetWord("Goods Receive (Authorization)"), string.Empty, "Goods_Receive_Authorization");
            rec.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);

            menu.MenuItems.Add(rec);

            return menu;
        }

        private ContextMenu BuildGoodsReturnContextMenu()
        {
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem(oDict.GetWord("Goods Return"), string.Empty, "Goods_Return"));

            MenuItem rej = new MenuItem(oDict.GetWord("Goods Return (Authorization)"), string.Empty, "Goods_Return_Authorization");
            rej.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);

            menu.MenuItems.Add(rej);
            return menu;
        }

        private ContextMenu BuildGoodsTransferContextMenu()
        {
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem(oDict.GetWord("Transfer"), string.Empty, "Transfer"));
            menu.MenuItems.Add(new MenuItem(oDict.GetWord("Transfer - Picking Note"), string.Empty, "Transfer_Picking_Note"));
            menu.MenuItems.Add(new MenuItem(oDict.GetWord("Transfer - Picking Note (Fast)"), string.Empty, "Transfer_Picking_Note_Fast"));
            return menu;
        }

        private ContextMenu BuildGoodsAdjustmentContextMenu()
        {
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem(oDict.GetWord("Adjustment"), string.Empty, "Adjustment"));

            MenuItem adj = new MenuItem(oDict.GetWord("Adjustment (Authorization)"), string.Empty, "Adjustment_Authorization");
            adj.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            menu.MenuItems.Add(adj);
            return menu;
        }

        private ContextMenu BuildGoodsReplenishmentContextMenu()
        {
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem(oDict.GetWord("Prepare Replenishment"), string.Empty, "Prepare_Replenishment"));
            //menu.MenuItems.Add(new MenuItem("Replenishment", string.Empty, "Replenishment"));
            //menu.MenuItems.Add(new MenuItem("Replenishment (Advance)", string.Empty, "Replenishment_Advance"));

            MenuItem confirm = new MenuItem(oDict.GetWord("Replenishment (Confirmation)"), string.Empty, "Replenishment_Confirmation");
            confirm.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            menu.MenuItems.Add(confirm);

            MenuItem auth = new MenuItem(oDict.GetWord("Replenishment (Authorization)"), string.Empty, "Replenishment_Authorization");
            auth.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            menu.MenuItems.Add(auth);
            return menu;
        }

        private ContextMenu BuildGoodsStockTakeContextMenu()
        {
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem(oDict.GetWord("Stock Take - All Items"), string.Empty, "StockTake_AllItems"));
            menu.MenuItems.Add(new MenuItem(oDict.GetWord("Stock Take - Partial"), string.Empty, "StockTake_Partial"));
            //menu.MenuItems.Add(new MenuItem("Stock Take", string.Empty, "StockTake"));
            menu.MenuItems.Add(new MenuItem(oDict.GetWord("Re-Capture On-Hand Quantity"), string.Empty, "Recapture_OnHand_Quantity"));

            MenuItem approval = new MenuItem(oDict.GetWord("Stock Take - Approval"), string.Empty, "StockTake_Approval");
            approval.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            menu.MenuItems.Add(approval);

            MenuItem auth = new MenuItem(oDict.GetWord("Stock Take (Authorization)"), string.Empty, "StockTake_Authorization");
            auth.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Posting);
            menu.MenuItems.Add(auth);
            return menu;
        }

        private void AddItemToToolBar(ToolBar atsInvt)
        {
            atsInvt.MenuHandle = false;
            atsInvt.DragHandle = false;
            atsInvt.TextAlign = ToolBarTextAlign.Right;
            atsInvt.Controls.Clear();

            #region cmdNew
            ContextMenu ddlNew = new ContextMenu();

            switch (fType)
            {
                case FormType.GoodsReceive:
                    ddlNew = BuildGoodsReceiveContextMenu();
                    break;
                case FormType.GoodsReturn:
                    ddlNew = BuildGoodsReturnContextMenu();
                    break;
                case FormType.Transfer:
                    ddlNew = BuildGoodsTransferContextMenu();
                    break;
                case FormType.Adjustment:
                    ddlNew = BuildGoodsAdjustmentContextMenu();
                    break;
                case FormType.Replenishment:
                    ddlNew = BuildGoodsReplenishmentContextMenu();
                    break;
                case FormType.StockTake:
                    ddlNew = BuildGoodsStockTakeContextMenu();
                    break;
                case FormType.All:
                    switch (RT2020.Controls.UserUtility.SecurityLevel())
                    {
                        case "1":
                            ddlNew.MenuItems.AddRange(BuildGoodsTransferContextMenu().MenuItems.Cast<MenuItem>().ToArray<MenuItem>());
                            break;
                        default:
                            ddlNew.MenuItems.AddRange(BuildGoodsReceiveContextMenu().MenuItems.Cast<MenuItem>().ToArray<MenuItem>());
                            ddlNew.MenuItems.Add(new MenuItem("-"));
                            ddlNew.MenuItems.AddRange(BuildGoodsReturnContextMenu().MenuItems.Cast<MenuItem>().ToArray<MenuItem>());
                            ddlNew.MenuItems.Add(new MenuItem("-"));
                            ddlNew.MenuItems.AddRange(BuildGoodsTransferContextMenu().MenuItems.Cast<MenuItem>().ToArray<MenuItem>());
                            ddlNew.MenuItems.Add(new MenuItem("-"));
                            ddlNew.MenuItems.AddRange(BuildGoodsAdjustmentContextMenu().MenuItems.Cast<MenuItem>().ToArray<MenuItem>());
                            ddlNew.MenuItems.Add(new MenuItem("-"));
                            ddlNew.MenuItems.AddRange(BuildGoodsReplenishmentContextMenu().MenuItems.Cast<MenuItem>().ToArray<MenuItem>());
                            ddlNew.MenuItems.Add(new MenuItem("-"));
                            ddlNew.MenuItems.AddRange(BuildGoodsStockTakeContextMenu().MenuItems.Cast<MenuItem>().ToArray<MenuItem>());
                            break;
                    }
                    break;
            }

            ToolBarButton cmdNew = new ToolBarButton("New", oDict.GetWord("New"));
            cmdNew.Style = ToolBarButtonStyle.DropDownButton;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.DropDownMenu = ddlNew;
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            atsInvt.Buttons.Add(cmdNew);
            cmdNew.MenuClick += new MenuEventHandler(cmdMenuClick);
            #endregion

            #region cmdImport
            ContextMenu ddlImport = new ContextMenu();

            switch (RT2020.Controls.UserUtility.SecurityLevel())
            {
                case "1":
                    ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("Transfer"), string.Empty, "Transfer_Import"));
                    ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("Transfer (Advance)"), string.Empty, "Transfer_Import_Advance"));
                    break;
                default:
                    ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("Goods Receive") + " (Excel)", string.Empty, "Goods_Receive_Import_Xls"));
                    ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("Goods Receive") + " (Txt file)", string.Empty, "Goods_Receive_Import_Txt"));
                    ddlImport.MenuItems.Add(new MenuItem("-"));
                    ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("Goods Return"), string.Empty, "Goods_Return_Import"));
                    ddlImport.MenuItems.Add(new MenuItem("-"));
                    ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("Transfer"), string.Empty, "Transfer_Import"));
                    ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("Transfer (Advance)"), string.Empty, "Transfer_Import_Advance"));
                    ddlImport.MenuItems.Add(new MenuItem("-"));
                    ddlImport.MenuItems.Add(new MenuItem(oDict.GetWord("Adjustment"), string.Empty, "Adjustment_Import"));
                    break;
            }

            ToolBarButton cmdImport = new ToolBarButton("Import", oDict.GetWord("Import"));
            cmdImport.Style = ToolBarButtonStyle.DropDownButton;
            cmdImport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdImport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdImport.DropDownMenu = ddlImport;

            atsInvt.Buttons.Add(cmdImport);
            cmdImport.MenuClick += new MenuEventHandler(cmdMenuClick);
            #endregion

            #region cmdExport
            ContextMenu ddlExport = new ContextMenu();

            switch (RT2020.Controls.UserUtility.SecurityLevel())
            {
                case "1":
                    ddlExport.MenuItems.Add(new MenuItem(oDict.GetWord("Transfer"), string.Empty, "Transfer_Export"));
                    break;
                default:
                    ddlExport.MenuItems.Add(new MenuItem(oDict.GetWord("Goods Receive"), string.Empty, "Goods_Receive_Export"));
                    ddlExport.MenuItems.Add(new MenuItem(oDict.GetWord("Goods Return"), string.Empty, "Goods_Return_Export"));
                    ddlExport.MenuItems[ddlExport.MenuItems.Count - 1].Enabled = false;
                    ddlExport.MenuItems.Add(new MenuItem(oDict.GetWord("Transfer"), string.Empty, "Transfer_Export"));
                    ddlExport.MenuItems.Add(new MenuItem(oDict.GetWord("Adjustment"), string.Empty, "Adjustment_Export"));
                    ddlExport.MenuItems[ddlExport.MenuItems.Count - 1].Enabled = false;
                    break;
            }

            ToolBarButton cmdExport = new ToolBarButton("Export", oDict.GetWord("Export"));
            cmdExport.Style = ToolBarButtonStyle.DropDownButton;
            cmdExport.Image = new IconResourceHandle("16x16.ico_16_4407_up.gif");
            cmdExport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdExport.DropDownMenu = ddlExport;

            atsInvt.Buttons.Add(cmdExport);
            cmdExport.MenuClick += new MenuEventHandler(cmdMenuClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;
            atsInvt.Buttons.Add(sep);
            #endregion

            #region Stock Status
            switch (RT2020.Controls.UserUtility.SecurityLevel())
            {
                case "1":
                    break;
                default:
                    ContextMenu ddlStockStatus = new ContextMenu();
                    ddlStockStatus.MenuItems.Add(new MenuItem(oDict.GetWord("Monthly"), string.Empty, "StockStatus_Monthly"));
                    ddlStockStatus.MenuItems.Add(new MenuItem(oDict.GetWord("Stock Value"), string.Empty, "StockStatus_StockValue"));
                    ddlStockStatus.MenuItems.Add(new MenuItem(oDict.GetWord("Retail Value"), string.Empty, "StockStatus_RetailValue"));

                    ToolBarButton cmdStockStatus = new ToolBarButton("StockStatus", oDict.GetWord("Stock Status"));
                    cmdStockStatus.Style = ToolBarButtonStyle.DropDownButton;
                    cmdStockStatus.Image = new IconResourceHandle("16x16.16_reports.gif");
                    cmdStockStatus.DropDownMenu = ddlStockStatus;
                    cmdStockStatus.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

                    atsInvt.Buttons.Add(cmdStockStatus);
                    cmdStockStatus.MenuClick += new MenuEventHandler(cmdMenuClick);
                    break;
            }
            #endregion

            if (atsPaneCtrl != null)
            {
                atsPaneCtrl.Controls.Add(atsInvt);
            }
        }

        void cmdMenuClick(object sender, MenuItemEventArgs e)
        {
            if (!(e.MenuItem.Tag == null))
            {
                switch (e.MenuItem.Tag.ToString().ToLower())
                {
                    case "goods_receive":
                        RT2020.Inventory.GoodsReceive.Wizard wizCAP = new RT2020.Inventory.GoodsReceive.Wizard();
                        wizCAP.ShowDialog();
                        break;
                    case "goods_receive_authorization":
                        RT2020.Inventory.GoodsReceive.Authorization wizAuthRecv = new RT2020.Inventory.GoodsReceive.Authorization();
                        wizAuthRecv.ShowDialog();
                        break;
                    case "goods_return":
                        RT2020.Inventory.GoodsReturn.Wizard wizRej = new RT2020.Inventory.GoodsReturn.Wizard();
                        wizRej.ShowDialog();
                        break;
                    case "goods_return_authorization":
                        RT2020.Inventory.GoodsReturn.Authorization wizAuthRej = new RT2020.Inventory.GoodsReturn.Authorization();
                        wizAuthRej.ShowDialog();
                        break;
                    case "transfer":
                        RT2020.Inventory.Transfer.Wizard wizTxfer = new RT2020.Inventory.Transfer.Wizard(EnumHelper.TxType.TXF);
                        wizTxfer.ShowDialog();
                        break;
                    case "transfer_picking_note":
                        RT2020.Inventory.Transfer.Wizard wizTxfer_PNQ = new RT2020.Inventory.Transfer.Wizard(EnumHelper.TxType.PNQ);
                        wizTxfer_PNQ.ShowDialog();
                        break;
                    case "transfer_picking_note_fast":
                        RT2020.Inventory.Transfer.PickingNoteFast wizPNQFast = new RT2020.Inventory.Transfer.PickingNoteFast();
                        wizPNQFast.ShowDialog();
                        break;
                    case "adjustment":
                        RT2020.Inventory.Adjustment.Wizard wizAdj = new RT2020.Inventory.Adjustment.Wizard();
                        wizAdj.ShowDialog();
                        break;
                    case "adjustment_authorization":
                        RT2020.Inventory.Adjustment.Authorization wizAuthAdj = new RT2020.Inventory.Adjustment.Authorization();
                        wizAuthAdj.ShowDialog();
                        break;
                    case "prepare_replenishment":
                        RT2020.Inventory.Replenishment.Preparation wizRepPreparation = new RT2020.Inventory.Replenishment.Preparation();
                        wizRepPreparation.ShowDialog();
                        break;
                    case "replenishment":
                        RT2020.Inventory.Replenishment.Wizard wizRPL = new RT2020.Inventory.Replenishment.Wizard();
                        wizRPL.ShowDialog();
                        break;
                    case "replenishment_advance":
                        RT2020.Inventory.Replenishment.Wizard_Advance wizRPLAdv = new RT2020.Inventory.Replenishment.Wizard_Advance();
                        wizRPLAdv.ShowDialog();
                        break;
                    case "replenishment_confirmation":
                        RT2020.Inventory.Replenishment.Confirmation wizConfirm = new RT2020.Inventory.Replenishment.Confirmation();
                        wizConfirm.ShowDialog();
                        break;
                    case "replenishment_authorization":
                        RT2020.Inventory.Replenishment.Authorization wizAuth = new RT2020.Inventory.Replenishment.Authorization();
                        wizAuth.ShowDialog();
                        break;
                    case "stocktake_allitems":
                        RT2020.Inventory.StockTake.AllItems wizStkAll = new RT2020.Inventory.StockTake.AllItems();
                        wizStkAll.ShowDialog();
                        break;
                    case "stocktake_partial":
                        RT2020.Inventory.StockTake.PartialItems wizStkPartial = new RT2020.Inventory.StockTake.PartialItems();
                        wizStkPartial.ShowDialog();
                        break;
                    case "stocktake":
                        RT2020.Inventory.StockTake.Wizard wizStockTake = new RT2020.Inventory.StockTake.Wizard();
                        wizStockTake.ShowDialog();
                        break;
                    case "recapture_onhand_quantity":
                        RT2020.Inventory.StockTake.RecaptureOnhand wizRecaptureOnhand = new RT2020.Inventory.StockTake.RecaptureOnhand();
                        wizRecaptureOnhand.ShowDialog();
                        break;
                    case "stocktake_approval":
                        RT2020.Inventory.StockTake.Approval wizApproval = new RT2020.Inventory.StockTake.Approval();
                        wizApproval.ShowDialog();
                        break;
                    case "stocktake_authorization":
                        RT2020.Inventory.StockTake.Authorization wizAuthStk = new RT2020.Inventory.StockTake.Authorization();
                        wizAuthStk.ShowDialog();
                        break;
                    case "goods_receive_import_xls":
                        RT2020.Inventory.GoodsReceive.Import.ImportXls wizXlsImport = new RT2020.Inventory.GoodsReceive.Import.ImportXls();
                        wizXlsImport.ShowDialog();
                        break;
                    case "goods_receive_import_txt":
                        RT2020.Inventory.GoodsReceive.Import.ImportTxt wizCAPTxtImport = new RT2020.Inventory.GoodsReceive.Import.ImportTxt();
                        wizCAPTxtImport.ShowDialog();
                        break;
                    case "goods_return_import":
                        break;
                    case "transfer_import":
                        RT2020.Inventory.Transfer.Import.ImportTxt wizTxferImport = new RT2020.Inventory.Transfer.Import.ImportTxt();
                        wizTxferImport.ShowDialog();
                        break;
                    case "transfer_import_advance":
                        RT2020.Inventory.Transfer.Import.AdvanceImport wizTxferImportAdv = new RT2020.Inventory.Transfer.Import.AdvanceImport();
                        wizTxferImportAdv.ShowDialog();
                        break;
                    case "adjustment_import":
                        break;
                    case "goods_receive_export":
                        RT2020.Inventory.GoodsReceive.Export.Export2Txt wizCAPExport = new RT2020.Inventory.GoodsReceive.Export.Export2Txt();
                        wizCAPExport.ShowDialog();
                        break;
                    case "goods_return_export":
                        break;
                    case "transfer_export":
                        RT2020.Inventory.Transfer.Export.Export2Txt wizTxferExport = new RT2020.Inventory.Transfer.Export.Export2Txt();
                        wizTxferExport.ShowDialog();
                        break;
                    case "adjustment_export":
                        break;
                    case "stockstatus_monthly":
                        RT2020.Inventory.Reports.StockStatus.StockStatus_Monthly wizMonthly = new RT2020.Inventory.Reports.StockStatus.StockStatus_Monthly();
                        wizMonthly.ShowDialog();
                        break;
                    case "stockstatus_stockvalue":
                        RT2020.Inventory.Reports.StockStatus.StockStatus_StockValue wizStockValue = new RT2020.Inventory.Reports.StockStatus.StockStatus_StockValue();
                        wizStockValue.ShowDialog();
                        break;
                    case "stockstatus_retailvalue":
                        RT2020.Inventory.Reports.StockStatus.StockStatus_RetailValue wizRetailValue = new RT2020.Inventory.Reports.StockStatus.StockStatus_RetailValue();
                        wizRetailValue.ShowDialog();
                        break;
                }
            }
        }
    }
}
