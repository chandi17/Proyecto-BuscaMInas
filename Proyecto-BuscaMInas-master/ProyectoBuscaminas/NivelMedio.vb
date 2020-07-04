Public Class NivelMedio
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Btn1_8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSalirJuego_Click(sender As Object, e As EventArgs) Handles btnSalirJuego.Click
        Dim salir As String

        salir = MsgBox("¿Esta seguro que desea salir?", 36, "SALIR")
        If salir = 6 Then
            End
        End If
    End Sub

    Private Sub btnMenuPrincipal_Click(sender As Object, e As EventArgs) Handles btnMenuPrincipal.Click
        'Definir las Variables
        Dim formulario As New MenuPrincipal

        'Pasar al Siguiente Formulario
        formulario.Show()
        Me.Close()
    End Sub

    Private Sub NivelMedio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Hacer el formulario del tamaño de la pantalla
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class