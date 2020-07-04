Public Class NivelFacil
#Region "Evaliación del Juego"
    Private Estado As Boolean = False
    Private Sub evaluar0(ByRef botones1_1 As Button, ByRef botones1_2 As Button, ByRef botones1_3 As Button, ByRef botones2_1 As Button, ByRef botones2_3 As Button, ByRef botones3_1 As Button, ByRef botones3_2 As Button, ByRef botones3_3 As Button, X As Integer, Y As Integer)
        'Evalua si en la posicion del arreglo al que pertenece ese boton = 0 entonces llama el evento click de cada uno de los botones que lo roden 
        If Ubicacion(X, Y) = 0 Then
            botones1_1.PerformClick()
            botones1_2.PerformClick()
            botones1_3.PerformClick()
            botones2_1.PerformClick()
            botones2_3.PerformClick()
            botones3_1.PerformClick()
            botones3_2.PerformClick()
            botones3_3.PerformClick()
        End If

    End Sub
    'Genera las minas en posiciones aleatorias en la matriz
    Public Sub GenerarMinas(PX As Integer, PY As Integer)
        'Evalua si es la primera vez que se generan las minas 
        If Estado = False Then
            'ASigna el tamaño de la matriz
            Estado = True
            ReDim Ubicacion(Filas, Columnas)
            ' X = Filas, Y = Columnas
            Dim X, Y As Integer

            For i = 1 To Minas Step 1
                'Genera los numeros aleatorios
                X = 0
                Y = 0
                Do While X = 0 Or Y = 0 Or X = PX And Y = PY
                    X = Math.Ceiling(Rnd() * Filas - 1)
                    Y = Math.Ceiling(Rnd() * Columnas - 1)
                Loop
                MsgBox(X, MessageBoxButtons.OK)
                MsgBox(Y, MessageBoxButtons.OK)
                'Evalua si ya existe una mina en esa posicion
                If Ubicacion(X, Y) <> -1 Then
                    Ubicacion(X, Y) = -1
                End If
                ' si existe una mina le restamos uno al contador para que vuelva a generar una vez mas 
                If Ubicacion(X, Y) = -1 Then
                    Minas += 1
                End If
            Next
        End If


    End Sub
    Public Function EvaluarCasillas(X As Integer, Y As Integer) As Integer
        'declaracion de las variables para especificar las cordenasdas de donde se encuentra el boton 
        Dim LimiteInferiorFilas As Integer = X - 1
        Dim LimiteInferiorColumnas As Integer = Y - 1
        Dim LimiteSuperiorFilas As Integer = X + 1
        Dim LimiteSuperiorColumnas As Integer = Y + 1
        Dim Resultado As Integer = 0
        'Evalua si el boton tiene una mina
        If Ubicacion(X, Y) <> -1 Then
            'Evalua las posiciones una por una y si encuentra una mina le suma al contador resultado y retorna el valor al final del ciclo
            For Filas = LimiteInferiorFilas To LimiteSuperiorFilas Step 1
                For Columnas = LimiteInferiorColumnas To LimiteSuperiorColumnas Step 1
                    'Evalua si existe una mina haceindo la excepcion de la poscion en la que se encuentra el boton al que le di click
                    If Ubicacion(Filas, Columnas) = -1 And Ubicacion(Filas, Columnas) <> Ubicacion(X, Y) Then
                        Resultado += 1
                    End If
                Next
            Next
        End If
        'Si es una mina retorna -1
        If Ubicacion(X, Y) = -1 Then
            Resultado = -1
        End If
        Return Resultado
    End Function
    Public Sub SeleccionImagen(btn As Button, X As Integer, Y As Integer)
        Gano += 1
        If Gano <> limiteDeBotones Then
            Select Case Ubicacion(X, Y)
                Case -1
                    'btn.Image = Image.FromFile("Ruta de los imagen")
                    btn.BackgroundImage = My.Resources.icons8_naval_mine_5
                    MessageBox.Show("Juego Terminado", "Fin", MessageBoxButtons.OK)
                    NuevoJuego.Show()
                    My.Forms.NivelFacil.Close()
                Case 0
                    btn.Text = ""
                    btn.BackColor = Color.FromArgb(1, 255, 255)
                Case 1
                    btn.Text = "1"
                Case 2
                    btn.Text = "2"
                Case 3
                    btn.Text = "3"
                Case 4
                    btn.Text = "4"
                Case 5
                    btn.Text = "5"
                Case 6
                    btn.Text = "6"
                Case 7
                    btn.Text = "7"
                Case 8
                    btn.Text = "8"
                Case Else
                    MsgBox("Error de asignación de imagen", MessageBoxButtons.OK)
            End Select
        Else
            MessageBox.Show("Felicidades Gano", "Felicidades")
            NuevoJuego.Show()
            My.Forms.NivelFacil.Close()
        End If

    End Sub
    Public Sub Resumen(X As Integer, Y As Integer, ByRef botones2_2 As Button, ByRef botones1_1 As Button, ByRef botones1_2 As Button, ByRef botones1_3 As Button, ByRef botones2_1 As Button, ByRef botones2_3 As Button, ByRef botones3_1 As Button, ByRef botones3_2 As Button, ByRef botones3_3 As Button)
        If clicks(X, Y) = False Then
            clicks(X, Y) = True
            GenerarMinas(X, Y)
            Ubicacion(X, Y) = EvaluarCasillas(X, Y)
            evaluar0(botones1_1, botones1_2, botones1_3, botones2_1, botones2_3, botones3_1, botones3_2, botones3_3, X, Y)
            SeleccionImagen(botones2_2, X, Y)

        End If
    End Sub
#End Region
#Region "eventos y propiedades del Juego"

    Private Sub Btn1_1_Click(sender As Object, e As EventArgs) Handles Btn1_1.Click
        'Declaracion de variable para almacenar el valor que retorna la funcion "EvaluarCasillas"
        Resumen(1, 1, Me.Btn1_1, Me.Btn0_1, Me.Btn0_2, Me.Btn0_3, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2)
    End Sub

    Private Sub Btn1_2_Click(sender As Object, e As EventArgs) Handles Btn1_2.Click
        Resumen(1, 2, Me.Btn1_2, Me.Btn0_1, Me.Btn0_2, Me.Btn0_3, Me.Btn1_1, Me.Btn1_3, Me.Btn2_1, Me.Btn2_2, Me.Btn2_3)
    End Sub

    Private Sub Btn1_3_Click(sender As Object, e As EventArgs) Handles Btn1_3.Click

        Resumen(1, 3, Me.Btn1_3, Me.Btn0_2, Me.Btn0_3, Me.Btn0_3, Me.Btn1_2, Me.Btn1_4, Me.Btn2_2, Me.Btn2_3, Me.Btn2_4)

    End Sub

    Private Sub Btn1_4_Click(sender As Object, e As EventArgs) Handles Btn1_4.Click
        Resumen(1, 4, Me.Btn1_4, Me.Btn0_3, Me.Btn0_4, Me.Btn0_5, Me.Btn1_3, Me.Btn1_5, Me.Btn2_3, Me.Btn2_4, Me.Btn2_5)

    End Sub

    Private Sub Btn1_5_Click(sender As Object, e As EventArgs) Handles Btn1_5.Click
        Resumen(1, 5, Me.Btn1_5, Me.Btn0_4, Me.Btn0_5, Me.Btn0_6, Me.Btn1_4, Me.Btn1_6, Me.Btn2_4, Me.Btn2_5, Me.Btn2_6)
    End Sub

    Private Sub Btn2_1_Click(sender As Object, e As EventArgs) Handles Btn2_1.Click
        Resumen(2, 1, Me.Btn2_1, Me.Btn1_0, Me.Btn1_1, Me.Btn1_2, Me.Btn2_0, Me.Btn2_2, Me.Btn3_0, Me.Btn3_1, Me.Btn3_2)
    End Sub

    Private Sub Btn2_2_Click(sender As Object, e As EventArgs) Handles Btn2_2.Click
        Resumen(2, 2, Me.Btn2_2, Me.Btn1_1, Me.Btn1_2, Me.Btn1_3, Me.Btn2_1, Me.Btn2_3, Me.Btn3_1, Me.Btn3_2, Me.Btn3_3)
    End Sub

    Private Sub Btn2_3_Click(sender As Object, e As EventArgs) Handles Btn2_3.Click
        Resumen(2, 3, Me.Btn2_3, Me.Btn1_2, Me.Btn1_3, Me.Btn1_4, Me.Btn2_2, Me.Btn2_4, Me.Btn3_2, Me.Btn3_3, Me.Btn3_4)
    End Sub

    Private Sub Btn2_4_Click(sender As Object, e As EventArgs) Handles Btn2_4.Click
        Resumen(2, 4, Me.Btn2_4, Me.Btn1_3, Me.Btn1_4, Me.Btn1_5, Me.Btn2_3, Me.Btn2_5, Me.Btn3_3, Me.Btn3_4, Me.Btn3_5)
    End Sub
    Private Sub Btn2_5_Click(sender As Object, e As EventArgs) Handles Btn2_5.Click
        Resumen(2, 5, Me.Btn2_5, Me.Btn1_4, Me.Btn1_5, Me.Btn1_6, Me.Btn2_4, Me.Btn2_6, Me.Btn3_4, Me.Btn3_5, Me.Btn3_6)
    End Sub

    Private Sub Btn3_1_Click(sender As Object, e As EventArgs) Handles Btn3_1.Click
        Resumen(3, 1, Me.Btn3_1, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, Me.Btn3_0, Me.Btn3_2, Me.Btn4_0, Me.Btn4_1, Me.Btn4_2)

    End Sub

    Private Sub Btn3_2_Click(sender As Object, e As EventArgs) Handles Btn3_2.Click
        Resumen(3, 2, Me.Btn3_2, Me.Btn2_1, Me.Btn2_2, Me.Btn2_3, Me.Btn3_1, Me.Btn3_3, Me.Btn4_1, Me.Btn4_2, Me.Btn4_3)
    End Sub

    Private Sub Btn3_3_Click(sender As Object, e As EventArgs) Handles Btn3_3.Click
        Resumen(3, 3, Me.Btn3_3, Me.Btn2_2, Me.Btn2_3, Me.Btn2_4, Me.Btn3_2, Me.Btn3_4, Me.Btn4_2, Me.Btn4_3, Me.Btn4_4)
    End Sub

    Private Sub Btn3_4_Click(sender As Object, e As EventArgs) Handles Btn3_4.Click
        Resumen(3, 4, Me.Btn3_4, Me.Btn2_3, Me.Btn2_4, Me.Btn2_5, Me.Btn3_3, Me.Btn3_5, Me.Btn4_3, Me.Btn4_4, Me.Btn4_5)
    End Sub

    Private Sub Btn3_5_Click(sender As Object, e As EventArgs) Handles Btn3_5.Click
        Resumen(3, 5, Me.Btn3_5, Me.Btn2_4, Me.Btn2_5, Me.Btn2_6, Me.Btn3_4, Me.Btn3_6, Me.Btn4_4, Me.Btn4_5, Me.Btn4_6)
    End Sub

    Private Sub Btn4_1_Click(sender As Object, e As EventArgs) Handles Btn4_1.Click
        Resumen(4, 1, Me.Btn4_1, Me.Btn3_0, Me.Btn3_1, Me.Btn3_2, Me.Btn4_0, Me.Btn4_2, Me.Btn5_0, Me.Btn5_1, Me.Btn5_2)
    End Sub
    Private Sub Btn4_2_Click(sender As Object, e As EventArgs) Handles Btn4_2.Click
        Resumen(4, 2, Me.Btn4_2, Me.Btn3_1, Me.Btn3_2, Me.Btn3_3, Me.Btn4_1, Me.Btn4_3, Me.Btn5_1, Me.Btn5_2, Me.Btn5_3)
    End Sub

    Private Sub Btn4_3_Click(sender As Object, e As EventArgs) Handles Btn4_3.Click
        Resumen(4, 3, Me.Btn4_3, Me.Btn3_2, Me.Btn3_3, Me.Btn3_4, Me.Btn4_2, Me.Btn4_4, Me.Btn5_2, Me.Btn5_3, Me.Btn5_4)
    End Sub

    Private Sub Btn4_4_Click(sender As Object, e As EventArgs) Handles Btn4_4.Click
        Resumen(4, 4, Me.Btn4_4, Me.Btn3_3, Me.Btn3_4, Me.Btn3_5, Me.Btn4_3, Me.Btn4_5, Me.Btn5_3, Me.Btn5_4, Me.Btn5_5)
    End Sub

    Private Sub Btn4_5_Click(sender As Object, e As EventArgs) Handles Btn4_5.Click
        Resumen(4, 5, Me.Btn4_5, Me.Btn3_4, Me.Btn3_5, Me.Btn3_6, Me.Btn4_4, Me.Btn4_6, Me.Btn5_4, Me.Btn5_5, Me.Btn5_6)
    End Sub

    Private Sub Btn5_1_Click(sender As Object, e As EventArgs) Handles Btn5_1.Click
        Resumen(5, 1, Me.Btn5_1, Me.Btn4_0, Me.Btn4_1, Me.Btn4_2, Me.Btn5_0, Me.Btn5_2, Me.Btn6_0, Me.Btn6_1, Me.Btn6_2)
    End Sub

    Private Sub Btn5_2_Click(sender As Object, e As EventArgs) Handles Btn5_2.Click
        Resumen(5, 2, Me.Btn5_2, Me.Btn4_1, Me.Btn4_2, Me.Btn4_3, Me.Btn5_1, Me.Btn5_3, Me.Btn6_1, Me.Btn6_2, Me.Btn6_3)
    End Sub

    Private Sub Btn5_3_Click(sender As Object, e As EventArgs) Handles Btn5_3.Click
        Resumen(5, 3, Me.Btn5_3, Me.Btn4_2, Me.Btn4_3, Me.Btn4_4, Me.Btn5_2, Me.Btn5_4, Me.Btn6_2, Me.Btn6_3, Me.Btn6_4)
    End Sub

    Private Sub Btn5_4_Click(sender As Object, e As EventArgs) Handles Btn5_4.Click
        Resumen(5, 4, Me.Btn5_4, Me.Btn4_3, Me.Btn4_4, Me.Btn4_5, Me.Btn5_3, Me.Btn5_5, Me.Btn6_3, Me.Btn6_4, Me.Btn6_5)
    End Sub

    Private Sub Btn5_5_Click(sender As Object, e As EventArgs) Handles Btn5_5.Click
        Resumen(5, 5, Me.Btn5_5, Me.Btn4_4, Me.Btn4_5, Me.Btn4_6, Me.Btn5_4, Me.Btn5_6, Me.Btn6_4, Me.Btn6_5, Me.Btn6_6)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Hacer el formulario del tamaño de la pantalla
        Me.WindowState = FormWindowState.Maximized

        Filas = 6
        Columnas = 6
        Minas = 3
        limiteDeBotones = (Filas - 1) * (Columnas - 1) - Minas
        ReDim clicks(Filas, Columnas)
        For i = 0 To Filas Step 1
            For m = 0 To Columnas Step 1
                Ubicacion(i, m) = 0
                clicks(i, m) = False
            Next
        Next
        Estado = False
        Gano = 0
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

    Private Sub PanelSuperior_Paint(sender As Object, e As PaintEventArgs) Handles PanelSuperior.Paint

    End Sub

    Private Sub lblMin_Click(sender As Object, e As EventArgs) Handles lblMin.Click

    End Sub
End Class
#End Region