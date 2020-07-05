Imports System.Runtime.InteropServices
Public Class NuevoJuego
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub Button1_Paint(sender As Object, e As PaintEventArgs) Handles btnPrincipiante.Paint
        Dim buttonPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim myRectangle As Rectangle = btnPrincipiante.ClientRectangle
        myRectangle.Inflate(0, 30)
        buttonPath.AddEllipse(myRectangle)
        btnPrincipiante.Region = New Region(buttonPath)

    End Sub

    Private Sub Button2_Paint(sender As Object, e As PaintEventArgs) Handles btnFacil.Paint
        Dim buttonPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim myRectangle As Rectangle = btnFacil.ClientRectangle
        myRectangle.Inflate(0, 30)
        buttonPath.AddEllipse(myRectangle)
        btnFacil.Region = New Region(buttonPath)

    End Sub

    Private Sub Button3_Paint(sender As Object, e As PaintEventArgs) Handles btnIntermedio.Paint
        Dim buttonPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim myRectangle As Rectangle = btnIntermedio.ClientRectangle
        myRectangle.Inflate(0, 30)
        buttonPath.AddEllipse(myRectangle)
        btnIntermedio.Region = New Region(buttonPath)

    End Sub

    Private Sub Button4_Paint(sender As Object, e As PaintEventArgs) Handles btnAvanzado.Paint
        Dim buttonPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim myRectangle As Rectangle = btnAvanzado.ClientRectangle
        myRectangle.Inflate(0, 30)
        buttonPath.AddEllipse(myRectangle)
        btnAvanzado.Region = New Region(buttonPath)

    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles btnPrincipiante.MouseHover
        btnPrincipiante.Size = New Size(width:=550, height:=60)
    End Sub

    Private Sub btnPrincipiante_MouseLeave(sender As Object, e As EventArgs) Handles btnPrincipiante.MouseLeave
        btnPrincipiante.Size = New Size(width:=500, height:=50)
    End Sub


    Private Sub btnFacil_MouseHover(sender As Object, e As EventArgs) Handles btnFacil.MouseHover
        btnFacil.Size = New Size(width:=550, height:=60)
    End Sub

    Private Sub btnFacil_MouseLeave(sender As Object, e As EventArgs) Handles btnFacil.MouseLeave
        btnFacil.Size = New Size(width:=500, height:=50)
    End Sub

    Private Sub btnIntermedio_MouseHover(sender As Object, e As EventArgs) Handles btnIntermedio.MouseHover
        btnIntermedio.Size = New Size(width:=550, height:=60)
    End Sub

    Private Sub btnIntermedio_MouseLeave(sender As Object, e As EventArgs) Handles btnIntermedio.MouseLeave
        btnIntermedio.Size = New Size(width:=500, height:=50)
    End Sub

    Private Sub btnAvanzado_MouseHover(sender As Object, e As EventArgs) Handles btnAvanzado.MouseHover
        btnAvanzado.Size = New Size(width:=550, height:=60)
    End Sub

    Private Sub btnAvanzado_MouseLeave(sender As Object, e As EventArgs) Handles btnAvanzado.MouseLeave
        btnAvanzado.Size = New Size(width:=500, height:=50)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dim salir As String
        salir = MsgBox("¿Esta seguro que desea salir?", 36, "SALIR")
        If salir = 6 Then
            End
        End If
    End Sub


    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles BarraSuperior.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub btnFacil_Click(sender As Object, e As EventArgs) Handles btnFacil.Click
        'Definir las Variables
        Dim formulario As New NivelMedio

        'Pasar al Siguiente Formulario
        formulario.Show()
        Me.Close()

    End Sub

    Private Sub btnPrincipiante_Click(sender As Object, e As EventArgs) Handles btnPrincipiante.Click
        'Definir las Variables
        Dim formulario As New NivelFacil

        'Pasar al Siguiente Formulario
        formulario.Show()
        Me.Close()
    End Sub

    Private Sub btnIntermedio_Click(sender As Object, e As EventArgs) Handles btnIntermedio.Click
        'Definir las Variables
        Dim formulario As New NivelDificil

        'Pasar al Siguiente Formulario
        formulario.Show()
        Me.Close()
    End Sub

    Private Sub NuevoJuego_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnAvanzado_Click(sender As Object, e As EventArgs) Handles btnAvanzado.Click
        MenuPrincipal.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class