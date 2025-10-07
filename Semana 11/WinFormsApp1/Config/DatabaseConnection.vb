Imports Microsoft.Data.SqlClient
Public Class DatabaseConnection
    Private Shared ReadOnly connectionString As String = "Server=localhost;Database=Ejemplo;Integrated Security=true;TrustServerCertificate=True;"

    Private Shared connection As SqlConnection = Nothing
    Public Shared Function GetConnection() As SqlConnection
        If connection Is Nothing OrElse connection.State = ConnectionState.Closed Then
            connection = New SqlConnection(connectionString)
            connection.Open()
        End If
        Return connection
    End Function
End Class
