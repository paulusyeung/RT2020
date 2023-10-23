

Public Class Form1
    Inherits System.Windows.Forms.Form

    '-- Automatic Theme Support
    'Dim mL As Phantom.Generic.Theming.ThemeListener = New Phantom.Generic.Theming.ThemeListener(Me)

#Region " Windows Form Designer generated code "

    Public Sub New()


        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents Panelcontrol1 As Phantom.Controls.Panelcontrol
    Friend WithEvents NavigationBar1 As Phantom.Controls.NavigationBar
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents NavigationBarPane1 As Phantom.Controls.NavigationBarPane
    Friend WithEvents NavigationBarPane2 As Phantom.Controls.NavigationBarPane
    Friend WithEvents NavigationBarPane3 As Phantom.Controls.NavigationBarPane
    Friend WithEvents NavigationBarPane4 As Phantom.Controls.NavigationBarPane
    Friend WithEvents Panelcontrol2 As Phantom.Controls.Panelcontrol


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panelcontrol1 = New Phantom.Controls.Panelcontrol
        Me.Panelcontrol2 = New Phantom.Controls.Panelcontrol
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.NavigationBar1 = New Phantom.Controls.NavigationBar
        Me.NavigationBarPane1 = New Phantom.Controls.NavigationBarPane
        Me.NavigationBarPane2 = New Phantom.Controls.NavigationBarPane
        Me.NavigationBarPane3 = New Phantom.Controls.NavigationBarPane
        Me.NavigationBarPane4 = New Phantom.Controls.NavigationBarPane
        Me.Panelcontrol1.SuspendLayout()
        Me.NavigationBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panelcontrol1
        '
        Me.Panelcontrol1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panelcontrol1.BackColor = System.Drawing.SystemColors.Control
        Me.Panelcontrol1.Controls.Add(Me.Panelcontrol2)
        Me.Panelcontrol1.Controls.Add(Me.Splitter1)
        Me.Panelcontrol1.Controls.Add(Me.NavigationBar1)
        Me.Panelcontrol1.GradientColorEnd = System.Drawing.Color.Empty
        Me.Panelcontrol1.GradientColorStart = System.Drawing.Color.Empty
        Me.Panelcontrol1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panelcontrol1.Location = New System.Drawing.Point(2, 2)
        Me.Panelcontrol1.MinHeight = 0
        Me.Panelcontrol1.Name = "Panelcontrol1"
        Me.Panelcontrol1.Size = New System.Drawing.Size(691, 466)
        Me.Panelcontrol1.TabIndex = 0
        Me.Panelcontrol1.Text = "Panelcontrol1"
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
        'Panelcontrol2
        '
        Me.Panelcontrol2.BackColor = System.Drawing.SystemColors.Control
        Me.Panelcontrol2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panelcontrol2.GradientColorEnd = System.Drawing.Color.Empty
        Me.Panelcontrol2.GradientColorStart = System.Drawing.Color.Empty
        Me.Panelcontrol2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.Panelcontrol2.Location = New System.Drawing.Point(202, 0)
        Me.Panelcontrol2.MinHeight = 50
        Me.Panelcontrol2.Name = "Panelcontrol2"
        Me.Panelcontrol2.Size = New System.Drawing.Size(489, 466)
        Me.Panelcontrol2.TabIndex = 2
        Me.Panelcontrol2.Text = "Panelcontrol2"
        Me.Panelcontrol2.Theme = Phantom.Generic.Theming.ThemeStyle.Unthemed
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
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Splitter1.Location = New System.Drawing.Point(200, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(2, 466)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'NavigationBar1
        '
        Me.NavigationBar1.AlphaSettings.HoverItemAlpha = 70
        Me.NavigationBar1.AlphaSettings.SelectedItemAlpha = 100
        Me.NavigationBar1.AlphaSettings.UnselectedItemAlpha = 70
        Me.NavigationBar1.AlphaSettings.UseAlphaSettings = False
        Me.NavigationBar1.Controls.Add(Me.NavigationBarPane1)
        Me.NavigationBar1.Controls.Add(Me.NavigationBarPane2)
        Me.NavigationBar1.Controls.Add(Me.NavigationBarPane3)
        Me.NavigationBar1.Controls.Add(Me.NavigationBarPane4)
        Me.NavigationBar1.Cursor = System.Windows.Forms.Cursors.Default
        Me.NavigationBar1.DesignTimeEdit = True
        Me.NavigationBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavigationBar1.HeaderFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.NavigationBar1.HeaderForeColor = System.Drawing.Color.White
        Me.NavigationBar1.HeaderTextalignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationBar1.Location = New System.Drawing.Point(0, 0)
        Me.NavigationBar1.Logo.Alpha = 50
        Me.NavigationBar1.Logo.DisplayLogo = True
        Me.NavigationBar1.Logo.Image = Nothing
        Me.NavigationBar1.LogoImagePosition = Phantom.Generic.ImagePosition.BottomRight
        Me.NavigationBar1.Name = "NavigationBar1"
        Me.NavigationBar1.Panels.Add(Me.NavigationBarPane1)
        Me.NavigationBar1.Panels.Add(Me.NavigationBarPane2)
        Me.NavigationBar1.Panels.Add(Me.NavigationBarPane3)
        Me.NavigationBar1.Panels.Add(Me.NavigationBarPane4)
        Me.NavigationBar1.SelectedForecolor = System.Drawing.Color.Red

        Me.NavigationBar1.Size = New System.Drawing.Size(200, 466)
        Me.NavigationBar1.TabIndex = 0
        Me.NavigationBar1.Text = "NavigationBar1"
        Me.NavigationBar1.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.NavigationBar1.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.NavigationBar1.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.NavigationBar1.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.NavigationBar1.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.NavigationBar1.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.NavigationBar1.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.NavigationBar1.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.NavigationBar1.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.NavigationBar1.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.NavigationBar1.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.NavigationBar1.ToolTipTimeOut = 5000
        Me.NavigationBar1.VisibleItems = 3

        '
        'NavigationBarPane1
        '
        Me.NavigationBarPane1.Caption = "Panel Item"
        Me.NavigationBarPane1.Hidden = False
        Me.NavigationBarPane1.Location = New System.Drawing.Point(1, 26)
        Me.NavigationBarPane1.MainImagePosition = Phantom.Generic.ImagePosition.Center
        Me.NavigationBarPane1.Name = "NavigationBarPane1"
        Me.NavigationBarPane1.Selected = False
        Me.NavigationBarPane1.Size = New System.Drawing.Size(198, 308)
        Me.NavigationBarPane1.TabIndex = 17
        Me.NavigationBarPane1.TabStop = True
        Me.NavigationBarPane1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationBarPane1.TextPaddingOffset = New System.Drawing.Point(0, 0)
        '
        'NavigationBarPane2
        '
        Me.NavigationBarPane2.Caption = "Panel Item"
        Me.NavigationBarPane2.Hidden = False
        Me.NavigationBarPane2.Location = New System.Drawing.Point(1, 26)
        Me.NavigationBarPane2.MainImagePosition = Phantom.Generic.ImagePosition.Center
        Me.NavigationBarPane2.Name = "NavigationBarPane2"
        Me.NavigationBarPane2.Selected = True
        Me.NavigationBarPane2.Size = New System.Drawing.Size(198, 308)
        Me.NavigationBarPane2.TabIndex = 18
        Me.NavigationBarPane2.TabStop = True
        Me.NavigationBarPane2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationBarPane2.TextPaddingOffset = New System.Drawing.Point(0, 0)
        '
        'NavigationBarPane3
        '
        Me.NavigationBarPane3.Caption = "Panel Item"
        Me.NavigationBarPane3.Hidden = True
        Me.NavigationBarPane3.Location = New System.Drawing.Point(1, 26)
        Me.NavigationBarPane3.MainImagePosition = Phantom.Generic.ImagePosition.Center
        Me.NavigationBarPane3.Name = "NavigationBarPane3"
        Me.NavigationBarPane3.Selected = False
        Me.NavigationBarPane3.Size = New System.Drawing.Size(198, 298)
        Me.NavigationBarPane3.TabIndex = 19
        Me.NavigationBarPane3.TabStop = True
        Me.NavigationBarPane3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationBarPane3.TextPaddingOffset = New System.Drawing.Point(0, 0)
        '
        'NavigationBarPane4
        '
        Me.NavigationBarPane4.Caption = "Panel Item"
        Me.NavigationBarPane4.Hidden = False
        Me.NavigationBarPane4.Location = New System.Drawing.Point(1, 26)
        Me.NavigationBarPane4.MainImagePosition = Phantom.Generic.ImagePosition.Center
        Me.NavigationBarPane4.Name = "NavigationBarPane4"
        Me.NavigationBarPane4.Selected = False
        Me.NavigationBarPane4.Size = New System.Drawing.Size(198, 308)
        Me.NavigationBarPane4.TabIndex = 20
        Me.NavigationBarPane4.TabStop = True
        Me.NavigationBarPane4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationBarPane4.TextPaddingOffset = New System.Drawing.Point(0, 0)
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(696, 470)
        Me.Controls.Add(Me.Panelcontrol1)
        Me.Name = "Form1"
        Me.Text = "Phantom Navigation Pane Test Suite"
        Me.Panelcontrol1.ResumeLayout(False)
        Me.NavigationBar1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.NavigationBar1.SelectedItem = Me.NavigationBarPane4

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
End Class
