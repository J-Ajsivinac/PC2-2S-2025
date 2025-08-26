Public Class Form1

    Private contadorLocal As Integer = 0 ' Variable local, solo accesible dentro de este formulario
    Private configuracionFormulario As String = "Formulario Principal"

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    ' Form1_load es el procedimiento que se ejecuta al cargar el formulario
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Me -> hace referencia al formulario actual, equivalente a "this" en otros lenguajes
        Me.Text = "Formulario Principal"
        EstablecerUsuario("Juan Perez") ' Llama a la función para establecer el nombre del usuario)
        ActualizarEtiquetas()
    End Sub

    Private Sub ActualizarEtiquetas()
        ' Actualiza las etiquetas del formulario con información del usuario y contador
        Dim informacion As String = ""

        informacion = "Usuario: " & NombreUsuario & vbCrLf ' vbCrLf es un salto de línea (\n)
        informacion &= "Contador Global: " & ContadorGlobal.ToString() & vbCrLf
        informacion &= "Contador Local: " & contadorLocal.ToString() & vbCrLf
        informacion &= "Configuración del Formulario: " & configuracionFormulario

        ' Actualiza el texto de las etiquetas en el formulario
        ' la condicion If verifica si txtInformacion no es Nothing (es decir, si el control existe)
        If txtInformacion IsNot Nothing Then
            txtInformacion.Text = informacion
        End If
    End Sub

    ' Eventos de los botones - llamadas a funciones y procedimientos
    Private Sub btnSumar_Click(sender As Object, e As EventArgs) Handles btnSumar.Click
        Dim num1 As Integer
        Dim num2 As Integer
        Dim resultado As Integer
        ' Convert.ToInt32 convierte el texto del TextBox a un número entero
        ' Si el texto no es un número válido, lanzará una excepción
        num1 = Convert.ToInt32(txtNum1.Text)
        num2 = Convert.ToInt32(txtNum2.Text)

        resultado = SumarNumeros(num1, num2) ' Llama a la función SumarNumeros del módulo global)
        lblSumaResultado.Text = "Resultado: " & resultado.ToString()

        ' Incrementa el contador local
        contadorLocal += 1

        ActualizarEtiquetas()
    End Sub

    Private Sub btnVerificarPrimo_Click(sender As Object, e As EventArgs) Handles btnVerificarPrimo.Click
        Dim numAValidar As Integer
        numAValidar = Convert.ToInt32(txtNumPrimo.Text)

        Dim resultadoFuncionValidar As Boolean = EsPrimo(numAValidar) ' Llama a la función EsPrimo del módulo global
        If resultadoFuncionValidar Then
            lblEsPrimo.ForeColor = Color.Green
            lblEsPrimo.Text = numAValidar.ToString() & " es un número primo."
        Else
            lblEsPrimo.ForeColor = Color.Red
            lblEsPrimo.Text = numAValidar.ToString() & " no es un número primo."
        End If

        ActualizarEtiquetas()
    End Sub
End Class
