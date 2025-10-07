# 🧩 Comparación: ¿Cuándo usar cada método?

| **MÉTODO**           | **TIPO DE CONSULTA**         | **QUÉ DEVUELVE**                                      |
| -------------------- | ---------------------------- | ----------------------------------------------------- |
| `ExecuteQuery`       | `SELECT`                     | Lista de diccionarios (múltiples filas)               |
| `ExecuteSingleQuery` | `SELECT`                     | Un diccionario (una fila) o `Nothing` si no hay datos |
| `ReturningId`        | `INSERT` (principalmente)    | El ID del nuevo registro (`Long/BIGINT`)              |
| `ExecuteNonQuery`    | `INSERT`, `UPDATE`, `DELETE` | Número de filas afectadas (`Integer`)                 |

---

## 💡 Casos prácticos de uso

### 🧱 Caso 1: Activar/Desactivar usuario

```vbnet
Dim filasAfectadas = BaseModel.Instance.ExecuteNonQuery(
    "UPDATE usuarios SET activo = @estado WHERE id = @id",
    New Dictionary(Of String, Object) From {
        {"@estado", False},
        {"@id", 10}
    }
)

If filasAfectadas > 0 Then
    MessageBox.Show("Usuario desactivado correctamente")
Else
    MessageBox.Show("No se encontró el usuario")
End If
```

---

### 🗑️ Caso 2: Eliminar productos sin stock

```vbnet
Dim eliminados = BaseModel.Instance.ExecuteNonQuery(
    "DELETE FROM productos WHERE stock = 0"
)
MessageBox.Show($"Se eliminaron {eliminados} productos sin stock")
```

---

### 💰 Caso 3: Aplicar descuento masivo

```vbnet
Dim actualizados = BaseModel.Instance.ExecuteNonQuery(
    "UPDATE productos SET precio = precio * 0.9 WHERE categoria = @cat",
    New Dictionary(Of String, Object) From {{"@cat", "Ropa"}}
)
MessageBox.Show($"Descuento aplicado a {actualizados} productos")
```

---

### 🧾 Caso 4: Registrar actividad (log)

```vbnet
BaseModel.Instance.ExecuteNonQuery(
    "INSERT INTO logs (usuario_id, accion, fecha) VALUES (@user, @accion, GETDATE())",
    New Dictionary(Of String, Object) From {
        {"@user", usuarioActual.Id},
        {"@accion", "Inicio de sesión"}
    }
)
' No necesitamos el valor de retorno porque es solo un log
```

---

### 🛒 Caso 5: Limpiar carrito de compras

```vbnet
Dim itemsEliminados = BaseModel.Instance.ExecuteNonQuery(
    "DELETE FROM carrito WHERE usuario_id = @userId",
    New Dictionary(Of String, Object) From {{"@userId", 25}}
)
Console.WriteLine($"Se limpiaron {itemsEliminados} productos del carrito")
```

---

## ⚙️ Ventajas de `ExecuteNonQuery`

1. **Eficiente** → No carga datos en memoria, solo devuelve un número
2. **Simple** → Fácil de usar para operaciones básicas
3. **Informativo** → Saber cuántas filas se afectaron es útil para validaciones
4. **Versátil** → Funciona para `INSERT`, `UPDATE` y `DELETE`
5. **Rápido** → Más rápido que `ReturningId` si no necesitas el ID

---

## 🔑 Diferencia clave con `ReturningId`

| **Aspecto**    | **ExecuteNonQuery**                           | **ReturningId**                                    |
| -------------- | --------------------------------------------- | -------------------------------------------------- |
| **Devuelve**   | Número de filas afectadas (`Integer`)         | ID del registro insertado (`Long`)                 |
| **Uso típico** | Cuando **no** necesitas el ID del registro    | Cuando **sí** necesitas el ID para usarlo después  |
| **Ejemplo**    | `INSERT INTO logs`, `UPDATE` masivo, `DELETE` | Insertar usuario y luego usar su ID para su perfil |

