Module ModuloQuickSort

    ' Procedimiento público que inicia el proceso de QuickSort
    ' Parámetros:
    '   arr() - Arreglo de enteros que se va a ordenar
    '   salida - Control RichTextBox donde se mostrará el proceso paso a paso
    Public Sub RealizarQuickSort(ByVal arr() As Integer, ByVal salida As RichTextBox)

        ' Limpiamos el contenido previo del RichTextBox
        salida.Clear()

        ' Mostramos el estado inicial del arreglo antes de ordenar
        salida.AppendText("Array inicial: " & String.Join(", ", arr) & vbCrLf & vbCrLf)

        ' Cambiamos el color del texto a azul para destacar mensajes importantes
        salida.SelectionColor = Color.Blue
        salida.AppendText("Iniciando QuickSort..." & vbCrLf & vbCrLf)

        ' Llamamos al procedimiento recursivo QuickSort
        ' Parámetros: arreglo, índice inicial (0), índice final (longitud-1), salida, nivel de recursión (0)
        QuickSort(arr, 0, arr.Length - 1, salida, 0)

        ' Al finalizar, mostramos el arreglo completamente ordenado
        salida.SelectionColor = Color.Blue
        salida.AppendText("Array final ordenado: " & String.Join(", ", arr) & vbCrLf)
    End Sub

    ' Procedimiento RECURSIVO que implementa el algoritmo QuickSort
    ' Este es el núcleo del algoritmo que se llama a sí mismo (recursión)
    ' Parámetros:
    '   arr() - Arreglo a ordenar
    '   bajo - Índice inicial del segmento a ordenar
    '   alto - Índice final del segmento a ordenar
    '   salida - RichTextBox para mostrar el proceso
    '   nivel - Nivel de profundidad de la recursión (para indentar visualmente)
    Private Sub QuickSort(ByVal arr() As Integer, ByVal bajo As Integer, ByVal alto As Integer, ByVal salida As RichTextBox, ByVal nivel As Integer)

        ' CASO BASE: Solo procesamos si hay al menos 2 elementos (bajo < alto)
        ' Si bajo >= alto, significa que el segmento tiene 0 o 1 elemento y ya está "ordenado"
        If bajo < alto Then

            ' PASO 1: PARTICIONAR
            ' Dividimos el arreglo y obtenemos la posición final del pivote
            ' El pivote queda en su posición correcta después de particionar
            Dim pi As Integer = Particionar(arr, bajo, alto, salida, nivel)

            ' Mostramos cómo quedó el arreglo después de la partición
            salida.SelectionColor = Color.DarkGray
            ' String.Concat(Enumerable.Repeat("  ", nivel)) crea indentación según el nivel de recursión
            salida.AppendText(String.Concat(Enumerable.Repeat("  ", nivel)) & "Array después de partición: " & String.Join(", ", arr) & vbCrLf & vbCrLf)

            ' PASO 2: DIVIDIR Y CONQUISTAR (Recursión)
            ' Ordenamos recursivamente la parte IZQUIERDA (elementos menores al pivote)
            ' Va desde 'bajo' hasta 'pi - 1' (antes del pivote)
            QuickSort(arr, bajo, pi - 1, salida, nivel + 1)

            ' Ordenamos recursivamente la parte DERECHA (elementos mayores al pivote)
            ' Va desde 'pi + 1' (después del pivote) hasta 'alto'
            QuickSort(arr, pi + 1, alto, salida, nivel + 1)

            ' Nota: El pivote (en posición pi) NO se incluye en las llamadas recursivas
            ' porque ya está en su posición final correcta
        End If
    End Sub

    ' Función que realiza la PARTICIÓN del arreglo
    ' Este es el corazón del algoritmo QuickSort
    ' Objetivo: Colocar el pivote en su posición correcta y reorganizar los elementos
    '           de modo que los menores queden a la izquierda y los mayores a la derecha
    ' Parámetros:
    '   arr() - Arreglo a particionar
    '   bajo - Índice inicial del segmento
    '   alto - Índice final del segmento
    '   salida - RichTextBox para mostrar el proceso
    '   nivel - Nivel de recursión para indentación
    ' Retorna: La posición final donde quedó el pivote
    Private Function Particionar(ByVal arr() As Integer, ByVal bajo As Integer, ByVal alto As Integer, ByVal salida As RichTextBox, ByVal nivel As Integer) As Integer

        ' Seleccionamos el PIVOTE: en este caso, siempre es el último elemento del segmento
        ' Existen otras estrategias: primer elemento, elemento del medio, aleatorio, etc.
        Dim pivote As Integer = arr(alto)

        ' Informamos sobre la partición actual
        salida.SelectionColor = Color.Green
        salida.AppendText(String.Concat(Enumerable.Repeat("  ", nivel)) & "Partición (pivote = " & pivote & ", rango " & bajo & " a " & alto & "):" & vbCrLf)

        ' Variable 'i': Marca la frontera entre elementos menores y mayores al pivote
        ' Inicialmente está en bajo-1 (antes del primer elemento)
        ' Todos los elementos a la izquierda de 'i' serán menores al pivote
        Dim i As Integer = bajo - 1

        ' Recorremos todos los elementos EXCEPTO el pivote (de bajo a alto-1)
        For j As Integer = bajo To alto - 1

            salida.SelectionColor = Color.Black
            salida.AppendText(String.Concat(Enumerable.Repeat("  ", nivel + 1)) & "Comparando " & arr(j) & " con pivote " & pivote & ": ")

            ' COMPARACIÓN CLAVE: Si el elemento actual es MENOR que el pivote
            If arr(j) < pivote Then

                ' Movemos la frontera 'i' una posición a la derecha
                i += 1

                ' INTERCAMBIO: Colocamos el elemento menor en la zona de "menores"
                ' Intercambiamos arr(i) con arr(j)
                Dim temp As Integer = arr(i)
                arr(i) = arr(j)
                arr(j) = temp

                ' Resaltamos el intercambio en rojo
                salida.SelectionColor = Color.Red
                salida.AppendText("Intercambio con " & arr(j) & "." & vbCrLf)
            Else
                ' Si el elemento es mayor o igual al pivote, no hacemos nada
                ' Se queda en la zona de "mayores"
                salida.AppendText("Sin intercambio." & vbCrLf)
            End If
        Next

        ' PASO FINAL: Colocar el PIVOTE en su posición correcta
        ' En este momento:
        '   - Elementos de bajo a i son menores al pivote
        '   - Elementos de i+1 a alto-1 son mayores o iguales al pivote
        '   - El pivote está en la posición 'alto'
        ' Intercambiamos el pivote con el elemento en i+1
        Dim temp2 As Integer = arr(i + 1)
        arr(i + 1) = arr(alto)
        arr(alto) = temp2

        salida.SelectionColor = Color.Red
        salida.AppendText(String.Concat(Enumerable.Repeat("  ", nivel + 1)) & "Colocando pivote en posición " & (i + 1) & "." & vbCrLf)

        ' Retornamos la posición final del pivote
        ' Esta posición divide el arreglo en dos sub-arreglos para la recursión
        Return i + 1
    End Function

End Module