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
End Class