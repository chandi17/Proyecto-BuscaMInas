Public Class NivelMedio
    Dim conexion As Conexion = New Conexion()
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub



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
                'MsgBox(X, MessageBoxButtons.OK)
                'MsgBox(Y, MessageBoxButtons.OK)
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
        'txtTiempo.Text = 1
        Gano += 1
        If Gano <> limiteDeBotones Then
            Select Case Ubicacion(X, Y)
                Case -1
                    'btn.Image = Image.FromFile("Ruta de los imagen")
                    'btn.BackgroundImage = My.Resources.icons8_naval_mine_5
                    TimerMedio.Stop()
                    MessageBox.Show("Juego Terminado", "Fin", MessageBoxButtons.OK)
                    NuevoJuego.Show()
                    My.Forms.NivelMedio.Close()


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
            TimerMedio.Stop()
            Dim avatar As String = ""
            Do While avatar = ""
                avatar = InputBox("Ingresa tu avatar: ", "Campo Obligatorio")
            Loop
            segundos = Int(Val(lblSegs.Text))
            minutos = Int(Val(lblMin.Text))
            puntos = (minutos * 360) + segundos
            Dim verificar As Boolean = Conexion.ValidarExiste(avatar)
            If verificar = False Then
                Conexion.insertarPuntos(puntos, avatar)
                Dim mensa As String = "Felicidades " & avatar & " tu tiempo es: " & minutos & " : " & segundos & " Segundos"
                MessageBox.Show(mensa, "Felicidades", MessageBoxButtons.OK)
                MenuPrincipal.Show()
                My.Forms.NivelFacil.Close()
                Exit Sub
            Else
                Conexion.ActualizarDatos(puntos, avatar)
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

        Filas = 11
        Columnas = 11
        Minas = 10
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

    Public Sub Resumen(X As Integer, Y As Integer, ByRef botones2_2 As Button, ByRef botones1_1 As Button, ByRef botones1_2 As Button, ByRef botones1_3 As Button, ByRef botones2_1 As Button, ByRef botones2_3 As Button, ByRef botones3_1 As Button, ByRef botones3_2 As Button, ByRef botones3_3 As Button)
        TimerMedio.Start()

        If clicks(X, Y) = False Then
            clicks(X, Y) = True
            GenerarMinas(X, Y)
            Ubicacion(X, Y) = EvaluarCasillas(X, Y)
            evaluar0(botones1_1, botones1_2, botones1_3, botones2_1, botones2_3, botones3_1, botones3_2, botones3_3, X, Y)
            SeleccionImagen(botones2_2, X, Y)

        End If
    End Sub

#Region "Botones"
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

    Private Sub Btn5_10_Click(sender As Object, e As EventArgs) Handles Btn5_9.Click
        Resumen(5, 10, Me.Btn5_10, Me.Btn4_9, Me.Btn4_10, Me.Btn4_11, Me.Btn5_9, Me.Btn5_11, Me.Btn6_9, Me.Btn6_10, Me.Btn6_11)
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

    Private Sub Btn7_7_Click(sender As Object, e As EventArgs) Handles Btn7_6.Click
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
#End Region



    Private Sub TimerMedio_Tick(sender As Object, e As EventArgs) Handles TimerMedio.Tick
        lblMiliSegs.Text += 1


        If lblMiliSegs.Text = 10 Then
            lblMiliSegs.Text = 0
            lblSegs.Text += 1
        End If

        If lblSegs.Text = 60 Then
            lblSegs.Text = 0
            lblMin.Text += 1
        End If

        If lblMin.Text = 60 Then
            lblMin.Text = 0
        End If
    End Sub

    Private Sub PanelSuperior_Paint(sender As Object, e As PaintEventArgs) Handles PanelSuperior.Paint

    End Sub
End Class