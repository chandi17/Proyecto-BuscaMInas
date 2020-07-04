Public Class NivelDificil
    Private Sub NivelDificil_Load(sender As Object, e As EventArgs)
        'Hacer el formulario del tamaño de la pantalla
        Me.WindowState = FormWindowState.Maximized
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

    Private Sub NivelDificil_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        'Hacer el formulario del tamaño de la pantalla
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class