Public Class blanket
    Inherits System.Windows.Forms.Form
    Dim screencolour As Color
    Dim cnt As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal screen_colour As Color)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        screencolour = screen_colour
        Panel1.BackColor = screencolour
        Me.Refresh()
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
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(blanket))
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Exit Blanket"
        '
        'Panel1
        '
        Me.Panel1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.ContextMenu = Me.ContextMenu1
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 265)
        Me.Panel1.TabIndex = 0
        '
        'blanket
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.ContextMenu = Me.ContextMenu1
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1})
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "blanket"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Const WM_NCHITTEST As Integer = &H84
    Private Const HTCLIENT As Integer = &H1
    Private Const HTCAPTION As Integer = &H2

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_NCHITTEST
                MyBase.WndProc(m)
                If (m.Result.ToInt32 = HTCLIENT) Then
                    m.Result = IntPtr.op_Explicit(HTCAPTION)
                End If
                Exit Sub
        End Select

        MyBase.WndProc(m)
    End Sub

    Protected Sub Error_Handler(ByVal message As String)
        MsgBox("Screen Blanket has encountered the following error: " & vbCrLf & message, MsgBoxStyle.Exclamation, "Error Encountered")
    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)

        'this event is fired everytime the user moves the mouse scroll wheel
        'one click. So each notch the wheel moves, this event is fired.

        'e.Delta will return either negative 120 or positive 120(returns 
        'the number 120 on my computer at least)

        'check if delta returns a negative number, then decrease the number
        Try

            If e.Delta < 0 Then

                cnt -= 10
                'MsgBox(Screen.FromControl(Me).GetBounds(Me).Height + cnt & " grth " & PictureBox1.Height & " And " & Me.Width = Screen.FromControl(Me).GetBounds(Me).Width + cnt & " grth " & PictureBox1.Width)
                'If Screen.FromControl(Me).GetBounds(Me).Height + cnt > PictureBox1.Height And Me.Width = Screen.FromControl(Me).GetBounds(Me).Width + cnt > PictureBox1.Width Then
                If Screen.FromControl(Me).GetBounds(Me).Height + cnt > 20 And Screen.FromControl(Me).GetBounds(Me).Width + cnt > 20 Then

                    Me.Height = Screen.FromControl(Me).GetBounds(Me).Height + cnt
                    Me.Width = Screen.FromControl(Me).GetBounds(Me).Width + cnt

                    Me.Refresh()
                Else
                    cnt += 10
                End If
                'delta returns a positive number, so increase the number
            Else

                cnt += 10


                Me.Height = Screen.FromControl(Me).GetBounds(Me).Height + cnt
                Me.Width = Screen.FromControl(Me).GetBounds(Me).Width + cnt


                Me.Refresh()
            End If

        Catch ex As Exception
            Error_Handler(ex.ToString)
        End Try


    End Sub

    'Handles key presses when the image control is in focus.
    Private Sub Navigation_Key_Handler(ByVal sender As System.Object, ByVal keyselected As System.Windows.Forms.KeyEventArgs) Handles Panel1.KeyDown, MyBase.KeyDown
        Try


            If keyselected.KeyCode = Keys.Escape Then


                Me.Close()
                Me.Dispose()

                keyselected.Handled = True

                Exit Sub
            End If


            keyselected.Handled = True

        Catch ex As Exception
            Error_Handler(ex.ToString)
        End Try

    End Sub

    'Handles mouse clicks when the image control is in focus.
    Private Sub Navigation_Mouse_Handler(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown
        Try
            'If double left-click when image control is in focus, select next image
            If e.Clicks = 2 And e.Button = MouseButtons.Left Then
                Me.Close()
                Me.Dispose()
            End If


        Catch ex As Exception
            Error_Handler(ex.ToString)
        End Try

    End Sub



    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Try
            Me.Close()
        Me.Dispose()
        Catch ex As Exception
            Error_Handler(ex.ToString)
        End Try

    End Sub

    Private Sub blanket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Height = Screen.FromControl(Me).GetBounds(Me).Height
            Me.Width = Screen.FromControl(Me).GetBounds(Me).Width

            Me.Top = 0
            Me.Left = 0

        Me.Refresh()
        Catch ex As Exception
            Error_Handler(ex.ToString)
        End Try
    End Sub
End Class
