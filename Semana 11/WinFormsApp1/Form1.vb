Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim response As String = Usuario.Registrar("juan123", "contrasena123", "juan@example.com")
        'MessageBox.Show(response)
        Dim idUsuario As Integer = 6
        'Dim response As String = Module1.Crear("Laptop", "Laptop de alta gama", 999.99, idUsuario)
        'MessageBox.Show(response)
        'Dim idProducto As Integer = 3
        'Dim response As String = Module1.Actualizar(idProducto, "Nuevo 2", "new 2", 222.2)
        'MessageBox.Show(response)
        'Dim idProducto As Integer = 3
        'Dim response As String = Module1.Eliminar(idProducto)
        'MessageBox.Show(response)
        'Try
        '    Console.WriteLine(vbCrLf & "Lista de productos:")
        '    Dim productos = Module1.ObtenerPorUsuario(idUsuario)
        '    If productos.Count = 0 Then
        '        MessageBox.Show("No se encontraron productos para este usuario.")
        '        Return
        '    End If
        '    For Each producto In productos
        '        MessageBox.Show($"ID: {producto("Id")}, Nombre: {producto("Nombre")}, Precio: {producto("Precio")}")
        '    Next
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'Dim response As String = Usuario.Login("juan123", "contrasena123")

        Dim nombreUsuario As String = txtName.Text
        Dim contrasena As String = txtPassword.Text

        If nombreUsuario = "" OrElse contrasena = "" Then
            MessageBox.Show("Error: Nombre de usuario y contraseña son requeridos.")
            Return
        End If

        Dim response As String = Usuario.Login(nombreUsuario, contrasena)

        MessageBox.Show(response)
        If Sesion.EstaLogueado Then
            Dim form As New VentanaUsuario()
            form.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim form As New Register()
        form.Show()
        Me.Hide()
    End Sub
End Class
