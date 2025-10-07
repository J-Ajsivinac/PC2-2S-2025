Imports Microsoft.Data.SqlClient

Module Usuario
    Public Function Login(nombreUsuario As String, contrasena As String) As String
        If String.IsNullOrEmpty(nombreUsuario) OrElse String.IsNullOrEmpty(contrasena) Then
            Return "Error: Nombre de usuario y contraseña son requeridos."
        End If

        Dim query As String = "SELECT Id, NombreUsuario, Correo FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Contrasena = @Contrasena"
        Dim params As New Dictionary(Of String, Object) From {
            {"@NombreUsuario", nombreUsuario},
            {"@Contrasena", contrasena}
        }

        Try
            Dim result = BaseModel.Instance.ExecuteSingleQuery(query, params)
            If result IsNot Nothing Then
                'CLng convierte a Long
                Sesion.UsuarioId = CLng(result("Id"))
                'CStr convierte a String
                Sesion.NombreUsuario = CStr(result("NombreUsuario"))
                Sesion.Correo = CStr(result("Correo"))
                Sesion.EstaLogueado = True
                Return $"Login exitoso. Bienvenido, {result("NombreUsuario")} (ID: {result("Id")})"
            Else
                Return "Error: Credenciales inválidas."
            End If
        Catch sqlEx As SqlException
            Return $"Error de base de datos: {sqlEx.Message}"
        Catch ex As Exception
            Return $"Error inesperado: {ex.Message}"
        End Try
    End Function
End Module
