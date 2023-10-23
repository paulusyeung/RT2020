Public Class ucSelectedItemProps
    Inherits System.Windows.Forms.UserControl

    Private WithEvents m_ParentNavigationBar As Itchin.Winforms.Controls.NavigationBar
    Private m_EventsView As ListView

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal ParentNavbar As Itchin.Winforms.Controls.NavigationBar, ByVal EventList As ListView)


        MyBase.New()

        m_ParentNavigationBar = ParentNavbar
        m_EventsView = EventList

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        AddHandler cboSelItemImageAlignment.SelectedIndexChanged, AddressOf OnCBOValueChanged
        AddHandler cboSelItemTextAlignment.SelectedIndexChanged, AddressOf OnCBOValueChanged

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pnlCurrentItem As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents Panelcontrol8 As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents cboColor As ColorPicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panelcontrol6 As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSelItemImageAlignment As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents picToolbar As System.Windows.Forms.PictureBox
    Friend WithEvents picMain As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panelcontrol7 As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents selItemTextOffsetX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSelItemTextAlignment As System.Windows.Forms.ComboBox
    Friend WithEvents txtSelCaption As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlCurrentItem = New Itchin.Winforms.Controls.Panelcontrol
        Me.Panelcontrol8 = New Itchin.Winforms.Controls.Panelcontrol
        Me.cboColor = New Navbar_Tutorial.ColorPicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panelcontrol6 = New Itchin.Winforms.Controls.Panelcontrol
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboSelItemImageAlignment = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.picToolbar = New System.Windows.Forms.PictureBox
        Me.picMain = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panelcontrol7 = New Itchin.Winforms.Controls.Panelcontrol
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.selItemTextOffsetX = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboSelItemTextAlignment = New System.Windows.Forms.ComboBox
        Me.txtSelCaption = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.pnlCurrentItem.SuspendLayout()
        Me.Panelcontrol8.SuspendLayout()
        Me.Panelcontrol6.SuspendLayout()
        Me.Panelcontrol7.SuspendLayout()
        CType(Me.selItemTextOffsetX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCurrentItem
        '
        Me.pnlCurrentItem.AutoScroll = True
        Me.pnlCurrentItem.Controls.Add(Me.Panelcontrol8)
        Me.pnlCurrentItem.Controls.Add(Me.Panelcontrol6)
        Me.pnlCurrentItem.Controls.Add(Me.Panelcontrol7)
        Me.pnlCurrentItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCurrentItem.GradientColorEnd = System.Drawing.Color.Empty
        Me.pnlCurrentItem.GradientColorStart = System.Drawing.Color.Empty
        Me.pnlCurrentItem.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pnlCurrentItem.Location = New System.Drawing.Point(0, 0)
        Me.pnlCurrentItem.MinHeight = 0
        Me.pnlCurrentItem.Name = "pnlCurrentItem"
        Me.pnlCurrentItem.Size = New System.Drawing.Size(432, 296)
        Me.pnlCurrentItem.TabIndex = 27
        Me.pnlCurrentItem.Text = "Panelcontrol1"
        Me.pnlCurrentItem.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.pnlCurrentItem.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlCurrentItem.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.pnlCurrentItem.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlCurrentItem.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlCurrentItem.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.pnlCurrentItem.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.pnlCurrentItem.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlCurrentItem.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlCurrentItem.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlCurrentItem.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'Panelcontrol8
        '
        Me.Panelcontrol8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panelcontrol8.Controls.Add(Me.cboColor)
        Me.Panelcontrol8.Controls.Add(Me.Label13)
        Me.Panelcontrol8.GradientColorEnd = System.Drawing.Color.Empty
        Me.Panelcontrol8.GradientColorStart = System.Drawing.Color.Empty
        Me.Panelcontrol8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panelcontrol8.Location = New System.Drawing.Point(8, 248)
        Me.Panelcontrol8.MinHeight = 0
        Me.Panelcontrol8.Name = "Panelcontrol8"
        Me.Panelcontrol8.Size = New System.Drawing.Size(417, 40)
        Me.Panelcontrol8.TabIndex = 17
        Me.Panelcontrol8.Text = "Panelcontrol2"
        Me.Panelcontrol8.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Panelcontrol8.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol8.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.Panelcontrol8.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol8.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol8.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.Panelcontrol8.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.Panelcontrol8.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol8.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol8.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol8.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'cboColor
        '
        Me.cboColor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboColor.Appearance = Navbar_Tutorial.ColorPicker.ColorPickerAppearance.ComboBox
        Me.cboColor.Color = System.Drawing.Color.Red
        Me.cboColor.InitalColor = System.Drawing.Color.Red
        Me.cboColor.Location = New System.Drawing.Point(80, 8)
        Me.cboColor.Name = "cboColor"
        Me.cboColor.Size = New System.Drawing.Size(329, 22)
        Me.cboColor.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Sel Color"
        '
        'Panelcontrol6
        '
        Me.Panelcontrol6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panelcontrol6.BackColor = System.Drawing.Color.Transparent
        Me.Panelcontrol6.Controls.Add(Me.Label6)
        Me.Panelcontrol6.Controls.Add(Me.cboSelItemImageAlignment)
        Me.Panelcontrol6.Controls.Add(Me.Label5)
        Me.Panelcontrol6.Controls.Add(Me.picToolbar)
        Me.Panelcontrol6.Controls.Add(Me.picMain)
        Me.Panelcontrol6.Controls.Add(Me.Label4)
        Me.Panelcontrol6.GradientColorEnd = System.Drawing.Color.Empty
        Me.Panelcontrol6.GradientColorStart = System.Drawing.Color.Empty
        Me.Panelcontrol6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panelcontrol6.Location = New System.Drawing.Point(8, 128)
        Me.Panelcontrol6.MinHeight = 0
        Me.Panelcontrol6.Name = "Panelcontrol6"
        Me.Panelcontrol6.Size = New System.Drawing.Size(417, 112)
        Me.Panelcontrol6.TabIndex = 16
        Me.Panelcontrol6.Text = "Panelcontrol2"
        Me.Panelcontrol6.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Panelcontrol6.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol6.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.Panelcontrol6.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol6.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol6.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.Panelcontrol6.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.Panelcontrol6.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol6.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol6.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol6.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(20, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Alignment:"
        '
        'cboSelItemImageAlignment
        '
        Me.cboSelItemImageAlignment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSelItemImageAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelItemImageAlignment.Items.AddRange(New Object() {"TopLeft", "TopRight", "TopCenter", "BottomLeft", "BottomRight", "BottomCenter", "MiddleLeft", "MiddleRight", "MiddleCenter"})
        Me.cboSelItemImageAlignment.Location = New System.Drawing.Point(88, 80)
        Me.cboSelItemImageAlignment.Name = "cboSelItemImageAlignment"
        Me.cboSelItemImageAlignment.Size = New System.Drawing.Size(313, 21)
        Me.cboSelItemImageAlignment.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Images:"
        '
        'picToolbar
        '
        Me.picToolbar.BackColor = System.Drawing.Color.Transparent
        Me.picToolbar.Location = New System.Drawing.Point(192, 24)
        Me.picToolbar.Name = "picToolbar"
        Me.picToolbar.Size = New System.Drawing.Size(48, 48)
        Me.picToolbar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picToolbar.TabIndex = 16
        Me.picToolbar.TabStop = False
        '
        'picMain
        '
        Me.picMain.BackColor = System.Drawing.Color.Transparent
        Me.picMain.Location = New System.Drawing.Point(88, 24)
        Me.picMain.Name = "picMain"
        Me.picMain.Size = New System.Drawing.Size(48, 48)
        Me.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picMain.TabIndex = 15
        Me.picMain.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(96, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Main                          Toolbar"
        '
        'Panelcontrol7
        '
        Me.Panelcontrol7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panelcontrol7.BackColor = System.Drawing.Color.Transparent
        Me.Panelcontrol7.Controls.Add(Me.Label9)
        Me.Panelcontrol7.Controls.Add(Me.Label8)
        Me.Panelcontrol7.Controls.Add(Me.selItemTextOffsetX)
        Me.Panelcontrol7.Controls.Add(Me.Label7)
        Me.Panelcontrol7.Controls.Add(Me.cboSelItemTextAlignment)
        Me.Panelcontrol7.Controls.Add(Me.txtSelCaption)
        Me.Panelcontrol7.Controls.Add(Me.Label3)
        Me.Panelcontrol7.GradientColorEnd = System.Drawing.Color.Empty
        Me.Panelcontrol7.GradientColorStart = System.Drawing.Color.Empty
        Me.Panelcontrol7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panelcontrol7.Location = New System.Drawing.Point(8, 8)
        Me.Panelcontrol7.MinHeight = 0
        Me.Panelcontrol7.Name = "Panelcontrol7"
        Me.Panelcontrol7.Size = New System.Drawing.Size(417, 112)
        Me.Panelcontrol7.TabIndex = 15
        Me.Panelcontrol7.Text = "Panelcontrol2"
        Me.Panelcontrol7.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Panelcontrol7.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol7.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.Panelcontrol7.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol7.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol7.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.Panelcontrol7.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.Panelcontrol7.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol7.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol7.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol7.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(80, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 16)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "x:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(16, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Text Offset:"
        '
        'selItemTextOffsetX
        '
        Me.selItemTextOffsetX.Location = New System.Drawing.Point(104, 72)
        Me.selItemTextOffsetX.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.selItemTextOffsetX.Name = "selItemTextOffsetX"
        Me.selItemTextOffsetX.Size = New System.Drawing.Size(48, 20)
        Me.selItemTextOffsetX.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(16, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Alignment:"
        '
        'cboSelItemTextAlignment
        '
        Me.cboSelItemTextAlignment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSelItemTextAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelItemTextAlignment.Items.AddRange(New Object() {"TopLeft", "TopRight", "TopCenter", "BottomLeft", "BottomRight", "BottomCenter", "MiddleLeft", "MiddleRight", "MiddleCenter"})
        Me.cboSelItemTextAlignment.Location = New System.Drawing.Point(80, 40)
        Me.cboSelItemTextAlignment.Name = "cboSelItemTextAlignment"
        Me.cboSelItemTextAlignment.Size = New System.Drawing.Size(329, 21)
        Me.cboSelItemTextAlignment.TabIndex = 20
        '
        'txtSelCaption
        '
        Me.txtSelCaption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSelCaption.Location = New System.Drawing.Point(80, 8)
        Me.txtSelCaption.Name = "txtSelCaption"
        Me.txtSelCaption.Size = New System.Drawing.Size(329, 20)
        Me.txtSelCaption.TabIndex = 15
        Me.txtSelCaption.Text = ""
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Caption:"
        '
        'ucSelectedItemProps
        '
        Me.Controls.Add(Me.pnlCurrentItem)
        Me.Name = "ucSelectedItemProps"
        Me.Size = New System.Drawing.Size(432, 296)
        Me.pnlCurrentItem.ResumeLayout(False)
        Me.Panelcontrol8.ResumeLayout(False)
        Me.Panelcontrol6.ResumeLayout(False)
        Me.Panelcontrol7.ResumeLayout(False)
        CType(Me.selItemTextOffsetX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub



#End Region

   
    Private Sub m_ParentNavigationBar_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles m_ParentNavigationBar.Invalidated
        SetDefaults()

    End Sub

    Public Sub SetDefaults()
        Dim _sColor As String
        Dim _sItem As String

        With Me.m_ParentNavigationBar.SelectedItem
            If Not Me.m_ParentNavigationBar.SelectedItem Is Nothing Then
                Me.Enabled = True
                Me.cboColor.InitalColor = Me.m_ParentNavigationBar.SelectedForecolor
                Me.picMain.Image = .Image
                Me.picToolbar.Image = .ToolbarImage
                Me.txtSelCaption.Text = .Caption.ToString
                SetComboAlignment(Me.cboSelItemImageAlignment, .MainImagePosition)
                SetComboAlignment(Me.cboSelItemTextAlignment, .TextAlignment)
                selItemTextOffsetX.Value = .TextPaddingOffset.X
            Else
                Me.Enabled = False
                Me.cboColor.InitalColor = Color.Transparent
                Me.picMain.Image = Nothing
                Me.picToolbar.Image = Nothing
                Me.txtSelCaption.Text = Nothing
                selItemTextOffsetX.Value = 0
            End If

        End With

    End Sub


    Private Sub OnCBOValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Not m_ParentNavigationBar.SelectedItem Is Nothing Then

            Select Case sender.Text

                Case "MiddleLeft"
                    If sender Is cboSelItemImageAlignment Then m_ParentNavigationBar.SelectedItem.MainImagePosition = ContentAlignment.MiddleLeft
                    If sender Is cboSelItemTextAlignment Then m_ParentNavigationBar.SelectedItem.TextAlignment = ContentAlignment.MiddleLeft

                Case "MiddleRight"
                    If sender Is cboSelItemImageAlignment Then m_ParentNavigationBar.SelectedItem.MainImagePosition = ContentAlignment.MiddleRight
                    If sender Is Me.cboSelItemTextAlignment Then m_ParentNavigationBar.SelectedItem.TextAlignment = ContentAlignment.MiddleRight

                Case "TopLeft"
                    If sender Is cboSelItemImageAlignment Then m_ParentNavigationBar.SelectedItem.MainImagePosition = ContentAlignment.TopLeft
                    If sender Is Me.cboSelItemTextAlignment Then m_ParentNavigationBar.SelectedItem.TextAlignment = ContentAlignment.TopLeft

                Case "TopRight"
                    If sender Is cboSelItemImageAlignment Then m_ParentNavigationBar.SelectedItem.MainImagePosition = ContentAlignment.TopRight
                    If sender Is Me.cboSelItemTextAlignment Then m_ParentNavigationBar.SelectedItem.TextAlignment = ContentAlignment.TopRight

                Case "BottomLeft"
                    If sender Is cboSelItemImageAlignment Then m_ParentNavigationBar.SelectedItem.MainImagePosition = ContentAlignment.BottomLeft
                    If sender Is cboSelItemTextAlignment Then m_ParentNavigationBar.SelectedItem.TextAlignment = ContentAlignment.BottomLeft

                Case "BottomRight"
                    If sender Is cboSelItemImageAlignment Then m_ParentNavigationBar.SelectedItem.MainImagePosition = ContentAlignment.BottomRight
                    If sender Is Me.cboSelItemTextAlignment Then m_ParentNavigationBar.SelectedItem.TextAlignment = ContentAlignment.BottomRight

                Case "MiddleCenter"
                    If sender Is Me.cboSelItemTextAlignment Then m_ParentNavigationBar.SelectedItem.TextAlignment = ContentAlignment.MiddleCenter
                    If sender Is cboSelItemImageAlignment Then m_ParentNavigationBar.SelectedItem.MainImagePosition = ContentAlignment.MiddleCenter

                Case "BottomCenter"
                    If sender Is Me.cboSelItemTextAlignment Then m_ParentNavigationBar.SelectedItem.TextAlignment = ContentAlignment.BottomCenter
                    If sender Is cboSelItemImageAlignment Then m_ParentNavigationBar.SelectedItem.MainImagePosition = ContentAlignment.BottomCenter

                Case "TopCenter"
                    If sender Is Me.cboSelItemTextAlignment Then m_ParentNavigationBar.SelectedItem.TextAlignment = ContentAlignment.TopCenter
                    If sender Is cboSelItemImageAlignment Then m_ParentNavigationBar.SelectedItem.MainImagePosition = ContentAlignment.TopCenter


            End Select

        End If

    End Sub

    Private Sub m_ParentNavigationBar_ItemSelected(ByVal Panel As Itchin.Winforms.Controls.NavigationBarPane) Handles m_ParentNavigationBar.ItemSelected
        SetDefaults()
    End Sub


    Private Sub m_ParentNavigationBar_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ParentNavigationBar.Validated
        SetDefaults()
    End Sub

    Private Sub ucSelectedItemProps_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        SetDefaults()
    End Sub

    Private Sub selItemTextOffsetX_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selItemTextOffsetX.ValueChanged
        Dim pt As Point
        pt.X = Me.selItemTextOffsetX.Value
        pt.Y = 0
        If Not m_ParentNavigationBar.SelectedItem Is Nothing Then
            Me.m_ParentNavigationBar.SelectedItem.TextPaddingOffset = pt
        End If


    End Sub

    Protected Overrides Sub Finalize()

        RemoveHandler cboSelItemImageAlignment.SelectedIndexChanged, AddressOf OnCBOValueChanged
        RemoveHandler cboSelItemTextAlignment.SelectedIndexChanged, AddressOf OnCBOValueChanged

        MyBase.Finalize()
    End Sub

    Private Sub txtSelCaption_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSelCaption.KeyDown
        If Not m_ParentNavigationBar.SelectedItem Is Nothing Then
            Me.m_ParentNavigationBar.SelectedItem.Caption = Me.txtSelCaption.Text
        End If
    End Sub

    Private Sub txtSelCaption_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSelCaption.KeyUp
        If Not m_ParentNavigationBar.SelectedItem Is Nothing Then
            Me.m_ParentNavigationBar.SelectedItem.Caption = Me.txtSelCaption.Text
        End If
    End Sub

    Private Sub cboColor_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboColor.ColorChanged
        If Not m_ParentNavigationBar.SelectedItem Is Nothing Then
            Me.m_ParentNavigationBar.SelectedForecolor = Me.cboColor.Color
        End If
    End Sub

    
End Class
