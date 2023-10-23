Public Class ucCurrentNavBarTheme
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
        '-- Set up our theme style options
        Me.cboThemeType.Items.Add(Itchin.Winforms.Generic.Theming.ThemeStyle.HomeStead.ToString)
        Me.cboThemeType.Items.Add(Itchin.Winforms.Generic.Theming.ThemeStyle.Metallic.ToString)
        Me.cboThemeType.Items.Add(Itchin.Winforms.Generic.Theming.ThemeStyle.NormalColor.ToString)
        Me.cboThemeType.Items.Add(Itchin.Winforms.Generic.Theming.ThemeStyle.Unthemed.ToString)
        Me.cboThemeType.Items.Add("Custom")
        Me.cboThemeType.Items.Add("Automatic")
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
    Friend WithEvents pnlThemeProperties As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents Panelcontrol2 As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents lblCurrenttheme As System.Windows.Forms.Label
    Friend WithEvents cboThemeType As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlThemeProperties = New Itchin.Winforms.Controls.Panelcontrol
        Me.Panelcontrol2 = New Itchin.Winforms.Controls.Panelcontrol
        Me.lblCurrenttheme = New System.Windows.Forms.Label
        Me.cboThemeType = New System.Windows.Forms.ComboBox
        Me.pnlThemeProperties.SuspendLayout()
        Me.Panelcontrol2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlThemeProperties
        '
        Me.pnlThemeProperties.Controls.Add(Me.Panelcontrol2)
        Me.pnlThemeProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlThemeProperties.GradientColorEnd = System.Drawing.Color.Empty
        Me.pnlThemeProperties.GradientColorStart = System.Drawing.Color.Empty
        Me.pnlThemeProperties.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pnlThemeProperties.Location = New System.Drawing.Point(0, 0)
        Me.pnlThemeProperties.MinHeight = 0
        Me.pnlThemeProperties.Name = "pnlThemeProperties"
        Me.pnlThemeProperties.Size = New System.Drawing.Size(464, 48)
        Me.pnlThemeProperties.TabIndex = 21
        Me.pnlThemeProperties.Text = "Panelcontrol1"
        Me.pnlThemeProperties.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.pnlThemeProperties.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlThemeProperties.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.pnlThemeProperties.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlThemeProperties.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlThemeProperties.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.pnlThemeProperties.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.pnlThemeProperties.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlThemeProperties.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlThemeProperties.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlThemeProperties.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'Panelcontrol2
        '
        Me.Panelcontrol2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panelcontrol2.Controls.Add(Me.lblCurrenttheme)
        Me.Panelcontrol2.Controls.Add(Me.cboThemeType)
        Me.Panelcontrol2.GradientColorEnd = System.Drawing.Color.Empty
        Me.Panelcontrol2.GradientColorStart = System.Drawing.Color.Empty
        Me.Panelcontrol2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panelcontrol2.Location = New System.Drawing.Point(8, 8)
        Me.Panelcontrol2.MinHeight = 0
        Me.Panelcontrol2.Name = "Panelcontrol2"
        Me.Panelcontrol2.Size = New System.Drawing.Size(448, 32)
        Me.Panelcontrol2.TabIndex = 15
        Me.Panelcontrol2.Text = "Panelcontrol2"
        Me.Panelcontrol2.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Panelcontrol2.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol2.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.Panelcontrol2.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol2.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol2.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.Panelcontrol2.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.Panelcontrol2.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol2.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol2.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol2.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'lblCurrenttheme
        '
        Me.lblCurrenttheme.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrenttheme.Location = New System.Drawing.Point(16, 8)
        Me.lblCurrenttheme.Name = "lblCurrenttheme"
        Me.lblCurrenttheme.Size = New System.Drawing.Size(88, 16)
        Me.lblCurrenttheme.TabIndex = 14
        Me.lblCurrenttheme.Text = "Current Theme"
        '
        'cboThemeType
        '
        Me.cboThemeType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboThemeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboThemeType.Location = New System.Drawing.Point(112, 6)
        Me.cboThemeType.Name = "cboThemeType"
        Me.cboThemeType.Size = New System.Drawing.Size(328, 21)
        Me.cboThemeType.TabIndex = 13
        '
        'ucCurrentNavBarTheme
        '
        Me.Controls.Add(Me.pnlThemeProperties)
        Me.Name = "ucCurrentNavBarTheme"
        Me.Size = New System.Drawing.Size(464, 48)
        Me.pnlThemeProperties.ResumeLayout(False)
        Me.Panelcontrol2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cboThemeType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboThemeType.SelectedIndexChanged
        Select Case Me.cboThemeType.SelectedIndex
            '-- HomeStead
        Case Is = 0 : m_NavbarThemeHandler.Enabled = False : m_ParentNavigationBar.Theme = Itchin.Winforms.Generic.Theming.ThemeStyle.HomeStead
                AddToEvents(m_EventsView, " (Themeing)", "Set to HomeStead")

                '-- Metallic Theme
            Case Is = 1 : m_NavbarThemeHandler.Enabled = False
                m_ParentNavigationBar.Theme = Itchin.Winforms.Generic.Theming.ThemeStyle.Metallic
                AddToEvents(m_EventsView, " (Themeing)", "Set to Metallic")

                '-- Normal Color (Blue)
            Case Is = 2 : m_NavbarThemeHandler.Enabled = False : m_ParentNavigationBar.Theme = Itchin.Winforms.Generic.Theming.ThemeStyle.NormalColor
                AddToEvents(m_EventsView, " (Themeing)", "Set to Normal color")

                '-- Unthemed
            Case Is = 3 : m_NavbarThemeHandler.Enabled = False : m_ParentNavigationBar.Theme = Itchin.Winforms.Generic.Theming.ThemeStyle.Unthemed
                AddToEvents(m_EventsView, " (Themeing)", "Set to Unthemed")

                '-- Custom Theme
            Case Is = 4 : m_NavbarThemeHandler.Enabled = False : m_ParentNavigationBar.ThemeFormat = m_NavbarCustomTheme
                AddToEvents(m_EventsView, " (Themeing)", "Set to Custom")

                '-- Automatic themeing
            Case Is = 5 : m_NavbarThemeHandler.Enabled = True
                AddToEvents(m_EventsView, " (Themeing)", "Set to Automatic")

        End Select
    End Sub

    Private Sub m_ParentNavigationBar_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles m_ParentNavigationBar.Validating
        SetDefaults()
    End Sub

    Private Sub ucCurrentNavBarTheme_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        SetDefaults()
    End Sub

    Public Sub SetDefaults()

        Me.cboThemeType.Text = m_ParentNavigationBar.Theme.ToString

    End Sub
End Class
