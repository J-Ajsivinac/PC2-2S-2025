## 1. TOP 5 Autores con más libros en la colección

### Objetivo
Encontrar los 5 autores que tienen la mayor cantidad de libros registrados en la biblioteca.

### Consulta SQL
```sql
SELECT 
    a.id,
    CONCAT(a.nombre, ' ', a.apellido) AS autor,
    COUNT(l.id) AS cantidad_libros
FROM autor a
JOIN libro l ON a.id = l.autor_id
GROUP BY a.id, a.nombre, a.apellido
ORDER BY cantidad_libros DESC
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;
```

### Explicación Paso a Paso

**1. FROM y JOIN**: Combinamos las tablas `autor` y `libro`

```mermaid
graph LR
    A[Tabla AUTOR] -->|JOIN ON autor_id| B[Tabla LIBRO]
    style A fill:#e1f5ff
    style B fill:#fff4e1
```

**2. Relación entre tablas:**

```mermaid
erDiagram
    AUTOR ||--o{ LIBRO : escribe
    AUTOR {
        int id PK
        string nombre
        string apellido
    }
    LIBRO {
        int id PK
        string nombre
        int autor_id FK
    }
```

**3. Proceso de la consulta:**

```mermaid
flowchart TD
    A[Inicio] --> B[Unir autor con libro usando autor_id]
    B --> C[Agrupar por autor id, nombre, apellido]
    C --> D[Contar cuántos libros tiene cada autor]
    D --> E[Ordenar de mayor a menor cantidad]
    E --> F[Tomar solo los primeros 5]
    F --> G[Resultado Final]
    
    style A fill:#90EE90
    style G fill:#FFB6C1
```

### Visualización del resultado

```mermaid
graph TD
    subgraph "Resultado TOP 5"
    A1["👤 Gabriel García Márquez<br/> 15 libros"]
    A2["👤 Isabel Allende<br/> 12 libros"]
    A3["👤 Jorge Luis Borges<br/> 10 libros"]
    A4["👤 Mario Vargas Llosa<br/> 8 libros"]
    A5["👤 Octavio Paz<br/> 7 libros"]
    end
    
    style A1 fill:#gold
    style A2 fill:#silver
    style A3 fill:#cd7f32
```

### Conceptos clave:
- **JOIN**: Une dos tablas relacionadas
- **GROUP BY**: Agrupa registros con características comunes
- **COUNT()**: Cuenta cuántos registros hay en cada grupo
- **ORDER BY DESC**: Ordena de mayor a menor
- **FETCH NEXT 5**: Limita el resultado a 5 registros

---

## 2. TOP 5 Editoriales más populares

### Objetivo
Identificar las editoriales que han publicado más libros en nuestra colección.

### Consulta SQL
```sql
SELECT 
    e.id,
    e.nombre AS editorial,
    COUNT(l.id) AS cantidad_libros
FROM editorial e
JOIN libro l ON e.id = l.editorial_id
GROUP BY e.id, e.nombre
ORDER BY cantidad_libros DESC
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;
```

### Diagrama de Relación

```mermaid
erDiagram
    EDITORIAL ||--o{ LIBRO : publica
    EDITORIAL {
        int id PK
        string nombre
    }
    LIBRO {
        int id PK
        string nombre
        int editorial_id FK
    }
```

### Proceso Visual

```mermaid
flowchart LR
    A[Editorial A<br/>20 libros] --> R[Ranking]
    B[Editorial B<br/>18 libros] --> R
    C[Editorial C<br/>15 libros] --> R
    D[Editorial D<br/>12 libros] --> R
    E[Editorial E<br/>10 libros] --> R
    F[Editorial F<br/>5 libros] -.No entra.-> R
    
    R --> T[TOP 5]
    
    style A fill:#gold
    style B fill:#silver
    style C fill:#cd7f32
    style T fill:#90EE90
```

### Ejemplo de Agrupación

```mermaid
graph TD
    subgraph "Libros por Editorial"
    E1[Penguin Random House]
    E1 --> L1[Libro 1]
    E1 --> L2[Libro 2]
    E1 --> L3[Libro 3]
    E1 --> L4[...]
    
    E2[Planeta]
    E2 --> L5[Libro A]
    E2 --> L6[Libro B]
    
    E3[Alfaguara]
    E3 --> L7[Libro X]
    end
    
    E1 -.COUNT = 4.-> R1[Ranking 1]
    E2 -.COUNT = 2.-> R2[Ranking 2]
    E3 -.COUNT = 1.-> R3[Ranking 3]
```

---

## 3. Libros actualmente prestados (no devueltos)

### Objetivo
Mostrar todos los libros que están prestados y aún no han sido devueltos.

### Consulta SQL
```sql
SELECT 
    p.id AS id_prestamo,
    l.nombre AS libro,
    CONCAT(u.nombre, ' ', u.apellido) AS usuario,
    p.fecha_prestamo
FROM prestamo p
JOIN libro l ON p.libro_id = l.id
JOIN usuario u ON p.usuario_id = u.id
LEFT JOIN devolucion d ON d.prestamo_id = p.id
WHERE d.id IS NULL;
```

### Diagrama de Relaciones

```mermaid
erDiagram
    PRESTAMO ||--|| LIBRO : contiene
    PRESTAMO ||--|| USUARIO : realizado_por
    PRESTAMO ||--o| DEVOLUCION : puede_tener
    
    PRESTAMO {
        int id PK
        int libro_id FK
        int usuario_id FK
        date fecha_prestamo
    }
    LIBRO {
        int id PK
        string nombre
    }
    USUARIO {
        int id PK
        string nombre
        string apellido
    }
    DEVOLUCION {
        int id PK
        int prestamo_id FK
        date fecha_devolucion
    }
```

### Flujo de la Consulta
```mermaid
flowchart TD
    A[Tabla PRESTAMO] --> B{Tiene<br/>DEVOLUCION?}
    B -->|NO| C[ Incluir en resultado<br/>Libro AÚN prestado]
    B -->|SÍ| D[ Excluir<br/>Ya fue devuelto]
    
    C --> E[Mostrar:<br/>- ID Préstamo<br/>- Nombre Libro<br/>- Usuario<br/>- Fecha]
    
    style C fill:#90EE90
    style D fill:#FFB6C1
    style E fill:#87CEEB
```

### Visualización de LEFT JOIN

```mermaid
graph LR
    subgraph "PRESTAMO"
    P1[Préstamo 1]
    P2[Préstamo 2]
    P3[Préstamo 3]
    end
    
    subgraph "DEVOLUCION"
    D2[Devolución Préstamo 2]
    end
    
    P1 -.Sin devolución.-> R1[ Incluir]
    P2 --> D2
    D2 -.Tiene devolución.-> R2[ Excluir]
    P3 -.Sin devolución.-> R3[ Incluir]
    
    style R1 fill:#90EE90
    style R2 fill:#FFB6C1
    style R3 fill:#90EE90
```

### Concepto Clave: LEFT JOIN + WHERE NULL

```mermaid
graph TD
    A["LEFT JOIN:<br/>Trae TODOS los préstamos"] --> B["Incluye NULL cuando<br/>no hay devolución"]
    B --> C["WHERE d.id IS NULL:<br/>Filtra solo los NULL"]
    C --> D["Resultado:<br/>Solo préstamos SIN devolución"]
    
    style A fill:#e1f5ff
    style D fill:#90EE90
```

---

## 4. Usuarios que deben a la biblioteca

### 🎯 Objetivo
Identificar usuarios con multas pendientes de pago.

### Consulta SQL
```sql
SELECT 
    DISTINCT u.id,
    CONCAT(u.nombre, ' ', u.apellido) AS usuario,
    COUNT(m.id) AS cantidad_multas,
    SUM(m.monto) AS total_deuda
FROM multa m
JOIN devolucion d ON m.devolucion_id = d.id
JOIN prestamo p ON d.prestamo_id = p.id
JOIN usuario u ON p.usuario_id = u.id
GROUP BY u.id, u.nombre, u.apellido
HAVING SUM(m.monto) > 0
ORDER BY total_deuda DESC;
```

### Cadena de Relaciones

```mermaid
erDiagram
    MULTA ||--|| DEVOLUCION : por
    DEVOLUCION ||--|| PRESTAMO : corresponde_a
    PRESTAMO ||--|| USUARIO : realizado_por
    
    USUARIO {
        int id PK
        string nombre
        string apellido
    }
    PRESTAMO {
        int id PK
        int usuario_id FK
    }
    DEVOLUCION {
        int id PK
        int prestamo_id FK
    }
    MULTA {
        int id PK
        int devolucion_id FK
        decimal monto
    }
```

### Proceso de la Consulta

```mermaid
flowchart TD
    A[Tabla MULTA] --> B[JOIN con DEVOLUCION]
    B --> C[JOIN con PRESTAMO]
    C --> D[JOIN con USUARIO]
    D --> E[Agrupar por USUARIO]
    E --> F[Contar multas y sumar montos]
    F --> G{Monto > 0?}
    G -->|SÍ| H[✅ Incluir usuario]
    G -->|NO| I[❌ Excluir usuario]
    H --> J[Ordenar por deuda mayor]
    
    style A fill:#FFB6C1
    style H fill:#90EE90
    style I fill:#D3D3D3
    style J fill:#87CEEB
```

### 💰 Ejemplo Visual de Agregación

```mermaid
graph TD
    subgraph "Usuario: Juan Pérez"
    M1[Multa 1: $50]
    M2[Multa 2: $30]
    M3[Multa 3: $20]
    end
    
    M1 --> SUM[SUM monto]
    M2 --> SUM
    M3 --> SUM
    
    M1 --> COUNT[COUNT multas]
    M2 --> COUNT
    M3 --> COUNT
    
    SUM --> R1[Total: $100]
    COUNT --> R2[Cantidad: 3]
    
    style SUM fill:#FFD700
    style COUNT fill:#87CEEB
    style R1 fill:#FF6B6B
    style R2 fill:#4ECDC4
```

### Diferencia: WHERE vs HAVING

```mermaid
graph LR
    A[WHERE] -->|Filtra ANTES<br/>de agrupar| B[Registros individuales]
    C[HAVING] -->|Filtra DESPUÉS<br/>de agrupar| D[Grupos agregados]
    
    style A fill:#e1f5ff
    style C fill:#fff4e1
```

---

## 5. TOP 5 Usuarios con más multas

### Objetivo
Identificar los 5 usuarios que han acumulado más multas (no necesariamente el mayor monto).

### Consulta SQL
```sql
SELECT 
    TOP 5
    u.id,
    CONCAT(u.nombre, ' ', u.apellido) AS usuario,
    COUNT(m.id) AS cantidad_multas,
    SUM(m.monto) AS total_monto
FROM multa m
JOIN devolucion d ON m.devolucion_id = d.id
JOIN prestamo p ON d.prestamo_id = p.id
JOIN usuario u ON p.usuario_id = u.id
GROUP BY u.id, u.nombre, u.apellido
ORDER BY cantidad_multas DESC, total_monto DESC;
```

### Diferencia con la consulta anterior

```mermaid
graph TD
    subgraph "Consulta 4: Usuarios con DEUDA"
    A[Incluye TODOS los usuarios<br/>que tienen multas pendientes]
    A --> B[HAVING SUM monto mayor 0]
    A --> C[Ordena por MONTO total]
    end
    
    subgraph "Consulta 5: TOP 5 con MÁS MULTAS"
    D[Solo los 5 usuarios<br/>con más multas]
    D --> E[Sin filtro HAVING]
    D --> F[Ordena por CANTIDAD de multas]
    F --> G[Luego por monto]
    end
    
    style A fill:#FFE4E1
    style D fill:#E6E6FA
```

### 🏆 Ranking Visual

```mermaid
graph TD
    subgraph "Ranking por CANTIDAD de Multas"
    U1[" Usuario A<br/> 12 multas<br/>💰 $150"]
    U2[" Usuario B<br/> 10 multas<br/>💰 $200"]
    U3[" Usuario C<br/>9 multas<br/>💰 $180"]
    U4["Usuario D<br/> 8 multas<br/>💰 $95"]
    U5["Usuario E<br/>7 multas<br/>💰 $220"]
    end
    
    style U1 fill:#FFD700
    style U2 fill:#C0C0C0
    style U3 fill:#CD7F32
```

### Comparación de Ordenamiento

```mermaid
flowchart LR
    A[Usuarios con multas] --> B{Ordenar por}
    B -->|1° Prioridad| C[CANTIDAD de multas DESC]
    C -->|2° Prioridad| D[MONTO total DESC]
    D --> E[Tomar TOP 5]
    
    style C fill:#87CEEB
    style D fill:#FFD700
    style E fill:#90EE90
```

### Ejemplo de Ordenamiento Dual

```mermaid
graph TD
    subgraph "Antes de ordenar"
    A[Usuario 1: 10 multas, $100]
    B[Usuario 2: 10 multas, $200]
    C[Usuario 3: 12 multas, $50]
    end
    
    subgraph "Después de ORDER BY cantidad DESC, monto DESC"
    D[1° Usuario 3: 12 multas, $50]
    E[2° Usuario 2: 10 multas, $200]
    F[3° Usuario 1: 10 multas, $100]
    end
    
    A --> F
    B --> E
    C --> D
    
    style D fill:#FFD700
    style E fill:#C0C0C0
    style F fill:#CD7F32
```

---

## Resumen de Conceptos SQL

```mermaid
mindmap
  root((Conceptos<br/>Clave SQL))
    JOIN
      INNER JOIN
      LEFT JOIN
      Relaciona tablas
    Agregación
      COUNT
      SUM
      GROUP BY
    Filtrado
      WHERE
        Antes de agrupar
      HAVING
        Después de agrupar
    Ordenamiento
      ORDER BY ASC
      ORDER BY DESC
      Múltiples columnas
    Limitación
      TOP N
      FETCH NEXT
      OFFSET
```

---

## Guía de Construcción de Consultas

```mermaid
flowchart TD
    START[Inicio] --> Q1{¿Qué datos<br/>necesito?}
    Q1 --> Q2[Identificar tablas necesarias]
    Q2 --> Q3{¿Necesito<br/>relacionar tablas?}
    Q3 -->|SÍ| Q4[Usar JOIN]
    Q3 -->|NO| Q5[FROM tabla]
    Q4 --> Q6{¿Necesito<br/>contar/sumar?}
    Q5 --> Q6
    Q6 -->|SÍ| Q7[Usar COUNT/SUM<br/>y GROUP BY]
    Q6 -->|NO| Q8[SELECT directo]
    Q7 --> Q9{¿Filtrar<br/>grupos?}
    Q9 -->|SÍ| Q10[Usar HAVING]
    Q9 -->|NO| Q11[Continuar]
    Q8 --> Q12{¿Filtrar<br/>registros?}
    Q10 --> Q11
    Q12 -->|SÍ| Q13[Usar WHERE]
    Q12 -->|NO| Q11
    Q13 --> Q11
    Q11 --> Q14{¿Ordenar?}
    Q14 -->|SÍ| Q15[ORDER BY]
    Q14 -->|NO| Q16[Fin]
    Q15 --> Q17{¿Limitar<br/>resultados?}
    Q17 -->|SÍ| Q18[TOP o FETCH]
    Q17 -->|NO| Q16
    Q18 --> Q16
    
    style START fill:#90EE90
    style Q16 fill:#FFB6C1
    style Q7 fill:#FFD700
    style Q10 fill:#87CEEB
```
