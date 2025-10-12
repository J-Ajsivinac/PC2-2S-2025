Module ConvertTypes
    Public Function ConvertToDataTable(data As List(Of Dictionary(Of String, Object))) As DataTable
        ' Se crea un objeto DataTable vacío que será llenado
        Dim dt As New DataTable()

        ' Si la lista está vacía, se retorna directamente el DataTable vacío
        If data.Count = 0 Then Return dt

        ' Crear las columnas del DataTable usando las claves del primer diccionario
        ' (se asume que todos los diccionarios tienen las mismas claves)
        For Each key In data(0).Keys
            dt.Columns.Add(key)
        Next

        ' Agregar los valores de cada diccionario como filas en el DataTable
        For Each row In data
            ' Se crea una nueva fila vacía con la estructura del DataTable
            Dim dr As DataRow = dt.NewRow()

            ' Se recorren las parejas clave-valor (key-value pair, kvp) del diccionario
            For Each kvp In row
                ' Asigna el valor al campo correspondiente en la fila
                dr(kvp.Key) = kvp.Value
            Next

            ' Una vez completada la fila, se agrega al DataTable
            dt.Rows.Add(dr)
        Next

        ' Se retorna el DataTable completo
        Return dt
    End Function
End Module
