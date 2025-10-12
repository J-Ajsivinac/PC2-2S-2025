Public Class Register
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim form As New Form1()
        form.Show()
        Me.Hide()
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim response As String = Usuario.Registrar("juan123", "contrasena123", "juan@example.com")
        If response.StartsWith("Registro exitoso") Then
            MessageBox.Show("Registro exitoso. Ahora puedes iniciar sesión.")
            Dim form As New Form1()
            form.Show()
            Me.Hide()
        Else
            MessageBox.Show(response)
        End If
    End Sub
End Class