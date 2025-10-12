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


    Public Function Registrar(nombreUsuario As String, contrasena As String, correo As String) As String
        If String.IsNullOrEmpty(nombreUsuario) OrElse String.IsNullOrEmpty(contrasena) OrElse String.IsNullOrEmpty(correo) Then
            Return "Error: Todos los campos son requeridos."
        End If

        If contrasena.Length < 6 Then
            Return "Error: La contraseña debe tener al menos 6 caracteres."
        End If

        Dim query As String = "INSERT INTO Usuarios (NombreUsuario, Contrasena, Correo) VALUES (@NombreUsuario, @Contrasena, @Correo)"
        Dim params As New Dictionary(Of String, Object) From {
            {"@NombreUsuario", nombreUsuario},
            {"@Contrasena", contrasena},
            {"@Correo", correo}
        }

        Try
            Dim id As Long = BaseModel.Instance.ReturningId(query, params)
            If id > 0 Then
                Return $"Registro exitoso." & vbCrLf & $"ID: {id}"
            Else
                Return "Error: No se pudo registrar el usuario."
            End If
        Catch sqlEx As SqlException
            If sqlEx.Number = 2627 Then ' Violación de UNIQUE constraint
                Return "Error: El nombre de usuario o correo ya existe."
            Else
                Return $"Error de base de datos: {sqlEx.Message}"
            End If
        Catch ex As Exception
            Return $"Error inesperado: {ex.Message}"
        End Try
    End Function
End Module
