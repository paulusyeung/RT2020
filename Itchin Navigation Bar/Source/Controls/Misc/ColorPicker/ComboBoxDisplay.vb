' ==============================================================================
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'
' © 2003-2004 LaMarvin. All Rights Reserved.
'
' FMI: http://www.vbinfozine.com/a_default.shtml
' ==============================================================================

Imports System.Drawing

' Implements a ComboBox-like appearance to be used with the ColorPicker control
' be means of the ComboBoxDisplayAdapter.
Public Class ComboBoxDisplay
	Inherits Control

	' This flag tells us if we have to emulate a dropped-down appearance in the
	' painting code.
	Private _HasDropDownAppearance As Boolean

	' This is the currently selected color displayed
	Private _Color As Color

	' The client area is partitioned into the following rectangles:
	Private _ColorBoxRect As Rectangle	' the color box rectangle on the left
	Private _TextBoxRect As RectangleF	' the rectangle for the color name in the middle
	Private _TextFormat As StringFormat	' format of the displayed color name
	Private _ButtonRect As Rectangle	 ' the rectanngle for the drop-down button on the right

	' This event is raised when the user changes the drop-down appearance of the
	' control by clicking it, or by pressing the Alt+Down Arrow key combination.
	Public Event DropDownAppearanceChanged As EventHandler


	Public Sub New()
		MyBase.New()
        'Add any initialization after the InitializeComponent() call

        ' This draws the control whenever it is resized
        setstyle(ControlStyles.ResizeRedraw, True)

        setstyle(ControlStyles.UserPaint, True)

        ' This supports mouse movement such as the mouse wheel
        setstyle(ControlStyles.UserMouse, True)

        ' This allows the control to be transparent
        setstyle(ControlStyles.SupportsTransparentBackColor, True)

        ' setstyle(ControlStyles.ContainerControl, True)
        setstyle(ControlStyles.Selectable, True)


        ' This helps with drawing the control so that it doesn't flicker
        Me.SetStyle(ControlStyles.DoubleBuffer _
          Or ControlStyles.UserPaint _
          Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.EnableNotifyMessage, _
          True)

        ' This updates the styles
        Me.UpdateStyles()

        Me.ForeColor = SystemColors.WindowText
		Me.BackColor = SystemColors.Window
		Me._TextFormat = New StringFormat(StringFormatFlags.NoWrap)
		Me._TextFormat.Alignment = StringAlignment.Near
        Me._TextFormat.LineAlignment = StringAlignment.Center

	End Sub


	Public Overridable Property Color() As Color
		Get
			Return Me._Color
		End Get
		Set(ByVal Value As Color)
			Me._Color = Value
			Me.Invalidate()
		End Set
	End Property


	Public Overridable Property HasDropDownAppearance() As Boolean
		Get
			Return Me._HasDropDownAppearance
		End Get
		Set(ByVal Value As Boolean)
			If Me._HasDropDownAppearance = Value Then
				Return
			End If
			Me._HasDropDownAppearance = Value
			Me.Invalidate()
			Me.OnDropDownAppearanceChanged(EventArgs.Empty)
		End Set
	End Property


	Protected Overridable Sub OnDropDownAppearanceChanged(ByVal e As EventArgs)
		RaiseEvent DropDownAppearanceChanged(Me, EventArgs.Empty)
	End Sub


	Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
		Try
			MyBase.OnPaint(e)

			Dim State As ButtonState = ButtonState.Normal
			If Me.HasDropDownAppearance Then
				State = ButtonState.Pushed
			End If

			Dim ColorBrush As New SolidBrush(Me.Color)
			Try
				e.Graphics.FillRectangle(ColorBrush, Me._ColorBoxRect)
			Finally
				ColorBrush.Dispose()
			End Try

			' I don't like the black outline that the PropertyGrid displays around the PaintValue-drawn
			' image by an UITypeEditor. If you like it, then uncomment the following lines :-)
			'Dim OutlineRect As Rectangle = Me._ColorBoxRect
			'OutlineRect.Width -= 1
			'OutlineRect.Height -= 1
			'e.Graphics.DrawRectangle(Pens.Black, OutlineRect)

			If Not Me._TextBoxRect.IsEmpty Then
				e.Graphics.DrawString(Me.Text, Me.Font, System.Drawing.Brushes.Black, Me._TextBoxRect, Me.TextFormat)
			End If

			ControlPaint.DrawComboButton(e.Graphics, Me._ButtonRect, State)

			ControlPaint.DrawBorder3D(e.Graphics, Me.ClientRectangle, Border3DStyle.Flat)

			If Me.ShouldDrawFocusRect Then
				ControlPaint.DrawFocusRectangle(e.Graphics, Me.ClientRectangle)
			End If

		Catch ex As Exception
			Trace.WriteLine(ex.ToString())
		End Try
	End Sub


	Protected Overridable ReadOnly Property ShouldDrawFocusRect() As Boolean
		Get
			Return Me.HasDropDownAppearance OrElse Me.Parent.ContainsFocus
		End Get
	End Property


	Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
		Try
			' Set focus to itself in the case we don't have focus yet. Originally I thought
			' that the control regains focus automatically when clicked by the mouse, but it 
			' didn't work so.
			If Not Me.Focused Then
				Me.Focus()
			End If
			MyBase.OnMouseDown(e)
			Me.HasDropDownAppearance = Not Me.HasDropDownAppearance
		Catch ex As Exception
			Trace.WriteLine(ex.ToString())
		End Try
	End Sub


	Protected Overridable ReadOnly Property DownButtonWidth() As Integer
		Get
			Return SystemInformation.CaptionButtonSize.Width
		End Get
	End Property


	Protected Overridable Property TextFormat() As StringFormat
		Get
			Return Me._TextFormat
		End Get
		Set(ByVal Value As StringFormat)
			If Value Is Nothing Then
				Throw New ArgumentNullException("Value")
			End If
			Me._TextFormat = Value
		End Set
	End Property


	Protected Overridable Sub GetDisplayLayout( _
	 ByRef colorBoxRect As Rectangle, _
	 ByRef textBoxRect As RectangleF, _
	 ByRef buttonRect As Rectangle)

		Const DistanceFromEdge As Integer = 2

		' The button occupies the right portion.
		buttonRect = Rectangle.FromLTRB( _
		 Me.Width - Me.DownButtonWidth, DistanceFromEdge, Me.Width - DistanceFromEdge, Me.Height - DistanceFromEdge)

		If Len(Me.Text) = 0 Then
			' No text to display, so we'll fill the whole client area (except the button)
			' with the current color.
			colorBoxRect = Rectangle.FromLTRB(DistanceFromEdge, DistanceFromEdge, buttonRect.Left, buttonRect.Bottom)
			textBoxRect = RectangleF.Empty
		Else
			' The color box should occupy the left portion of the control. The color box widthg is 
			' set to 1.5 * width of the drop-down button.
			colorBoxRect = Rectangle.FromLTRB( _
			 2 * DistanceFromEdge, 2 * DistanceFromEdge, _
			 CInt(1.5 * Me.DownButtonWidth), _
			 buttonRect.Bottom - DistanceFromEdge)

			' The text occupies the middle portion.
			textBoxRect = RectangleF.FromLTRB( _
			 colorBoxRect.Right + DistanceFromEdge, DistanceFromEdge, _
			 buttonRect.Left - DistanceFromEdge, buttonRect.Bottom)
		End If
	End Sub


	Protected Overrides Sub OnLayout(ByVal levent As System.Windows.Forms.LayoutEventArgs)
		' Recompute the display rectangles here, so they don't have to be recomputed 
		' every time OnPaint is called by the system.
		Me.GetDisplayLayout(Me._ColorBoxRect, Me._TextBoxRect, Me._ButtonRect)
		MyBase.OnLayout(levent)
		Me.Invalidate()
	End Sub


	Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
		MyBase.OnTextChanged(e)

		' If the text changed, we have to recompute the display layout and repaint
		' the control.
		Me.OnLayout(New LayoutEventArgs(Me, "Text"))
	End Sub


	Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
		If e.KeyData = (Keys.Down Or Keys.Alt) Then
			' Alt+Down Arrow should switch the drop-down appearance just like the left mouse click.
			e.Handled = True
			Me.HasDropDownAppearance = Not Me.HasDropDownAppearance
		Else
			MyBase.OnKeyDown(e)
		End If
	End Sub

End Class
