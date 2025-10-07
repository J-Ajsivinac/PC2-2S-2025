Module Sesion
    Public UsuarioId As Long = 0
    Public NombreUsuario As String = ""
    Public Correo As String = ""
    Public EstaLogueado As Boolean = False

    Public Sub CerrarSesion()
        UsuarioId = 0
        NombreUsuario = ""
        Correo = ""
        EstaLogueado = False
    End Sub
End Module
