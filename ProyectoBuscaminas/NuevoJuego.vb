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
        btnPrincipiante.Size = New Size(width:=270, height:=41)
    End Sub

    Private Sub btnPrincipiante_MouseLeave(sender As Object, e As EventArgs) Handles btnPrincipiante.MouseLeave
        btnPrincipiante.Size = New Size(width:=261, height:=30)
    End Sub


    Private Sub btnFacil_MouseHover(sender As Object, e As EventArgs) Handles btnFacil.MouseHover
        btnFacil.Size = New Size(width:=270, height:=41)
    End Sub

    Private Sub btnFacil_MouseLeave(sender As Object, e As EventArgs) Handles btnFacil.MouseLeave
        btnFacil.Size = New Size(width:=261, height:=30)
    End Sub

    Private Sub btnIntermedio_MouseHover(sender As Object, e As EventArgs) Handles btnIntermedio.MouseHover
        btnIntermedio.Size = New Size(width:=270, height:=41)
    End Sub

    Private Sub btnIntermedio_MouseLeave(sender As Object, e As EventArgs) Handles btnIntermedio.MouseLeave
        btnIntermedio.Size = New Size(width:=261, height:=30)
    End Sub

    Private Sub btnAvanzado_MouseHover(sender As Object, e As EventArgs) Handles btnAvanzado.MouseHover
        btnAvanzado.Size = New Size(width:=270, height:=41)
    End Sub

    Private Sub btnAvanzado_MouseLeave(sender As Object, e As EventArgs) Handles btnAvanzado.MouseLeave
        btnAvanzado.Size = New Size(width:=261, height:=30)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub btnFacil_Click(sender As Object, e As EventArgs) Handles btnFacil.Click
        NivelFacil.Show()
        Me.Hide()
    End Sub
End Class