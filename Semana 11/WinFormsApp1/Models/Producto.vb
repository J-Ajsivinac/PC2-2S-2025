Imports Microsoft.Data.SqlClient

Module Producto
    Public Function Crear(nombre As String, descripcion As String, precio As Decimal, idUsuario As Integer) As String
        If String.IsNullOrEmpty(nombre) OrElse precio <= 0 Then
            Return "Error: Nombre y precio positivo son requeridos."
        End If

        Dim query As String = "INSERT INTO Productos (Nombre, Descripcion, Precio, IdUsuario) VALUES (@Nombre, @Descripcion, @Precio, @IdUsuario)"
        Dim params As New Dictionary(Of String, Object) From {
            {"@Nombre", nombre},
            {"@Descripcion", descripcion},
            {"@Precio", precio},
            {"@IdUsuario", idUsuario}
        }

        Try
            Dim id As Long = BaseModel.Instance.ReturningId(query, params)
            If id > 0 Then
                Return "Producto creado exitosamente."
            Else
                Return "Error: No se pudo crear el producto."
            End If
        Catch sqlEx As SqlException
            Return $"Error de base de datos: {sqlEx.Message}"
        Catch ex As Exception
            Return $"Error inesperado: {ex.Message}"
        End Try
    End Function

    ' Leer todos los productos de un usuario
    Public Function ObtenerPorUsuario(idUsuario As Integer) As List(Of Dictionary(Of String, Object))
        If idUsuario <= 0 Then
            Throw New ArgumentException("Error: ID de usuario inválido.")
        End If

        Dim query As String = "SELECT * FROM Productos WHERE IdUsuario = @IdUsuario"
        Dim params As New Dictionary(Of String, Object) From {
            {"@IdUsuario", idUsuario}
        }

        Try
            Return BaseModel.Instance.ExecuteQuery(query, params)
        Catch sqlEx As SqlException
            Throw New Exception($"Error de base de datos: {sqlEx.Message}")
        Catch ex As Exception
            Throw New Exception($"Error inesperado: {ex.Message}")
        End Try
    End Function

    ' Leer un producto por ID
    Public Function ObtenerPorId(id As Integer) As Dictionary(Of String, Object)
        If id <= 0 Then
            Throw New ArgumentException("Error: ID inválido.")
        End If

        Dim query As String = "SELECT * FROM Productos WHERE Id = @Id"
        Dim params As New Dictionary(Of String, Object) From {
            {"@Id", id}
        }

        Try
            Return BaseModel.Instance.ExecuteSingleQuery(query, params)
        Catch sqlEx As SqlException
            Throw New Exception($"Error de base de datos: {sqlEx.Message}")
        Catch ex As Exception
            Throw New Exception($"Error inesperado: {ex.Message}")
        End Try
    End Function

    ' Actualizar un producto
    Public Function Actualizar(id As Integer, nombre As String, descripcion As String, precio As Decimal) As String
        If id <= 0 OrElse String.IsNullOrEmpty(nombre) OrElse precio <= 0 Then
            Return "Error: ID válido, nombre y precio positivo son requeridos."
        End If

        Dim query As String = "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio WHERE Id = @Id"
        Dim params As New Dictionary(Of String, Object) From {
            {"@Nombre", nombre},
            {"@Descripcion", descripcion},
            {"@Precio", precio},
            {"@Id", id}
        }

        Try
            Dim affectedRows As Integer = Convert.ToInt32(BaseModel.Instance.ExecuteNonQuery(query, params))

            If affectedRows > 0 Then
                Return "Producto actualizado exitosamente."
            Else
                Return "Error: No se encontró el producto para actualizar."
            End If
        Catch sqlEx As SqlException
            Return $"Error de base de datos: {sqlEx.Message}"
        Catch ex As Exception
            Return $"Error inesperado: {ex.Message}"
        End Try
    End Function

    ' Eliminar un producto
    Public Function Eliminar(id As Integer) As String
        If id <= 0 Then
            Return "Error: ID inválido."
        End If

        Dim query As String = "DELETE FROM Productos WHERE Id = @Id"
        Dim params As New Dictionary(Of String, Object) From {
            {"@Id", id}
        }

        Try
            Dim affectedRows As Integer = Convert.ToInt32(BaseModel.Instance.ExecuteNonQuery(query, params))
            If affectedRows > 0 Then
                Return "Producto eliminado exitosamente."
            Else
                Return "Error: No se encontró el producto para eliminar."
            End If
        Catch sqlEx As SqlException
            Return $"Error de base de datos: {sqlEx.Message}"
        Catch ex As Exception
            Return $"Error inesperado: {ex.Message}"
        End Try
    End Function
End Module
