Public Class Form2
    Private Sub btnVerFormualrioPrincipal_Click(sender As Object, e As EventArgs) Handles btnVerFormualrioPrincipal.Click
        Dim formularioPrincipal As New Form1()
        formularioPrincipal.Show() ' Muestra el formulario Form1
        Me.Hide() ' Oculta el formulario actual (Form2)
        '<'
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim role As String
        If cmbRoles.SelectedItem Is Nothing Then
            MessageBox.Show("Por favor, selecciona un rol.")
            Return
        End If
        role = cmbRoles.SelectedItem.ToString().ToLower()

        Select Case role
            Case "administrador"
                MessageBox.Show("Has seleccionado el rol de Administrador.")
            Case "estudiante"
                MessageBox.Show("Has seleccionado el rol de Estudiante.")
            Case Else
                MessageBox.Show("Rol no reconocido.")
        End Select
    End Sub
End Class