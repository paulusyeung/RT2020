
#Region "Demo Tutorial Base Classes"

''' -----------------------------------------------------------------------------
''' Project	 : Test
''' Class	 : TutorialItem
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Tutorial Item
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[G_Noble]	12/05/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class TutorialItem
    Public Name As String
    Public Component As UserControl
End Class

''' -----------------------------------------------------------------------------
''' Project	 : Test
''' Class	 : DemoTutorials
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' A Simple Class To Hold All Demo Tutorial Properties
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[G_Noble]	12/05/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class DemoTutorials
    Inherits CollectionBase


    Public Event ItemChanged(ByVal Tutorial As TutorialItem)

    Private m_ParentPanel As Itchin.Winforms.Controls.Panelcontrol
    Private m_TempTutorial As TutorialItem

    Public Sub New()
        MyBase.New()
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Sets The Parent Panel
    ''' </summary>
    ''' <param name="ParentPanel"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[G_Noble]	12/05/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal ParentPanel As Itchin.Winforms.Controls.Panelcontrol)

        m_ParentPanel = ParentPanel

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Adds A Tutorial Item to The collection
    ''' </summary>
    ''' <param name="TutorialControl"></param>
    ''' <param name="TutorialName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[G_Noble]	12/05/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function AddTutorial(ByVal TutorialControl As UserControl, ByVal TutorialName As String) As TutorialItem

        Dim _NewItem As TutorialItem = New TutorialItem

        Try
            _NewItem.Component = TutorialControl
            _NewItem.Name = TutorialName

            m_ParentPanel.Controls.Add(TutorialControl)
            TutorialControl.Dock = DockStyle.Fill
            TutorialControl.Visible = False


            MyBase.List.Add(_NewItem)

            Return _NewItem


        Catch ex As Exception
            MsgBox(ex.StackTrace)

            Throw ex
        End Try

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Displays The Required Tutorial
    ''' </summary>
    ''' <param name="TutorialName"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[G_Noble]	12/05/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub ShowTutorial(ByVal TutorialName As String)

        Dim ctl As Object

        For Each m_TempTutorial In Me.InnerList

            If m_TempTutorial.Name = TutorialName Then

                For Each ctl In m_ParentPanel.Controls
                    If Not ctl.GetType Is GetType(Itchin.Winforms.Controls.NavBarHeaderPanel) Then
                        ctl.Visible = False
                        ctl.Dock = DockStyle.Fill
                        ctl.BringToFront()
                        ctl.setdefaults()
                    End If
                Next

                m_TempTutorial.Component.Visible = True

                RaiseEvent ItemChanged(m_TempTutorial)

                Exit For

            End If

        Next


    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

#End Region