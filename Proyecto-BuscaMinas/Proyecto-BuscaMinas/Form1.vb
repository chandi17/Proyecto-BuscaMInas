Public Class Form1
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
    Public Sub GenerarMinas()
        'Evalua si es la primera vez que se generan las minas 
        If Estado = False Then
            'ASigna el tamaño de la matriz
            ReDim Ubicacion(Filas, Columnas)
            ' X = Filas, Y = Columnas
            Dim X, Y As Integer

            For i = 1 To Minas Step 1
                'Genera los numeros aleatorios
                X = Math.Ceiling(Rnd() * Filas)
                Y = Math.Ceiling(Rnd() * Columnas)
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

        Estado = True
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
#End Region
#Region "Juego"

    Private Sub Btn1_1_Click(sender As Object, e As EventArgs) Handles Btn1_1.Click
        'Declaracion de variable para almacenar el valor que retorna la funcion "EvaluarCasillas"
        If clicks(1, 1) = False Then
            Dim temporal As Integer

            GenerarMinas()
            temporal = EvaluarCasillas(1, 1)
            Btn1_1.Text = temporal
            Ubicacion(1, 1) = temporal
            'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
        End If
        clicks(1, 1) = True
    End Sub

    Private Sub Btn1_2_Click(sender As Object, e As EventArgs) Handles Btn1_2.Click

        If clicks(1, 2) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(1, 2)
            Btn1_2.Text = temporal
            Ubicacion(1, 2) = temporal
            'evaluar0(Me.Btn0_1, Me.Btn0_2, Me.Btn0_3, Me.Btn1_1, Me.Btn1_3, Me.Btn2_1, Me.Btn2_2, Me.Btn2_3, 1, 2)
        End If
        clicks(1, 2) = True
    End Sub

    Private Sub Btn1_3_Click(sender As Object, e As EventArgs) Handles Btn1_3.Click
        If clicks(1, 3) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(1, 3)
            Btn1_3.Text = temporal
            Ubicacion(1, 3) = temporal
            'evaluar0(Me.Btn0_2, Me.Btn0_3, Me.Btn0_3, Me.Btn1_2, Me.Btn1_4, Me.Btn2_2, Me.Btn2_3, Me.Btn2_4, 1, 3)
        End If
        clicks(1, 3) = True
    End Sub

    Private Sub Btn1_4_Click(sender As Object, e As EventArgs) Handles Btn1_4.Click
        If clicks(1, 4) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(1, 4)
            Btn1_4.Text = temporal
            Ubicacion(1, 4) = temporal
            evaluar0(Me.Btn0_3, Me.Btn0_4, Me.Btn0_5, Me.Btn1_3, Me.Btn1_5, Me.Btn2_3, Me.Btn2_4, Me.Btn2_5, 1, 4)
        End If
        clicks(1, 4) = True
    End Sub

    Private Sub Btn1_5_Click(sender As Object, e As EventArgs) Handles Btn1_5.Click
        If clicks(1, 5) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(1, 5)
            Btn1_5.Text = temporal
            Ubicacion(1, 5) = temporal
            evaluar0(Me.Btn0_4, Me.Btn0_5, Me.Btn0_6, Me.Btn1_4, Me.Btn1_6, Me.Btn2_4, Me.Btn2_5, Me.Btn2_6, 1, 5)
        End If
        clicks(1, 5) = True
    End Sub

    Private Sub Btn2_1_Click(sender As Object, e As EventArgs) Handles Btn2_1.Click
        If clicks(2, 1) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(2, 1)
            Btn2_1.Text = temporal
            Ubicacion(2, 1) = temporal
            'evaluar0(Me.Btn1_0, Me.Btn1_1, Me.Btn1_2, Me.Btn2_0, Me.Btn2_2, Me.Btn3_0, Me.Btn3_1, Me.Btn3_2, 2, 1)
        End If
        clicks(2, 1) = True
    End Sub

    Private Sub Btn2_2_Click(sender As Object, e As EventArgs) Handles Btn2_2.Click
        If clicks(2, 2) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(2, 2)
            Btn2_2.Text = temporal
            Ubicacion(2, 2) = temporal
            evaluar0(Me.Btn1_1, Me.Btn1_2, Me.Btn1_3, Me.Btn2_1, Me.Btn2_3, Me.Btn3_1, Me.Btn3_2, Me.Btn3_3, 2, 2)
        End If
        clicks(2, 2) = True
    End Sub

    Private Sub Btn2_3_Click(sender As Object, e As EventArgs) Handles Btn2_3.Click
        If clicks(2, 3) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(2, 3)
            Btn2_3.Text = temporal
            Ubicacion(2, 3) = temporal
            'evaluar0(Me.Btn1_2, Me.Btn1_3, Me.Btn1_4, Me.Btn2_2, Me.Btn2_4, Me.Btn3_2, Me.Btn3_3, Me.Btn3_4, 2, 3)
        End If
        clicks(2, 3) = True
    End Sub

    Private Sub Btn2_4_Click(sender As Object, e As EventArgs) Handles Btn2_4.Click
        If clicks(2, 4) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(2, 4)
            Btn2_4.Text = temporal
            Ubicacion(2, 4) = temporal
            evaluar0(Me.Btn1_3, Me.Btn1_4, Me.Btn1_5, Me.Btn2_3, Me.Btn2_5, Me.Btn3_3, Me.Btn3_4, Me.Btn3_5, 2, 4)
        End If
        clicks(2, 4) = True
    End Sub
    Private Sub Btn2_5_Click(sender As Object, e As EventArgs) Handles Btn2_5.Click
        If clicks(2, 5) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(2, 5)
            Btn2_5.Text = temporal
            Ubicacion(2, 5) = temporal
            evaluar0(Me.Btn1_4, Me.Btn1_5, Me.Btn1_6, Me.Btn2_4, Me.Btn2_6, Me.Btn3_4, Me.Btn3_5, Me.Btn3_6, 2, 5)
        End If
        clicks(2, 5) = False
    End Sub

    Private Sub Btn3_1_Click(sender As Object, e As EventArgs) Handles Btn3_1.Click
        If clicks(3, 1) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(3, 1)
            Btn3_1.Text = temporal
            Ubicacion(3, 1) = temporal
            'evaluar0(Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, Me.Btn3_0, Me.Btn3_2, Me.Btn4_0, Me.Btn4_1, Me.Btn4_2, 3, 1)
        End If

    End Sub

    Private Sub Btn3_2_Click(sender As Object, e As EventArgs) Handles Btn3_2.Click
        If clicks(3, 2) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(3, 2)
            Btn3_2.Text = temporal
            Ubicacion(3, 2) = temporal
            ' evaluar0(Me.Btn2_1, Me.Btn2_2, Me.Btn2_3, Me.Btn3_1, Me.Btn3_3, Me.Btn4_1, Me.Btn4_2, Me.Btn4_3, 3, 2)
        End If
        clicks(3, 2) = True
    End Sub

    Private Sub Btn3_3_Click(sender As Object, e As EventArgs) Handles Btn3_3.Click
        If clicks(3, 3) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(3, 3)
            Btn3_3.Text = temporal
            Ubicacion(3, 3) = temporal
            'evaluar0(Me.Btn2_2, Me.Btn2_3, Me.Btn2_4, Me.Btn3_2, Me.Btn3_4, Me.Btn4_2, Me.Btn4_3, Me.Btn4_4, 3, 3)
        End If
        clicks(3, 3) = True
    End Sub

    Private Sub Btn3_4_Click(sender As Object, e As EventArgs) Handles Btn3_4.Click
        If clicks(3, 4) = False Then
            Dim temporal As Integer
            GenerarMinas()
            temporal = EvaluarCasillas(3, 4)
            Btn3_4.Text = temporal
            Ubicacion(3, 4) = temporal
            'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
        End If
        clicks(3, 4) = True
    End Sub

    Private Sub Btn3_5_Click(sender As Object, e As EventArgs) Handles Btn3_5.Click
        Dim temporal As Integer
        GenerarMinas()
        temporal = EvaluarCasillas(3, 5)
        Btn3_5.Text = temporal
        Ubicacion(3, 5) = temporal
        'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
    End Sub

    Private Sub Btn4_1_Click(sender As Object, e As EventArgs) Handles Btn4_1.Click
        Dim temporal As Integer
        GenerarMinas()
        temporal = EvaluarCasillas(4, 1)
        Btn4_1.Text = temporal
        Ubicacion(4, 1) = temporal
        'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
    End Sub

    Private Sub Btn4_2_Click(sender As Object, e As EventArgs) Handles Btn4_2.Click
        Dim temporal As Integer
        GenerarMinas()
        temporal = EvaluarCasillas(4, 2)
        Btn4_2.Text = temporal
        Ubicacion(4, 2) = temporal
        'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
    End Sub

    Private Sub Btn4_3_Click(sender As Object, e As EventArgs) Handles Btn4_3.Click
        Dim temporal As Integer
        GenerarMinas()
        temporal = EvaluarCasillas(4, 3)
        Btn4_3.Text = temporal
        Ubicacion(4, 3) = temporal
        'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
    End Sub

    Private Sub Btn4_4_Click(sender As Object, e As EventArgs) Handles Btn4_4.Click
        Dim temporal As Integer
        GenerarMinas()
        temporal = EvaluarCasillas(4, 4)
        Btn4_4.Text = temporal
        Ubicacion(4, 4) = temporal
        'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
    End Sub

    Private Sub Btn4_5_Click(sender As Object, e As EventArgs) Handles Btn4_5.Click
        Dim temporal As Integer
        GenerarMinas()
        temporal = EvaluarCasillas(4, 5)
        Btn4_5.Text = temporal
        Ubicacion(4, 5) = temporal
        'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
    End Sub

    Private Sub Btn5_1_Click(sender As Object, e As EventArgs) Handles Btn5_1.Click
        Dim temporal As Integer
        GenerarMinas()
        temporal = EvaluarCasillas(5, 1)
        Btn5_1.Text = temporal
        Ubicacion(5, 1) = temporal
        'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
    End Sub

    Private Sub Btn5_2_Click(sender As Object, e As EventArgs) Handles Btn5_2.Click
        Dim temporal As Integer
        GenerarMinas()
        temporal = EvaluarCasillas(5, 2)
        Btn5_2.Text = temporal
        Ubicacion(5, 2) = temporal
        'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
    End Sub

    Private Sub Btn5_3_Click(sender As Object, e As EventArgs) Handles Btn5_3.Click
        Dim temporal As Integer
        GenerarMinas()
        temporal = EvaluarCasillas(5, 3)
        Btn5_3.Text = temporal
        Ubicacion(5, 3) = temporal
        'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
    End Sub

    Private Sub Btn5_4_Click(sender As Object, e As EventArgs) Handles Btn5_4.Click
        Dim temporal As Integer
        GenerarMinas()
        temporal = EvaluarCasillas(5, 4)
        Btn5_4.Text = temporal
        Ubicacion(5, 4) = temporal
        'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
    End Sub

    Private Sub Btn5_5_Click(sender As Object, e As EventArgs) Handles Btn5_5.Click
        Dim temporal As Integer
        GenerarMinas()
        temporal = EvaluarCasillas(5, 5)
        Btn5_5.Text = temporal
        Ubicacion(5, 5) = temporal
        'evaluar0(Me.Btn0_0, Me.Btn0_1, Me.Btn0_2, Me.Btn1_0, Me.Btn1_2, Me.Btn2_0, Me.Btn2_1, Me.Btn2_2, 1, 1)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Filas = 6
        Columnas = 6
        Minas = 5
        ReDim clicks(Filas, Columnas)
    End Sub
End Class
#End Region