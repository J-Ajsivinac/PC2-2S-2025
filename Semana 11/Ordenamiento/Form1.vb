Public Class Form1
    Private Sub btnBubbleSort_Click(sender As Object, e As EventArgs) Handles btnBubbleSort.Click
        Dim input As String = txtInput.Text.Trim()
        If String.IsNullOrEmpty(input) Then
            MessageBox.Show("Ingrese números separados por comas.")
            Return
        End If

        Dim numerosStr() As String = input.Split(","c)
        Dim numeros(numerosStr.Length - 1) As Integer
        Try
            For i As Integer = 0 To numerosStr.Length - 1
                numeros(i) = Integer.Parse(numerosStr(i).Trim())
            Next
        Catch ex As Exception
            MessageBox.Show("Entrada inválida. Use números enteros separados por comas.")
            Return
        End Try

        ModuloBurbuja.RealizarOrdenamientoBurbuja(numeros, rtbOutput)
    End Sub

    Private Sub btnQuickSort_Click(sender As Object, e As EventArgs) Handles btnQuickSort.Click
        Dim input As String = txtInput.Text.Trim()
        If String.IsNullOrEmpty(input) Then
            MessageBox.Show("Ingrese números separados por comas.")
            Return
        End If

        Dim numerosStr() As String = input.Split(","c)
        Dim numeros(numerosStr.Length - 1) As Integer
        Try
            For i As Integer = 0 To numerosStr.Length - 1
                numeros(i) = Integer.Parse(numerosStr(i).Trim())
            Next
        Catch ex As Exception
            MessageBox.Show("Entrada inválida. Use números enteros separados por comas.")
            Return
        End Try

        ModuloQuickSort.RealizarQuickSort(numeros, rtbOutput)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        rtbOutput.Clear()
        txtInput.Clear()
    End Sub
End Class
