' ============================================================================
' IMPORTS - Librerías necesarias
' ============================================================================
' Esta librería contiene las clases para trabajar con SQL Server
Imports Microsoft.Data.SqlClient

' ============================================================================
' CLASE: BaseModel
' PROPÓSITO: Clase base para acceso a base de datos
' ============================================================================
Public Class BaseModel

    ' ========================================================================
    ' VARIABLES DE CLASE
    ' ========================================================================

    ' Variable estática (Shared) que guardará la ÚNICA instancia de esta clase
    ' Private = solo accesible dentro de esta clase
    ' Shared = es compartida por todas las instancias (variable de clase, no de objeto)
    Private Shared _instance As BaseModel

    ' Variable que guarda la conexión a la base de datos
    ' Protected = accesible desde esta clase y sus clases heredadas
    Protected db As SqlConnection

    ' ========================================================================
    ' PATRÓN SINGLETON - Propiedad Instance
    ' ========================================================================
    ' PROPÓSITO: Garantizar que solo exista UNA instancia de BaseModel en toda
    '            la aplicación. Esto evita tener múltiples conexiones abiertas
    '            innecesariamente.
    ' ========================================================================


    ' Propiedad de solo lectura (ReadOnly) para obtener la instancia única
    ' Shared = se puede llamar sin crear un objeto: BaseModel.Instance
    Public Shared ReadOnly Property Instance() As BaseModel
        Get
            ' Si todavía no se ha creado la instancia...
            If _instance Is Nothing Then
                ' ...la creamos por primera vez
                _instance = New BaseModel()
            End If

            ' Siempre devolvemos la MISMA instancia
            ' Esto garantiza que toda la app use la misma conexión
            Return _instance
        End Get
    End Property

    ' ========================================================================
    ' CONSTRUCTOR PRIVADO
    ' ========================================================================
    ' PROPÓSITO: Al ser Private, nadie puede hacer "New BaseModel()" desde fuera
    '            Solo se puede obtener la instancia mediante BaseModel.Instance
    ' ========================================================================

    Private Sub New()
        ' Obtiene la conexión desde otra clase (DatabaseConnection)
        db = DatabaseConnection.GetConnection()
    End Sub

    ' ========================================================================
    ' MÉTODOS PARA GESTIONAR LA CONEXIÓN
    ' ========================================================================

    ' ------------------------------------------------------------------------
    ' MÉTODO: OpenConnection
    ' PROPÓSITO: Abre la conexión a la base de datos si está cerrada
    ' ------------------------------------------------------------------------
    Public Sub OpenConnection()
        ' Verifica si la conexión NO está abierta
        If db.State <> ConnectionState.Open Then ' <> -> !=
            ' Si está cerrada, la abre
            db.Open()
        End If
        ' Si ya está abierta, no hace nada (evita error de "conexión ya abierta")
    End Sub

    ' ------------------------------------------------------------------------
    ' MÉTODO: CloseConnection
    ' PROPÓSITO: Cierra la conexión a la base de datos si está abierta
    ' ------------------------------------------------------------------------
    Public Sub CloseConnection()
        ' Verifica si la conexión está abierta
        If db.State = ConnectionState.Open Then
            ' Si está abierta, la cierra
            db.Close()
        End If
        ' Si ya está cerrada, no hace nada
    End Sub

    ' ========================================================================
    ' MÉTODO: ExecuteQuery
    ' ========================================================================
    ' PROPÓSITO: Ejecutar consultas SELECT que devuelven MÚLTIPLES filas
    ' 
    ' PARÁMETROS:
    '   - query: La consulta SQL a ejecutar (String)
    '            Ejemplo: "SELECT * FROM usuarios WHERE edad > @edad"
    '
    '   {"KEY": "VALOR"}
    '   - params: (OPCIONAL) Diccionario con los parámetros de la consulta
    '            Ejemplo: New Dictionary(Of String, Object) From {{"@edad", 18}}
    '            Los parámetros previenen SQL INJECTION (ataques de seguridad)
    '
    ' RETORNA: Lista de diccionarios, donde:
    '          - Cada diccionario = una fila de la base de datos
    '          - Cada clave del diccionario = nombre de columna
    '          - Cada valor = dato de esa columna
    '
    ' EJEMPLO DE USO:
    '   Dim usuarios = BaseModel.Instance.ExecuteQuery(
    '       "SELECT nombre, edad FROM usuarios WHERE activo = @activo",
    '       New Dictionary(Of String, Object) From {{"@activo", True}}
    '   )
    '   ' Acceder a datos: usuarios(0)("nombre") devuelve el nombre del primer usuario
    ' ========================================================================

    Public Function ExecuteQuery(query As String, Optional params As Dictionary(Of String, Object) = Nothing) As List(Of Dictionary(Of String, Object))

        ' Lista que guardará todos los resultados (todas las filas)
        Dim results As New List(Of Dictionary(Of String, Object))()

        ' Asegurarse de que la conexión esté abierta antes de ejecutar
        OpenConnection()

        ' Using: garantiza que el comando se libere de memoria al terminar
        ' Crea un comando SQL con la consulta y la conexión
        Using cmd As New SqlCommand(query, db)

            ' Si se pasaron parámetros...
            If params IsNot Nothing Then
                ' Recorrer cada parámetro del diccionario
                For Each kvp In params
                    ' Agregar el parámetro al comando SQL
                    ' kvp.Key = nombre del parámetro (ej: "@edad")
                    ' kvp.Value = valor del parámetro (ej: 18)
                    ' Esto previene SQL INJECTION
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
                Next
            End If

            ' Ejecutar la consulta y obtener un "lector" de datos
            ' El lector permite recorrer fila por fila los resultados
            Using reader As SqlDataReader = cmd.ExecuteReader()

                ' Mientras haya filas por leer...
                While reader.Read()

                    ' Crear un diccionario para esta fila
                    Dim row As New Dictionary(Of String, Object)()

                    ' Recorrer cada columna de la fila actual
                    ' FieldCount = número de columnas
                    For i As Integer = 0 To reader.FieldCount - 1
                        ' Agregar al diccionario:
                        ' - Clave: nombre de la columna
                        ' - Valor: dato de esa columna en esta fila
                        row(reader.GetName(i)) = reader.GetValue(i)
                    Next

                    ' Agregar esta fila (diccionario) a la lista de resultados
                    results.Add(row)
                End While

            End Using ' Aquí se cierra automáticamente el reader

        End Using ' Aquí se cierra automáticamente el comando

        ' Devolver la lista completa de resultados
        Return results

    End Function

    ' ========================================================================
    ' MÉTODO: ExecuteSingleQuery
    ' ========================================================================
    ' PROPÓSITO: Ejecutar consultas SELECT que devuelven UNA SOLA fila
    '
    ' PARÁMETROS: Igual que ExecuteQuery
    '
    ' RETORNA: Un solo diccionario (una fila) o Nothing si no hay resultados
    '
    ' EJEMPLO DE USO:
    '   Dim usuario = BaseModel.Instance.ExecuteSingleQuery(
    '       "SELECT * FROM usuarios WHERE id = @id",
    '       New Dictionary(Of String, Object) From {{"@id", 5}}
    '   )
    '   ' Acceder: usuario("nombre") devuelve el nombre del usuario con id=5
    ' ========================================================================

    Public Function ExecuteSingleQuery(query As String, Optional params As Dictionary(Of String, Object) = Nothing) As Dictionary(Of String, Object)

        ' Reutiliza ExecuteQuery para obtener todos los resultados
        Dim results = ExecuteQuery(query, params)

        ' Si hay al menos un resultado...
        If results.Count > 0 Then
            ' Devolver solo el primero (índice 0)
            Return results(0)
        End If

        ' Si no hay resultados, devolver Nothing (null)
        Return Nothing

    End Function

    ' ========================================================================
    ' MÉTODO: ReturningId
    ' ========================================================================
    ' PROPÓSITO: Ejecutar INSERT y obtener el ID del registro
    '            insertado (útil para INSERT principalmente)
    '
    ' PARÁMETROS:
    '   - query: Consulta SQL de inserción
    '            Ejemplo: "INSERT INTO productos (nombre, precio) VALUES (@nombre, @precio)"
    '   - params: Diccionario con parámetros
    '
    ' RETORNA: 
    '   - El ID del registro recién insertado (Long)
    '   - 0 si no se pudo obtener el ID
    '
    ' EJEMPLO DE USO:
    '   Dim nuevoId = BaseModel.Instance.ReturningId(
    '       "INSERT INTO productos (nombre, precio) VALUES (@nombre, @precio)",
    '       New Dictionary(Of String, Object) From {
    '           {"@nombre", "Laptop"},
    '           {"@precio", 1500}
    '       }
    '   )
    '   ' nuevoId contendrá el ID del producto recién insertado
    ' ========================================================================
    Public Function ReturningId(query As String, Optional params As Dictionary(Of String, Object) = Nothing) As Long

        ' ====================================================================
        ' PASO 1: Asegurar que la conexión a la base de datos esté abierta
        ' ====================================================================
        OpenConnection()

        ' ====================================================================
        ' PASO 2: Crear el comando SQL combinado
        ' ====================================================================
        ' MODIFICACIÓN CLAVE: Se usa interpolación de strings ($"...") para 
        ' combinar la consulta original con SCOPE_IDENTITY()
        ' 
        ' Estructura de la consulta final:
        ' [Tu consulta INSERT]; SELECT CAST(SCOPE_IDENTITY() AS BIGINT);
        '         ↑                                  ↑
        '    Query del usuario              Obtiene el último ID insertado
        '
        ' Ejemplo práctico:
        ' Si query = "INSERT INTO productos (nombre) VALUES (@nombre)"
        ' 
        ' La consulta final será:
        ' "INSERT INTO productos (nombre) VALUES (@nombre); SELECT CAST(SCOPE_IDENTITY() AS BIGINT);"
        '
        ' ¿Por qué BIGINT?
        ' - SCOPE_IDENTITY() devuelve tipo NUMERIC(38,0) por defecto
        ' - CAST lo convierte a BIGINT (entero de 64 bits)
        ' - Esto coincide con el tipo Long de VB.NET
        ' - Evita problemas de conversión y errores de tipos
        '
        Using cmd As New SqlCommand($"{query}; SELECT CAST(SCOPE_IDENTITY() AS BIGINT);", db)
            '                         ↑                    ↑
            '              Interpolación de string    Conversión explícita a BIGINT

            ' ================================================================
            ' PASO 3: Agregar parámetros al comando (si existen)
            ' ================================================================
            ' Verificar si se pasaron parámetros
            If params IsNot Nothing Then

                ' Recorrer cada par clave-valor del diccionario
                ' kvp = Key-Value Pair (Par Clave-Valor)
                For Each kvp In params

                    ' Agregar cada parámetro al comando SQL
                    ' kvp.Key = nombre del parámetro (ej: "@nombre")
                    ' kvp.Value = valor del parámetro (ej: "Laptop")
                    '
                    ' Esto previene SQL INJECTION al tratar los valores
                    ' como DATOS y no como CÓDIGO ejecutable
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)

                Next

            End If

            ' ================================================================
            ' PASO 4: Ejecutar la consulta y obtener el ID
            ' ================================================================
            ' ExecuteScalar() ejecuta la consulta y devuelve:
            ' - La primera columna de la primera fila del resultado
            ' - En este caso, devolverá el resultado de SCOPE_IDENTITY()
            '
            ' ¿Cómo funciona?
            ' 1. Ejecuta el INSERT
            ' 2. Luego ejecuta SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
            ' 3. Devuelve ese valor (el último ID insertado)
            '
            Dim result = cmd.ExecuteScalar()

            ' ================================================================
            ' PASO 5: Validar y convertir el resultado
            ' ================================================================
            ' Verificar que el resultado sea válido:
            ' - result IsNot Nothing: Que no sea nulo
            ' - Not IsDBNull(result): Que no sea un valor NULL de la base de datos
            '
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then

                ' Convertir el resultado a Long (entero de 64 bits)
                ' Convert.ToInt64 convierte cualquier tipo numérico a Long
                ' Esto es seguro porque ya hicimos CAST a BIGINT en SQL
                Return Convert.ToInt64(result)

            Else

                ' Si no se obtuvo un ID válido, devolver 0
                ' Esto puede pasar en estos casos:
                ' 1. La consulta fue UPDATE o DELETE (no genera ID nuevo)
                ' 2. La tabla no tiene columna IDENTITY (auto-incremental)
                ' 3. Hubo algún error en la ejecución
                Return 0

            End If

        End Using
        ' Al salir del Using, el comando (cmd) se libera automáticamente de memoria

    End Function

    ' Ejecutar UPDATE o DELETE y devolver número de filas afectadas
    ' ========================================================================
    ' MÉTODO: ExecuteNonQuery
    ' ========================================================================
    ' PROPÓSITO: Ejecutar consultas que NO devuelven datos (UPDATE, DELETE)
    '            y obtener el número de filas afectadas
    '
    ' ¿CUÁNDO USAR ESTE MÉTODO?
    ' - INSERT: Para insertar registros SIN necesitar el ID generado
    ' - UPDATE: Para actualizar registros existentes
    ' - DELETE: Para eliminar registros
    ' - Cualquier comando SQL que modifique datos pero no retorne resultados
    '
    ' DIFERENCIA CON OTROS MÉTODOS:
    ' - ExecuteQuery: Para SELECT (devuelve datos)
    ' - ReturningId: Para INSERT (devuelve el ID del nuevo registro)
    ' - ExecuteNonQuery: Para INSERT/UPDATE/DELETE (devuelve cantidad de filas afectadas)
    '
    ' PARÁMETROS:
    '   - query: Consulta SQL que modifica datos
    '            Ejemplos:
    '            "INSERT INTO logs (mensaje) VALUES (@msg)"
    '            "UPDATE usuarios SET activo = @activo WHERE id = @id"
    '            "DELETE FROM productos WHERE stock = 0"
    '   
    '   - params: (OPCIONAL) Diccionario con los parámetros de la consulta
    '            Ejemplo: New Dictionary(Of String, Object) From {
    '                {"@msg", "Usuario inició sesión"},
    '                {"@activo", False},
    '                {"@id", 5}
    '            }
    '
    ' RETORNA: 
    '   - Un número entero (Integer) que indica cuántas filas fueron afectadas
    '   
    '   Ejemplos:
    '   - Si actualizas 3 registros → devuelve 3
    '   - Si eliminas 1 registro → devuelve 1
    '   - Si insertas 1 registro → devuelve 1
    '   - Si no se afectó ninguna fila → devuelve 0
    '
    ' EJEMPLOS DE USO:
    '
    ' EJEMPLO 1 - UPDATE:
    '   Dim filasActualizadas = BaseModel.Instance.ExecuteNonQuery(
    '       "UPDATE productos SET stock = stock - @cantidad WHERE id = @id",
    '       New Dictionary(Of String, Object) From {
    '           {"@cantidad", 5},
    '           {"@id", 10}
    '       }
    '   )
    '   ' filasActualizadas = 1 (si se actualizó el producto con id=10)
    '   ' filasActualizadas = 0 (si no existe el producto con id=10)
    '
    ' EJEMPLO 2 - DELETE:
    '   Dim filasEliminadas = BaseModel.Instance.ExecuteNonQuery(
    '       "DELETE FROM carrito WHERE usuario_id = @userId",
    '       New Dictionary(Of String, Object) From {{"@userId", 25}}
    '   )
    '   ' filasEliminadas = 3 (si el usuario tenía 3 productos en el carrito)
    '
    ' EJEMPLO 3 - INSERT sin necesitar el ID:
    '   Dim filasInsertadas = BaseModel.Instance.ExecuteNonQuery(
    '       "INSERT INTO logs (mensaje, fecha) VALUES (@msg, GETDATE())",
    '       New Dictionary(Of String, Object) From {{"@msg", "Error 404"}}
    '   )
    '   ' filasInsertadas = 1 (se insertó correctamente)
    '
    ' EJEMPLO 4 - UPDATE múltiple:
    '   Dim filasActualizadas = BaseModel.Instance.ExecuteNonQuery(
    '       "UPDATE productos SET descuento = @desc WHERE categoria = @cat"
    '       New Dictionary(Of String, Object) From {
    '           {"@desc", 0.15},
    '           {"@cat", "Electrónica"}
    '       }
    '   )
    '   ' filasActualizadas = 25 (si 25 productos de electrónica fueron actualizados)
    ' ========================================================================

    Public Function ExecuteNonQuery(query As String, Optional params As Dictionary(Of String, Object) = Nothing) As Integer

        ' ====================================================================
        ' PASO 1: Asegurar que la conexión a la base de datos esté abierta
        ' ====================================================================
        ' Esto evita errores si la conexión está cerrada
        ' Si ya está abierta, no hace nada (OpenConnection verifica el estado)
        OpenConnection()

        ' ====================================================================
        ' PASO 2: Crear el comando SQL
        ' ====================================================================
        ' Using: Garantiza que el comando se libere de memoria automáticamente
        '        al terminar, incluso si ocurre un error
        '
        ' SqlCommand: Representa una instrucción SQL que se ejecutará en SQL Server
        '   - query: La consulta SQL a ejecutar
        '   - db: La conexión a la base de datos
        '
        Using cmd As New SqlCommand(query, db)

            ' ================================================================
            ' PASO 3: Agregar parámetros al comando (si se proporcionaron)
            ' ================================================================
            ' Verificar si el diccionario de parámetros NO es Nothing (null)
            If params IsNot Nothing Then

                ' Recorrer cada elemento del diccionario
                ' kvp = Key-Value Pair (Par Clave-Valor)
                For Each kvp In params

                    ' Agregar cada parámetro al comando SQL
                    ' 
                    ' kvp.Key = Nombre del parámetro (ej: "@id")
                    ' kvp.Value = Valor del parámetro (ej: 5)
                    '
                    ' AddWithValue hace 3 cosas importantes:
                    ' 1. Agrega el parámetro al comando
                    ' 2. Detecta automáticamente el tipo de dato
                    ' 3. Escapa caracteres especiales (previene SQL Injection)
                    '
                    ' Ejemplo de iteración:
                    ' Primera vuelta: kvp.Key = "@id", kvp.Value = 10
                    '                 Se agrega @id con valor 10
                    ' Segunda vuelta: kvp.Key = "@activo", kvp.Value = False
                    '                 Se agrega @activo con valor False
                    '
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)

                Next

            End If
            ' Si params es Nothing, simplemente no agrega parámetros
            ' (útil para consultas simples sin parámetros)

            ' ================================================================
            ' PASO 4: Ejecutar la consulta y devolver filas afectadas
            ' ================================================================
            ' ExecuteNonQuery() hace lo siguiente:
            ' 
            ' 1. Envía la consulta SQL al servidor
            ' 2. SQL Server ejecuta el INSERT/UPDATE/DELETE
            ' 3. Devuelve un número entero con las filas afectadas
            '
            ' ¿Qué significa "filas afectadas"?
            ' - INSERT: Cantidad de registros insertados
            ' - UPDATE: Cantidad de registros modificados
            ' - DELETE: Cantidad de registros eliminados
            '
            ' IMPORTANTE: ExecuteNonQuery() NO devuelve datos de la tabla
            '             Solo devuelve el NÚMERO de filas que cambiaron
            '
            ' Ejemplos de valores de retorno:
            ' - 0: Ninguna fila fue afectada
            '      (ej: UPDATE con WHERE que no coincide con ningún registro)
            ' - 1: Una fila fue afectada
            '      (ej: DELETE que eliminó un solo registro)
            ' - 50: Cincuenta filas fueron afectadas
            '      (ej: UPDATE que modificó 50 registros)
            '
            Return cmd.ExecuteNonQuery()

        End Using
        ' Al salir del Using, el comando se libera automáticamente de memoria
        ' Esto es equivalente a hacer: cmd.Dispose()

    End Function

End Class