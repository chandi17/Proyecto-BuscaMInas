'Importar esta libreria para el funcionamiento del movimiento
'del formulario
Imports System.Runtime.InteropServices
Public Class InicioBuscaminas
    Dim conexion As Conexion = New Conexion()

    'Codigo para manejar el movimiento del formulario
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    'Definicion de variable Global
    Dim contador As Integer

    'Barra de cargando para iniciar el juego e ir a la pagina de inicio
    Private Sub pgbCargando_Click(sender As Object, e As EventArgs) Handles pgbCargando.Click
        'Funcionalidad del Timer
        pgbCargando.Value = 0.0
        pgbCargando.Maximum = 100
        timerCargando.Interval = 40
        timerCargando.Enabled = True
    End Sub

    Private Sub timerCargando_Tick(sender As Object, e As EventArgs) Handles timerCargando.Tick
        'Se realiza la condicion para verificar si el contador es menor
        'que 100 y asi comenzar el conteo
        If contador < 100 Then
            pgbCargando.Value = contador
            contador += 3
        Else
            'Se desactiva el temporizador
            timerCargando.Enabled = False
            'Cierra el formulario y muestra el Menu Principal del juego
            MenuPrincipal.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub InicioBuscaminas_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub InicioBuscaminas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion.Verificarconexion()
        Dim avatar As String = "Elmer"
        Dim Mens As String = conexion.insertarPuntos(54, avatar)
        MsgBox(Mens, MessageBoxButtons.OK)
    End Sub
End Class