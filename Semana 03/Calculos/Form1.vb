Public Class Form1
    ' Constantes para los precios de clientes Regulares
    Private Const REGULARDETERGENTPRICE As Double = 5.0
    Private Const REGULARDEODORANTPRICE As Double = 7.0
    Private Const REGULARGLASSCLEANERPRICE As Double = 6.0
    Private Const REGULARSOFTENERPRICE As Double = 8.0
    Private Const REGULARCHLORINEPRICE As Double = 3.5

    ' Constantes para los precios de clientes Mayoristas
    Private Const MayoristaDetergentPrice As Double = 4.5
    Private Const MayoristaDeodorantPrice As Double = 6.5
    Private Const MayoristaGlassCleanerPrice As Double = 5.5
    Private Const MayoristaSoftenerPrice As Double = 7.5
    Private Const MayoristaChlorinePrice As Double = 3.0

    ' Constantes para los precios de clientes Premium
    Private Const PremiumDetergentPrice As Double = 4.0
    Private Const PremiumDeodorantPrice As Double = 6.0
    Private Const PremiumGlassCleanerPrice As Double = 5.0
    Private Const PremiumSoftenerPrice As Double = 7.0
    Private Const PremiumChlorinePrice As Double = 2.5

    ' Constantes para descuentos y limites
    Private Const DiscountOverThreeProducts As Double = 0.05
    Private Const DiscountMayoristaDetergentChlorine As Double = 0.04
    Private Const DiscountOverFifteenSubtotal As Double = 0.1
    Private Const MinimumSubtotalForDiscount As Double = 15.0

    ' Variables de instancia
    Private selectedClientType As String = ""
    Private subtotal As Double = 0.0
    Private total As Double = 0.0
    Private discount1 As Double = 0.0
    Private discount2 As Double = 0.0
    Private selectedProductCount As Integer = 0

    ' Variables para las cantidades de productos
    Private detergentQuantity As Integer
    Private deodorantQuantity As Integer
    Private glassCleanerQuantity As Integer
    Private softenerQuantity As Integer
    Private chlorineQuantity As Integer

    Private Sub BtnCalculate_Click(sender As Object, e As EventArgs) Handles BtnCalculate.Click
        selectedClientType = CmbClientType.Text.ToLower() ' Mayorista -> mayorista

        ' Verifica si el campo está vacío, es nulo o solo contiene espacios en blanco
        If String.IsNullOrEmpty(TxtDetergent.Text) Then
            detergentQuantity = 0
            ' Si el campo contiene texto, verifica que sea un número válido
        ElseIf Not Integer.TryParse(TxtDetergent.Text, detergentQuantity) OrElse detergentQuantity < 0 Then
            ' Muestra mensaje de error al usuario cuando:
            ' 1. El texto no puede convertirse a número (TryParse retorna False)
            '    O (OrElse)
            ' 2. El número es negativo
            MessageBox.Show("Por favor, ingrese solo números enteros no negativos en las cantidaes",
                "Error de entrada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            ' Regresa para evitar continuar con el cálculo
            Exit Sub
        End If

        ' Si llegamos aquí, significa que:
        ' 1. El campo estaba vacío y se asignó 0, O
        ' 2. El campo contenía un número válido no negativo

        If String.IsNullOrWhiteSpace(TxtDeodorant.Text) Then
            deodorantQuantity = 0
        ElseIf Not Integer.TryParse(TxtDeodorant.Text, deodorantQuantity) OrElse deodorantQuantity < 0 Then
            MessageBox.Show("Por favor, ingrese solo números enteros no negativos en las cantidades.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TxtGlassCleaner.Text) Then
            glassCleanerQuantity = 0
        ElseIf Not Integer.TryParse(TxtGlassCleaner.Text, glassCleanerQuantity) OrElse glassCleanerQuantity < 0 Then
            MessageBox.Show("Por favor, ingrese solo números enteros no negativos en las cantidades.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TxtSoftener.Text) Then
            softenerQuantity = 0
        ElseIf Not Integer.TryParse(TxtSoftener.Text, softenerQuantity) OrElse softenerQuantity < 0 Then
            MessageBox.Show("Por favor, ingrese solo números enteros no negativos en las cantidades.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TxtChlorine.Text) Then
            chlorineQuantity = 0
        ElseIf Not Integer.TryParse(TxtChlorine.Text, chlorineQuantity) OrElse chlorineQuantity < 0 Then
            MessageBox.Show("Por favor, ingrese solo números enteros no negativos en las cantidades.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not (detergentQuantity > 0 Or deodorantQuantity > 0 Or glassCleanerQuantity > 0 Or softenerQuantity > 0 Or chlorineQuantity > 0) Then
            MessageBox.Show("Debe ingresar al menos una cantidad mayor a 0 para algún producto.",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Exit Sub
        End If

        subtotal = 0.0
        discount1 = 0.0
        discount2 = 0.0
        selectedProductCount = 0

        Select Case selectedClientType
            Case "regular"
                If detergentQuantity > 0 Then
                    subtotal += detergentQuantity * REGULARDETERGENTPRICE ' subtotal = subtotal + detergentQuantity * REGULARDETERGENTPRICE
                    selectedProductCount += 1 ' selectedProductCount = selectedProductCount + 1
                End If
                If deodorantQuantity > 0 Then
                    subtotal += deodorantQuantity * REGULARDEODORANTPRICE
                    selectedProductCount += 1
                End If
                If glassCleanerQuantity > 0 Then
                    subtotal += glassCleanerQuantity * REGULARGLASSCLEANERPRICE
                    selectedProductCount += 1
                End If
                If softenerQuantity > 0 Then
                    subtotal += softenerQuantity * REGULARSOFTENERPRICE
                    selectedProductCount += 1
                End If
                If chlorineQuantity > 0 Then
                    subtotal += chlorineQuantity * REGULARCHLORINEPRICE
                    selectedProductCount += 1
                End If
            Case "mayorista"
                If detergentQuantity > 0 Then
                    subtotal += detergentQuantity * MayoristaDetergentPrice
                    selectedProductCount += 1
                End If
                If deodorantQuantity > 0 Then
                    subtotal += deodorantQuantity * MayoristaDeodorantPrice
                    selectedProductCount += 1
                End If
                If glassCleanerQuantity > 0 Then
                    subtotal += glassCleanerQuantity * MayoristaGlassCleanerPrice
                    selectedProductCount += 1
                End If
                If softenerQuantity > 0 Then
                    subtotal += softenerQuantity * MayoristaSoftenerPrice
                    selectedProductCount += 1
                End If
                If chlorineQuantity > 0 Then
                    subtotal += chlorineQuantity * MayoristaChlorinePrice
                    selectedProductCount += 1
                End If
            Case "premium"
                If detergentQuantity > 0 Then
                    subtotal += detergentQuantity * PremiumDetergentPrice
                    selectedProductCount += 1
                End If
                If deodorantQuantity > 0 Then
                    subtotal += deodorantQuantity * PremiumDeodorantPrice
                    selectedProductCount += 1
                End If
                If glassCleanerQuantity > 0 Then
                    subtotal += glassCleanerQuantity * PremiumGlassCleanerPrice
                    selectedProductCount += 1
                End If
                If softenerQuantity > 0 Then
                    subtotal += softenerQuantity * PremiumSoftenerPrice
                    selectedProductCount += 1
                End If
                If chlorineQuantity > 0 Then
                    subtotal += chlorineQuantity * PremiumChlorinePrice
                    selectedProductCount += 1
                End If
        End Select

        ' Aplicar descuentos
        If selectedProductCount > 3 Then
            discount1 += subtotal * DiscountOverThreeProducts
        End If
        If selectedClientType = "mayorista" AndAlso detergentQuantity > 0 AndAlso chlorineQuantity > 0 Then
            discount1 += subtotal * DiscountMayoristaDetergentChlorine
        End If
        If subtotal > MinimumSubtotalForDiscount Then
            discount2 = subtotal * DiscountOverFifteenSubtotal
        End If

        ' Calcular total
        total = subtotal - discount1 - discount2

        ' Mostrar resultados
        LblSubtotal.Text = subtotal.ToString("C2")
        LblDiscount1.Text = discount1.ToString("C2")
        LblDiscount2.Text = discount2.ToString("C2")
        LblTotal.Text = total.ToString("C2")
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ' Restablecer controles
        CmbClientType.SelectedIndex = -1
        TxtDetergent.Text = ""
        TxtDeodorant.Text = ""
        TxtGlassCleaner.Text = ""
        TxtSoftener.Text = ""
        TxtChlorine.Text = ""

        ' Limpiar etiquetas
        LblSubtotal.Text = String.Empty
        LblDiscount1.Text = String.Empty
        LblDiscount2.Text = String.Empty
        LblTotal.Text = String.Empty

        ' Reiniciar variables
        subtotal = 0.0
        discount1 = 0.0
        discount2 = 0.0
        selectedProductCount = 0
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        If MessageBox.Show("¿Desea salir?", "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class
