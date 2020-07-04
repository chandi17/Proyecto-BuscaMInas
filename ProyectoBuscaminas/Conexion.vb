
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
    Function insertarPuntos(ByVal puntos As Integer, ByVal avatar As String) As String
        Dim mensaje As String = "Nuevo Record almacenado"
        Try
            'comando = New SqlCommand("insert into Mejores.Ranking(avatar,puntos) Values('" & avatar & "'," & 72 & ")", LaConexion)
            LaConexion.Open()
            Dim Temporal As String = "insert into Mejores.Ranking(avatar,puntos) Values('Chandi17',72)"
            comando = New SqlCommand(Temporal, LaConexion)
            comando.ExecuteNonQuery()
        Catch ex As Exception
            mensaje = "No se inserto por:  " + ex.ToString
        End Try
        Return mensaje
    End Function



End Class
