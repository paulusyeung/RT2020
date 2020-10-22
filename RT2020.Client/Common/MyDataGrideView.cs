using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RT2020.Client.Common
{
    public partial class MyDataGrideView : DataGridView
    {
        int WM_LBUTTONDOWN = 0x0201;
        int WM_LBUTTONDBLCLK = 0x0203;
        int MK_LBUTTON = 0x1;
        bool bShiftKey = false;

        public MyDataGrideView()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            Keys key = (keyData & Keys.KeyCode);

            //if (key == Keys.Enter || key == Keys.Right || key == Keys.Down)
            //{
            //    SendKeys.Send("{Tab}");
            //    return true;
            //}
            //else if (key == Keys.Left || key == Keys.Up)
            //{
            //    return true;
            //}
            if (key == Keys.Tab)
            {
                int col = this.CurrentCell.ColumnIndex + 1;
                for (; col < this.Columns.Count; col++)
                {
                    if (!this.Columns[col].ReadOnly)
                    { break; }
                }
                if (col < this.Columns.Count)
                {
                    this.CurrentCell = this.Rows[this.CurrentCell.RowIndex].Cells[col];
                }
                else
                {
                    if (this.CurrentCell.RowIndex != this.Rows.Count - 1)
                    {
                        for (col = 0; col <= this.CurrentCell.ColumnIndex; col++)
                        {
                            if (!this.Columns[col].ReadOnly)
                            {
                                break;
                            }
                        }
                        if (col <= this.CurrentCell.ColumnIndex)
                        {
                            this.CurrentCell = this.Rows[this.CurrentCell.RowIndex + 1].Cells[col];
                        }
                    }
                }
                return true;

            }
            return base.ProcessDialogKey(keyData);
        }

        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            //{
            //    SendKeys.Send("{Tab}");
            //    return true;
            //}

            if (e.KeyData == Keys.Tab)
            {
                int col = this.CurrentCell.ColumnIndex + 1;
                for (; col < this.Columns.Count; col++)
                {
                    if (!this.Columns[col].ReadOnly)
                    { break; }
                }
                if (col < this.Columns.Count)
                {
                    this.CurrentCell = this.Rows[this.CurrentCell.RowIndex].Cells[col];
                }
                else
                {
                    if (this.CurrentCell.RowIndex != this.Rows.Count - 1)
                    {
                        for (col = 0; col <= this.CurrentCell.ColumnIndex; col++)
                        {
                            if (!this.Columns[col].ReadOnly)
                            {
                                break;
                            }
                        }
                        if (col <= this.CurrentCell.ColumnIndex)
                        {
                            this.CurrentCell = this.Rows[this.CurrentCell.RowIndex + 1].Cells[col];
                        }
                    }
                }
                return true;
            }
            return base.ProcessDataGridViewKey(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_LBUTTONDBLCLK)
            {
                if (m.WParam.ToInt32() == MK_LBUTTON)
                {
                    int lparam = m.LParam.ToInt32();
                    int xpos = lparam & 0x0000FFFF;
                    int ypos = lparam >> 16;
                    if (!IsReadonlyCell(xpos, ypos))
                    {
                        base.WndProc(ref m);
                    }
                }
            }
            else
            {
                base.WndProc(ref m);
            }

        }

        private bool IsReadonlyCell(int xpos, int ypos)
        {
            int column = 0;
            for (; column < this.ColumnCount; column++)
            {
                if (this.GetColumnDisplayRectangle(column, true).Contains(xpos, ypos))
                {
                    break;
                }
            }

            if (column < this.ColumnCount)
            {
                if (this.Columns[column].ReadOnly)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
