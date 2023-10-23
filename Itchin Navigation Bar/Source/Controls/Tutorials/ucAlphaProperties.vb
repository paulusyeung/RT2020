Public Class ucAlphaProperties
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
        AddHandler sbHoverItemAlpha.ValueChanged, AddressOf OnAlphaValueChanged
        AddHandler sbUnSelectedAlpha.ValueChanged, AddressOf OnAlphaValueChanged
        AddHandler sbSelectedAlpha.ValueChanged, AddressOf OnAlphaValueChanged

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
    Friend WithEvents pnlAlphaProperties As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents Panelcontrol5 As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents lblUnSelItemAlpha As System.Windows.Forms.Label
    Friend WithEvents sbUnSelectedAlpha As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblHovItemAlpha As System.Windows.Forms.Label
    Friend WithEvents sbHoverItemAlpha As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSelItemAlpha As System.Windows.Forms.Label
    Friend WithEvents sbSelectedAlpha As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panelcontrol3 As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboUseAlphaSettings As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlAlphaProperties = New Itchin.Winforms.Controls.Panelcontrol
        Me.Panelcontrol5 = New Itchin.Winforms.Controls.Panelcontrol
        Me.lblUnSelItemAlpha = New System.Windows.Forms.Label
        Me.sbUnSelectedAlpha = New System.Windows.Forms.NumericUpDown
        Me.lblHovItemAlpha = New System.Windows.Forms.Label
        Me.sbHoverItemAlpha = New System.Windows.Forms.NumericUpDown
        Me.lblSelItemAlpha = New System.Windows.Forms.Label
        Me.sbSelectedAlpha = New System.Windows.Forms.NumericUpDown
        Me.Panelcontrol3 = New Itchin.Winforms.Controls.Panelcontrol
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboUseAlphaSettings = New System.Windows.Forms.ComboBox
        Me.pnlAlphaProperties.SuspendLayout()
        Me.Panelcontrol5.SuspendLayout()
        CType(Me.sbUnSelectedAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbHoverItemAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbSelectedAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panelcontrol3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAlphaProperties
        '
        Me.pnlAlphaProperties.BackColor = System.Drawing.Color.Transparent
        Me.pnlAlphaProperties.Controls.Add(Me.Panelcontrol5)
        Me.pnlAlphaProperties.Controls.Add(Me.Panelcontrol3)
        Me.pnlAlphaProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAlphaProperties.GradientColorEnd = System.Drawing.Color.Empty
        Me.pnlAlphaProperties.GradientColorStart = System.Drawing.Color.Empty
        Me.pnlAlphaProperties.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pnlAlphaProperties.Location = New System.Drawing.Point(0, 0)
        Me.pnlAlphaProperties.MinHeight = 0
        Me.pnlAlphaProperties.Name = "pnlAlphaProperties"
        Me.pnlAlphaProperties.Size = New System.Drawing.Size(424, 160)
        Me.pnlAlphaProperties.TabIndex = 22
        Me.pnlAlphaProperties.Text = "Panelcontrol1"
        Me.pnlAlphaProperties.Theme = Itchin.Winforms.Generic.Theming.ThemeStyle.Unthemed
        Me.pnlAlphaProperties.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.pnlAlphaProperties.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlAlphaProperties.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(178, Byte), CType(178, Byte), CType(181, Byte))
        Me.pnlAlphaProperties.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(228, Byte), CType(228, Byte), CType(232, Byte))
        Me.pnlAlphaProperties.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(228, Byte), CType(228, Byte), CType(232, Byte))
        Me.pnlAlphaProperties.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(240, Byte), CType(240, Byte), CType(242, Byte))
        Me.pnlAlphaProperties.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.pnlAlphaProperties.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(211, Byte), CType(212, Byte), CType(218, Byte))
        Me.pnlAlphaProperties.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(211, Byte), CType(212, Byte), CType(218, Byte))
        Me.pnlAlphaProperties.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlAlphaProperties.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(178, Byte), CType(178, Byte), CType(181, Byte))
        '
        'Panelcontrol5
        '
        Me.Panelcontrol5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panelcontrol5.Controls.Add(Me.lblUnSelItemAlpha)
        Me.Panelcontrol5.Controls.Add(Me.sbUnSelectedAlpha)
        Me.Panelcontrol5.Controls.Add(Me.lblHovItemAlpha)
        Me.Panelcontrol5.Controls.Add(Me.sbHoverItemAlpha)
        Me.Panelcontrol5.Controls.Add(Me.lblSelItemAlpha)
        Me.Panelcontrol5.Controls.Add(Me.sbSelectedAlpha)
        Me.Panelcontrol5.GradientColorEnd = System.Drawing.Color.Empty
        Me.Panelcontrol5.GradientColorStart = System.Drawing.Color.Empty
        Me.Panelcontrol5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panelcontrol5.Location = New System.Drawing.Point(8, 48)
        Me.Panelcontrol5.MinHeight = 0
        Me.Panelcontrol5.Name = "Panelcontrol5"
        Me.Panelcontrol5.Size = New System.Drawing.Size(408, 104)
        Me.Panelcontrol5.TabIndex = 18
        Me.Panelcontrol5.Text = "Panelcontrol2"
        Me.Panelcontrol5.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Panelcontrol5.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol5.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.Panelcontrol5.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol5.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol5.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.Panelcontrol5.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.Panelcontrol5.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol5.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol5.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol5.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'lblUnSelItemAlpha
        '
        Me.lblUnSelItemAlpha.BackColor = System.Drawing.Color.Transparent
        Me.lblUnSelItemAlpha.Location = New System.Drawing.Point(8, 72)
        Me.lblUnSelItemAlpha.Name = "lblUnSelItemAlpha"
        Me.lblUnSelItemAlpha.Size = New System.Drawing.Size(120, 16)
        Me.lblUnSelItemAlpha.TabIndex = 19
        Me.lblUnSelItemAlpha.Text = "Unselected Item Alpha"
        '
        'sbUnSelectedAlpha
        '
        Me.sbUnSelectedAlpha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbUnSelectedAlpha.Location = New System.Drawing.Point(128, 72)
        Me.sbUnSelectedAlpha.Name = "sbUnSelectedAlpha"
        Me.sbUnSelectedAlpha.Size = New System.Drawing.Size(274, 20)
        Me.sbUnSelectedAlpha.TabIndex = 20
        Me.sbUnSelectedAlpha.Tag = "2"
        Me.sbUnSelectedAlpha.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblHovItemAlpha
        '
        Me.lblHovItemAlpha.BackColor = System.Drawing.Color.Transparent
        Me.lblHovItemAlpha.Location = New System.Drawing.Point(8, 40)
        Me.lblHovItemAlpha.Name = "lblHovItemAlpha"
        Me.lblHovItemAlpha.Size = New System.Drawing.Size(112, 16)
        Me.lblHovItemAlpha.TabIndex = 17
        Me.lblHovItemAlpha.Text = "Hover Item Alpha"
        '
        'sbHoverItemAlpha
        '
        Me.sbHoverItemAlpha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbHoverItemAlpha.Location = New System.Drawing.Point(128, 40)
        Me.sbHoverItemAlpha.Name = "sbHoverItemAlpha"
        Me.sbHoverItemAlpha.Size = New System.Drawing.Size(274, 20)
        Me.sbHoverItemAlpha.TabIndex = 18
        Me.sbHoverItemAlpha.Tag = "1"
        Me.sbHoverItemAlpha.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblSelItemAlpha
        '
        Me.lblSelItemAlpha.BackColor = System.Drawing.Color.Transparent
        Me.lblSelItemAlpha.Location = New System.Drawing.Point(8, 8)
        Me.lblSelItemAlpha.Name = "lblSelItemAlpha"
        Me.lblSelItemAlpha.Size = New System.Drawing.Size(120, 16)
        Me.lblSelItemAlpha.TabIndex = 14
        Me.lblSelItemAlpha.Text = "Selected Item Alpha"
        '
        'sbSelectedAlpha
        '
        Me.sbSelectedAlpha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbSelectedAlpha.Location = New System.Drawing.Point(128, 6)
        Me.sbSelectedAlpha.Name = "sbSelectedAlpha"
        Me.sbSelectedAlpha.Size = New System.Drawing.Size(274, 20)
        Me.sbSelectedAlpha.TabIndex = 16
        Me.sbSelectedAlpha.Tag = "0"
        Me.sbSelectedAlpha.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Panelcontrol3
        '
        Me.Panelcontrol3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panelcontrol3.Controls.Add(Me.Label1)
        Me.Panelcontrol3.Controls.Add(Me.cboUseAlphaSettings)
        Me.Panelcontrol3.GradientColorEnd = System.Drawing.Color.Empty
        Me.Panelcontrol3.GradientColorStart = System.Drawing.Color.Empty
        Me.Panelcontrol3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panelcontrol3.Location = New System.Drawing.Point(8, 8)
        Me.Panelcontrol3.MinHeight = 0
        Me.Panelcontrol3.Name = "Panelcontrol3"
        Me.Panelcontrol3.Size = New System.Drawing.Size(408, 32)
        Me.Panelcontrol3.TabIndex = 15
        Me.Panelcontrol3.Text = "Panelcontrol2"
        Me.Panelcontrol3.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Panelcontrol3.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol3.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.Panelcontrol3.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol3.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol3.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.Panelcontrol3.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.Panelcontrol3.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol3.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol3.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol3.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Use alpha Settings"
        '
        'cboUseAlphaSettings
        '
        Me.cboUseAlphaSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUseAlphaSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUseAlphaSettings.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboUseAlphaSettings.Location = New System.Drawing.Point(128, 6)
        Me.cboUseAlphaSettings.Name = "cboUseAlphaSettings"
        Me.cboUseAlphaSettings.Size = New System.Drawing.Size(272, 21)
        Me.cboUseAlphaSettings.TabIndex = 13
        '
        'ucAlphaProperties
        '
        Me.Controls.Add(Me.pnlAlphaProperties)
        Me.Name = "ucAlphaProperties"
        Me.Size = New System.Drawing.Size(424, 160)
        Me.pnlAlphaProperties.ResumeLayout(False)
        Me.Panelcontrol5.ResumeLayout(False)
        CType(Me.sbUnSelectedAlpha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbHoverItemAlpha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbSelectedAlpha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panelcontrol3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        RemoveHandler sbHoverItemAlpha.ValueChanged, AddressOf OnAlphaValueChanged
        RemoveHandler sbUnSelectedAlpha.ValueChanged, AddressOf OnAlphaValueChanged
        RemoveHandler sbSelectedAlpha.ValueChanged, AddressOf OnAlphaValueChanged
        MyBase.Finalize()
    End Sub

    Private Sub OnAlphaValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case sender.tag
            Case Is = 0 : m_ParentNavigationBar.AlphaSettings.SelectedItemAlpha = sender.value
                AddToEvents(Me.m_EventsView, " (Navbar Selected Alpha Setting Change: " & m_ParentNavigationBar.AlphaSettings.SelectedItemAlpha & ")", "Alpha Settings")
            Case Is = 1 : m_ParentNavigationBar.AlphaSettings.HoverItemAlpha = sender.value
                AddToEvents(Me.m_EventsView, " (Navbar Hover Alpha Setting Change: " & m_ParentNavigationBar.AlphaSettings.HoverItemAlpha & ")", "Alpha Settings")
            Case Is = 2 : m_ParentNavigationBar.AlphaSettings.UnselectedItemAlpha = sender.value
                AddToEvents(Me.m_EventsView, " (Navbar Unselected Alpha Setting Change: " & m_ParentNavigationBar.AlphaSettings.UnselectedItemAlpha & ")", "Alpha Settings")

        End Select
    End Sub

    Private Sub m_ParentNavigationBar_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ParentNavigationBar.Validated
        Me.sbHoverItemAlpha.Value = m_ParentNavigationBar.AlphaSettings.HoverItemAlpha
        Me.sbSelectedAlpha.Value = m_ParentNavigationBar.AlphaSettings.SelectedItemAlpha
        Me.sbUnSelectedAlpha.Value = m_ParentNavigationBar.AlphaSettings.UnselectedItemAlpha

    End Sub

    Private Sub cboUseAlphaSettings_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUseAlphaSettings.SelectedIndexChanged
        m_ParentNavigationBar.AlphaSettings.UseAlphaSettings = Me.cboUseAlphaSettings.SelectedIndex = 0
        AddToEvents(Me.m_EventsView, " (Use Alpha Settings: " & m_ParentNavigationBar.AlphaSettings.UseAlphaSettings & ")", "Alpha Settings")

    End Sub

    Private Sub m_ParentNavigationBar_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles m_ParentNavigationBar.Invalidated
        SetDefaults()
    End Sub

    Private Sub ucAlphaProperties_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        SetDefaults()
    End Sub

    Public Sub SetDefaults()

        Me.sbHoverItemAlpha.Value = m_ParentNavigationBar.AlphaSettings.HoverItemAlpha
        Me.sbSelectedAlpha.Value = m_ParentNavigationBar.AlphaSettings.SelectedItemAlpha
        Me.sbUnSelectedAlpha.Value = m_ParentNavigationBar.AlphaSettings.UnselectedItemAlpha
        Me.cboUseAlphaSettings.Text = IIf(m_ParentNavigationBar.AlphaSettings.UseAlphaSettings, "Yes", "No")

    End Sub
End Class
