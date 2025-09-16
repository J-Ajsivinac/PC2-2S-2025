Public Class Form1
    ' Declaracion de variables Globales

    Private nombres() As String  ' Vector para almacentar nombres de estudiantes
    Private calificaciones(,) As Double ' Matriz para almacenar calificaciones de estudiantes
    Private promedios() As Double ' Vector para almacenar promedios de estudiantes
    Private cantidadEstudiantes As Integer = 0 ' Cantidad de estudiantes
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' CONFIGURACIÓN DEL DataGridView - agregar columnas
        ' .Add (nombre_columna, texto_encabezado)
        dgvDatos.Columns.Add("Nombre", "Nombre")
        dgvDatos.Columns.Add("Calif1", "Calificación 1")
        dgvDatos.Columns.Add("Calif2", "Calificación 2")
        dgvDatos.Columns.Add("Calif3", "Calificación 3")
        dgvDatos.Columns.Add("Promedio", "Promedio")
        dgvDatos.Columns.Add("Estado", "Estado")

        ' INICIALIZACIÓN DE ARREGLOS usando ReDim
        ' ReDim nombre_vector(tamaño-1)
        Dim tamanio As Integer = 20 ' Definir tamaño máximo
        ReDim nombres(tamanio)           ' Vector para 20 estudiantes (índices 0-19)
        ReDim calificaciones(tamanio, 2) ' Matriz: 20 estudiantes x 3 calificaciones
        ReDim promedios(tamanio)         ' Vector para 20 promedios
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        ' ASIGNACIÓN DIRECTA de nombres de ejemplo
        nombres(0) = "Ana López"
        nombres(1) = "Juan Perez"
        nombres(2) = "María García"
        cantidadEstudiantes += 3 ' Actualizar cantidad de estudiantes}

        ' CICLOS FOR...NEXT ANIDADOS para generar calificaciones de ejemplo
        ' CICLO EXTERNO: Controla los estudiantes (i = 0, 1, 2)
        For i As Integer = 0 To 2           ' Por cada estudiante
            ' CICLO INTERNO: Controla las calificaciones de cada estudiante (j = 0, 1, 2)
            ' ANIDAMIENTO: Por cada valor de i, j recorre completamente 0, 1, 2
            For j As Integer = 0 To 2       ' Por cada calificación
                ' RESULTADO: 9 iteraciones totales (3 estudiantes × 3 calificaciones)
                ' Fórmula para generar calificaciones variadas
                ' Llenar la matriz calificaciones (i=estudiante, j=calificación)
                calificaciones(i, j) = 80 + (i * 5) + (j * 2)
            Next j  ' NEXT interno: incrementa j, cuando j>2 sale del ciclo interno
        Next i      ' NEXT externo: incrementa i, cuando i>2 sale del ciclo externo

        ActualizarDataGridView()  ' Refrescar la vista
    End Sub

    ' MÉTODO PARA ACTUALIZAR LA VISTA DE DATOS
    ' ========================================
    Private Sub ActualizarDataGridView()
        dgvDatos.Rows.Clear()  ' Limpiar filas existentes

        ' CICLO FOR...NEXT para llenar el DataGridView
        ' FUNCIONAMIENTO: Recorre desde 0 hasta cantidadEstudiantes-1
        ' USO: Ideal cuando sabes exactamente cuántos elementos procesar
        For i As Integer = 0 To cantidadEstudiantes - 1
            ' Crear nueva fila
            Dim fila As New DataGridViewRow()
            fila.CreateCells(dgvDatos)

            ' ASIGNACIÓN DE VALORES A CELDAS
            fila.Cells(0).Value = nombres(i)
            ' variableNumirca.ToString()
            ' "f1" Formato numérico con 1 decimal
            ' "f2" Formato numérico con 2 decimales
            fila.Cells(1).Value = calificaciones(i, 0).ToString("F1")  ' Calificación 1
            fila.Cells(2).Value = calificaciones(i, 1).ToString("F1")  ' Calificación 2
            fila.Cells(3).Value = calificaciones(i, 2).ToString("F1")  ' Calificación 3
            fila.Cells(4).Value = promedios(i).ToString("F2")          ' Promedio

            ' ESTRUCTURA CONDICIONAL TERNARIA para determinar estado
            Dim estado As String = If(promedios(i) >= 70, "APROBADO", "REPROBADO")
            fila.Cells(5).Value = estado

            ' FORMATO CONDICIONAL - colorear filas según estado
            If estado = "REPROBADO" Then
                fila.DefaultCellStyle.BackColor = Color.LightPink   ' Rojo para reprobados
            Else
                fila.DefaultCellStyle.BackColor = Color.LightGreen  ' Verde para aprobados
            End If

            dgvDatos.Rows.Add(fila)  ' Agregar fila al DataGridView
        Next i
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        Dim i As Integer = 0

        ' CICLO DO WHILE - FUNCIONAMIENTO DETALLADO:
        ' CONDICIÓN AL INICIO: Evalúa la condición ANTES de ejecutar el bloque
        ' CARACTERÍSTICA: Si la condición es falsa desde el inicio, NO ejecuta ni una vez
        ' USO: Cuando necesitas que el ciclo se ejecute 0 o más veces
        Do While i < cantidadEstudiantes
            ' BLOQUE DE CÓDIGO: Se ejecuta mientras i sea menor que cantidadEstudiantes
            Dim suma As Double = 0

            ' CICLO FOR...NEXT INTERNO para sumar las 3 calificaciones de cada estudiante
            For j As Integer = 0 To 2
                suma += calificaciones(i, j)
            Next j

            ' Calcular promedio dividiendo suma entre 3
            promedios(i) = suma / 3

            ' IMPORTANTE: Incrementar contador manualmente (diferencia clave con FOR)
            i += 1  ' Si olvidas esto, tendrás un CICLO INFINITO
        Loop        ' LOOP: Regresa a evaluar la condición Do While

        ActualizarDataGridView()  ' Refrescar vista con nuevos promedios
        MessageBox.Show("Promedios calculados.")
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' VALIDACIÓN DE ENTRADA usando estructura condicional
        Dim nombre As String = txtNombre.Text.Trim()
        If nombre = "" Then
            MessageBox.Show("Ingrese un nombre válido.")
            Return  ' Sale del método si no hay nombre
        End If

        Try
            ' PROCESAMIENTO DE CALIFICACIONES
            ' Convertir el texto de calificaciones en un array
            '.Split(separador) -> Divide el texto en partes usando el separador
            ' ' El carácter 'c' indica que es un carácter literal -> quiere decir coma
            ' 12,24,36 -> {"12", "24", "36"}
            Dim califTexto() As String = txtCalif.Text.Split(","c)

            ' VALIDACIÓN usando estructura condicional - exactamente 3 calificaciones
            If califTexto.Length <> 3 Then
                MessageBox.Show("Debe ingresar exactamente 3 calificaciones.")
                Return
            End If

            ' ALMACENAMIENTO EN ESTRUCTURAS DE DATOS
            nombres(cantidadEstudiantes) = nombre  ' Guardar nombre en el vector

            ' CICLO FOR...NEXT para procesar las 3 calificaciones
            ' FUNCIONAMIENTO: Ejecuta un número fijo de iteraciones (3 veces: i=0, i=1, i=2)
            ' CARACTERÍSTICAS: Contador automático, inicio y fin definidos, incremento automático
            For i As Integer = 0 To 2
                ' ITERACIÓN: i toma valores 0, 1, 2 (corresponde a las 3 calificaciones)
                ' Convertir cada calificación de texto a número y almacenar en la matriz
                calificaciones(cantidadEstudiantes, i) = Convert.ToDouble(califTexto(i).Trim())
            Next i  ' NEXT: Incrementa i automáticamente y verifica si i <= 2

            cantidadEstudiantes += 1  ' Incrementar contador

            ' Limpiar campos de entrada
            txtNombre.Clear()
            txtCalif.Clear()

            ' Actualizar la vista de datos
            ActualizarDataGridView()

        Catch ex As Exception
            ' MANEJO DE ERRORES - por si hay problemas de conversión
            MessageBox.Show("Error en las calificaciones: " & ex.Message)
        End Try
    End Sub

    ' EVENTO DE DOBLE CLIC EN CELDA - MOSTRAR DETALLES
    ' ===============================================
    Private Sub dgvDatos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellContentDoubleClick
        ' VALIDACIÓN - verificar que se hizo clic en una fila válida
        If e.RowIndex >= 0 Then
            If chkEditMode.Checked Then
                ' MODO EDICIÓN: Permitir editar directamente en el DataGridView

                ' Validar que estemos seleccionando una de de las calificaciones
                If e.ColumnIndex >= 1 AndAlso e.ColumnIndex <= 3 Then
                    Dim indiceEstudiante As Integer = e.RowIndex
                    Dim indiceCalif As Integer = e.ColumnIndex - 1 ' Ajuste: 1=Calif1, 2=Calif2, 3=Calif3 -> 0,1,2

                    ' PEDIR NUEVA CALIFICACIÓN AL USUARIO
                    Dim nuevaCalifStr As String = InputBox($"Ingrese la nueva calificación para {nombres(indiceEstudiante)} (Examen {indiceCalif + 1}):", "Modificar Calificación", calificaciones(indiceEstudiante, indiceCalif).ToString("F2"))
                    If nuevaCalifStr <> "" Then
                        Try
                            Dim nuevaCalif As Double = Convert.ToDouble(nuevaCalifStr)
                            If nuevaCalif >= 0 AndAlso nuevaCalif <= 100 Then ' Rango típico de calificaciones
                                ModificarCalificacion(indiceEstudiante, indiceCalif, nuevaCalif)
                            Else
                                MessageBox.Show("La calificación debe estar entre 0 y 100.")
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Error: Ingrese un número válido.")
                        End Try
                    End If
                End If
            Else
                ' CONSTRUCCIÓN DE MENSAJE DETALLADO
                ' e.rowIndex da el índice de la fila clickeada
                Dim detalle As String = $"Estudiante: {nombres(e.RowIndex)}" & vbCrLf &
                                       "Calificaciones:" & vbCrLf

                ' CICLO FOR...NEXT para mostrar cada calificación
                ' ELECCIÓN DE CICLO: For es perfecto aquí porque sabemos que son exactamente 3 calificaciones
                ' ALTERNATIVA: Podríamos usar While, pero For es más claro para rangos fijos
                For i As Integer = 0 To 2
                    ' FORMAT: F2 significa 2 decimales, i+1 convierte índice 0,1,2 en números 1,2,3
                    ' $ representa el valor de la variable en el mensaje
                    ' $"{variable}" representa el valor de la variable en el mensaje
                    detalle &= $"  Examen {i + 1}: {calificaciones(e.RowIndex, i):F2}" & vbCrLf
                Next i  ' INCREMENTO AUTOMÁTICO: No necesitamos i += 1 como en While

                ' Agregar promedio al mensaje
                detalle &= $"Promedio: {promedios(e.RowIndex):F2}"

                ' Mostrar ventana con detalles del estudiante
                MessageBox.Show(detalle, "Detalle del Estudiante")
            End If
            '
        End If

    End Sub

    ' MÉTODO PARA MODIFICAR CALIFICACIÓN
    Private Sub ModificarCalificacion(indiceEstudiante As Integer, indiceCalif As Integer, nuevaCalif As Double)
        If indiceEstudiante < 0 OrElse indiceEstudiante >= cantidadEstudiantes Then
            MessageBox.Show("Índice de estudiante inválido.")
            Return
        End If

        If indiceCalif < 0 OrElse indiceCalif > 2 Then
            MessageBox.Show("Índice de calificación inválido (debe ser 0, 1 o 2).")
            Return
        End If

        ' ACTUALIZAR MATRIZ DE CALIFICACIONES
        calificaciones(indiceEstudiante, indiceCalif) = nuevaCalif

        ' RECALCULAR PROMEDIO usando While
        Dim suma As Double = 0
        ' j es el contador de las calificaciones
        Dim j As Integer = 0
        While j < 3
            suma += calificaciones(indiceEstudiante, j)
            j += 1
        End While
        promedios(indiceEstudiante) = suma / 3

        ActualizarDataGridView() ' Refrescar DataGridView
        MessageBox.Show($"Calificación {indiceCalif + 1} del estudiante {nombres(indiceEstudiante)} actualizada a {nuevaCalif:F2}.")
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        ' i va a funcionar como un contador o índice
        ' i va a ser el indice de los estudiantes
        Dim i As Integer = 0

        Do
            If i >= cantidadEstudiantes Then Exit Do ' Evitar error si i excede cantidadEstudiantes
            ' Limpieza de datos
            nombres(i) = ""
            promedios(i) = 0

            ' CICLO FOR...NEXT INTERNO para limpiar las 3 calificaciones
            ' VENTAJA FOR: Para rangos fijos (0 a 2), For es más legible que While
            For j As Integer = 0 To 2
                ' Primera iteración i = 0, j= 0 ( estudiante 1, parcial 1)
                ' Segunda iteración i = 0, j= 1 (estudiante 1, parcial 2)
                ' Tercera iteración i = 0, j= 2 (estudiante 1, parcial 3)
                ' Cuarta iteración i = 1, j= 0 (estudiante 2, parcial 1)
                calificaciones(i, j) = 0
            Next j
            i += 1  ' Incrementar contador
        Loop

        cantidadEstudiantes = 0 ' Reiniciar contador de estudiantes
        ActualizarDataGridView()
    End Sub

    Private Sub btnEstadistica_Click(sender As Object, e As EventArgs) Handles btnEstadistica.Click
        ' Verificar que existan datos
        If cantidadEstudiantes = 0 Then
            MessageBox.Show("No hay datos.")
            Return
        End If

        ' Variables para estadísticas
        Dim aprobados As Integer = 0
        Dim sumaGeneral As Double = 0
        Dim mejorPromedio As Double = -1
        Dim mejorNombre As String = ""

        Dim i As Integer = 0
        While i < cantidadEstudiantes
            sumaGeneral += promedios(i)

            ' ESTRUCTURA CONDICIONAL - contar aprobados
            If promedios(i) >= 70 Then
                aprobados += 1
            End If

            ' ESTRUCTURA CONDICIONAL - encontrar mejor estudiante
            If promedios(i) > mejorPromedio Then
                mejorPromedio = promedios(i)
                mejorNombre = nombres(i)
            End If

            i += 1
        End While

        ' CÁLCULOS FINALES
        Dim promedioGeneral As Double = sumaGeneral / cantidadEstudiantes
        Dim reprobados As Integer = cantidadEstudiantes - aprobados

        Dim mensaje As String = "=== ESTADÍSTICAS ===" & vbCrLf &
                               $"Total estudiantes: {cantidadEstudiantes}" & vbCrLf &
                               $"Promedio general: {promedioGeneral:F2}" & vbCrLf &
                               $"Aprobados: {aprobados}" & vbCrLf &
                               $"Reprobados: {reprobados}" & vbCrLf &
                               $"Mejor estudiante: {mejorNombre} ({mejorPromedio:F2})"
        MessageBox.Show(mensaje, "Estadísticas")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ' BÚSQUEDA SECUENCIAL - encontrar estudiante por nombre
        ' .trim() es para limpiar espacios al inicio y final
        ' " hola " -> "hola"
        Dim textoBuscar As String = txtBuscar.Text.Trim().ToLower()
        If textoBuscar = "" Then
            MessageBox.Show("Ingrese un nombre para buscar.")
            Return
        End If

        Dim encontrado As Boolean = False

        For i As Integer = 0 To cantidadEstudiantes - 1
            ' contains es para buscar si una cadena está dentro de otra
            ' Ana López -> ana
            If nombres(i).ToLower().Contains(textoBuscar) Then
                ' Seleccionar la fila correspondiente en el DataGridView
                dgvDatos.ClearSelection()  ' Limpiar selección previa
                dgvDatos.Rows(i).Selected = True
                ' FirstDisplayedScrollingRowIndex desplaza la vista para mostrar la fila
                dgvDatos.FirstDisplayedScrollingRowIndex = i ' Desplazar a la fila encontrada
                encontrado = True
                Exit For  ' Salir del ciclo al encontrar el primer match
            End If
        Next
        If Not encontrado Then
            MessageBox.Show("Estudiante no encontrado.")
        End If
    End Sub
End Class
