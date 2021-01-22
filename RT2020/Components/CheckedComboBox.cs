using System;
using System.Data;
using System.Configuration;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using System.Collections.Generic;

namespace RT2020.Components
{
    //-------------------------------------------------------------------------------
    //[Serializable()]
    public class CheckedComboBoxForm : Form
    {
        CheckedComboBox mobjParent = null;
        CheckedComboBoxView objCheckedComboView = null;

        public CheckedComboBoxView GetCheckedComboBoxView()
        {
            return objCheckedComboView;
        }
        public CheckedComboBox GetCheckedComboBox()
        {
            return mobjParent;
        }
        public CheckedComboBoxForm(CheckedComboBox objParent)
        {
            mobjParent = objParent;

            this.Width = 250;
            this.Height = 200;

            objCheckedComboView = new CheckedComboBoxView();
            objCheckedComboView.Dock = DockStyle.Fill;

            this.Controls.Add(objCheckedComboView);

            objCheckedComboView.DoubleClick += new EventHandler(OnClose);
            objCheckedComboView.ItemCheck += new ItemCheckHandler(OnItemCheck);
            objCheckedComboView.MouseDown += new MouseEventHandler(OnMouseDown);
            objCheckedComboView.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            mobjParent.Text = "";
            foreach (int i in objCheckedComboView.CheckedIndices)
            {
                objCheckedComboView.SetItemChecked(i, false);
            }
            foreach (int i in objCheckedComboView.SelectedIndices)
            {
                LoadDisplayValue(i);

                objCheckedComboView.SetItemChecked(i, true);
            }
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Close();
            }
            else
            {
                // 2020.08.08 paulus: 淨係 OnItemCheck 唔夠，要包埋啱啱 check 嘅 item，好似重複咗，不過 OnItemCheck 可以用 keyboard
                mobjParent.Text = "";
                foreach (int i in objCheckedComboView.CheckedIndices)
                {
                    LoadDisplayValue(i);
                }
            }
        }
        private void OnClose(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OnItemCheck(object sender, ItemCheckEventArgs e)
        {
            mobjParent.Text = "";
            foreach (int i in objCheckedComboView.CheckedIndices)
            {
                LoadDisplayValue(i);
            }
        }
        private void LoadDisplayValue(int idx)
        {
            mobjParent.Text += (mobjParent.Text != string.Empty) ? "; " : "";
            var type = objCheckedComboView.Items[0].GetType();
            if (type == typeof(string))
            {
                mobjParent.Text += objCheckedComboView.Items[idx].ToString();
            }
            else
            {
                var item = (KeyValuePair<Guid, string>)objCheckedComboView.Items[idx];
                mobjParent.Text += item.Value;
            }
        }
        public void AddString(string newValue, bool bChecked)
        {
            if (newValue == null || newValue == string.Empty)
                return;
            
            objCheckedComboView.Items.Add(newValue, bChecked);
        }
        public void AddKvpItem(object newObject, bool bChecked)
        {
            if (newObject == null)
                return;

            objCheckedComboView.Items.Add(newObject, bChecked);
        }
        public void SelectAll(bool bChecked)
        {
            for (int i = 0; i < objCheckedComboView.Items.Count; i++)
            {
                objCheckedComboView.SetItemChecked(i, bChecked);
            }
        }
        public void Clear()
        {
            objCheckedComboView.Items.Clear();
        }
        public void ClearSelected()
        {
            objCheckedComboView.ClearSelected();
            for (int i = 0; i < objCheckedComboView.Items.Count; i++)
            {
                objCheckedComboView.SetItemChecked(i, false);
            }
            mobjParent.Text = "";
        }
        public int Count()
        {
            return objCheckedComboView.Items.Count;
        }
        public void SetCheckWithText(string text)
        {
            string ls_aux;
            string ls_checkStr;
            int pos;

            if (text == null || text == string.Empty)
            {
                SelectAll(false);
                return;
            }

            ls_aux = text;

            SelectAll(false);

            pos = ls_aux.IndexOf("; ");
            while (ls_aux != string.Empty && pos != -1)
            {
                ls_checkStr = ls_aux.Substring(0, pos);
                ls_aux = ls_aux.Substring(pos + 2);
                SetCheck(ls_checkStr, true);
                pos = ls_aux.IndexOf("; ");
            }
            // seleccionar o que sobra
            if (ls_aux != string.Empty)
                SetCheck(ls_aux, true);
        }
        public int SetCheck(string nText, bool bChecked)
        {
            if (nText == null || nText == string.Empty)
                return -1;

            int pos = objCheckedComboView.FindString(nText);
            objCheckedComboView.SetItemChecked(pos, bChecked);
            return pos;
        }
        public bool GetCheck(int nIndex)
        {
            return objCheckedComboView.GetItemChecked(nIndex);
        }
        public void SetCheck(int nIndex, bool bChecked)
        {
            objCheckedComboView.SetItemChecked(nIndex, bChecked);
        }
        public void SetSelectionMode(SelectionMode mode)
        {
            objCheckedComboView.SelectionMode = mode;
        }
        public void SetDataSource(object source)
        {
            objCheckedComboView.DataSource = source;
        }
        public void SetDisplayMember(string name)
        {
            objCheckedComboView.DisplayMember = name;
        }
        public void SetValueMember(string name)
        { 
            objCheckedComboView.ValueMember = name;
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
        private void ItemCheck(object objSender, ItemCheckEventArgs objArgs)
        {

        }
    }

    //-------------------------------------------------------------------------------
    //[Serializable()]
    public class CheckedComboBox : ComboBox
    {
        private CheckedComboBoxForm mobjDropDown = null;

        public CheckedComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDown;

            if (mobjDropDown == null)
            {
                mobjDropDown = new CheckedComboBoxForm(this);
            }
        }
        protected override Form GetCustomDropDown()
        {

            return mobjDropDown;
        }

        public void AddString(string newValue, bool bChecked)
        {
            mobjDropDown.AddString(newValue, bChecked);
        }
        public void AddKvpItem(object newObject, bool bChecked)
        {
            mobjDropDown.AddKvpItem(newObject, bChecked);
        }
        public CheckedComboBoxView GetCheckedComboView()
        {
            return mobjDropDown.GetCheckedComboBoxView();
        }
        public void SelectAll(bool bChecked)
        {
            mobjDropDown.SelectAll(bChecked);
        }
        public void Clear()
        {
            mobjDropDown.Clear();
        }
        public void ClearSelected()
        {
            mobjDropDown.ClearSelected();
        }
        public void SetCheckWithText(string text)
        {
            mobjDropDown.SetCheckWithText(text);
        }
        public bool GetCheck(int nIndex)
        {
            return mobjDropDown.GetCheck(nIndex);
        }
        public void SetCheck(int nIndex, bool bChecked)
        {
            mobjDropDown.SetCheck(nIndex, bChecked);
        }
        public int Count()
        {
            return mobjDropDown.Count();
        }
        public void SetWidth(int nWidth)
        {
            mobjDropDown.Width = nWidth;
        }
        public void SetSelectionMode(SelectionMode mode)
        {
            mobjDropDown.SetSelectionMode(mode);
        }
        public void SetDataSource(object source)
        {
            mobjDropDown.SetDataSource(source);
        }
        public void SetDisplayMember(string name)
        {
            mobjDropDown.SetDisplayMember(name);
        }
        public void SetValueMember(string name)
        {
            mobjDropDown.SetValueMember(name);
        }
        protected override bool IsCustomDropDown
        {
            get
            {
                return true;
            }
        }
    }

    //[Serializable()]
    public class CheckedComboBoxView : CheckedListBox
    {
        public CheckedComboBoxView()
        {

        }

        protected override bool IsDelayedDrawing
        {
            get
            {
                return false;
            }
        }
    }
}
