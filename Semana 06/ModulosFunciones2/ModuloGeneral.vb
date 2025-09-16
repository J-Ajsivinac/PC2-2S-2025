' Module Principal 
' Este modulo contiene variables globlaes, funciones y procedimientos
' que pueden ser utilizados desde cualquier parte del proyecto.

Module ModuloGeneral
    ' Variables globales
    Public ContadorGlobal As Integer = 0 ' Varible publica accesible desde toda la aplicacion
    Public NombreUsuario As String = ""  ' Variable global para almacenar nombre de usuario

    ' Variable privada del módulo - solo acesible dentro de este módulo
    Private ConfiguracionSecreta As String = "ValorSecreto"

    ' Funciones Númericas
    Public Function SumarNumeros(ByVal num1 As Integer, ByVal num2 As Integer) As Integer
        ' Variable local - solo va a existir dentro de esta función
        Dim resultado As Integer = num1 + num2
        ContadorGlobal += 1 ' Incrementa el contador global
        ' ContadoraGlobal = ContadorGlobal + 1

        Return resultado
    End Function

    ' A = i * r^2
    Public Function CalcularAreaCirculo(ByVal radio As Double) As Double
        ' Calcula el área de un círculo dado su radio
        ' Math.Pow  Eleva un número a una potencia
        ' Return Math.PI * Math.Pow(radio, 2)
        Const PI As Double = 3.1415926535897931
        Return PI * radio * radio
    End Function

    Public Function EsPrimo(ByVal numero As Integer) As Boolean
        ' Verifica si un número es primo
        ' Un número es primo si es mayor que 1 y no tiene divisores aparte de 1 y sí mismo
        ContadorGlobal += 2
        If numero < 2 Then Return False
        ' For loop para verificar si el número es divisible por algún número entre 2 y la raíz cuadrada del número
        For i As Integer = 2 To Math.Sqrt(numero)
            If numero Mod i = 0 Then Return False
        Next
        ' Si no se encontró ningún divisor, el número es primo
        Return True
    End Function

    Public Function ConvertirATitulo(ByVal texto As String) As String
        ' Convierte un texto a formato título (cada palabra inicia con mayúscula)
        If String.IsNullOrEmpty(texto) Then
            Return ""
        End If

        Dim textoLower As String = texto.ToLower()
        ' primer caracter va a guardar el primer caracter en mayuscula
        ' para eso se usa el substring para tomar el primer caracter
        ' substring funciona de la siguiente manera:
        ' substring(inicio, longitud)
        ' en este caso, inicio es 0 y longitud es 1
        ' substring(0, 1) toma el primer caracter del texto
        ' y lo convierte a mayúscula
        Dim primerCaracter As String = textoLower.Substring(0, 1).ToUpper()
        Dim restoTexto As String = ""

        If textoLower.Length > 1 Then
            ' Si el texto tiene más de un caracter, se toma el resto del texto
            ' desde el segundo caracter hasta el final
            ' substring(1) toma el texto desde el segundo caracter hasta el final
            restoTexto = textoLower.Substring(1)
        End If

        Return primerCaracter & restoTexto

    End Function

    Public Function InvertirText(ByVal text As String) As String
        ' Invierte el texto dado
        Dim textoInvertido As String = ""
        Dim i As Integer
        ' Recorre el texto desde el último caracter hasta el primero
        ' palabra = "Hola"
        ' H -> text(0)
        ' o -> text(1)
        ' l -> text(2)
        ' a -> text(3)
        ' No se puede hacer text(4) porque no existe
        ' text.Length = 4
        ' text.Length - 1 = 3
        ' Lo que va a hacer el for es recorrer el texto desde el último caracter hasta el primero
        ' text(i) va a tomar el caracter en la posición i del texto
        ' text(3) = "a"
        For i = text.Length - 1 To 0 Step -1
            ' Recorre el texto desde el último caracter hasta el primero
            textoInvertido &= text(i) ' Agrega cada caracter al texto invertido
        Next
        Return textoInvertido
    End Function

    Public Sub IncrementarContador(ByVal incremento As Integer)
        ContadorGlobal += incremento
        ' Los procedimientos NO usan Return, solo ejecutan código
    End Sub

    Public Sub EstablecerUsuario(ByVal nombre As String)
        ' Validar que el nombre no esté vacío
        ' Trim elimina los espacios al principio y al final del texto
        ' " hola " -> "hola"
        If Not String.IsNullOrEmpty(nombre.Trim()) Then
            NombreUsuario = ConvertirATitulo(nombre.Trim())
        Else
            NombreUsuario = "Usuario Anónimo"
        End If
    End Sub

    Public Sub ReiniciarDatos()
        ContadorGlobal = 0
        NombreUsuario = ""
        ' ConfiguracionSecreta no se puede cambiar desde fuera del módulo (Private)
    End Sub

    Public Function FormatearNombre(nombre As String, apellido As String) As String
        ' Uso de funciones de cadena incorporadas
        Dim nombreFormateado As String
        nombreFormateado = nombre.Trim().ToUpper() + ", " + apellido.Trim().ToLower()
        Return nombreFormateado
    End Function
End Module
