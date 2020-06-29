Public Class Form1
#Region "Evaliación del Juego"
    Private Estado As Boolean = False
    Public Sub GenerarMinas(Filas As Integer, Columnas As Integer, minas As Integer)

        If Estado = False Then
            ReDim Ubicacion(Filas, Columnas)
            Dim X, Y As Integer

            For i = 1 To minas Step 1
                X = Math.Ceiling(Rnd() * Filas)
                Y = Math.Ceiling(Rnd() * Columnas)
                If Ubicacion(X, Y) <> -1 Then
                    Ubicacion(X, Y) = -1

                End If
                If Ubicacion(X, Y) = -1 Then
                    minas -= 1
                End If
            Next
        End If
        Estado = True
    End Sub
    Public Function EvaluarCasillas(X As Integer, Y As Integer)
        Dim LimiteInferiorFilas As Integer = X - 1
        Dim LimiteInferiorColumnas As Integer = Y - 1
        Dim LimiteSuperiorFilas As Integer = X + 1
        Dim LimiteSuperiorColumnas As Integer = Y + 1
        Dim Resultado As Integer = 0

        If Ubicacion(X, Y) <> -1 Then

            For Filas = LimiteInferiorFilas To LimiteSuperiorFilas Step 1
                For Columnas = LimiteInferiorColumnas To LimiteSuperiorColumnas Step 1
                    If Ubicacion(Filas, Columnas) = -1 And Ubicacion(Filas, Columnas) <> Ubicacion(X, Y) Then
                        Resultado += 1
                    End If
                Next
            Next
        End If
        If Ubicacion(X, Y) = -1 Then
            Resultado = -1
        End If
        Return Resultado
    End Function
#End Region

    Private Sub Btn1_1_Click(sender As Object, e As EventArgs) Handles Btn1_1.Click

        Dim R As Integer
        GenerarMinas(6, 6, 6)
        For i = 1 To 5 Step 1
            For m = 1 To 5 Step 1
                ListBox.Items.Add(Ubicacion(i, m).ToString)
            Next
            ListBox.Items.Add("Salto de linea")
        Next
        R = EvaluarCasillas(1, 1)
        Btn1_1.Text = R

    End Sub

    Private Sub Btn1_2_Click(sender As Object, e As EventArgs) Handles Btn1_2.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(1, 2)
        Btn1_2.Text = Estado
    End Sub

    Private Sub Btn1_3_Click(sender As Object, e As EventArgs) Handles Btn1_3.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(1, 3)
        Btn1_3.Text = Estado
    End Sub

    Private Sub Btn1_4_Click(sender As Object, e As EventArgs) Handles Btn1_4.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(1, 4)
        Btn1_4.Text = Estado
    End Sub

    Private Sub Btn1_5_Click(sender As Object, e As EventArgs) Handles Btn1_5.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(1, 5)
        Btn1_5.Text = Estado
    End Sub

    Private Sub Btn2_1_Click(sender As Object, e As EventArgs) Handles Btn2_1.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(2, 1)
        Btn2_1.Text = Estado
    End Sub

    Private Sub Btn2_2_Click(sender As Object, e As EventArgs) Handles Btn2_2.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(2, 2)
        Btn2_2.Text = Estado
    End Sub

    Private Sub Btn2_3_Click(sender As Object, e As EventArgs) Handles Btn2_3.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(2, 3)
        Btn2_3.Text = Estado
    End Sub

    Private Sub Btn2_4_Click(sender As Object, e As EventArgs) Handles Btn2_4.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(2, 4)
        Btn2_4.Text = Estado
    End Sub

    Private Sub Btn2_5_Click(sender As Object, e As EventArgs) Handles Btn2_5.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(2, 5)
        Btn2_5.Text = Estado
    End Sub

    Private Sub Btn3_1_Click(sender As Object, e As EventArgs) Handles Btn3_1.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(3, 1)
        Btn3_1.Text = Estado
    End Sub

    Private Sub Btn3_2_Click(sender As Object, e As EventArgs) Handles Btn3_2.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(3, 2)
        Btn3_2.Text = Estado
    End Sub

    Private Sub Btn3_3_Click(sender As Object, e As EventArgs) Handles Btn3_3.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(3, 3)
        Btn3_3.Text = Estado
    End Sub

    Private Sub Btn3_4_Click(sender As Object, e As EventArgs) Handles Btn3_4.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(3, 4)
        Btn3_4.Text = Estado
    End Sub

    Private Sub Btn3_5_Click(sender As Object, e As EventArgs) Handles Btn3_5.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(3, 5)
        Btn3_5.Text = Estado
    End Sub

    Private Sub Btn4_1_Click(sender As Object, e As EventArgs) Handles Btn4_1.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(4, 1)
        Btn4_1.Text = Estado
    End Sub

    Private Sub Btn4_2_Click(sender As Object, e As EventArgs) Handles Btn4_2.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(4, 2)
        Btn4_2.Text = Estado
    End Sub

    Private Sub Btn4_3_Click(sender As Object, e As EventArgs) Handles Btn4_3.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(4, 3)
        Btn4_3.Text = Estado
    End Sub

    Private Sub Btn4_4_Click(sender As Object, e As EventArgs) Handles Btn4_4.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(4, 4)
        Btn4_4.Text = Estado
    End Sub

    Private Sub Btn4_5_Click(sender As Object, e As EventArgs) Handles Btn4_5.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(4, 5)
        Btn4_5.Text = Estado
    End Sub

    Private Sub Btn5_1_Click(sender As Object, e As EventArgs) Handles Btn5_1.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(5, 1)
        Btn5_1.Text = Estado
    End Sub

    Private Sub Btn5_2_Click(sender As Object, e As EventArgs) Handles Btn5_2.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(5, 2)
        Btn5_2.Text = Estado
    End Sub

    Private Sub Btn5_3_Click(sender As Object, e As EventArgs) Handles Btn5_3.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(5, 3)
        Btn5_3.Text = Estado
    End Sub

    Private Sub Btn5_4_Click(sender As Object, e As EventArgs) Handles Btn5_4.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(5, 4)
        Btn5_4.Text = Estado
    End Sub

    Private Sub Btn5_5_Click(sender As Object, e As EventArgs) Handles Btn5_5.Click
        Dim Estado As Integer
        GenerarMinas(6, 6, 6)
        Estado = EvaluarCasillas(5, 5)
        Btn5_5.Text = Estado
    End Sub
End Class
