Module ModuloBurbuja
    ' Procedimiento principal que implementa el algoritmo de ordenamiento burbuja
    ' Parámetros:
    '   arr() - Arreglo de enteros que se va a ordenar
    '   salida - Control RichTextBox donde se mostrará el proceso paso a paso
    Public Sub RealizarOrdenamientoBurbuja(ByVal arr() As Integer, ByVal salida As RichTextBox)

        ' Limpiamos el contenido previo del RichTextBox
        salida.Clear()

        ' Mostramos el estado inicial del arreglo antes de ordenar
        salida.AppendText("Array inicial: " & String.Join(", ", arr) & vbCrLf & vbCrLf)

        ' Cambiamos el color del texto a azul para destacar mensajes importantes
        salida.SelectionColor = Color.Blue
        salida.AppendText("Iniciando Ordenamiento Burbuja..." & vbCrLf & vbCrLf)

        ' Guardamos la longitud del arreglo para usar en los bucles
        Dim n As Integer = arr.Length

        ' BUCLE EXTERNO: Controla el número de pasadas completas por el arreglo
        ' Se ejecuta n-1 veces porque en cada pasada al menos un elemento queda en su posición final
        For i As Integer = 0 To n - 2

            ' Cambiamos a color verde para identificar cada nueva pasada
            salida.SelectionColor = Color.Green
            salida.AppendText("Pasada " & (i + 1) & ":" & vbCrLf)

            ' BUCLE INTERNO: Realiza las comparaciones e intercambios en cada pasada
            ' Va desde 0 hasta n-i-2 porque:
            '   - Los últimos i elementos ya están ordenados (de pasadas anteriores)
            '   - Restamos 2 porque comparamos j con j+1 (evitamos salir del índice)
            For j As Integer = 0 To n - i - 2

                ' Volvemos a color negro para el texto de comparación
                salida.SelectionColor = Color.Black
                salida.AppendText("  Comparando " & arr(j) & " y " & arr(j + 1) & ": ")

                ' COMPARACIÓN: Si el elemento actual es mayor que el siguiente
                If arr(j) > arr(j + 1) Then

                    ' INTERCAMBIO: Usamos una variable temporal para intercambiar valores
                    ' Este es el corazón del algoritmo burbuja
                    Dim temp As Integer = arr(j)        ' Guardamos arr(j) temporalmente
                    arr(j) = arr(j + 1)                 ' Movemos el menor a la posición j
                    arr(j + 1) = temp                   ' Movemos el mayor a la posición j+1

                    ' Resaltamos en rojo cuando se realiza un intercambio
                    salida.SelectionColor = Color.Red
                    salida.AppendText("Intercambio realizado." & vbCrLf)
                Else
                    ' Si el elemento ya está en orden, no hacemos intercambio
                    salida.AppendText("Sin intercambio." & vbCrLf)
                End If

                ' Mostramos cómo quedó el arreglo después de esta comparación
                ' Esto ayuda a visualizar cómo "burbujean" los elementos grandes hacia el final
                salida.SelectionColor = Color.DarkGray
                salida.AppendText("  Array actual: " & String.Join(", ", arr) & vbCrLf)
            Next

            ' Agregamos una línea en blanco entre pasadas para mejor legibilidad
            salida.AppendText(vbCrLf)
        Next

        ' Al finalizar todas las pasadas, mostramos el arreglo completamente ordenado
        salida.SelectionColor = Color.Blue
        salida.AppendText("Array final ordenado: " & String.Join(", ", arr) & vbCrLf)
    End Sub
End Module
