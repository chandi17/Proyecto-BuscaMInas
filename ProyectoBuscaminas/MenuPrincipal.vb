'Importar la libreria para el movimiento del formulario
Imports System.Runtime.InteropServices
Public Class MenuPrincipal
    'Codigo para el movimiento
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        'Cerrar el programa
        End
    End Sub

    Private Sub btnMaximizar_Click(sender As Object, e As EventArgs) Handles btnMaximizar.Click
        'Hacer el formulario del tamaño de la pantalla
        btnMaximizar.Visible = False
        btnRestaurar.Visible = True
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        'Quitar el formulario de la pantalla
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnRestaurar_Click(sender As Object, e As EventArgs) Handles btnRestaurar.Click
        'Restaura el tamaño del formulario
        btnRestaurar.Visible = False
        btnMaximizar.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub PanelSuperior_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelSuperior.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub btnNuevoJuego_Paint(sender As Object, e As PaintEventArgs) Handles btnNuevoJuego.Paint
        Dim buttonPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim myRectangle As Rectangle = btnNuevoJuego.ClientRectangle
        myRectangle.Inflate(0, 30)
        buttonPath.AddEllipse(myRectangle)
        btnNuevoJuego.Region = New Region(buttonPath)
    End Sub

    Private Sub btnNuevoJuego_MouseHover(sender As Object, e As EventArgs) Handles btnNuevoJuego.MouseHover
        btnNuevoJuego.Size = New Size(width:=270, height:=91)
    End Sub

    Private Sub btnNuevoJuego_MouseLeave(sender As Object, e As EventArgs) Handles btnNuevoJuego.MouseLeave
        btnNuevoJuego.Size = New Size(width:=261, height:=80)
    End Sub

    Private Sub btnMejorPuntaje_Paint(sender As Object, e As PaintEventArgs) Handles btnMejorPuntaje.Paint
        Dim buttonPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim myRectangle As Rectangle = btnMejorPuntaje.ClientRectangle
        myRectangle.Inflate(0, 30)
        buttonPath.AddEllipse(myRectangle)
        btnMejorPuntaje.Region = New Region(buttonPath)
    End Sub

    Private Sub btnMejorPuntaje_MouseHover(sender As Object, e As EventArgs) Handles btnMejorPuntaje.MouseHover
        btnMejorPuntaje.Size = New Size(width:=270, height:=91)
    End Sub

    Private Sub btnMejorPuntaje_MouseLeave(sender As Object, e As EventArgs) Handles btnMejorPuntaje.MouseLeave
        btnMejorPuntaje.Size = New Size(width:=261, height:=80)
    End Sub

    Private Sub btnAyuda_Paint(sender As Object, e As PaintEventArgs) Handles btnAyuda.Paint
        Dim buttonPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim myRectangle As Rectangle = btnAyuda.ClientRectangle
        myRectangle.Inflate(0, 30)
        buttonPath.AddEllipse(myRectangle)
        btnAyuda.Region = New Region(buttonPath)
    End Sub

    Private Sub btnAyuda_MouseHover(sender As Object, e As EventArgs) Handles btnAyuda.MouseHover
        btnAyuda.Size = New Size(width:=270, height:=91)
    End Sub

    Private Sub btnAyuda_MouseLeave(sender As Object, e As EventArgs) Handles btnAyuda.MouseLeave
        btnAyuda.Size = New Size(width:=261, height:=80)
    End Sub

    Private Sub btnNuevoJuego_Click(sender As Object, e As EventArgs) Handles btnNuevoJuego.Click
        NuevoJuego.Show()
        Me.Hide()
    End Sub

    Private Sub MenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        FormAyuda.Show()
    End Sub
End Class