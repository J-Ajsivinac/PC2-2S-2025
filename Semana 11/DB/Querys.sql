SELECT 
    a.id,
    CONCAT(a.nombre, ' ', a.apellido) AS autor,
    COUNT(l.id) AS cantidad_libros
FROM autor a
JOIN libro l ON a.id = l.autor_id
GROUP BY a.id, a.nombre, a.apellido
ORDER BY cantidad_libros DESC
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;


SELECT 
    e.id,
    e.nombre AS editorial,
    COUNT(l.id) AS cantidad_libros
FROM editorial e
JOIN libro l ON e.id = l.editorial_id
GROUP BY e.id, e.nombre
ORDER BY cantidad_libros DESC
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;


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
