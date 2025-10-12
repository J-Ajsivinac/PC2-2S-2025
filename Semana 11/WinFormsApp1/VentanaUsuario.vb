Public Class VentanaUsuario
    Private Sub VentanaUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName.Text = $"Usuario: {Sesion.NombreUsuario}"
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Sesion.CerrarSesion()
        Dim loginForm As New Form1()
        loginForm.Show()
        Me.Close()
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim response As String = Producto.Crear("Laptop 2", "Laptop de alta gama", 999.99, Sesion.UsuarioId)
        MessageBox.Show(response)
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim idText As String = txtID.Text

        If Not Integer.TryParse(idText, Nothing) OrElse String.IsNullOrEmpty(idText) Then
            MessageBox.Show("Error: ID de producto inválido.")
            Return
        End If
        Dim idProducto As Integer = Convert.ToInt32(idText)

        Dim response As String = Producto.Actualizar(idProducto, "Nuevo 2", "new 2", 222.2)
        MessageBox.Show(response)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim idText As String = txtID.Text
        If Not Integer.TryParse(idText, Nothing) OrElse String.IsNullOrEmpty(idText) Then
            MessageBox.Show("Error: ID de producto inválido.")
            Return
        End If
        Dim idProducto As Integer = Convert.ToInt32(idText)
        Dim response As String = Producto.Eliminar(idProducto)
        MessageBox.Show(response)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim idText As String = txtID.Text
        If Not Integer.TryParse(idText, Nothing) OrElse String.IsNullOrEmpty(idText) Then
            MessageBox.Show("Error: ID de producto inválido.")
            Return
        End If
        Dim idProducto As Integer = Convert.ToInt32(idText)
        Try
            Dim prod = Producto.ObtenerPorId(idProducto)
            If prod Is Nothing OrElse prod.Count = 0 Then
                MessageBox.Show("No se encontró el producto con el ID proporcionado.")
                Return
            End If
            MessageBox.Show($"ID: {prod("Id")}, Nombre: {prod("Nombre")}, Descripción: {prod("Descripcion")}, Precio: {prod("Precio")}, UsuarioId: {prod("IdUsuario")}")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        ' Limpiar el DataGridView antes de llenarlo nuevamente
        dataView.DataSource = Nothing

        Dim data As List(Of Dictionary(Of String, Object)) = Producto.ObtenerPorUsuario(Sesion.UsuarioId)
        If data.Count = 0 Then
            MessageBox.Show("No se encontraron productos para este usuario.")
            Return
        End If
        Dim dt As DataTable = ConvertTypes.ConvertToDataTable(data)
        dataView.DataSource = dt
    End Sub
End Class