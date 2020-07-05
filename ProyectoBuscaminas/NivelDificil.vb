Public Class NivelDificil
    Dim conexion As New Conexion
#Region "Evaliación del Juego"
    Private Estado As Boolean = False
    Public Sub evaluar0(ByRef botones1_1 As Button, ByRef botones1_2 As Button, ByRef botones1_3 As Button, ByRef botones2_1 As Button, ByRef botones2_3 As Button, ByRef botones3_1 As Button, ByRef botones3_2 As Button, ByRef botones3_3 As Button, X As Integer, Y As Integer)
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
                    TimerDificil.Stop()
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
            TimerDificil.Stop()
            Dim avatar As String = ""
            Do While avatar = ""
                avatar = InputBox("Ingresa tu avatar: ", "Campo Obligatorio")
            Loop
            segundos = Int(Val(lblSegs.Text))
            minutos = Int(Val(lblMin.Text))
            puntos = (minutos * 360) + segundos
            Dim verificar As Boolean = conexion.ValidarExiste(avatar)
            If verificar = False Then
                conexion.insertarPuntos(puntos, avatar)
                Dim mensa As String = "Felicidades " & avatar & " tu tiempo es: " & minutos & " : " & segundos & " Segundos"
                MessageBox.Show(mensa, "Felicidades", MessageBoxButtons.OK)
                MenuPrincipal.Show()
                My.Forms.NivelFacil.Close()
                Exit Sub
            Else
                conexion.ActualizarDatos(puntos, avatar)
                Dim mensa As String = "Felicidades " & avatar & "tu tiempo es: " & minutos & " : " & segundos & " Segundos"
                MessageBox.Show(mensa, "Felicidades", MessageBoxButtons.OK)
                MenuPrincipal.Show()
                My.Forms.NivelFacil.Close()
                Exit Sub
            End If
            MenuPrincipal.Show()
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
            TimerDificil.Start()
        End If
    End Sub
#End Region
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

        Filas = 16
        Columnas = 16
        Minas = 15
        limiteDeBotones = (Filas - 1) * (Columnas - 1) - Minas
        ReDim clicks(Filas, Columnas)
        ReDim Ubicacion(Filas, Columnas)
        For i = 0 To Filas Step 1
            For m = 0 To Columnas Step 1
                Ubicacion(i, m) = 0
                clicks(i, m) = False
            Next
        Next
        Estado = False
        Gano = 0
    End Sub

    Private Sub Btn1_1_Click(sender As Object, e As EventArgs) Handles Btn1_1.Click
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

    Private Sub Btn1_6_Click(sender As Object, e As EventArgs) Handles Btn1_6.Click
        Resumen(1, 6, Me.Btn1_6, Me.Btn0_5, Me.Btn0_6, Me.Btn0_7, Me.Btn1_5, Me.Btn1_7, Me.Btn2_5, Me.Btn2_6, Me.Btn2_7)
    End Sub

    Private Sub Btn1_7_Click(sender As Object, e As EventArgs) Handles Btn1_7.Click
        Resumen(1, 7, Me.Btn1_7, Me.Btn0_6, Me.Btn0_7, Me.Btn0_8, Me.Btn1_6, Me.Btn1_8, Me.Btn2_6, Me.Btn2_7, Me.Btn2_8)
    End Sub

    Private Sub Btn1_8_Click(sender As Object, e As EventArgs) Handles Btn1_8.Click
        Resumen(1, 8, Me.Btn1_8, Me.Btn0_7, Me.Btn0_8, Me.Btn0_9, Me.Btn1_7, Me.Btn1_9, Me.Btn2_7, Me.Btn2_8, Me.Btn2_9)
    End Sub

    Private Sub Btn1_9_Click(sender As Object, e As EventArgs) Handles Btn1_9.Click
        Resumen(1, 9, Me.Btn1_9, Me.Btn0_8, Me.Btn0_9, Me.Btn0_10, Me.Btn1_8, Me.Btn1_10, Me.Btn2_8, Me.Btn2_9, Me.Btn2_10)
    End Sub

    Private Sub Btn1_10_Click(sender As Object, e As EventArgs) Handles Btn1_10.Click
        Resumen(1, 10, Me.Btn1_10, Me.Btn0_9, Me.Btn0_10, Me.Btn0_11, Me.Btn1_9, Me.Btn1_11, Me.Btn2_9, Me.Btn2_10, Me.Btn2_11)
    End Sub

    Private Sub Btn1_11_Click(sender As Object, e As EventArgs) Handles Btn1_11.Click
        Resumen(1, 11, Me.Btn1_11, Me.Btn0_10, Me.Btn0_11, Me.Btn0_12, Me.Btn1_10, Me.Btn1_12, Me.Btn2_10, Me.Btn2_11, Me.Btn2_12)
    End Sub

    Private Sub Btn1_12_Click(sender As Object, e As EventArgs) Handles Btn1_12.Click
        Resumen(1, 12, Me.Btn1_12, Me.Btn0_11, Me.Btn0_12, Me.Btn0_13, Me.Btn1_11, Me.Btn1_13, Me.Btn2_11, Me.Btn2_12, Me.Btn2_13)
    End Sub

    Private Sub Btn1_13_Click(sender As Object, e As EventArgs) Handles Btn1_13.Click
        Resumen(1, 13, Me.Btn1_13, Me.Btn0_12, Me.Btn0_13, Me.Btn0_14, Me.Btn1_12, Me.Btn1_14, Me.Btn2_12, Me.Btn2_13, Me.Btn2_14)
    End Sub

    Private Sub Btn1_14_Click(sender As Object, e As EventArgs) Handles Btn1_14.Click
        Resumen(1, 14, Me.Btn1_14, Me.Btn0_13, Me.Btn0_14, Me.Btn0_15, Me.Btn1_13, Me.Btn1_15, Me.Btn2_13, Me.Btn2_14, Me.Btn2_15)
    End Sub

    Private Sub Btn1_15_Click(sender As Object, e As EventArgs) Handles Btn1_15.Click
        Resumen(1, 15, Me.Btn1_15, Me.Btn0_14, Me.Btn0_15, Me.Btn0_16, Me.Btn1_14, Me.Btn1_16, Me.Btn2_14, Me.Btn2_15, Me.Btn2_16)
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

    Private Sub Btn2_6_Click(sender As Object, e As EventArgs) Handles Btn2_6.Click
        Resumen(2, 6, Me.Btn2_6, Me.Btn1_5, Me.Btn1_6, Me.Btn1_7, Me.Btn2_5, Me.Btn2_7, Me.Btn3_5, Me.Btn3_6, Me.Btn3_7)
    End Sub

    Private Sub Btn2_7_Click(sender As Object, e As EventArgs) Handles Btn2_7.Click
        Resumen(2, 7, Me.Btn2_7, Me.Btn1_6, Me.Btn1_7, Me.Btn1_8, Me.Btn2_6, Me.Btn2_8, Me.Btn3_6, Me.Btn3_7, Me.Btn3_8)
    End Sub

    Private Sub Btn2_8_Click(sender As Object, e As EventArgs) Handles Btn2_8.Click
        Resumen(2, 8, Me.Btn2_8, Me.Btn1_7, Me.Btn1_8, Me.Btn1_9, Me.Btn2_7, Me.Btn2_9, Me.Btn3_7, Me.Btn3_8, Me.Btn3_9)
    End Sub

    Private Sub Btn2_9_Click(sender As Object, e As EventArgs) Handles Btn2_9.Click
        Resumen(2, 9, Me.Btn2_9, Me.Btn1_8, Me.Btn1_9, Me.Btn1_10, Me.Btn2_8, Me.Btn2_10, Me.Btn3_8, Me.Btn3_9, Me.Btn3_10)
    End Sub

    Private Sub Btn2_10_Click(sender As Object, e As EventArgs) Handles Btn2_10.Click
        Resumen(2, 10, Me.Btn2_10, Me.Btn1_9, Me.Btn1_10, Me.Btn1_11, Me.Btn2_9, Me.Btn2_11, Me.Btn3_9, Me.Btn3_10, Me.Btn3_11)
    End Sub

    Private Sub Btn2_11_Click(sender As Object, e As EventArgs) Handles Btn2_11.Click
        Resumen(2, 11, Me.Btn2_11, Me.Btn1_10, Me.Btn1_11, Me.Btn1_12, Me.Btn2_10, Me.Btn2_12, Me.Btn3_10, Me.Btn3_11, Me.Btn3_12)
    End Sub

    Private Sub Btn2_12_Click(sender As Object, e As EventArgs) Handles Btn2_12.Click
        Resumen(2, 12, Me.Btn2_12, Me.Btn1_11, Me.Btn1_12, Me.Btn1_13, Me.Btn2_11, Me.Btn2_13, Me.Btn3_11, Me.Btn3_12, Me.Btn3_13)
    End Sub

    Private Sub Btn2_13_Click(sender As Object, e As EventArgs) Handles Btn2_13.Click
        Resumen(2, 13, Me.Btn2_13, Me.Btn1_12, Me.Btn1_13, Me.Btn1_14, Me.Btn2_12, Me.Btn2_14, Me.Btn3_12, Me.Btn3_13, Me.Btn3_14)
    End Sub

    Private Sub Btn2_14_Click(sender As Object, e As EventArgs) Handles Btn2_14.Click
        Resumen(2, 14, Me.Btn2_14, Me.Btn1_13, Me.Btn1_14, Me.Btn1_15, Me.Btn2_13, Me.Btn2_15, Me.Btn3_13, Me.Btn3_14, Me.Btn3_15)
    End Sub

    Private Sub Btn2_15_Click(sender As Object, e As EventArgs) Handles Btn2_15.Click
        Resumen(2, 15, Me.Btn2_15, Me.Btn1_14, Me.Btn1_15, Me.Btn1_16, Me.Btn2_14, Me.Btn2_16, Me.Btn3_14, Me.Btn3_15, Me.Btn3_16)
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

    Private Sub Btn3_6_Click(sender As Object, e As EventArgs) Handles Btn3_6.Click
        Resumen(3, 6, Me.Btn3_6, Me.Btn2_5, Me.Btn2_6, Me.Btn2_7, Me.Btn3_5, Me.Btn3_7, Me.Btn4_5, Me.Btn4_6, Me.Btn4_7)
    End Sub

    Private Sub Btn3_7_Click(sender As Object, e As EventArgs) Handles Btn3_7.Click
        Resumen(3, 7, Me.Btn3_7, Me.Btn2_6, Me.Btn2_7, Me.Btn2_8, Me.Btn3_6, Me.Btn3_8, Me.Btn4_6, Me.Btn4_7, Me.Btn4_8)
    End Sub

    Private Sub Btn3_8_Click(sender As Object, e As EventArgs) Handles Btn3_8.Click
        Resumen(3, 8, Me.Btn3_8, Me.Btn2_7, Me.Btn2_8, Me.Btn2_9, Me.Btn3_7, Me.Btn3_9, Me.Btn4_7, Me.Btn4_8, Me.Btn4_9)
    End Sub

    Private Sub Btn3_9_Click(sender As Object, e As EventArgs) Handles Btn3_9.Click
        Resumen(3, 9, Me.Btn3_9, Me.Btn2_8, Me.Btn2_9, Me.Btn2_10, Me.Btn3_8, Me.Btn3_10, Me.Btn4_8, Me.Btn4_9, Me.Btn4_10)
    End Sub

    Private Sub Btn3_10_Click(sender As Object, e As EventArgs) Handles Btn3_10.Click
        Resumen(3, 10, Me.Btn3_10, Me.Btn2_9, Me.Btn2_10, Me.Btn2_11, Me.Btn3_9, Me.Btn3_11, Me.Btn4_9, Me.Btn4_10, Me.Btn4_11)
    End Sub

    Private Sub Btn3_11_Click(sender As Object, e As EventArgs) Handles Btn3_11.Click
        Resumen(3, 11, Me.Btn3_11, Me.Btn2_10, Me.Btn2_11, Me.Btn2_12, Me.Btn3_10, Me.Btn3_12, Me.Btn4_10, Me.Btn4_11, Me.Btn4_12)
    End Sub

    Private Sub Btn3_12_Click(sender As Object, e As EventArgs) Handles Btn3_12.Click
        Resumen(3, 12, Me.Btn3_12, Me.Btn2_11, Me.Btn2_12, Me.Btn2_13, Me.Btn3_11, Me.Btn3_13, Me.Btn4_11, Me.Btn4_12, Me.Btn4_13)
    End Sub

    Private Sub Btn3_13_Click(sender As Object, e As EventArgs) Handles Btn3_13.Click
        Resumen(3, 13, Me.Btn3_13, Me.Btn2_12, Me.Btn2_13, Me.Btn2_14, Me.Btn3_12, Me.Btn3_14, Me.Btn4_12, Me.Btn4_13, Me.Btn4_14)
    End Sub

    Private Sub Btn3_14_Click(sender As Object, e As EventArgs) Handles Btn3_14.Click
        Resumen(3, 14, Me.Btn3_14, Me.Btn2_13, Me.Btn2_14, Me.Btn2_15, Me.Btn3_13, Me.Btn3_15, Me.Btn4_13, Me.Btn4_14, Me.Btn4_15)
    End Sub

    Private Sub Btn3_15_Click(sender As Object, e As EventArgs) Handles Btn3_15.Click
        Resumen(3, 15, Me.Btn3_15, Me.Btn2_14, Me.Btn2_15, Me.Btn2_16, Me.Btn3_14, Me.Btn3_16, Me.Btn4_14, Me.Btn4_15, Me.Btn4_16)
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

    Private Sub Btn4_6_Click(sender As Object, e As EventArgs) Handles Btn4_6.Click
        Resumen(4, 6, Me.Btn4_6, Me.Btn3_5, Me.Btn3_6, Me.Btn3_7, Me.Btn4_5, Me.Btn4_7, Me.Btn5_5, Me.Btn5_6, Me.Btn5_7)
    End Sub

    Private Sub Btn4_7_Click(sender As Object, e As EventArgs) Handles Btn4_7.Click
        Resumen(4, 7, Me.Btn4_7, Me.Btn3_6, Me.Btn3_7, Me.Btn3_8, Me.Btn4_6, Me.Btn4_8, Me.Btn5_6, Me.Btn5_7, Me.Btn5_8)
    End Sub

    Private Sub Btn4_8_Click(sender As Object, e As EventArgs) Handles Btn4_8.Click
        Resumen(4, 8, Me.Btn4_8, Me.Btn3_7, Me.Btn3_8, Me.Btn3_9, Me.Btn4_7, Me.Btn4_9, Me.Btn5_7, Me.Btn5_8, Me.Btn5_9)
    End Sub

    Private Sub Btn4_9_Click(sender As Object, e As EventArgs) Handles Btn4_9.Click
        Resumen(4, 9, Me.Btn4_9, Me.Btn3_8, Me.Btn3_9, Me.Btn3_10, Me.Btn4_8, Me.Btn4_10, Me.Btn5_8, Me.Btn5_9, Me.Btn5_10)
    End Sub

    Private Sub Btn4_10_Click(sender As Object, e As EventArgs) Handles Btn4_10.Click
        Resumen(4, 10, Me.Btn4_10, Me.Btn3_9, Me.Btn3_10, Me.Btn3_11, Me.Btn4_9, Me.Btn4_11, Me.Btn5_9, Me.Btn5_10, Me.Btn5_11)
    End Sub

    Private Sub Btn4_11_Click(sender As Object, e As EventArgs) Handles Btn4_11.Click
        Resumen(4, 11, Me.Btn4_11, Me.Btn3_10, Me.Btn3_11, Me.Btn3_12, Me.Btn4_10, Me.Btn4_12, Me.Btn5_10, Me.Btn5_11, Me.Btn5_12)
    End Sub

    Private Sub Btn4_12_Click(sender As Object, e As EventArgs) Handles Btn4_12.Click
        Resumen(4, 12, Me.Btn4_12, Me.Btn3_11, Me.Btn3_12, Me.Btn3_13, Me.Btn4_11, Me.Btn4_13, Me.Btn5_11, Me.Btn5_12, Me.Btn5_13)
    End Sub

    Private Sub Btn4_13_Click(sender As Object, e As EventArgs) Handles Btn4_13.Click
        Resumen(4, 13, Me.Btn4_13, Me.Btn3_12, Me.Btn3_13, Me.Btn3_14, Me.Btn4_12, Me.Btn4_14, Me.Btn5_12, Me.Btn5_13, Me.Btn5_14)
    End Sub

    Private Sub Btn4_14_Click(sender As Object, e As EventArgs) Handles Btn4_14.Click
        Resumen(4, 14, Me.Btn4_14, Me.Btn3_13, Me.Btn3_14, Me.Btn3_15, Me.Btn4_13, Me.Btn4_15, Me.Btn5_13, Me.Btn5_14, Me.Btn5_15)
    End Sub

    Private Sub Btn4_15_Click(sender As Object, e As EventArgs) Handles Btn4_15.Click
        Resumen(4, 15, Me.Btn4_15, Me.Btn3_14, Me.Btn3_15, Me.Btn3_16, Me.Btn4_14, Me.Btn4_16, Me.Btn5_14, Me.Btn5_15, Me.Btn5_16)
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

    Private Sub Btn5_6_Click(sender As Object, e As EventArgs) Handles Btn5_6.Click
        Resumen(5, 6, Me.Btn5_6, Me.Btn4_5, Me.Btn4_6, Me.Btn4_7, Me.Btn5_5, Me.Btn5_7, Me.Btn6_5, Me.Btn6_6, Me.Btn6_7)
    End Sub

    Private Sub Btn5_7_Click(sender As Object, e As EventArgs) Handles Btn5_7.Click
        Resumen(5, 7, Me.Btn5_7, Me.Btn4_6, Me.Btn4_7, Me.Btn4_8, Me.Btn5_6, Me.Btn5_8, Me.Btn6_6, Me.Btn6_7, Me.Btn6_8)
    End Sub

    Private Sub Btn5_8_Click(sender As Object, e As EventArgs) Handles Btn5_8.Click
        Resumen(5, 8, Me.Btn5_8, Me.Btn4_7, Me.Btn4_8, Me.Btn4_9, Me.Btn5_7, Me.Btn5_9, Me.Btn6_7, Me.Btn6_8, Me.Btn6_9)
    End Sub

    Private Sub Btn5_9_Click(sender As Object, e As EventArgs) Handles Btn5_9.Click
        Resumen(5, 9, Me.Btn5_9, Me.Btn4_8, Me.Btn4_9, Me.Btn4_10, Me.Btn5_8, Me.Btn5_10, Me.Btn6_8, Me.Btn6_9, Me.Btn6_10)
    End Sub

    Private Sub Btn5_10_Click(sender As Object, e As EventArgs) Handles Btn5_10.Click
        Resumen(5, 10, Me.Btn5_10, Me.Btn4_9, Me.Btn4_10, Me.Btn4_11, Me.Btn5_9, Me.Btn5_11, Me.Btn6_9, Me.Btn6_10, Me.Btn6_11)
    End Sub

    Private Sub Btn5_11_Click(sender As Object, e As EventArgs) Handles Btn5_11.Click
        Resumen(5, 11, Me.Btn5_11, Me.Btn4_10, Me.Btn4_11, Me.Btn4_12, Me.Btn5_10, Me.Btn5_12, Me.Btn6_10, Me.Btn6_11, Me.Btn6_12)
    End Sub

    Private Sub Btn5_12_Click(sender As Object, e As EventArgs) Handles Btn5_12.Click
        Resumen(5, 12, Me.Btn5_12, Me.Btn4_11, Me.Btn4_12, Me.Btn4_13, Me.Btn5_11, Me.Btn5_13, Me.Btn6_11, Me.Btn6_12, Me.Btn6_13)
    End Sub

    Private Sub Btn5_13_Click(sender As Object, e As EventArgs) Handles Btn5_13.Click
        Resumen(5, 13, Me.Btn5_13, Me.Btn4_12, Me.Btn4_13, Me.Btn4_14, Me.Btn5_12, Me.Btn5_14, Me.Btn6_12, Me.Btn6_13, Me.Btn6_14)
    End Sub

    Private Sub Btn5_14_Click(sender As Object, e As EventArgs) Handles Btn5_14.Click
        Resumen(5, 14, Me.Btn5_14, Me.Btn4_13, Me.Btn4_14, Me.Btn4_15, Me.Btn5_13, Me.Btn5_15, Me.Btn6_13, Me.Btn6_14, Me.Btn6_15)
    End Sub

    Private Sub Btn5_15_Click(sender As Object, e As EventArgs) Handles Btn5_15.Click
        Resumen(5, 15, Me.Btn5_15, Me.Btn4_14, Me.Btn4_15, Me.Btn4_16, Me.Btn5_14, Me.Btn5_16, Me.Btn6_14, Me.Btn6_15, Me.Btn6_16)
    End Sub

    Private Sub Btn6_1_Click(sender As Object, e As EventArgs) Handles Btn6_1.Click
        Resumen(6, 1, Me.Btn6_1, Me.Btn5_0, Me.Btn5_1, Me.Btn5_2, Me.Btn6_0, Me.Btn6_2, Me.Btn7_0, Me.Btn7_1, Me.Btn7_2)
    End Sub

    Private Sub Btn6_2_Click(sender As Object, e As EventArgs) Handles Btn6_2.Click
        Resumen(6, 2, Me.Btn6_2, Me.Btn5_1, Me.Btn5_2, Me.Btn5_3, Me.Btn6_1, Me.Btn6_3, Me.Btn7_1, Me.Btn7_2, Me.Btn7_3)
    End Sub

    Private Sub Btn6_3_Click(sender As Object, e As EventArgs) Handles Btn6_3.Click
        Resumen(6, 3, Me.Btn6_3, Me.Btn5_2, Me.Btn5_3, Me.Btn5_4, Me.Btn6_2, Me.Btn6_4, Me.Btn7_2, Me.Btn7_3, Me.Btn7_4)
    End Sub

    Private Sub Btn6_4_Click(sender As Object, e As EventArgs) Handles Btn6_4.Click
        Resumen(6, 4, Me.Btn6_4, Me.Btn5_3, Me.Btn5_4, Me.Btn5_5, Me.Btn6_3, Me.Btn6_5, Me.Btn7_3, Me.Btn7_4, Me.Btn7_5)
    End Sub

    Private Sub Btn6_5_Click(sender As Object, e As EventArgs) Handles Btn6_5.Click
        Resumen(6, 5, Me.Btn6_5, Me.Btn5_4, Me.Btn5_5, Me.Btn5_6, Me.Btn6_4, Me.Btn6_6, Me.Btn7_4, Me.Btn7_5, Me.Btn7_6)
    End Sub

    Private Sub Btn6_6_Click(sender As Object, e As EventArgs) Handles Btn6_6.Click
        Resumen(6, 6, Me.Btn6_6, Me.Btn5_5, Me.Btn5_6, Me.Btn5_7, Me.Btn6_5, Me.Btn6_7, Me.Btn7_5, Me.Btn7_6, Me.Btn7_7)
    End Sub

    Private Sub Btn6_7_Click(sender As Object, e As EventArgs) Handles Btn6_7.Click
        Resumen(6, 7, Me.Btn6_7, Me.Btn5_6, Me.Btn5_7, Me.Btn5_8, Me.Btn6_6, Me.Btn6_8, Me.Btn7_6, Me.Btn7_7, Me.Btn7_8)
    End Sub

    Private Sub Btn6_8_Click(sender As Object, e As EventArgs) Handles Btn6_8.Click
        Resumen(6, 8, Me.Btn6_8, Me.Btn5_7, Me.Btn5_8, Me.Btn5_9, Me.Btn6_7, Me.Btn6_9, Me.Btn7_7, Me.Btn7_8, Me.Btn7_9)
    End Sub

    Private Sub Btn6_9_Click(sender As Object, e As EventArgs) Handles Btn6_9.Click
        Resumen(6, 9, Me.Btn6_9, Me.Btn5_8, Me.Btn5_9, Me.Btn5_10, Me.Btn6_8, Me.Btn6_10, Me.Btn7_8, Me.Btn7_9, Me.Btn7_10)
    End Sub

    Private Sub Btn6_10_Click(sender As Object, e As EventArgs) Handles Btn6_10.Click
        Resumen(6, 10, Me.Btn6_10, Me.Btn5_9, Me.Btn5_10, Me.Btn5_11, Me.Btn6_9, Me.Btn6_11, Me.Btn7_9, Me.Btn7_10, Me.Btn7_11)
    End Sub

    Private Sub Btn6_11_Click(sender As Object, e As EventArgs) Handles Btn6_11.Click
        Resumen(6, 11, Me.Btn6_11, Me.Btn5_10, Me.Btn5_11, Me.Btn5_12, Me.Btn6_10, Me.Btn6_12, Me.Btn7_10, Me.Btn7_11, Me.Btn7_12)
    End Sub

    Private Sub Btn6_12_Click(sender As Object, e As EventArgs) Handles Btn6_12.Click
        Resumen(6, 12, Me.Btn6_12, Me.Btn5_11, Me.Btn5_12, Me.Btn5_13, Me.Btn6_11, Me.Btn6_13, Me.Btn7_11, Me.Btn7_12, Me.Btn7_13)
    End Sub

    Private Sub Btn6_13_Click(sender As Object, e As EventArgs) Handles Btn6_13.Click
        Resumen(6, 13, Me.Btn6_13, Me.Btn5_12, Me.Btn5_13, Me.Btn5_14, Me.Btn6_12, Me.Btn6_14, Me.Btn7_12, Me.Btn7_13, Me.Btn7_14)
    End Sub

    Private Sub Btn6_14_Click(sender As Object, e As EventArgs) Handles Btn6_14.Click
        Resumen(6, 14, Me.Btn6_14, Me.Btn5_13, Me.Btn5_14, Me.Btn5_15, Me.Btn6_13, Me.Btn6_15, Me.Btn7_13, Me.Btn7_14, Me.Btn7_15)
    End Sub

    Private Sub Btn6_15_Click(sender As Object, e As EventArgs) Handles Btn6_15.Click
        Resumen(6, 15, Me.Btn6_15, Me.Btn5_14, Me.Btn5_15, Me.Btn5_16, Me.Btn6_14, Me.Btn6_16, Me.Btn7_14, Me.Btn7_15, Me.Btn7_16)
    End Sub

    Private Sub Btn7_1_Click(sender As Object, e As EventArgs) Handles Btn7_1.Click
        Resumen(7, 1, Me.Btn7_1, Me.Btn6_0, Me.Btn6_1, Me.Btn6_2, Me.Btn7_0, Me.Btn7_2, Me.Btn8_0, Me.Btn8_1, Me.Btn8_2)
    End Sub

    Private Sub Btn7_2_Click(sender As Object, e As EventArgs) Handles Btn7_2.Click
        Resumen(7, 2, Me.Btn7_2, Me.Btn6_1, Me.Btn6_2, Me.Btn6_3, Me.Btn7_1, Me.Btn7_3, Me.Btn8_1, Me.Btn8_2, Me.Btn8_3)
    End Sub

    Private Sub Btn7_3_Click(sender As Object, e As EventArgs) Handles Btn7_3.Click
        Resumen(7, 3, Me.Btn7_3, Me.Btn6_2, Me.Btn6_3, Me.Btn6_4, Me.Btn7_2, Me.Btn7_4, Me.Btn8_2, Me.Btn8_3, Me.Btn8_4)
    End Sub

    Private Sub Btn7_4_Click(sender As Object, e As EventArgs) Handles Btn7_4.Click
        Resumen(7, 4, Me.Btn7_4, Me.Btn6_3, Me.Btn6_4, Me.Btn6_5, Me.Btn7_3, Me.Btn7_5, Me.Btn8_3, Me.Btn8_4, Me.Btn8_5)
    End Sub

    Private Sub Btn7_5_Click(sender As Object, e As EventArgs) Handles Btn7_5.Click
        Resumen(7, 5, Me.Btn7_5, Me.Btn6_4, Me.Btn6_5, Me.Btn6_6, Me.Btn7_4, Me.Btn7_6, Me.Btn8_4, Me.Btn8_5, Me.Btn8_6)
    End Sub

    Private Sub Btn7_6_Click(sender As Object, e As EventArgs) Handles Btn7_6.Click
        Resumen(7, 6, Me.Btn7_6, Me.Btn6_5, Me.Btn6_6, Me.Btn6_7, Me.Btn7_5, Me.Btn7_7, Me.Btn8_5, Me.Btn8_6, Me.Btn8_7)
    End Sub

    Private Sub Btn7_7_Click(sender As Object, e As EventArgs) Handles Btn7_7.Click
        Resumen(7, 7, Me.Btn7_7, Me.Btn6_6, Me.Btn6_7, Me.Btn6_8, Me.Btn7_6, Me.Btn7_8, Me.Btn8_6, Me.Btn8_7, Me.Btn8_8)
    End Sub

    Private Sub Btn7_8_Click(sender As Object, e As EventArgs) Handles Btn7_8.Click
        Resumen(7, 8, Me.Btn7_8, Me.Btn6_7, Me.Btn6_8, Me.Btn6_9, Me.Btn7_7, Me.Btn7_9, Me.Btn8_7, Me.Btn8_8, Me.Btn8_9)
    End Sub

    Private Sub Btn7_9_Click(sender As Object, e As EventArgs) Handles Btn7_9.Click
        Resumen(7, 9, Me.Btn7_9, Me.Btn6_8, Me.Btn6_9, Me.Btn6_10, Me.Btn7_8, Me.Btn7_10, Me.Btn8_8, Me.Btn8_9, Me.Btn8_10)
    End Sub

    Private Sub Btn7_10_Click(sender As Object, e As EventArgs) Handles Btn7_10.Click
        Resumen(7, 10, Me.Btn7_10, Me.Btn6_9, Me.Btn6_10, Me.Btn6_11, Me.Btn7_9, Me.Btn7_11, Me.Btn8_9, Me.Btn8_10, Me.Btn8_11)
    End Sub

    Private Sub Btn7_11_Click(sender As Object, e As EventArgs) Handles Btn7_11.Click
        Resumen(7, 11, Me.Btn7_11, Me.Btn6_10, Me.Btn6_11, Me.Btn6_12, Me.Btn7_10, Me.Btn7_12, Me.Btn8_10, Me.Btn8_11, Me.Btn8_12)
    End Sub

    Private Sub Btn7_12_Click(sender As Object, e As EventArgs) Handles Btn7_12.Click
        Resumen(7, 12, Me.Btn7_12, Me.Btn6_11, Me.Btn6_12, Me.Btn6_13, Me.Btn7_11, Me.Btn7_13, Me.Btn8_11, Me.Btn8_12, Me.Btn8_13)
    End Sub

    Private Sub Btn7_13_Click(sender As Object, e As EventArgs) Handles Btn7_13.Click
        Resumen(7, 13, Me.Btn7_13, Me.Btn6_12, Me.Btn6_13, Me.Btn6_14, Me.Btn7_12, Me.Btn7_14, Me.Btn8_12, Me.Btn8_13, Me.Btn8_14)
    End Sub

    Private Sub Btn7_14_Click(sender As Object, e As EventArgs) Handles Btn7_14.Click
        Resumen(7, 14, Me.Btn7_14, Me.Btn6_13, Me.Btn6_14, Me.Btn6_15, Me.Btn7_13, Me.Btn7_15, Me.Btn8_13, Me.Btn8_14, Me.Btn8_15)
    End Sub

    Private Sub Btn7_15_Click(sender As Object, e As EventArgs) Handles Btn7_15.Click
        Resumen(7, 15, Me.Btn7_15, Me.Btn6_14, Me.Btn6_15, Me.Btn6_16, Me.Btn7_14, Me.Btn7_16, Me.Btn8_14, Me.Btn8_15, Me.Btn8_16)
    End Sub

    Private Sub Btn8_1_Click(sender As Object, e As EventArgs) Handles Btn8_1.Click
        Resumen(8, 1, Me.Btn8_1, Me.Btn7_0, Me.Btn7_1, Me.Btn7_2, Me.Btn8_0, Me.Btn8_2, Me.Btn9_0, Me.Btn9_1, Me.Btn9_2)
    End Sub

    Private Sub Btn8_2_Click(sender As Object, e As EventArgs) Handles Btn8_2.Click
        Resumen(8, 2, Me.Btn8_2, Me.Btn7_1, Me.Btn7_2, Me.Btn7_3, Me.Btn8_1, Me.Btn8_3, Me.Btn9_1, Me.Btn9_2, Me.Btn9_3)
    End Sub

    Private Sub Btn8_3_Click(sender As Object, e As EventArgs) Handles Btn8_3.Click
        Resumen(8, 3, Me.Btn8_3, Me.Btn7_2, Me.Btn7_3, Me.Btn7_4, Me.Btn8_2, Me.Btn8_4, Me.Btn9_2, Me.Btn9_3, Me.Btn9_4)
    End Sub

    Private Sub Btn8_4_Click(sender As Object, e As EventArgs) Handles Btn8_4.Click
        Resumen(8, 4, Me.Btn8_4, Me.Btn7_3, Me.Btn7_4, Me.Btn7_5, Me.Btn8_3, Me.Btn8_5, Me.Btn9_3, Me.Btn9_4, Me.Btn9_5)
    End Sub

    Private Sub Btn8_5_Click(sender As Object, e As EventArgs) Handles Btn8_5.Click
        Resumen(8, 5, Me.Btn8_5, Me.Btn7_4, Me.Btn7_5, Me.Btn7_6, Me.Btn8_4, Me.Btn8_6, Me.Btn9_4, Me.Btn9_5, Me.Btn9_6)
    End Sub

    Private Sub Btn8_6_Click(sender As Object, e As EventArgs) Handles Btn8_6.Click
        Resumen(8, 6, Me.Btn8_6, Me.Btn7_5, Me.Btn7_6, Me.Btn7_7, Me.Btn8_5, Me.Btn8_7, Me.Btn9_5, Me.Btn9_6, Me.Btn9_7)
    End Sub

    Private Sub Btn8_7_Click(sender As Object, e As EventArgs) Handles Btn8_7.Click
        Resumen(8, 7, Me.Btn8_7, Me.Btn7_6, Me.Btn7_7, Me.Btn7_8, Me.Btn8_6, Me.Btn8_8, Me.Btn9_6, Me.Btn9_7, Me.Btn9_8)
    End Sub

    Private Sub Btn8_8_Click(sender As Object, e As EventArgs) Handles Btn8_8.Click
        Resumen(8, 8, Me.Btn8_8, Me.Btn7_7, Me.Btn7_8, Me.Btn7_9, Me.Btn8_7, Me.Btn8_9, Me.Btn9_7, Me.Btn9_8, Me.Btn9_9)
    End Sub

    Private Sub Btn8_9_Click(sender As Object, e As EventArgs) Handles Btn8_9.Click
        Resumen(8, 9, Me.Btn8_9, Me.Btn7_8, Me.Btn7_9, Me.Btn7_10, Me.Btn8_8, Me.Btn8_10, Me.Btn9_8, Me.Btn9_9, Me.Btn9_10)
    End Sub

    Private Sub Btn8_10_Click(sender As Object, e As EventArgs) Handles Btn8_10.Click
        Resumen(8, 10, Me.Btn8_10, Me.Btn7_9, Me.Btn7_10, Me.Btn7_11, Me.Btn8_9, Me.Btn8_11, Me.Btn9_9, Me.Btn9_10, Me.Btn9_11)
    End Sub

    Private Sub Btn8_11_Click(sender As Object, e As EventArgs) Handles Btn8_11.Click
        Resumen(8, 11, Me.Btn8_11, Me.Btn7_10, Me.Btn7_11, Me.Btn7_12, Me.Btn8_10, Me.Btn8_12, Me.Btn9_10, Me.Btn9_11, Me.Btn9_12)
    End Sub

    Private Sub Btn8_12_Click(sender As Object, e As EventArgs) Handles Btn8_12.Click
        Resumen(8, 12, Me.Btn8_12, Me.Btn7_11, Me.Btn7_12, Me.Btn7_13, Me.Btn8_11, Me.Btn8_13, Me.Btn9_11, Me.Btn9_12, Me.Btn9_13)
    End Sub

    Private Sub Btn8_13_Click(sender As Object, e As EventArgs) Handles Btn8_13.Click
        Resumen(8, 13, Me.Btn8_13, Me.Btn7_12, Me.Btn7_13, Me.Btn7_14, Me.Btn8_12, Me.Btn8_14, Me.Btn9_12, Me.Btn9_13, Me.Btn9_14)
    End Sub

    Private Sub Btn8_14_Click(sender As Object, e As EventArgs) Handles Btn8_14.Click
        Resumen(8, 14, Me.Btn8_14, Me.Btn7_13, Me.Btn7_14, Me.Btn7_15, Me.Btn8_13, Me.Btn8_15, Me.Btn9_13, Me.Btn9_14, Me.Btn9_15)
    End Sub

    Private Sub Btn8_15_Click(sender As Object, e As EventArgs) Handles Btn8_15.Click
        Resumen(8, 15, Me.Btn8_15, Me.Btn7_14, Me.Btn7_15, Me.Btn7_16, Me.Btn8_14, Me.Btn8_16, Me.Btn9_14, Me.Btn9_15, Me.Btn9_16)
    End Sub

    Private Sub Btn9_1_Click(sender As Object, e As EventArgs) Handles Btn9_1.Click
        Resumen(9, 1, Me.Btn9_1, Me.Btn8_0, Me.Btn8_1, Me.Btn8_2, Me.Btn9_0, Me.Btn9_2, Me.Btn10_0, Me.Btn10_1, Me.Btn10_2)
    End Sub

    Private Sub Btn9_2_Click(sender As Object, e As EventArgs) Handles Btn9_2.Click
        Resumen(9, 2, Me.Btn9_2, Me.Btn8_1, Me.Btn8_2, Me.Btn8_3, Me.Btn9_1, Me.Btn9_3, Me.Btn10_1, Me.Btn10_2, Me.Btn10_3)
    End Sub

    Private Sub Btn9_3_Click(sender As Object, e As EventArgs) Handles Btn9_3.Click
        Resumen(9, 3, Me.Btn9_3, Me.Btn8_2, Me.Btn8_3, Me.Btn8_4, Me.Btn9_2, Me.Btn9_4, Me.Btn10_2, Me.Btn10_3, Me.Btn10_4)
    End Sub

    Private Sub Btn9_4_Click(sender As Object, e As EventArgs) Handles Btn9_4.Click
        Resumen(9, 4, Me.Btn9_4, Me.Btn8_3, Me.Btn8_4, Me.Btn8_5, Me.Btn9_3, Me.Btn9_5, Me.Btn10_3, Me.Btn10_4, Me.Btn10_5)
    End Sub

    Private Sub Btn9_5_Click(sender As Object, e As EventArgs) Handles Btn9_5.Click
        Resumen(9, 5, Me.Btn9_5, Me.Btn8_4, Me.Btn8_5, Me.Btn8_6, Me.Btn9_4, Me.Btn9_6, Me.Btn10_4, Me.Btn10_5, Me.Btn10_6)
    End Sub

    Private Sub Btn9_6_Click(sender As Object, e As EventArgs) Handles Btn9_6.Click
        Resumen(9, 6, Me.Btn9_6, Me.Btn8_5, Me.Btn8_6, Me.Btn8_7, Me.Btn9_5, Me.Btn9_7, Me.Btn10_5, Me.Btn10_6, Me.Btn10_7)
    End Sub

    Private Sub Btn9_7_Click(sender As Object, e As EventArgs) Handles Btn9_7.Click
        Resumen(9, 7, Me.Btn9_7, Me.Btn8_6, Me.Btn8_7, Me.Btn8_8, Me.Btn9_6, Me.Btn9_8, Me.Btn10_6, Me.Btn10_7, Me.Btn10_8)
    End Sub

    Private Sub Btn9_8_Click(sender As Object, e As EventArgs) Handles Btn9_8.Click
        Resumen(9, 8, Me.Btn9_8, Me.Btn8_7, Me.Btn8_8, Me.Btn8_9, Me.Btn9_7, Me.Btn9_9, Me.Btn10_7, Me.Btn10_8, Me.Btn10_9)
    End Sub

    Private Sub Btn9_9_Click(sender As Object, e As EventArgs) Handles Btn9_9.Click
        Resumen(9, 9, Me.Btn9_9, Me.Btn8_8, Me.Btn8_9, Me.Btn8_10, Me.Btn9_8, Me.Btn9_10, Me.Btn10_8, Me.Btn10_9, Me.Btn10_10)
    End Sub

    Private Sub Btn9_10_Click(sender As Object, e As EventArgs) Handles Btn9_10.Click
        Resumen(9, 10, Me.Btn9_10, Me.Btn8_9, Me.Btn8_10, Me.Btn8_11, Me.Btn9_9, Me.Btn9_11, Me.Btn10_9, Me.Btn10_10, Me.Btn10_11)
    End Sub

    Private Sub Btn9_11_Click(sender As Object, e As EventArgs) Handles Btn9_11.Click
        Resumen(9, 11, Me.Btn9_11, Me.Btn8_10, Me.Btn8_11, Me.Btn8_12, Me.Btn9_10, Me.Btn9_12, Me.Btn10_10, Me.Btn10_11, Me.Btn10_12)
    End Sub

    Private Sub Btn9_12_Click(sender As Object, e As EventArgs) Handles Btn9_12.Click
        Resumen(9, 12, Me.Btn9_12, Me.Btn8_11, Me.Btn8_12, Me.Btn8_13, Me.Btn9_11, Me.Btn9_13, Me.Btn10_11, Me.Btn10_12, Me.Btn10_13)
    End Sub

    Private Sub Btn9_13_Click(sender As Object, e As EventArgs) Handles Btn9_13.Click
        Resumen(9, 13, Me.Btn9_13, Me.Btn8_12, Me.Btn8_13, Me.Btn8_14, Me.Btn9_12, Me.Btn9_14, Me.Btn10_12, Me.Btn10_13, Me.Btn10_14)
    End Sub

    Private Sub Btn9_14_Click(sender As Object, e As EventArgs) Handles Btn9_14.Click
        Resumen(9, 14, Me.Btn9_14, Me.Btn8_13, Me.Btn8_14, Me.Btn8_15, Me.Btn9_13, Me.Btn9_15, Me.Btn10_13, Me.Btn10_14, Me.Btn10_15)
    End Sub

    Private Sub Btn9_15_Click(sender As Object, e As EventArgs) Handles Btn9_15.Click
        Resumen(9, 15, Me.Btn9_15, Me.Btn8_14, Me.Btn8_15, Me.Btn8_16, Me.Btn9_14, Me.Btn9_16, Me.Btn10_14, Me.Btn10_15, Me.Btn10_16)
    End Sub

    Private Sub Btn10_1_Click(sender As Object, e As EventArgs) Handles Btn10_1.Click
        Resumen(10, 1, Me.Btn10_1, Me.Btn9_0, Me.Btn9_1, Me.Btn9_2, Me.Btn10_0, Me.Btn10_2, Me.Btn11_0, Me.Btn11_1, Me.Btn11_2)
    End Sub

    Private Sub Btn10_2_Click(sender As Object, e As EventArgs) Handles Btn10_2.Click
        Resumen(10, 2, Me.Btn10_2, Me.Btn9_1, Me.Btn9_2, Me.Btn9_3, Me.Btn10_1, Me.Btn10_3, Me.Btn11_1, Me.Btn11_2, Me.Btn11_3)
    End Sub

    Private Sub Btn10_3_Click(sender As Object, e As EventArgs) Handles Btn10_3.Click
        Resumen(10, 3, Me.Btn10_3, Me.Btn9_2, Me.Btn9_3, Me.Btn9_4, Me.Btn10_2, Me.Btn10_4, Me.Btn11_2, Me.Btn11_3, Me.Btn11_4)
    End Sub

    Private Sub Btn10_4_Click(sender As Object, e As EventArgs) Handles Btn10_4.Click
        Resumen(10, 4, Me.Btn10_4, Me.Btn9_3, Me.Btn9_4, Me.Btn9_5, Me.Btn10_3, Me.Btn10_5, Me.Btn11_3, Me.Btn11_4, Me.Btn11_5)
    End Sub

    Private Sub Btn10_5_Click(sender As Object, e As EventArgs) Handles Btn10_5.Click
        Resumen(10, 5, Me.Btn10_5, Me.Btn9_4, Me.Btn9_5, Me.Btn9_6, Me.Btn10_4, Me.Btn10_6, Me.Btn11_4, Me.Btn11_5, Me.Btn11_6)
    End Sub

    Private Sub Btn10_6_Click(sender As Object, e As EventArgs) Handles Btn10_6.Click
        Resumen(10, 6, Me.Btn10_6, Me.Btn9_5, Me.Btn9_6, Me.Btn9_7, Me.Btn10_5, Me.Btn10_7, Me.Btn11_5, Me.Btn11_6, Me.Btn11_7)
    End Sub

    Private Sub Btn10_7_Click(sender As Object, e As EventArgs) Handles Btn10_7.Click
        Resumen(10, 7, Me.Btn10_7, Me.Btn9_6, Me.Btn9_7, Me.Btn9_8, Me.Btn10_6, Me.Btn10_8, Me.Btn11_6, Me.Btn11_7, Me.Btn11_8)
    End Sub

    Private Sub Btn10_8_Click(sender As Object, e As EventArgs) Handles Btn10_8.Click
        Resumen(10, 8, Me.Btn10_8, Me.Btn9_7, Me.Btn9_8, Me.Btn9_9, Me.Btn10_7, Me.Btn10_9, Me.Btn11_7, Me.Btn11_8, Me.Btn11_9)
    End Sub

    Private Sub Btn10_9_Click(sender As Object, e As EventArgs) Handles Btn10_9.Click
        Resumen(10, 9, Me.Btn10_9, Me.Btn9_8, Me.Btn9_9, Me.Btn9_10, Me.Btn10_8, Me.Btn10_10, Me.Btn11_8, Me.Btn11_9, Me.Btn11_10)
    End Sub

    Private Sub Btn10_10_Click(sender As Object, e As EventArgs) Handles Btn10_10.Click
        Resumen(10, 10, Me.Btn10_10, Me.Btn9_9, Me.Btn9_10, Me.Btn9_11, Me.Btn10_9, Me.Btn10_11, Me.Btn11_9, Me.Btn11_10, Me.Btn11_11)
    End Sub


    Private Sub Btn10_11_Click(sender As Object, e As EventArgs) Handles Btn10_11.Click
        Resumen(10, 11, Me.Btn10_11, Me.Btn9_10, Me.Btn9_11, Me.Btn9_12, Me.Btn10_10, Me.Btn10_12, Me.Btn11_10, Me.Btn11_11, Me.Btn11_12)
    End Sub

    Private Sub Btn10_12_Click(sender As Object, e As EventArgs) Handles Btn10_12.Click
        Resumen(10, 12, Me.Btn10_12, Me.Btn9_11, Me.Btn9_12, Me.Btn9_13, Me.Btn10_11, Me.Btn10_13, Me.Btn11_11, Me.Btn11_12, Me.Btn11_13)
    End Sub

    Private Sub Btn10_13_Click(sender As Object, e As EventArgs) Handles Btn10_13.Click
        Resumen(10, 13, Me.Btn10_13, Me.Btn9_12, Me.Btn9_13, Me.Btn9_14, Me.Btn10_12, Me.Btn10_14, Me.Btn11_12, Me.Btn11_13, Me.Btn11_14)
    End Sub

    Private Sub Btn10_14_Click(sender As Object, e As EventArgs) Handles Btn10_14.Click
        Resumen(10, 14, Me.Btn10_14, Me.Btn9_13, Me.Btn9_14, Me.Btn9_15, Me.Btn10_13, Me.Btn10_15, Me.Btn11_13, Me.Btn11_14, Me.Btn11_15)
    End Sub

    Private Sub Btn10_15_Click(sender As Object, e As EventArgs) Handles Btn10_15.Click
        Resumen(10, 15, Me.Btn10_15, Me.Btn9_14, Me.Btn9_15, Me.Btn9_16, Me.Btn10_14, Me.Btn10_16, Me.Btn11_14, Me.Btn11_15, Me.Btn11_16)
    End Sub

    Private Sub Btn11_1_Click(sender As Object, e As EventArgs) Handles Btn11_1.Click
        Resumen(11, 1, Me.Btn11_1, Me.Btn10_0, Me.Btn10_1, Me.Btn10_2, Me.Btn11_0, Me.Btn11_2, Me.Btn12_0, Me.Btn12_1, Me.Btn12_2)
    End Sub

    Private Sub Btn11_2_Click(sender As Object, e As EventArgs) Handles Btn11_2.Click
        Resumen(11, 2, Me.Btn11_2, Me.Btn10_1, Me.Btn10_2, Me.Btn10_3, Me.Btn11_1, Me.Btn11_3, Me.Btn12_1, Me.Btn12_2, Me.Btn12_3)
    End Sub

    Private Sub Btn11_3_Click(sender As Object, e As EventArgs) Handles Btn11_3.Click
        Resumen(11, 3, Me.Btn11_3, Me.Btn10_2, Me.Btn10_3, Me.Btn10_4, Me.Btn11_2, Me.Btn11_4, Me.Btn12_2, Me.Btn12_3, Me.Btn12_4)
    End Sub

    Private Sub Btn11_4_Click(sender As Object, e As EventArgs) Handles Btn11_4.Click
        Resumen(11, 4, Me.Btn11_4, Me.Btn10_3, Me.Btn10_4, Me.Btn10_5, Me.Btn11_3, Me.Btn11_5, Me.Btn12_3, Me.Btn12_4, Me.Btn12_5)
    End Sub

    Private Sub Btn11_5_Click(sender As Object, e As EventArgs) Handles Btn11_5.Click
        Resumen(11, 5, Me.Btn11_5, Me.Btn10_4, Me.Btn10_5, Me.Btn10_6, Me.Btn11_4, Me.Btn11_6, Me.Btn12_4, Me.Btn12_5, Me.Btn12_6)
    End Sub

    Private Sub Btn11_6_Click(sender As Object, e As EventArgs) Handles Btn11_6.Click
        Resumen(11, 6, Me.Btn11_6, Me.Btn10_5, Me.Btn10_6, Me.Btn10_7, Me.Btn11_5, Me.Btn11_7, Me.Btn12_5, Me.Btn12_6, Me.Btn12_7)
    End Sub

    Private Sub Btn11_7_Click(sender As Object, e As EventArgs) Handles Btn11_7.Click
        Resumen(11, 7, Me.Btn11_7, Me.Btn10_6, Me.Btn10_7, Me.Btn10_8, Me.Btn11_6, Me.Btn11_7, Me.Btn12_6, Me.Btn12_7, Me.Btn12_8)
    End Sub

    Private Sub Btn11_8_Click(sender As Object, e As EventArgs) Handles Btn11_8.Click
        Resumen(11, 8, Me.Btn11_8, Me.Btn10_7, Me.Btn10_8, Me.Btn10_9, Me.Btn11_7, Me.Btn11_9, Me.Btn12_7, Me.Btn12_8, Me.Btn12_9)
    End Sub

    Private Sub Btn11_9_Click(sender As Object, e As EventArgs) Handles Btn11_9.Click
        Resumen(11, 9, Me.Btn11_9, Me.Btn10_8, Me.Btn10_9, Me.Btn10_10, Me.Btn11_8, Me.Btn11_10, Me.Btn12_8, Me.Btn12_9, Me.Btn12_10)
    End Sub

    Private Sub Btn11_10_Click(sender As Object, e As EventArgs) Handles Btn11_10.Click
        Resumen(11, 10, Me.Btn11_10, Me.Btn10_9, Me.Btn10_10, Me.Btn10_11, Me.Btn11_9, Me.Btn11_11, Me.Btn12_9, Me.Btn12_10, Me.Btn12_11)
    End Sub

    Private Sub Btn11_11_Click(sender As Object, e As EventArgs) Handles Btn11_11.Click
        Resumen(11, 11, Me.Btn11_11, Me.Btn10_10, Me.Btn10_11, Me.Btn10_12, Me.Btn11_10, Me.Btn11_12, Me.Btn12_10, Me.Btn12_11, Me.Btn12_12)
    End Sub

    Private Sub Btn11_12_Click(sender As Object, e As EventArgs) Handles Btn11_12.Click
        Resumen(11, 12, Me.Btn11_12, Me.Btn10_11, Me.Btn10_12, Me.Btn10_13, Me.Btn11_11, Me.Btn11_13, Me.Btn12_11, Me.Btn12_12, Me.Btn12_13)
    End Sub

    Private Sub Btn11_13_Click(sender As Object, e As EventArgs) Handles Btn11_13.Click
        Resumen(11, 13, Me.Btn11_13, Me.Btn10_12, Me.Btn10_13, Me.Btn10_14, Me.Btn11_12, Me.Btn11_14, Me.Btn12_12, Me.Btn12_13, Me.Btn12_14)
    End Sub

    Private Sub Btn11_14_Click(sender As Object, e As EventArgs) Handles Btn11_14.Click
        Resumen(11, 14, Me.Btn11_14, Me.Btn10_13, Me.Btn10_14, Me.Btn10_15, Me.Btn11_13, Me.Btn11_15, Me.Btn12_13, Me.Btn12_14, Me.Btn12_15)
    End Sub

    Private Sub Btn11_15_Click(sender As Object, e As EventArgs) Handles Btn11_15.Click
        Resumen(11, 15, Me.Btn11_15, Me.Btn10_14, Me.Btn10_15, Me.Btn10_16, Me.Btn11_14, Me.Btn11_16, Me.Btn12_14, Me.Btn12_15, Me.Btn12_16)
    End Sub

    Private Sub Btn12_1_Click(sender As Object, e As EventArgs) Handles Btn12_1.Click
        Resumen(12, 1, Me.Btn12_1, Me.Btn11_0, Me.Btn11_1, Me.Btn11_2, Me.Btn12_0, Me.Btn12_2, Me.Btn13_0, Me.Btn13_1, Me.Btn13_2)
    End Sub

    Private Sub Btn12_2_Click(sender As Object, e As EventArgs) Handles Btn12_2.Click
        Resumen(12, 2, Me.Btn12_2, Me.Btn11_1, Me.Btn11_2, Me.Btn11_3, Me.Btn12_1, Me.Btn12_3, Me.Btn13_1, Me.Btn13_2, Me.Btn13_3)
    End Sub

    Private Sub Btn12_3_Click(sender As Object, e As EventArgs) Handles Btn12_3.Click
        Resumen(12, 3, Me.Btn12_3, Me.Btn11_2, Me.Btn11_3, Me.Btn11_4, Me.Btn12_2, Me.Btn12_4, Me.Btn13_2, Me.Btn13_3, Me.Btn13_4)
    End Sub

    Private Sub Btn12_4_Click(sender As Object, e As EventArgs) Handles Btn12_4.Click
        Resumen(12, 4, Me.Btn12_4, Me.Btn11_3, Me.Btn11_4, Me.Btn11_5, Me.Btn12_3, Me.Btn12_5, Me.Btn13_3, Me.Btn13_4, Me.Btn13_5)
    End Sub

    Private Sub Btn12_5_Click(sender As Object, e As EventArgs) Handles Btn12_5.Click
        Resumen(12, 5, Me.Btn12_5, Me.Btn11_4, Me.Btn11_5, Me.Btn11_6, Me.Btn12_4, Me.Btn12_6, Me.Btn13_4, Me.Btn13_5, Me.Btn13_6)
    End Sub

    Private Sub Btn12_6_Click(sender As Object, e As EventArgs) Handles Btn12_6.Click
        Resumen(12, 6, Me.Btn12_6, Me.Btn11_5, Me.Btn11_6, Me.Btn11_7, Me.Btn12_5, Me.Btn12_7, Me.Btn13_5, Me.Btn13_6, Me.Btn13_7)
    End Sub

    Private Sub Btn12_7_Click(sender As Object, e As EventArgs) Handles Btn12_7.Click
        Resumen(12, 7, Me.Btn12_7, Me.Btn11_6, Me.Btn11_7, Me.Btn11_8, Me.Btn12_6, Me.Btn12_8, Me.Btn13_6, Me.Btn13_7, Me.Btn13_8)
    End Sub

    Private Sub Btn12_8_Click(sender As Object, e As EventArgs) Handles Btn12_8.Click
        Resumen(12, 8, Me.Btn12_8, Me.Btn11_7, Me.Btn11_8, Me.Btn11_9, Me.Btn12_7, Me.Btn12_9, Me.Btn13_7, Me.Btn13_8, Me.Btn13_9)
    End Sub

    Private Sub Btn12_9_Click(sender As Object, e As EventArgs) Handles Btn12_9.Click
        Resumen(12, 9, Me.Btn12_9, Me.Btn11_8, Me.Btn11_9, Me.Btn11_10, Me.Btn12_8, Me.Btn12_10, Me.Btn13_8, Me.Btn13_9, Me.Btn13_10)
    End Sub

    Private Sub Btn12_10_Click(sender As Object, e As EventArgs) Handles Btn12_10.Click
        Resumen(12, 10, Me.Btn12_10, Me.Btn11_9, Me.Btn11_10, Me.Btn11_11, Me.Btn12_9, Me.Btn12_11, Me.Btn13_9, Me.Btn13_10, Me.Btn13_11)
    End Sub

    Private Sub Btn12_11_Click(sender As Object, e As EventArgs) Handles Btn12_11.Click
        Resumen(12, 11, Me.Btn12_11, Me.Btn11_10, Me.Btn11_11, Me.Btn11_12, Me.Btn12_10, Me.Btn12_12, Me.Btn13_10, Me.Btn13_11, Me.Btn13_12)
    End Sub

    Private Sub Btn12_12_Click(sender As Object, e As EventArgs) Handles Btn12_12.Click
        Resumen(12, 12, Me.Btn12_12, Me.Btn11_11, Me.Btn11_12, Me.Btn11_13, Me.Btn12_11, Me.Btn12_13, Me.Btn13_11, Me.Btn13_12, Me.Btn13_13)
    End Sub

    Private Sub Btn12_13_Click(sender As Object, e As EventArgs) Handles Btn12_13.Click
        Resumen(12, 13, Me.Btn12_13, Me.Btn11_12, Me.Btn11_13, Me.Btn11_14, Me.Btn12_12, Me.Btn12_14, Me.Btn13_12, Me.Btn13_13, Me.Btn13_14)
    End Sub

    Private Sub Btn12_14_Click(sender As Object, e As EventArgs) Handles Btn12_14.Click
        Resumen(12, 14, Me.Btn12_14, Me.Btn11_13, Me.Btn11_14, Me.Btn11_14, Me.Btn12_13, Me.Btn12_15, Me.Btn13_13, Me.Btn13_14, Me.Btn13_15)
    End Sub

    Private Sub Btn12_15_Click(sender As Object, e As EventArgs) Handles Btn12_15.Click
        Resumen(12, 15, Me.Btn12_15, Me.Btn11_14, Me.Btn11_15, Me.Btn11_16, Me.Btn12_14, Me.Btn12_16, Me.Btn13_14, Me.Btn13_15, Me.Btn13_16)
    End Sub

    Private Sub Btn13_1_Click(sender As Object, e As EventArgs) Handles Btn13_1.Click
        Resumen(13, 1, Me.Btn13_1, Me.Btn12_0, Me.Btn12_1, Me.Btn12_2, Me.Btn13_0, Me.Btn13_2, Me.Btn14_0, Me.Btn14_1, Me.Btn14_0)
    End Sub

    Private Sub Btn13_2_Click(sender As Object, e As EventArgs) Handles Btn13_2.Click
        Resumen(13, 2, Me.Btn13_2, Me.Btn12_1, Me.Btn12_2, Me.Btn12_3, Me.Btn13_1, Me.Btn13_3, Me.Btn14_1, Me.Btn14_2, Me.Btn14_3)
    End Sub

    Private Sub Btn13_3_Click(sender As Object, e As EventArgs) Handles Btn13_3.Click
        Resumen(13, 3, Me.Btn13_3, Me.Btn12_2, Me.Btn12_3, Me.Btn12_4, Me.Btn13_2, Me.Btn13_4, Me.Btn14_2, Me.Btn14_3, Me.Btn14_4)
    End Sub

    Private Sub Btn13_4_Click(sender As Object, e As EventArgs) Handles Btn13_4.Click
        Resumen(13, 4, Me.Btn13_4, Me.Btn12_3, Me.Btn12_4, Me.Btn12_5, Me.Btn13_3, Me.Btn13_5, Me.Btn14_3, Me.Btn14_4, Me.Btn14_5)
    End Sub

    Private Sub Btn13_5_Click(sender As Object, e As EventArgs) Handles Btn13_5.Click
        Resumen(13, 5, Me.Btn13_5, Me.Btn12_4, Me.Btn12_5, Me.Btn12_6, Me.Btn13_4, Me.Btn13_6, Me.Btn14_4, Me.Btn14_5, Me.Btn14_6)
    End Sub

    Private Sub Btn13_6_Click(sender As Object, e As EventArgs) Handles Btn13_6.Click
        Resumen(13, 6, Me.Btn13_6, Me.Btn12_5, Me.Btn12_6, Me.Btn12_7, Me.Btn13_5, Me.Btn13_7, Me.Btn14_6, Me.Btn14_7, Me.Btn14_8)
    End Sub

    Private Sub Btn13_7_Click(sender As Object, e As EventArgs) Handles Btn13_7.Click
        Resumen(13, 7, Me.Btn13_7, Me.Btn12_6, Me.Btn12_7, Me.Btn12_8, Me.Btn13_6, Me.Btn13_8, Me.Btn14_6, Me.Btn14_7, Me.Btn14_8)
    End Sub

    Private Sub Btn13_8_Click(sender As Object, e As EventArgs) Handles Btn13_8.Click
        Resumen(13, 8, Me.Btn13_8, Me.Btn12_7, Me.Btn12_8, Me.Btn12_9, Me.Btn13_7, Me.Btn13_9, Me.Btn14_7, Me.Btn14_8, Me.Btn14_9)
    End Sub

    Private Sub Btn13_9_Click(sender As Object, e As EventArgs) Handles Btn13_9.Click
        Resumen(13, 9, Me.Btn13_9, Me.Btn12_8, Me.Btn12_9, Me.Btn12_10, Me.Btn13_7, Me.Btn13_9, Me.Btn14_7, Me.Btn14_8, Me.Btn14_9)
    End Sub

    Private Sub Btn13_10_Click(sender As Object, e As EventArgs) Handles Btn13_10.Click
        Resumen(13, 10, Me.Btn13_10, Me.Btn12_9, Me.Btn12_10, Me.Btn12_11, Me.Btn13_9, Me.Btn13_11, Me.Btn14_9, Me.Btn14_10, Me.Btn14_11)
    End Sub

    Private Sub Btn13_11_Click(sender As Object, e As EventArgs) Handles Btn13_11.Click
        Resumen(13, 11, Me.Btn13_11, Me.Btn12_10, Me.Btn12_11, Me.Btn12_12, Me.Btn13_10, Me.Btn13_12, Me.Btn14_10, Me.Btn14_11, Me.Btn14_12)
    End Sub

    Private Sub Btn13_12_Click(sender As Object, e As EventArgs) Handles Btn13_12.Click
        Resumen(13, 12, Me.Btn13_12, Me.Btn12_11, Me.Btn12_12, Me.Btn12_13, Me.Btn13_11, Me.Btn13_13, Me.Btn14_11, Me.Btn14_12, Me.Btn14_13)
    End Sub

    Private Sub Btn13_13_Click(sender As Object, e As EventArgs) Handles Btn13_13.Click
        Resumen(13, 13, Me.Btn13_13, Me.Btn12_12, Me.Btn12_13, Me.Btn12_14, Me.Btn13_12, Me.Btn13_14, Me.Btn14_12, Me.Btn14_13, Me.Btn14_14)
    End Sub

    Private Sub Btn13_14_Click(sender As Object, e As EventArgs) Handles Btn13_14.Click
        Resumen(13, 14, Me.Btn13_14, Me.Btn12_13, Me.Btn12_14, Me.Btn12_15, Me.Btn13_13, Me.Btn13_15, Me.Btn14_13, Me.Btn14_14, Me.Btn14_15)
    End Sub

    Private Sub Btn13_15_Click(sender As Object, e As EventArgs) Handles Btn13_15.Click
        Resumen(13, 15, Me.Btn13_15, Me.Btn12_14, Me.Btn12_15, Me.Btn12_16, Me.Btn13_14, Me.Btn13_16, Me.Btn14_14, Me.Btn14_15, Me.Btn14_16)
    End Sub

    Private Sub Btn14_1_Click(sender As Object, e As EventArgs) Handles Btn14_1.Click
        Resumen(14, 1, Me.Btn14_1, Me.Btn13_0, Me.Btn13_1, Me.Btn13_2, Me.Btn14_0, Me.Btn14_2, Me.Btn15_0, Me.Btn15_1, Me.Btn15_2)
    End Sub

    Private Sub Btn14_2_Click(sender As Object, e As EventArgs) Handles Btn14_2.Click
        Resumen(14, 2, Me.Btn14_2, Me.Btn13_1, Me.Btn13_2, Me.Btn13_3, Me.Btn14_1, Me.Btn14_3, Me.Btn15_1, Me.Btn15_2, Me.Btn15_3)
    End Sub

    Private Sub Btn14_3_Click(sender As Object, e As EventArgs) Handles Btn14_3.Click
        Resumen(14, 3, Me.Btn14_3, Me.Btn13_2, Me.Btn13_3, Me.Btn13_4, Me.Btn14_2, Me.Btn14_4, Me.Btn15_2, Me.Btn15_3, Me.Btn15_4)
    End Sub

    Private Sub Btn14_4_Click(sender As Object, e As EventArgs) Handles Btn14_4.Click
        Resumen(14, 4, Me.Btn14_4, Me.Btn13_3, Me.Btn13_4, Me.Btn13_5, Me.Btn14_3, Me.Btn14_5, Me.Btn15_3, Me.Btn15_4, Me.Btn15_5)
    End Sub

    Private Sub Btn14_5_Click(sender As Object, e As EventArgs) Handles Btn14_5.Click
        Resumen(14, 5, Me.Btn14_5, Me.Btn13_4, Me.Btn13_5, Me.Btn13_6, Me.Btn14_4, Me.Btn14_6, Me.Btn15_4, Me.Btn15_5, Me.Btn15_6)
    End Sub

    Private Sub Btn14_6_Click(sender As Object, e As EventArgs) Handles Btn14_6.Click
        Resumen(14, 6, Me.Btn14_6, Me.Btn13_5, Me.Btn13_6, Me.Btn13_7, Me.Btn14_5, Me.Btn14_7, Me.Btn15_5, Me.Btn15_6, Me.Btn15_7)
    End Sub

    Private Sub Btn14_7_Click(sender As Object, e As EventArgs) Handles Btn14_7.Click
        Resumen(14, 7, Me.Btn14_7, Me.Btn13_6, Me.Btn13_7, Me.Btn13_8, Me.Btn14_6, Me.Btn14_8, Me.Btn15_6, Me.Btn15_7, Me.Btn15_8)
    End Sub

    Private Sub Btn14_8_Click(sender As Object, e As EventArgs) Handles Btn14_8.Click
        Resumen(14, 8, Me.Btn14_8, Me.Btn13_7, Me.Btn13_8, Me.Btn13_9, Me.Btn14_7, Me.Btn14_9, Me.Btn15_7, Me.Btn15_8, Me.Btn15_9)
    End Sub

    Private Sub Btn14_9_Click(sender As Object, e As EventArgs) Handles Btn14_9.Click
        Resumen(14, 9, Me.Btn14_9, Me.Btn13_8, Me.Btn13_9, Me.Btn13_10, Me.Btn14_8, Me.Btn14_10, Me.Btn15_8, Me.Btn15_9, Me.Btn15_10)
    End Sub

    Private Sub Btn14_10_Click(sender As Object, e As EventArgs) Handles Btn14_10.Click
        Resumen(14, 10, Me.Btn14_10, Me.Btn13_9, Me.Btn13_10, Me.Btn13_11, Me.Btn14_9, Me.Btn14_11, Me.Btn15_9, Me.Btn15_10, Me.Btn15_11)
    End Sub

    Private Sub Btn14_11_Click(sender As Object, e As EventArgs) Handles Btn14_11.Click
        Resumen(14, 11, Me.Btn14_11, Me.Btn13_10, Me.Btn13_11, Me.Btn13_12, Me.Btn14_10, Me.Btn14_12, Me.Btn15_10, Me.Btn15_11, Me.Btn15_12)
    End Sub

    Private Sub Btn14_12_Click(sender As Object, e As EventArgs) Handles Btn14_12.Click
        Resumen(14, 12, Me.Btn14_12, Me.Btn13_11, Me.Btn13_12, Me.Btn13_13, Me.Btn14_11, Me.Btn14_13, Me.Btn15_11, Me.Btn15_12, Me.Btn15_13)
    End Sub

    Private Sub Btn14_13_Click(sender As Object, e As EventArgs) Handles Btn14_13.Click
        Resumen(14, 13, Me.Btn14_13, Me.Btn13_12, Me.Btn13_13, Me.Btn13_14, Me.Btn14_12, Me.Btn14_14, Me.Btn15_12, Me.Btn15_13, Me.Btn15_14)
    End Sub

    Private Sub Btn14_14_Click(sender As Object, e As EventArgs) Handles Btn14_14.Click
        Resumen(14, 14, Me.Btn14_14, Me.Btn13_13, Me.Btn13_14, Me.Btn13_15, Me.Btn14_13, Me.Btn14_15, Me.Btn15_13, Me.Btn15_14, Me.Btn15_15)
    End Sub

    Private Sub Btn14_15_Click(sender As Object, e As EventArgs) Handles Btn14_15.Click
        Resumen(14, 15, Me.Btn14_15, Me.Btn13_14, Me.Btn13_15, Me.Btn13_16, Me.Btn14_14, Me.Btn14_16, Me.Btn15_14, Me.Btn15_15, Me.Btn15_16)
    End Sub

    Private Sub Btn15_1_Click(sender As Object, e As EventArgs) Handles Btn15_1.Click
        Resumen(15, 1, Me.Btn15_1, Me.Btn14_0, Me.Btn14_1, Me.Btn14_2, Me.Btn15_0, Me.Btn15_2, Me.Btn16_0, Me.Btn16_1, Me.Btn16_2)
    End Sub

    Private Sub Btn15_2_Click(sender As Object, e As EventArgs) Handles Btn15_2.Click
        Resumen(15, 2, Me.Btn15_2, Me.Btn14_1, Me.Btn14_2, Me.Btn14_3, Me.Btn15_1, Me.Btn15_3, Me.Btn16_1, Me.Btn16_2, Me.Btn16_3)
    End Sub

    Private Sub Btn15_3_Click(sender As Object, e As EventArgs) Handles Btn15_3.Click
        Resumen(15, 3, Me.Btn15_3, Me.Btn14_2, Me.Btn14_3, Me.Btn14_4, Me.Btn15_2, Me.Btn15_4, Me.Btn16_2, Me.Btn16_3, Me.Btn16_4)
    End Sub

    Private Sub Btn15_4_Click(sender As Object, e As EventArgs) Handles Btn15_4.Click
        Resumen(15, 4, Me.Btn15_4, Me.Btn14_3, Me.Btn14_4, Me.Btn14_5, Me.Btn15_3, Me.Btn15_5, Me.Btn16_3, Me.Btn16_4, Me.Btn16_5)
    End Sub
    Private Sub Btn15_5_Click(sender As Object, e As EventArgs) Handles Btn15_5.Click
        Resumen(15, 5, Me.Btn15_5, Me.Btn14_4, Me.Btn14_5, Me.Btn14_6, Me.Btn15_4, Me.Btn15_6, Me.Btn16_4, Me.Btn16_5, Me.Btn16_6)
    End Sub

    Private Sub Btn15_6_Click(sender As Object, e As EventArgs) Handles Btn15_6.Click
        Resumen(15, 6, Me.Btn15_6, Me.Btn14_5, Me.Btn14_6, Me.Btn14_7, Me.Btn15_5, Me.Btn15_7, Me.Btn16_5, Me.Btn16_6, Me.Btn16_7)
    End Sub

    Private Sub Btn15_7_Click(sender As Object, e As EventArgs) Handles Btn15_7.Click
        Resumen(15, 7, Me.Btn15_7, Me.Btn14_6, Me.Btn14_7, Me.Btn14_8, Me.Btn15_6, Me.Btn15_8, Me.Btn16_6, Me.Btn16_7, Me.Btn16_8)
    End Sub

    Private Sub Btn15_8_Click(sender As Object, e As EventArgs) Handles Btn15_8.Click
        Resumen(15, 8, Me.Btn15_8, Me.Btn14_7, Me.Btn14_8, Me.Btn14_9, Me.Btn15_7, Me.Btn15_9, Me.Btn16_7, Me.Btn16_8, Me.Btn16_9)
    End Sub

    Private Sub Btn15_9_Click(sender As Object, e As EventArgs) Handles Btn15_9.Click
        Resumen(15, 9, Me.Btn15_9, Me.Btn14_8, Me.Btn14_9, Me.Btn14_10, Me.Btn15_8, Me.Btn15_10, Me.Btn16_8, Me.Btn16_9, Me.Btn16_10)
    End Sub

    Private Sub Btn15_10_Click(sender As Object, e As EventArgs) Handles Btn15_10.Click
        Resumen(15, 10, Me.Btn15_10, Me.Btn14_9, Me.Btn14_10, Me.Btn14_11, Me.Btn15_9, Me.Btn15_11, Me.Btn16_9, Me.Btn16_10, Me.Btn16_11)
    End Sub

    Private Sub Btn15_11_Click(sender As Object, e As EventArgs) Handles Btn15_11.Click
        Resumen(15, 11, Me.Btn15_11, Me.Btn14_10, Me.Btn14_11, Me.Btn14_12, Me.Btn15_10, Me.Btn15_12, Me.Btn16_10, Me.Btn16_11, Me.Btn16_12)
    End Sub

    Private Sub Btn15_12_Click(sender As Object, e As EventArgs) Handles Btn15_12.Click
        Resumen(15, 12, Me.Btn15_12, Me.Btn14_11, Me.Btn14_12, Me.Btn14_13, Me.Btn15_11, Me.Btn15_13, Me.Btn16_11, Me.Btn16_12, Me.Btn16_13)
    End Sub

    Private Sub Btn15_13_Click(sender As Object, e As EventArgs) Handles Btn15_13.Click
        Resumen(15, 13, Me.Btn15_13, Me.Btn14_12, Me.Btn14_13, Me.Btn14_14, Me.Btn15_12, Me.Btn15_14, Me.Btn16_12, Me.Btn16_13, Me.Btn16_14)
    End Sub

    Private Sub Btn15_14_Click(sender As Object, e As EventArgs) Handles Btn15_14.Click
        Resumen(15, 14, Me.Btn15_14, Me.Btn14_13, Me.Btn14_14, Me.Btn14_15, Me.Btn15_13, Me.Btn15_15, Me.Btn16_13, Me.Btn16_14, Me.Btn16_15)
    End Sub

    Private Sub Btn15_15_Click(sender As Object, e As EventArgs) Handles Btn15_15.Click
        Resumen(15, 15, Me.Btn15_15, Me.Btn14_14, Me.Btn14_15, Me.Btn14_16, Me.Btn15_14, Me.Btn15_16, Me.Btn16_14, Me.Btn16_15, Me.Btn16_16)
    End Sub

End Class