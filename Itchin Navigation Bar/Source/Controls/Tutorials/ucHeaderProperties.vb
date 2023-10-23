Public Class ucHeaderProperties
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
    Friend WithEvents pnlHeaderProperties As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents lblHeaderShowHide As System.Windows.Forms.Label
    Friend WithEvents lblHeaderFontName As System.Windows.Forms.Label
    Friend WithEvents lblHeaderfont As System.Windows.Forms.Label
    Friend WithEvents cboHeader As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlHeaderProperties = New Itchin.Winforms.Controls.Panelcontrol
        Me.btnFont = New System.Windows.Forms.Button
        Me.lblHeaderShowHide = New System.Windows.Forms.Label
        Me.lblHeaderFontName = New System.Windows.Forms.Label
        Me.lblHeaderfont = New System.Windows.Forms.Label
        Me.cboHeader = New System.Windows.Forms.ComboBox
        Me.pnlHeaderProperties.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeaderProperties
        '
        Me.pnlHeaderProperties.Controls.Add(Me.btnFont)
        Me.pnlHeaderProperties.Controls.Add(Me.lblHeaderShowHide)
        Me.pnlHeaderProperties.Controls.Add(Me.lblHeaderFontName)
        Me.pnlHeaderProperties.Controls.Add(Me.lblHeaderfont)
        Me.pnlHeaderProperties.Controls.Add(Me.cboHeader)
        Me.pnlHeaderProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeaderProperties.GradientColorEnd = System.Drawing.Color.Empty
        Me.pnlHeaderProperties.GradientColorStart = System.Drawing.Color.Empty
        Me.pnlHeaderProperties.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pnlHeaderProperties.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeaderProperties.MinHeight = 0
        Me.pnlHeaderProperties.Name = "pnlHeaderProperties"
        Me.pnlHeaderProperties.Size = New System.Drawing.Size(336, 96)
        Me.pnlHeaderProperties.TabIndex = 17
        Me.pnlHeaderProperties.Text = "Panelcontrol3"
        Me.pnlHeaderProperties.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.pnlHeaderProperties.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlHeaderProperties.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.pnlHeaderProperties.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlHeaderProperties.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlHeaderProperties.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.pnlHeaderProperties.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.pnlHeaderProperties.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlHeaderProperties.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlHeaderProperties.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlHeaderProperties.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'btnFont
        '
        Me.btnFont.BackColor = System.Drawing.Color.Transparent
        Me.btnFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFont.Location = New System.Drawing.Point(48, 56)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.Size = New System.Drawing.Size(32, 22)
        Me.btnFont.TabIndex = 16
        Me.btnFont.Text = "..."
        Me.btnFont.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHeaderShowHide
        '
        Me.lblHeaderShowHide.BackColor = System.Drawing.Color.Transparent
        Me.lblHeaderShowHide.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeaderShowHide.Location = New System.Drawing.Point(8, 16)
        Me.lblHeaderShowHide.Name = "lblHeaderShowHide"
        Me.lblHeaderShowHide.Size = New System.Drawing.Size(72, 16)
        Me.lblHeaderShowHide.TabIndex = 19
        Me.lblHeaderShowHide.Text = "Display"
        '
        'lblHeaderFontName
        '
        Me.lblHeaderFontName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeaderFontName.BackColor = System.Drawing.Color.Transparent
        Me.lblHeaderFontName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeaderFontName.Location = New System.Drawing.Point(88, 56)
        Me.lblHeaderFontName.Name = "lblHeaderFontName"
        Me.lblHeaderFontName.Size = New System.Drawing.Size(242, 96)
        Me.lblHeaderFontName.TabIndex = 18
        '
        'lblHeaderfont
        '
        Me.lblHeaderfont.BackColor = System.Drawing.Color.Transparent
        Me.lblHeaderfont.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeaderfont.Location = New System.Drawing.Point(8, 56)
        Me.lblHeaderfont.Name = "lblHeaderfont"
        Me.lblHeaderfont.Size = New System.Drawing.Size(40, 16)
        Me.lblHeaderfont.TabIndex = 17
        Me.lblHeaderfont.Text = "Font"
        '
        'cboHeader
        '
        Me.cboHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboHeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHeader.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboHeader.Location = New System.Drawing.Point(88, 16)
        Me.cboHeader.Name = "cboHeader"
        Me.cboHeader.Size = New System.Drawing.Size(240, 21)
        Me.cboHeader.TabIndex = 13
        '
        'ucHeaderProperties
        '
        Me.Controls.Add(Me.pnlHeaderProperties)
        Me.Name = "ucHeaderProperties"
        Me.Size = New System.Drawing.Size(336, 96)
        Me.pnlHeaderProperties.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cboHeader_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHeader.SelectedIndexChanged
        Me.m_ParentNavigationBar.DisplayHeader = CBool(cboHeader.SelectedIndex = 0)
        AddToEvents(Me.m_EventsView, " (Header: " & Me.m_ParentNavigationBar.DisplayHeader & ")", "Header")

    End Sub

    Private Sub m_ParentNavigationBar_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_ParentNavigationBar.Validated
        SetDefaults()
    End Sub

    Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
        Dim _FSObject As FontDialog = New FontDialog

        With _FSObject
            .Font = Me.m_ParentNavigationBar.HeaderFont
            .ShowDialog(Me)
            Me.m_ParentNavigationBar.HeaderFont = .Font
            Me.lblHeaderFontName.Text = .Font.ToString
        End With

        _FSObject.Dispose()
    End Sub

    Public Sub SetDefaults()
        Me.cboHeader.Text = IIf(m_ParentNavigationBar.DisplayHeader, "Yes", "No")
        Me.lblHeaderFontName.Text = Me.m_ParentNavigationBar.Font.ToString
    End Sub

    Private Sub ucHeaderProperties_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        SetDefaults()
    End Sub
End Class
