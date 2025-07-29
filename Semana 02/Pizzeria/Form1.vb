Public Class Form1
    ' Declaración de constantes para los precios de las pizzas
    Const PRECIOHAWAINA As Integer = 80
    Const PRECIOPEPERONI As Integer = 60
    Const PRECIOJAMON As Integer = 75

    ' Declaración de variables globales
    Dim pagoSubTotal As Double = 0
    Dim total As Double = 0
    Dim descuento As Double = 0
    Dim descuentaFrecuente As Double = 0
    Dim temp As Double = 0

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtHawaina.Clear()
        txtJamon.Clear()
        txtPeperoni.Clear()

        lblRestultados.Text = "Q00.00"
        txtDescuento.Clear()

        chFrecuentes.Checked = False
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dim respuesta As DialogResult = MessageBox.Show("Seguro que quieres salir?", "Confirmacion", MessageBoxButtons.YesNo)
        If respuesta = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        'Reinicar variables
        pagoSubTotal = 0
        total = 0
        descuento = 0
        temp = 0

        Dim cantHawaina As Integer = 0
        cantHawaina = Val(txtHawaina.Text)
        'Subtotal por pizza Hawaina
        temp = cantHawaina * PRECIOHAWAINA

        descuento = temp * 0.03

        If chFrecuentes.Checked Then
            descuentaFrecuente = temp * 0.06
        Else
            descuentaFrecuente = 0
        End If

        pagoSubTotal = temp - descuento - descuentaFrecuente
        total = pagoSubTotal

        'mostrar los resultados
        txtDescuento.Text = "Q" & (descuento + descuentaFrecuente).ToString("F2") '.00
        lblRestultados.Text = "Q" & total.ToString("F2") '.00
    End Sub
End Class
