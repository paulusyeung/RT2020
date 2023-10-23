Imports System.IO
Imports Itchin.Winforms.Controls
Imports System.Reflection.Assembly

Public Class frmTest
    Inherits System.Windows.Forms.Form

    '-- Automatic Theme Support
    Dim m_ButtonHoverTheme As Itchin.Winforms.Generic.Theming.HeaderPanelThemeFormat
    Private WithEvents m_Tutorials As DemoTutorials


#Region " Windows Form Designer generated code "

    Public Sub New()


        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        AddHandler propButton0.Click, AddressOf OnPropertiesButtonClick
        AddHandler propButton1.Click, AddressOf OnPropertiesButtonClick
        AddHandler propButton2.Click, AddressOf OnPropertiesButtonClick
        AddHandler propButton3.Click, AddressOf OnPropertiesButtonClick
        AddHandler propButton4.Click, AddressOf OnPropertiesButtonClick

        '-- Save the loaded Theme
        m_NavbarCustomTheme = Me.NavBarMain.ThemeFormat()
        m_NavbarThemeHandler = New Itchin.Winforms.Generic.Theming.ThemeListener(Me, True)

        '-- Add The Tutorials
        m_Tutorials = New DemoTutorials(TutorialPanel)


        m_Tutorials.AddTutorial(New ucCurrentNavBarTheme(Me.NavBarMain, Me.lvwEvents), "Current Theme Properties")
        Me.propButton0.Tag = "Current Theme Properties"

        m_Tutorials.AddTutorial(New ucHeaderProperties(Me.NavBarMain, Me.lvwEvents), "Header Properties")
        Me.propButton1.Tag = "Header Properties"

        m_Tutorials.AddTutorial(New ucAlphaProperties(Me.NavBarMain, Me.lvwEvents), "Alpha Properties")
        Me.propButton2.Tag = "Alpha Properties"

        m_Tutorials.AddTutorial(New ucLogoProperties(Me.NavBarMain, Me.lvwEvents), "Logo Properties")
        Me.propButton3.Tag = "Logo Properties"

        m_Tutorials.AddTutorial(New ucSelectedItemProps(Me.NavBarMain, Me.lvwEvents), "SelectedItem Properties")
        Me.propButton4.Tag = "SelectedItem Properties"


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




    Friend WithEvents NavBarHeaderPanel1 As Itchin.Winforms.Controls.NavBarHeaderPanel
    Friend WithEvents NavBarMain As Itchin.Winforms.Controls.NavigationBar
    Friend WithEvents NavBarItem2 As Itchin.Winforms.Controls.NavigationBarPane
    Friend WithEvents NavBarItem1 As Itchin.Winforms.Controls.NavigationBarPane
    Friend WithEvents NavBarItem3 As Itchin.Winforms.Controls.NavigationBarPane
    Friend WithEvents NavBarItem4 As Itchin.Winforms.Controls.NavigationBarPane
    Friend WithEvents pnlSide As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents pnlEvents As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents pnlEventsHeader As Itchin.Winforms.Controls.NavBarHeaderPanel
    Friend WithEvents lvwEvents As System.Windows.Forms.ListView
    Friend WithEvents colEvents As System.Windows.Forms.ColumnHeader
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents NavBarHeaderPanel3 As Itchin.Winforms.Controls.NavBarHeaderPanel
    Friend WithEvents tvwTrash As System.Windows.Forms.TreeView
    Friend WithEvents pnlProperties As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents propButton1 As Itchin.Winforms.Controls.NavBarHeaderPanel
    Friend WithEvents propButton0 As Itchin.Winforms.Controls.NavBarHeaderPanel
    Friend WithEvents propButton2 As Itchin.Winforms.Controls.NavBarHeaderPanel
    Friend WithEvents pnlPropertiesHeader As Itchin.Winforms.Controls.NavBarHeaderPanel
    Friend WithEvents propButton3 As Itchin.Winforms.Controls.NavBarHeaderPanel
    Friend WithEvents propButton4 As Itchin.Winforms.Controls.NavBarHeaderPanel
    Friend WithEvents UcSelectedItemProps1 As Navbar_Tutorial.ucSelectedItemProps
    Public WithEvents chkEvents As System.Windows.Forms.CheckBox
    Friend WithEvents TutorialPanel As Itchin.Winforms.Controls.Panelcontrol
    Friend WithEvents TutorialHeader As Itchin.Winforms.Controls.NavBarHeaderPanel



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTest))
        Me.pnlSide = New Itchin.Winforms.Controls.Panelcontrol
        Me.NavBarHeaderPanel3 = New Itchin.Winforms.Controls.NavBarHeaderPanel
        Me.NavBarMain = New Itchin.Winforms.Controls.NavigationBar
        Me.NavBarItem3 = New Itchin.Winforms.Controls.NavigationBarPane
        Me.NavBarHeaderPanel1 = New Itchin.Winforms.Controls.NavBarHeaderPanel
        Me.NavBarItem1 = New Itchin.Winforms.Controls.NavigationBarPane
        Me.tvwTrash = New System.Windows.Forms.TreeView
        Me.NavBarItem2 = New Itchin.Winforms.Controls.NavigationBarPane
        Me.NavBarItem4 = New Itchin.Winforms.Controls.NavigationBarPane
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.pnlProperties = New Itchin.Winforms.Controls.Panelcontrol
        Me.TutorialHeader = New Itchin.Winforms.Controls.NavBarHeaderPanel
        Me.pnlPropertiesHeader = New Itchin.Winforms.Controls.NavBarHeaderPanel
        Me.TutorialPanel = New Itchin.Winforms.Controls.Panelcontrol
        Me.propButton1 = New Itchin.Winforms.Controls.NavBarHeaderPanel
        Me.propButton0 = New Itchin.Winforms.Controls.NavBarHeaderPanel
        Me.propButton2 = New Itchin.Winforms.Controls.NavBarHeaderPanel
        Me.propButton3 = New Itchin.Winforms.Controls.NavBarHeaderPanel
        Me.propButton4 = New Itchin.Winforms.Controls.NavBarHeaderPanel
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.pnlEvents = New Itchin.Winforms.Controls.Panelcontrol
        Me.pnlEventsHeader = New Itchin.Winforms.Controls.NavBarHeaderPanel
        Me.chkEvents = New System.Windows.Forms.CheckBox
        Me.lvwEvents = New System.Windows.Forms.ListView
        Me.colEvents = New System.Windows.Forms.ColumnHeader
        Me.colName = New System.Windows.Forms.ColumnHeader
        Me.pnlSide.SuspendLayout()
        Me.NavBarMain.SuspendLayout()
        Me.NavBarItem3.SuspendLayout()
        Me.NavBarItem1.SuspendLayout()
        Me.pnlProperties.SuspendLayout()
        Me.pnlEvents.SuspendLayout()
        Me.pnlEventsHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSide
        '
        Me.pnlSide.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSide.Controls.Add(Me.NavBarHeaderPanel3)
        Me.pnlSide.Controls.Add(Me.NavBarMain)
        Me.pnlSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSide.GradientColorEnd = System.Drawing.Color.Empty
        Me.pnlSide.GradientColorStart = System.Drawing.Color.Empty
        Me.pnlSide.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pnlSide.Location = New System.Drawing.Point(0, 0)
        Me.pnlSide.MinHeight = 0
        Me.pnlSide.Name = "pnlSide"
        Me.pnlSide.Size = New System.Drawing.Size(208, 475)
        Me.pnlSide.TabIndex = 0
        Me.pnlSide.Theme = Itchin.Winforms.Generic.Theming.ThemeStyle.Unthemed
        Me.pnlSide.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.pnlSide.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlSide.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(178, Byte), CType(178, Byte), CType(181, Byte))
        Me.pnlSide.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(228, Byte), CType(228, Byte), CType(232, Byte))
        Me.pnlSide.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(228, Byte), CType(228, Byte), CType(232, Byte))
        Me.pnlSide.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(240, Byte), CType(240, Byte), CType(242, Byte))
        Me.pnlSide.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.pnlSide.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(211, Byte), CType(212, Byte), CType(218, Byte))
        Me.pnlSide.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(211, Byte), CType(212, Byte), CType(218, Byte))
        Me.pnlSide.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlSide.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(178, Byte), CType(178, Byte), CType(181, Byte))
        '
        'NavBarHeaderPanel3
        '
        Me.NavBarHeaderPanel3.Caption = "Navigation Bar"
        Me.NavBarHeaderPanel3.DisplayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarHeaderPanel3.DisplayForecolor = System.Drawing.SystemColors.ControlText
        Me.NavBarHeaderPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavBarHeaderPanel3.DrawRightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NavBarHeaderPanel3.DrawStyle = Itchin.Winforms.Controls.EHeaderDrawStyle.Normal
        Me.NavBarHeaderPanel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarHeaderPanel3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.NavBarHeaderPanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.NavBarHeaderPanel3.ImageAlpha = 90
        Me.NavBarHeaderPanel3.Location = New System.Drawing.Point(0, 0)
        Me.NavBarHeaderPanel3.Name = "NavBarHeaderPanel3"
        Me.NavBarHeaderPanel3.Picture = CType(resources.GetObject("NavBarHeaderPanel3.Picture"), System.Drawing.Image)
        Me.NavBarHeaderPanel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NavBarHeaderPanel3.Size = New System.Drawing.Size(208, 32)
        Me.NavBarHeaderPanel3.TabIndex = 5
        Me.NavBarHeaderPanel3.Text = "Events"
        Me.NavBarHeaderPanel3.Theme = Itchin.Winforms.Generic.Theming.ThemeStyle.Unthemed
        Me.NavBarHeaderPanel3.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.NavBarHeaderPanel3.ThemeFormat.BorderColorTop = System.Drawing.SystemColors.ControlLight
        Me.NavBarHeaderPanel3.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(244, Byte))
        Me.NavBarHeaderPanel3.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(CType(236, Byte), CType(233, Byte), CType(217, Byte))
        Me.NavBarHeaderPanel3.UseAplha = False
        '
        'NavBarMain
        '
        Me.NavBarMain.AlphaSettings.HoverItemAlpha = 100
        Me.NavBarMain.AlphaSettings.SelectedItemAlpha = 100
        Me.NavBarMain.AlphaSettings.UnselectedItemAlpha = 70
        Me.NavBarMain.AlphaSettings.UseAlphaSettings = False
        Me.NavBarMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NavBarMain.BackColor = System.Drawing.Color.Transparent
        Me.NavBarMain.BackgroundImage = CType(resources.GetObject("NavBarMain.BackgroundImage"), System.Drawing.Image)
        Me.NavBarMain.Controls.Add(Me.NavBarItem3)
        Me.NavBarMain.Controls.Add(Me.NavBarItem1)
        Me.NavBarMain.Controls.Add(Me.NavBarItem2)
        Me.NavBarMain.Controls.Add(Me.NavBarItem4)
        Me.NavBarMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.NavBarMain.DesignTimeEdit = True
        Me.NavBarMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarMain.HeaderFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.NavBarMain.HeaderForeColor = System.Drawing.Color.White
        Me.NavBarMain.HeaderTextalignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavBarMain.Location = New System.Drawing.Point(16, 48)
        Me.NavBarMain.Logo.Alpha = 50
        Me.NavBarMain.Logo.DisplayLogo = True
        Me.NavBarMain.Logo.Image = CType(resources.GetObject("resource.Image"), System.Drawing.Image)
        Me.NavBarMain.LogoImagePosition = System.Drawing.ContentAlignment.BottomRight
        Me.NavBarMain.Name = "NavBarMain"
        Me.NavBarMain.Panels.Add(Me.NavBarItem1)
        Me.NavBarMain.Panels.Add(Me.NavBarItem2)
        Me.NavBarMain.Panels.Add(Me.NavBarItem3)
        Me.NavBarMain.Panels.Add(Me.NavBarItem4)
        Me.NavBarMain.SelectedForecolor = System.Drawing.Color.Red
        Me.NavBarMain.SelectedItem = Me.NavBarItem1
        Me.NavBarMain.ShowAddRemoveMenu = True
        Me.NavBarMain.ShowMenuButton = True
        Me.NavBarMain.Size = New System.Drawing.Size(176, 413)
        Me.NavBarMain.TabIndex = 4
        Me.NavBarMain.ThemeFormat.BorderColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(64, Byte), CType(0, Byte))
        Me.NavBarMain.ThemeFormat.HeaderColorOne = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.NavBarMain.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.NavBarMain.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.NavBarMain.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.NavBarMain.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.NavBarMain.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.NavBarMain.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.NavBarMain.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.NavBarMain.ThemeFormat.SplitterBarColorOne = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.NavBarMain.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
        Me.NavBarMain.ToolTipTimeOut = 5000
        Me.NavBarMain.VisibleItems = 2
        '
        'NavBarItem3
        '
        Me.NavBarItem3.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarItem3.Caption = "My Appointments"
        Me.NavBarItem3.Controls.Add(Me.NavBarHeaderPanel1)
        Me.NavBarItem3.Hidden = False
        Me.NavBarItem3.Image = CType(resources.GetObject("NavBarItem3.Image"), System.Drawing.Image)
        Me.NavBarItem3.Location = New System.Drawing.Point(1, 26)
        Me.NavBarItem3.MainImagePosition = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavBarItem3.Name = "NavBarItem3"
        Me.NavBarItem3.Selected = False
        Me.NavBarItem3.Size = New System.Drawing.Size(174, 283)
        Me.NavBarItem3.TabIndex = 19
        Me.NavBarItem3.TabStop = True
        Me.NavBarItem3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavBarItem3.TextPaddingOffset = New System.Drawing.Point(30, 0)
        Me.NavBarItem3.ToolbarImage = CType(resources.GetObject("NavBarItem3.ToolbarImage"), System.Drawing.Image)
        Me.NavBarItem3.Visible = False
        '
        'NavBarHeaderPanel1
        '
        Me.NavBarHeaderPanel1.BackColor = System.Drawing.Color.Transparent
        Me.NavBarHeaderPanel1.Caption = "Appointments"
        Me.NavBarHeaderPanel1.DisplayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarHeaderPanel1.DisplayForecolor = System.Drawing.SystemColors.ControlText
        Me.NavBarHeaderPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavBarHeaderPanel1.DrawRightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NavBarHeaderPanel1.DrawStyle = Itchin.Winforms.Controls.EHeaderDrawStyle.NavbarHeader
        Me.NavBarHeaderPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarHeaderPanel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.NavBarHeaderPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.NavBarHeaderPanel1.ImageAlpha = 50
        Me.NavBarHeaderPanel1.Location = New System.Drawing.Point(0, 0)
        Me.NavBarHeaderPanel1.Name = "NavBarHeaderPanel1"
        Me.NavBarHeaderPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NavBarHeaderPanel1.Size = New System.Drawing.Size(174, 24)
        Me.NavBarHeaderPanel1.TabIndex = 5
        Me.NavBarHeaderPanel1.Text = "NavBarHeaderPanel1"
        Me.NavBarHeaderPanel1.ThemeFormat.BorderColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(64, Byte), CType(0, Byte))
        Me.NavBarHeaderPanel1.ThemeFormat.BorderColorTop = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.NavBarHeaderPanel1.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.NavBarHeaderPanel1.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.NavBarHeaderPanel1.UseAplha = True
        '
        'NavBarItem1
        '
        Me.NavBarItem1.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarItem1.Caption = "My Music"
        Me.NavBarItem1.Controls.Add(Me.tvwTrash)
        Me.NavBarItem1.Hidden = False
        Me.NavBarItem1.Image = CType(resources.GetObject("NavBarItem1.Image"), System.Drawing.Image)
        Me.NavBarItem1.Location = New System.Drawing.Point(1, 26)
        Me.NavBarItem1.MainImagePosition = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavBarItem1.Name = "NavBarItem1"
        Me.NavBarItem1.Selected = True
        Me.NavBarItem1.Size = New System.Drawing.Size(174, 283)
        Me.NavBarItem1.TabIndex = 18
        Me.NavBarItem1.TabStop = True
        Me.NavBarItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavBarItem1.TextPaddingOffset = New System.Drawing.Point(30, 0)
        Me.NavBarItem1.ToolbarImage = CType(resources.GetObject("NavBarItem1.ToolbarImage"), System.Drawing.Image)
        '
        'tvwTrash
        '
        Me.tvwTrash.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvwTrash.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwTrash.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvwTrash.ImageIndex = -1
        Me.tvwTrash.Location = New System.Drawing.Point(0, 0)
        Me.tvwTrash.Name = "tvwTrash"
        Me.tvwTrash.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Classic", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Sample1")}), New System.Windows.Forms.TreeNode("Rock", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Sample1")}), New System.Windows.Forms.TreeNode("Misc")})
        Me.tvwTrash.SelectedImageIndex = -1
        Me.tvwTrash.Size = New System.Drawing.Size(174, 283)
        Me.tvwTrash.TabIndex = 0
        '
        'NavBarItem2
        '
        Me.NavBarItem2.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarItem2.Caption = "My Trash"
        Me.NavBarItem2.Hidden = True
        Me.NavBarItem2.Image = CType(resources.GetObject("NavBarItem2.Image"), System.Drawing.Image)
        Me.NavBarItem2.Location = New System.Drawing.Point(1, 26)
        Me.NavBarItem2.MainImagePosition = System.Drawing.ContentAlignment.MiddleCenter
        Me.NavBarItem2.Name = "NavBarItem2"
        Me.NavBarItem2.Selected = False
        Me.NavBarItem2.Size = New System.Drawing.Size(174, 340)
        Me.NavBarItem2.TabIndex = 17
        Me.NavBarItem2.TabStop = True
        Me.NavBarItem2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavBarItem2.TextPaddingOffset = New System.Drawing.Point(10, 0)
        Me.NavBarItem2.ToolbarImage = CType(resources.GetObject("NavBarItem2.ToolbarImage"), System.Drawing.Image)
        '
        'NavBarItem4
        '
        Me.NavBarItem4.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarItem4.Caption = "Scripts "
        Me.NavBarItem4.Hidden = False
        Me.NavBarItem4.Image = CType(resources.GetObject("NavBarItem4.Image"), System.Drawing.Image)
        Me.NavBarItem4.Location = New System.Drawing.Point(1, 26)
        Me.NavBarItem4.MainImagePosition = System.Drawing.ContentAlignment.MiddleRight
        Me.NavBarItem4.Name = "NavBarItem4"
        Me.NavBarItem4.Selected = False
        Me.NavBarItem4.Size = New System.Drawing.Size(174, 340)
        Me.NavBarItem4.TabIndex = 20
        Me.NavBarItem4.TabStop = True
        Me.NavBarItem4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.NavBarItem4.TextPaddingOffset = New System.Drawing.Point(-30, 0)
        Me.NavBarItem4.ToolbarImage = CType(resources.GetObject("NavBarItem4.ToolbarImage"), System.Drawing.Image)
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(208, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(4, 475)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'pnlProperties
        '
        Me.pnlProperties.AutoScroll = True
        Me.pnlProperties.BackColor = System.Drawing.SystemColors.Control
        Me.pnlProperties.Controls.Add(Me.TutorialHeader)
        Me.pnlProperties.Controls.Add(Me.pnlPropertiesHeader)
        Me.pnlProperties.Controls.Add(Me.TutorialPanel)
        Me.pnlProperties.Controls.Add(Me.propButton1)
        Me.pnlProperties.Controls.Add(Me.propButton0)
        Me.pnlProperties.Controls.Add(Me.propButton2)
        Me.pnlProperties.Controls.Add(Me.propButton3)
        Me.pnlProperties.Controls.Add(Me.propButton4)
        Me.pnlProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProperties.GradientColorEnd = System.Drawing.Color.Empty
        Me.pnlProperties.GradientColorStart = System.Drawing.Color.Empty
        Me.pnlProperties.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pnlProperties.Location = New System.Drawing.Point(212, 0)
        Me.pnlProperties.MinHeight = 0
        Me.pnlProperties.Name = "pnlProperties"
        Me.pnlProperties.Size = New System.Drawing.Size(466, 343)
        Me.pnlProperties.TabIndex = 25
        Me.pnlProperties.Text = "Panelcontrol1"
        Me.pnlProperties.Theme = Itchin.Winforms.Generic.Theming.ThemeStyle.Unthemed
        Me.pnlProperties.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.pnlProperties.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlProperties.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.pnlProperties.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlProperties.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlProperties.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.pnlProperties.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.pnlProperties.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlProperties.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlProperties.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlProperties.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'TutorialHeader
        '
        Me.TutorialHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TutorialHeader.Caption = "Tutorial Pane"
        Me.TutorialHeader.DisplayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TutorialHeader.DisplayForecolor = System.Drawing.SystemColors.ControlText
        Me.TutorialHeader.DrawRightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TutorialHeader.DrawStyle = Itchin.Winforms.Controls.EHeaderDrawStyle.Normal
        Me.TutorialHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TutorialHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TutorialHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.TutorialHeader.ImageAlpha = 100
        Me.TutorialHeader.Location = New System.Drawing.Point(16, 308)
        Me.TutorialHeader.Name = "TutorialHeader"
        Me.TutorialHeader.Picture = CType(resources.GetObject("TutorialHeader.Picture"), System.Drawing.Image)
        Me.TutorialHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TutorialHeader.Size = New System.Drawing.Size(430, 25)
        Me.TutorialHeader.TabIndex = 16
        Me.TutorialHeader.Text = "NavBarHeaderPanel4"
        Me.TutorialHeader.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.TutorialHeader.ThemeFormat.BorderColorTop = System.Drawing.SystemColors.ControlLight
        Me.TutorialHeader.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(244, Byte))
        Me.TutorialHeader.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(CType(236, Byte), CType(233, Byte), CType(217, Byte))
        Me.TutorialHeader.UseAplha = False
        '
        'pnlPropertiesHeader
        '
        Me.pnlPropertiesHeader.Caption = "Navigation Bar Test Suite"
        Me.pnlPropertiesHeader.DisplayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPropertiesHeader.DisplayForecolor = System.Drawing.SystemColors.ControlText
        Me.pnlPropertiesHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPropertiesHeader.DrawRightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pnlPropertiesHeader.DrawStyle = Itchin.Winforms.Controls.EHeaderDrawStyle.Normal
        Me.pnlPropertiesHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPropertiesHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlPropertiesHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pnlPropertiesHeader.ImageAlpha = 90
        Me.pnlPropertiesHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlPropertiesHeader.Name = "pnlPropertiesHeader"
        Me.pnlPropertiesHeader.Picture = CType(resources.GetObject("pnlPropertiesHeader.Picture"), System.Drawing.Image)
        Me.pnlPropertiesHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pnlPropertiesHeader.Size = New System.Drawing.Size(466, 32)
        Me.pnlPropertiesHeader.TabIndex = 0
        Me.pnlPropertiesHeader.Text = "Events"
        Me.pnlPropertiesHeader.Theme = Itchin.Winforms.Generic.Theming.ThemeStyle.Unthemed
        Me.pnlPropertiesHeader.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.pnlPropertiesHeader.ThemeFormat.BorderColorTop = System.Drawing.SystemColors.ControlLight
        Me.pnlPropertiesHeader.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(244, Byte))
        Me.pnlPropertiesHeader.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(CType(236, Byte), CType(233, Byte), CType(217, Byte))
        Me.pnlPropertiesHeader.UseAplha = False
        '
        'TutorialPanel
        '
        Me.TutorialPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TutorialPanel.GradientColorEnd = System.Drawing.Color.Empty
        Me.TutorialPanel.GradientColorStart = System.Drawing.Color.Empty
        Me.TutorialPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.TutorialPanel.Location = New System.Drawing.Point(112, 48)
        Me.TutorialPanel.MinHeight = 0
        Me.TutorialPanel.Name = "TutorialPanel"
        Me.TutorialPanel.Size = New System.Drawing.Size(334, 261)
        Me.TutorialPanel.TabIndex = 26
        Me.TutorialPanel.Text = "Panelcontrol2"
        Me.TutorialPanel.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.TutorialPanel.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.TutorialPanel.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(178, Byte), CType(178, Byte), CType(181, Byte))
        Me.TutorialPanel.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(228, Byte), CType(228, Byte), CType(232, Byte))
        Me.TutorialPanel.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(228, Byte), CType(228, Byte), CType(232, Byte))
        Me.TutorialPanel.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(240, Byte), CType(240, Byte), CType(242, Byte))
        Me.TutorialPanel.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.TutorialPanel.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(211, Byte), CType(212, Byte), CType(218, Byte))
        Me.TutorialPanel.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(211, Byte), CType(212, Byte), CType(218, Byte))
        Me.TutorialPanel.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.TutorialPanel.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(178, Byte), CType(178, Byte), CType(181, Byte))
        '
        'propButton1
        '
        Me.propButton1.Caption = "Header"
        Me.propButton1.DisplayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propButton1.DisplayForecolor = System.Drawing.SystemColors.ControlText
        Me.propButton1.DrawRightToLeft = System.Windows.Forms.RightToLeft.No
        Me.propButton1.DrawStyle = Itchin.Winforms.Controls.EHeaderDrawStyle.Normal
        Me.propButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propButton1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.propButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.propButton1.ImageAlpha = 100
        Me.propButton1.Location = New System.Drawing.Point(16, 87)
        Me.propButton1.Name = "propButton1"
        Me.propButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.propButton1.Size = New System.Drawing.Size(104, 32)
        Me.propButton1.TabIndex = 18
        Me.propButton1.Tag = "1"
        Me.propButton1.Text = "NavBarHeaderPanel7"
        Me.propButton1.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.propButton1.ThemeFormat.BorderColorTop = System.Drawing.SystemColors.ControlLight
        Me.propButton1.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(244, Byte))
        Me.propButton1.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(CType(236, Byte), CType(233, Byte), CType(217, Byte))
        Me.propButton1.UseAplha = False
        '
        'propButton0
        '
        Me.propButton0.Caption = "Theme"
        Me.propButton0.DisplayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propButton0.DisplayForecolor = System.Drawing.SystemColors.ControlText
        Me.propButton0.DrawRightToLeft = System.Windows.Forms.RightToLeft.No
        Me.propButton0.DrawStyle = Itchin.Winforms.Controls.EHeaderDrawStyle.Normal
        Me.propButton0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propButton0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.propButton0.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.propButton0.ImageAlpha = 100
        Me.propButton0.Location = New System.Drawing.Point(16, 56)
        Me.propButton0.Name = "propButton0"
        Me.propButton0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.propButton0.Size = New System.Drawing.Size(104, 32)
        Me.propButton0.TabIndex = 17
        Me.propButton0.Tag = "0"
        Me.propButton0.Text = "NavBarHeaderPanel6"
        Me.propButton0.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.propButton0.ThemeFormat.BorderColorTop = System.Drawing.SystemColors.ControlLight
        Me.propButton0.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(244, Byte))
        Me.propButton0.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(CType(236, Byte), CType(233, Byte), CType(217, Byte))
        Me.propButton0.UseAplha = False
        '
        'propButton2
        '
        Me.propButton2.Caption = "Alpha"
        Me.propButton2.DisplayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propButton2.DisplayForecolor = System.Drawing.SystemColors.ControlText
        Me.propButton2.DrawRightToLeft = System.Windows.Forms.RightToLeft.No
        Me.propButton2.DrawStyle = Itchin.Winforms.Controls.EHeaderDrawStyle.Normal
        Me.propButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propButton2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.propButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.propButton2.ImageAlpha = 100
        Me.propButton2.Location = New System.Drawing.Point(16, 118)
        Me.propButton2.Name = "propButton2"
        Me.propButton2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.propButton2.Size = New System.Drawing.Size(104, 32)
        Me.propButton2.TabIndex = 22
        Me.propButton2.Tag = "2"
        Me.propButton2.Text = "NavBarHeaderPanel9"
        Me.propButton2.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.propButton2.ThemeFormat.BorderColorTop = System.Drawing.SystemColors.ControlLight
        Me.propButton2.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(244, Byte))
        Me.propButton2.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(CType(236, Byte), CType(233, Byte), CType(217, Byte))
        Me.propButton2.UseAplha = False
        '
        'propButton3
        '
        Me.propButton3.Caption = "Logo"
        Me.propButton3.DisplayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propButton3.DisplayForecolor = System.Drawing.SystemColors.ControlText
        Me.propButton3.DrawRightToLeft = System.Windows.Forms.RightToLeft.No
        Me.propButton3.DrawStyle = Itchin.Winforms.Controls.EHeaderDrawStyle.Normal
        Me.propButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propButton3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.propButton3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.propButton3.ImageAlpha = 100
        Me.propButton3.Location = New System.Drawing.Point(16, 149)
        Me.propButton3.Name = "propButton3"
        Me.propButton3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.propButton3.Size = New System.Drawing.Size(104, 32)
        Me.propButton3.TabIndex = 23
        Me.propButton3.Tag = "3"
        Me.propButton3.Text = "NavBarHeaderPanel9"
        Me.propButton3.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.propButton3.ThemeFormat.BorderColorTop = System.Drawing.SystemColors.ControlLight
        Me.propButton3.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(244, Byte))
        Me.propButton3.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(CType(236, Byte), CType(233, Byte), CType(217, Byte))
        Me.propButton3.UseAplha = False
        '
        'propButton4
        '
        Me.propButton4.Caption = "Selected Item"
        Me.propButton4.DisplayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propButton4.DisplayForecolor = System.Drawing.SystemColors.ControlText
        Me.propButton4.DrawRightToLeft = System.Windows.Forms.RightToLeft.No
        Me.propButton4.DrawStyle = Itchin.Winforms.Controls.EHeaderDrawStyle.Normal
        Me.propButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propButton4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.propButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.propButton4.ImageAlpha = 100
        Me.propButton4.Location = New System.Drawing.Point(16, 180)
        Me.propButton4.Name = "propButton4"
        Me.propButton4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.propButton4.Size = New System.Drawing.Size(104, 32)
        Me.propButton4.TabIndex = 25
        Me.propButton4.Tag = "4"
        Me.propButton4.Text = "NavBarHeaderPanel9"
        Me.propButton4.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.propButton4.ThemeFormat.BorderColorTop = System.Drawing.SystemColors.ControlLight
        Me.propButton4.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(244, Byte))
        Me.propButton4.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(CType(236, Byte), CType(233, Byte), CType(217, Byte))
        Me.propButton4.UseAplha = False
        '
        'Splitter2
        '
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter2.Location = New System.Drawing.Point(212, 343)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(466, 4)
        Me.Splitter2.TabIndex = 24
        Me.Splitter2.TabStop = False
        '
        'pnlEvents
        '
        Me.pnlEvents.Controls.Add(Me.pnlEventsHeader)
        Me.pnlEvents.Controls.Add(Me.lvwEvents)
        Me.pnlEvents.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEvents.GradientColorEnd = System.Drawing.Color.Empty
        Me.pnlEvents.GradientColorStart = System.Drawing.Color.Empty
        Me.pnlEvents.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pnlEvents.Location = New System.Drawing.Point(212, 347)
        Me.pnlEvents.MinHeight = 0
        Me.pnlEvents.Name = "pnlEvents"
        Me.pnlEvents.Size = New System.Drawing.Size(466, 128)
        Me.pnlEvents.TabIndex = 23
        Me.pnlEvents.Text = "Panelcontrol1"
        Me.pnlEvents.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.pnlEvents.ThemeFormat.HeaderColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlEvents.ThemeFormat.HeaderColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        Me.pnlEvents.ThemeFormat.HotColorOne = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlEvents.ThemeFormat.HotColorTwo = System.Drawing.Color.FromArgb(CType(217, Byte), CType(221, Byte), CType(204, Byte))
        Me.pnlEvents.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(246, Byte), CType(245, Byte), CType(237, Byte))
        Me.pnlEvents.ThemeFormat.NormalColorTwo = System.Drawing.SystemColors.Control
        Me.pnlEvents.ThemeFormat.SelectedColorOne = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlEvents.ThemeFormat.SelectedColorTwo = System.Drawing.Color.FromArgb(CType(193, Byte), CType(200, Byte), CType(173, Byte))
        Me.pnlEvents.ThemeFormat.SplitterBarColorOne = System.Drawing.SystemColors.ControlLight
        Me.pnlEvents.ThemeFormat.SplitterBarColorTwo = System.Drawing.Color.FromArgb(CType(190, Byte), CType(187, Byte), CType(175, Byte))
        '
        'pnlEventsHeader
        '
        Me.pnlEventsHeader.Caption = "Events"
        Me.pnlEventsHeader.Controls.Add(Me.chkEvents)
        Me.pnlEventsHeader.DisplayFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEventsHeader.DisplayForecolor = System.Drawing.SystemColors.ControlText
        Me.pnlEventsHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEventsHeader.DrawRightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pnlEventsHeader.DrawStyle = Itchin.Winforms.Controls.EHeaderDrawStyle.Normal
        Me.pnlEventsHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEventsHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlEventsHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.pnlEventsHeader.ImageAlpha = 90
        Me.pnlEventsHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlEventsHeader.Name = "pnlEventsHeader"
        Me.pnlEventsHeader.Picture = CType(resources.GetObject("pnlEventsHeader.Picture"), System.Drawing.Image)
        Me.pnlEventsHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pnlEventsHeader.Size = New System.Drawing.Size(466, 32)
        Me.pnlEventsHeader.TabIndex = 0
        Me.pnlEventsHeader.Text = "Events"
        Me.pnlEventsHeader.ThemeFormat.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.pnlEventsHeader.ThemeFormat.BorderColorTop = System.Drawing.SystemColors.ControlLight
        Me.pnlEventsHeader.ThemeFormat.NormalColorOne = System.Drawing.Color.FromArgb(CType(249, Byte), CType(249, Byte), CType(244, Byte))
        Me.pnlEventsHeader.ThemeFormat.NormalColorTwo = System.Drawing.Color.FromArgb(CType(236, Byte), CType(233, Byte), CType(217, Byte))
        Me.pnlEventsHeader.UseAplha = False
        '
        'chkEvents
        '
        Me.chkEvents.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkEvents.BackColor = System.Drawing.Color.Transparent
        Me.chkEvents.Location = New System.Drawing.Point(362, 8)
        Me.chkEvents.Name = "chkEvents"
        Me.chkEvents.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkEvents.Size = New System.Drawing.Size(96, 18)
        Me.chkEvents.TabIndex = 0
        Me.chkEvents.Text = "Show events"
        '
        'lvwEvents
        '
        Me.lvwEvents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwEvents.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvwEvents.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colEvents, Me.colName})
        Me.lvwEvents.FullRowSelect = True
        Me.lvwEvents.GridLines = True
        Me.lvwEvents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwEvents.HideSelection = False
        Me.lvwEvents.Location = New System.Drawing.Point(1, 32)
        Me.lvwEvents.MultiSelect = False
        Me.lvwEvents.Name = "lvwEvents"
        Me.lvwEvents.Size = New System.Drawing.Size(463, 94)
        Me.lvwEvents.TabIndex = 1
        Me.lvwEvents.View = System.Windows.Forms.View.Details
        '
        'colEvents
        '
        Me.colEvents.Text = "Event"
        Me.colEvents.Width = 176
        '
        'colName
        '
        Me.colName.Text = "Description"
        Me.colName.Width = 262
        '
        'frmTest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(678, 475)
        Me.Controls.Add(Me.pnlProperties)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.pnlEvents)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.pnlSide)
        Me.MaximizeBox = False
        Me.Name = "frmTest"
        Me.Text = "Itchin Navigation Pane Test Suite"
        Me.pnlSide.ResumeLayout(False)
        Me.NavBarMain.ResumeLayout(False)
        Me.NavBarItem3.ResumeLayout(False)
        Me.NavBarItem1.ResumeLayout(False)
        Me.pnlProperties.ResumeLayout(False)
        Me.pnlEvents.ResumeLayout(False)
        Me.pnlEventsHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnPropertiesButtonClick(Me.propButton0, New EventArgs)
    End Sub

    Private Sub NavBarMain_ItemHidden(ByVal Panel As Itchin.Winforms.Controls.NavigationBarPane, ByVal ItemVisibleState As Boolean) Handles NavBarMain.ItemHidden


        AddToEvents(Me.lvwEvents, " (Item Hidden: State = " & ItemVisibleState & ")", " Panel: " & Panel.Caption)
    End Sub

    Private Sub NavBarMain_ItemHover(ByVal Panel As Itchin.Winforms.Controls.NavigationBarPane) Handles NavBarMain.ItemHover
        AddToEvents(Me.lvwEvents, " (Item Hover)", " Panel: " & Panel.Caption)
    End Sub

    Private Sub NavBarMain_ItemRightClick(ByVal Panel As Itchin.Winforms.Controls.NavigationBarPane) Handles NavBarMain.ItemRightClick
        AddToEvents(Me.lvwEvents, " (Item Right Click)", " Panel: " & Panel.Caption)
    End Sub

    Private Sub NavBarMain_ItemSelected(ByVal Panel As Itchin.Winforms.Controls.NavigationBarPane) Handles NavBarMain.ItemSelected
        AddToEvents(Me.lvwEvents, " (Item Select)", " Panel: " & Panel.Caption)

    End Sub


    Private Sub ShowButtonImage()

        Dim _TempPanel As Object


        For Each _TempPanel In Me.pnlProperties.Controls()
            If _TempPanel.GetType Is GetType(Itchin.Winforms.Controls.Panelcontrol) Then
                If Not _TempPanel Is Me.TutorialPanel Then
                    _TempPanel.Visible = False
                End If

            End If

            If _TempPanel.GetType Is GetType(Itchin.Winforms.Controls.NavBarHeaderPanel) Then
                If Not _TempPanel Is Me.pnlPropertiesHeader Then
                    If Not _TempPanel Is TutorialHeader Then
                        _TempPanel.picture = Nothing
                    End If
                End If
            End If
        Next


    End Sub



    Private Sub OnPropertiesButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ShowButtonImage()

        sender.picture = ImageFromResource("Selector.png")

        m_Tutorials.ShowTutorial(sender.tag)


    End Sub

    Protected Overrides Sub Finalize()

        m_Tutorials.Clear()
        m_Tutorials = Nothing

        RemoveHandler propButton0.Click, AddressOf OnPropertiesButtonClick
        RemoveHandler propButton1.Click, AddressOf OnPropertiesButtonClick
        RemoveHandler propButton2.Click, AddressOf OnPropertiesButtonClick
        RemoveHandler propButton3.Click, AddressOf OnPropertiesButtonClick
        RemoveHandler propButton4.Click, AddressOf OnPropertiesButtonClick


        'RemoveHandler sbLogoAlpha.ValueChanged, AddressOf OnAlphaValueChanged

        MyBase.Finalize()
    End Sub


    Private Sub m_Tutorials_ItemChanged(ByVal Tutorial As TutorialItem) Handles m_Tutorials.ItemChanged
        Me.TutorialHeader.Caption = "Tutorial ( " & Tutorial.Name & ")"
    End Sub

    Private Sub pnlProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlProperties.Click
        Me.NavBarMain.SelectedItem = Nothing


    End Sub

    Private Sub chkEvents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEvents.CheckedChanged
        m_bShowEvents = chkEvents.Checked
    End Sub
End Class
