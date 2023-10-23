Module Helpers

    '-- Saved Theme For Demo
    Public m_NavbarCustomTheme As Itchin.Winforms.Generic.Theming.NavigationBarThemeFormat
    Public m_NavbarThemeHandler As Itchin.Winforms.Generic.Theming.ThemeListener
    Public m_bShowEvents As Boolean

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Runs A New instance of The App
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[G_Noble]	16/05/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Sub main()
        Application.EnableVisualStyles()
        Application.DoEvents()
        Application.Run(New frmTest)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Returns An Image From A Resources
    ''' </summary>
    ''' <param name="ResFileName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[G_Noble]	16/05/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ImageFromResource(ByVal ResFileName As String) As System.Drawing.Image
        Dim AppExe As System.Reflection.Assembly
        Dim Stream As System.IO.Stream
        AppExe = System.Reflection.Assembly.GetExecutingAssembly()
        ResFileName = AppExe.GetName.Name & "." & ResFileName
        Stream = AppExe.GetManifestResourceStream(ResFileName)
        ImageFromResource = System.Drawing.Image.FromStream(Stream)
        Stream.Close()
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Returns An Icon From A Resource
    ''' </summary>
    ''' <param name="ResFileName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[G_Noble]	16/05/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function IconFromResource(ByVal ResFileName As String) As System.Drawing.Icon
        Dim AppExe As System.Reflection.Assembly
        Dim Stream As System.IO.Stream
        AppExe = System.Reflection.Assembly.GetExecutingAssembly()
        ResFileName = AppExe.GetName.Name & "." & ResFileName
        Stream = AppExe.GetManifestResourceStream(ResFileName)
        IconFromResource = New Icon(Stream)
        Stream.Close()
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Global Set Combo Text
    ''' </summary>
    ''' <param name="cbo"></param>
    ''' <param name="Algn"></param>
    ''' <remarks>
    ''' This Is Used Only For the Property Tutorials
    ''' </remarks>
    ''' <history>
    ''' 	[G_Noble]	16/05/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub SetComboAlignment(ByVal cbo As ComboBox, ByVal Algn As ContentAlignment)
        cbo.Text = Algn.ToString
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Adds An Entry To The Events Panel On The Main Window
    ''' </summary>
    ''' <param name="lvwEvents"></param>
    ''' <param name="sEvent"></param>
    ''' <param name="sPanelName"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[G_Noble]	16/05/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub AddToEvents(ByVal lvwEvents As ListView, ByVal sEvent As String, ByVal sPanelName As String)

        If m_bShowEvents Then

            Dim _xItem As ListViewItem = lvwEvents.Items.Add(sEvent)
            _xItem.SubItems.Add(sPanelName)
            _xItem.EnsureVisible()
            _xItem.Selected = True

        End If

    End Sub
End Module
