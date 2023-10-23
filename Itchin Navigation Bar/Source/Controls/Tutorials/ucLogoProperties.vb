Public Class ucLogoProperties
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
        If Me.sbLogoAlpha.Value <> Me.m_ParentNavigationBar.Logo.Alpha Then
            Me.sbLogoAlpha.Value = Me.m_ParentNavigationBar.Logo.Alpha
        End If
        SetDefaults()
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
    Friend WithEvents pnlPropertiesLogo As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents Panelcontrol1 As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents lblLogoAlpha As System.Windows.Forms.Label
    Friend WithEvents sbLogoAlpha As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panelcontrol4 As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboUseLogo As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlPropertiesLogo = New Itchin.Winforms.Controls.Panelcontrol
        Me.Panelcontrol1 = New Itchin.Winforms.Controls.Panelcontrol
        Me.lblLogoAlpha = New System.Windows.Forms.Label
        Me.sbLogoAlpha = New System.Windows.Forms.NumericUpDown
        Me.Panelcontrol4 = New Itchin.Winforms.Controls.Panelcontrol
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboUseLogo = New System.Windows.Forms.ComboBox
        Me.pnlPropertiesLogo.SuspendLayout()
        Me.Panelcontrol1.SuspendLayout()
        CType(Me.sbLogoAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panelcontrol4.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPropertiesLogo
        '
        Me.pnlPropertiesLogo.Controls.Add(Me.Panelcontrol1)
        Me.pnlPropertiesLogo.Controls.Add(Me.Panelcontrol4)
        Me.pnlPropertiesLogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPropertiesLogo.GradientColorEnd = System.Drawing.Color.Empty
        Me.pnlPropertiesLogo.GradientColorStart = System.Drawing.Color.Empty
        Me.pnlPropertiesLogo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pnlPropertiesLogo.Location = New System.Drawing.Point(0, 0)
        Me.pnlPropertiesLogo.MinHeight = 0
        Me.pnlPropertiesLogo.Name = "pnlPropertiesLogo"
        Me.pnlPropertiesLogo.Size = New System.Drawing.Size(448, 88)
        Me.pnlPropertiesLogo.TabIndex = 25
        Me.pnlPropertiesLogo.Text = "Panelcontrol1"
        Me.pnlPropertiesLogo.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.pnlPropertiesLogo.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlPropertiesLogo.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.pnlPropertiesLogo.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlPropertiesLogo.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlPropertiesLogo.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.pnlPropertiesLogo.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.pnlPropertiesLogo.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlPropertiesLogo.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlPropertiesLogo.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlPropertiesLogo.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'Panelcontrol1
        '
        Me.Panelcontrol1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panelcontrol1.Controls.Add(Me.lblLogoAlpha)
        Me.Panelcontrol1.Controls.Add(Me.sbLogoAlpha)
        Me.Panelcontrol1.GradientColorEnd = System.Drawing.Color.Empty
        Me.Panelcontrol1.GradientColorStart = System.Drawing.Color.Empty
        Me.Panelcontrol1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panelcontrol1.Location = New System.Drawing.Point(8, 48)
        Me.Panelcontrol1.MinHeight = 0
        Me.Panelcontrol1.Name = "Panelcontrol1"
        Me.Panelcontrol1.Size = New System.Drawing.Size(432, 32)
        Me.Panelcontrol1.TabIndex = 17
        Me.Panelcontrol1.Text = "Panelcontrol2"
        Me.Panelcontrol1.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Panelcontrol1.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol1.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.Panelcontrol1.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol1.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol1.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.Panelcontrol1.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.Panelcontrol1.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol1.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol1.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol1.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'lblLogoAlpha
        '
        Me.lblLogoAlpha.BackColor = System.Drawing.Color.Transparent
        Me.lblLogoAlpha.Location = New System.Drawing.Point(16, 8)
        Me.lblLogoAlpha.Name = "lblLogoAlpha"
        Me.lblLogoAlpha.Size = New System.Drawing.Size(104, 16)
        Me.lblLogoAlpha.TabIndex = 14
        Me.lblLogoAlpha.Text = "Logo Alpha"
        '
        'sbLogoAlpha
        '
        Me.sbLogoAlpha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbLogoAlpha.Location = New System.Drawing.Point(128, 6)
        Me.sbLogoAlpha.Name = "sbLogoAlpha"
        Me.sbLogoAlpha.Size = New System.Drawing.Size(298, 20)
        Me.sbLogoAlpha.TabIndex = 16
        Me.sbLogoAlpha.Tag = "3"
        Me.sbLogoAlpha.Value = Me.m_ParentNavigationBar.Logo.Alpha ' New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Panelcontrol4
        '
        Me.Panelcontrol4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panelcontrol4.Controls.Add(Me.Label2)
        Me.Panelcontrol4.Controls.Add(Me.cboUseLogo)
        Me.Panelcontrol4.GradientColorEnd = System.Drawing.Color.Empty
        Me.Panelcontrol4.GradientColorStart = System.Drawing.Color.Empty
        Me.Panelcontrol4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panelcontrol4.Location = New System.Drawing.Point(8, 8)
        Me.Panelcontrol4.MinHeight = 0
        Me.Panelcontrol4.Name = "Panelcontrol4"
        Me.Panelcontrol4.Size = New System.Drawing.Size(432, 32)
        Me.Panelcontrol4.TabIndex = 15
        Me.Panelcontrol4.Text = "Panelcontrol2"
        Me.Panelcontrol4.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Panelcontrol4.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol4.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.Panelcontrol4.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol4.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.Panelcontrol4.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.Panelcontrol4.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.Panelcontrol4.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol4.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.Panelcontrol4.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.Panelcontrol4.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(16, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Use Logo"
        '
        'cboUseLogo
        '
        Me.cboUseLogo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUseLogo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUseLogo.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboUseLogo.Location = New System.Drawing.Point(128, 6)
        Me.cboUseLogo.Name = "cboUseLogo"
        Me.cboUseLogo.Size = New System.Drawing.Size(296, 21)
        Me.cboUseLogo.TabIndex = 13
        '
        'ucLogoProperties
        '
        Me.Controls.Add(Me.pnlPropertiesLogo)
        Me.Name = "ucLogoProperties"
        Me.Size = New System.Drawing.Size(448, 88)
        Me.pnlPropertiesLogo.ResumeLayout(False)
        Me.Panelcontrol1.ResumeLayout(False)
        CType(Me.sbLogoAlpha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panelcontrol4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub m_ParentNavigationBar_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles m_ParentNavigationBar.Invalidated
        SetDefaults()
    End Sub

    Private Sub cboUseLogo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUseLogo.SelectedIndexChanged
        Me.m_ParentNavigationBar.Logo.DisplayLogo = Me.cboUseLogo.SelectedIndex = 0
        AddToEvents(Me.m_EventsView, " (Use Logo : " & Me.m_ParentNavigationBar.Logo.DisplayLogo & ")", "Logo Settings")
    End Sub

    Private Sub sbLogoAlpha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbLogoAlpha.ValueChanged
        Me.m_ParentNavigationBar.Logo.Alpha = Me.sbLogoAlpha.Value
        AddToEvents(Me.m_EventsView, " (Logo Alpha : " & m_ParentNavigationBar.Logo.Alpha & ")", "Logo Alpha Settings")

    End Sub

    Public Sub SetDefaults()

        Me.sbLogoAlpha.Value = m_ParentNavigationBar.Logo.Alpha
        Me.cboUseLogo.Text = IIf(m_ParentNavigationBar.Logo.DisplayLogo, "Yes", "No")

    End Sub

    Private Sub m_ParentNavigationBar_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ParentNavigationBar.Validated
        SetDefaults()
    End Sub

    Private Sub ucLogoProperties_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        SetDefaults()
    End Sub
End Class
