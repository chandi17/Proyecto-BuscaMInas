
Imports System.Data.SqlClient
Public Class Conexion
    'Verifica la conexión
    Public con As New SqlConnection(My.Settings.Conexión)
    Public LaConexion As SqlConnection = New SqlConnection("Data Source=CHANDIA;Initial Catalog=BuscaMinas;Integrated Security=True")
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public comando As SqlCommand
    Public dr As SqlDataReader

#Region "Consultas"
    'Consulta el Avatar'
    Public sqlAvatar As String = "select avatar from Mejores.Ranking "
    Public cmdAvatar As New SqlCommand(sqlAvatar, con)
    'Consulta el puntos'
    Public sqlPuntos As String = "select puntos from Mejores.Ranking "
    Public cmdPuntos As New SqlCommand(sqlAvatar, con)
#End Region
    Public Sub Verificarconexion()
        Try
            'conexion es el nombre de la clase; open() abre la conexion con sql, si se abre la conexion muestra e msj conectado sino cierra la conexion
            LaConexion.Open()
            MessageBox.Show("Conectado")
        Catch ex As Exception
            MessageBox.Show("Error al conectar")
        Finally
            LaConexion.Close()
        End Try
    End Sub
    Function insertarPuntos(ByVal puntos As Integer, ByVal avatar As String)

        Dim mensaje As String = "Nuevo Record almacenado"

        Try
            LaConexion.Open()
            '"insert into Mejores.Ranking(avatar,puntos) Values('Ericka',200)"
            Dim Temporal As String = "insert into Mejores.Ranking(avatar,puntos) Values('" & avatar & "'," & 72 & ")"
            comando = New SqlCommand(Temporal, LaConexion)
            comando.ExecuteNonQuery()
        Catch ex As Exception
            mensaje = "No se inserto por:  " + ex.ToString
        Finally
            LaConexion.Close()
        End Try
        Return mensaje

    End Function

    Public Function VerificarPuntuacion() As Integer
        Dim resultado As Integer
        Try
            LaConexion.Open()
            ''Dim query As String = "select * from personas.estudiante where codigo = '" + codigo + "'"
            comando = New SqlCommand(" select puntos from Mejores.Ranking", LaConexion)
            dr = comando.ExecuteReader
            If dr.Read Then
                resultado = dr.GetInt32(0)
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            resultado = 0
        Finally
            LaConexion.Close()
        End Try
        Return resultado
    End Function

    Public Function ValidarExiste(avatar As String) As Boolean
        Dim resultado As Boolean = False
        Try
            LaConexion.Open()
            ''Dim query As String = "select * from personas.estudiante where codigo = '" + codigo + "'"
            comando = New SqlCommand(" select puntos from Mejores.Ranking where Mejores.avatar = '" + avatar + "'", LaConexion)
            dr = comando.ExecuteReader
            If dr.Read Then
                resultado = True
            Else
                resultado = False
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            LaConexion.Close()
        End Try
        Return resultado
    End Function

    Sub ActualizarDatos(puntos As Integer, avatar As String)
        Try
            LaConexion.Open()
            'update Mejores.Ranking set puntos = 90 where avatar = 'Chandi17' 
            Dim modificar As String = "update Mejores.Ranking set puntos = " & puntos & " where avatar = '" & avatar & "'"
            'SQLcommand requiere dos parametros: 1. Instruccion sql que será modificarE, almacena la instrucción sql
            '2. Establecer una comunicacion con la base de datos, conexion
            comando = New SqlCommand(modificar, LaConexion)
            'Retorna el valor de Filas Afectadas
            Dim i As Integer = comando.ExecuteNonQuery()
            LaConexion.Close()
            If (i > 0) Then
                MsgBox("Has Superado tu record Anterior")
            Else
                MsgBox("Error")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            LaConexion.Close()
        End Try

    End Sub

    Sub ResetPuntos()

        Dim resultado As Boolean = False
        Try
            LaConexion.Open()
            'Dim modificar As String = String.Format("truncate {0},{1},{2}",tabla,nombre,apellido)
            Dim modificar As String = "truncate table Mejores.Ranking"
            comando = New SqlCommand(modificar, LaConexion)
            Dim i As Integer = comando.ExecuteNonQuery()
            LaConexion.Close()
            MsgBox("Reset con exito")
        Catch ex As Exception
            MsgBox("Error al reset")
        Finally
            LaConexion.Close()
        End Try

    End Sub
End Class
